using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using AzDev.Models.Assembly;
using Newtonsoft.Json;

namespace AzDev.Services
{
    class DefaultAssemblyService : IAssemblyService
    {
        private readonly IFileSystem _fs;
        private readonly INugetService _nuget;
        private readonly ILogger _logger = AzDevModule.GetService<ILogger>() ?? NoopLogger.Instance;

        public DefaultAssemblyService() : this(new FileSystem())
        {
        }

        public DefaultAssemblyService(IFileSystem fs)
        {
            _fs = fs;
            _nuget = AzDevModule.GetService<INugetService>() ?? throw new InvalidOperationException("Nuget service is not available.");
            _logger = AzDevModule.GetService<ILogger>() ?? NoopLogger.Instance;
        }

        public void UpdateAssembly(string manifestFilePath, string downloadPath, string runtimeMetadataPath, string cgManifestPath)
        {
            _logger.Information($"Updating assembly using manifest: {manifestFilePath}, download path: {downloadPath}, runtime metadata path: {runtimeMetadataPath}, cg manifest path: {cgManifestPath}");

            if (!_fs.File.Exists(manifestFilePath))
            {
                throw new FileNotFoundException($"Manifest file does not exist", manifestFilePath);
            }

            var devAssemblies = ReadAndParseManifests(_fs.File.ReadAllText(manifestFilePath));
            CleanDownloadDirectory(downloadPath);
            var inspectedAssemblies = devAssemblies.Select(da =>
            {
                string path = DownloadDevAssembly(da, downloadPath);
                return InspectAssembly(path, da);
            }).OrderBy(x => x.Path).ToList();
            UpdateRuntimeMetadata(inspectedAssemblies, runtimeMetadataPath);
            UpdateCgManifest(inspectedAssemblies, cgManifestPath);
        }

        private List<DevAssembly> ReadAndParseManifests(string manifestsInJson)
        {
            try
            {
                var manifestDataList = JsonConvert.DeserializeObject<List<DevAssembly>>(manifestsInJson);
                return manifestDataList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading or parsing manifest file: " + ex.Message, ex);
            }
        }

        private void CleanDownloadDirectory(string downloadPath)
        {
            var subDirs = _fs.Directory.GetDirectories(downloadPath, "net*");
            foreach (var subDir in subDirs)
            {
                _logger.Information($"Deleting directory: {subDir}");
                _fs.Directory.Delete(subDir, true);
            }
        }

        private string DownloadDevAssembly(DevAssembly devAssembly, string downloadPath)
        {
            var packageName = devAssembly.PackageName;
            var packageVersion = devAssembly.PackageVersion;
            var targetFramework = devAssembly.TargetFramework;

            string pathWithTargetFramework = Path.Combine(downloadPath, targetFramework);
            if (!_fs.Directory.Exists(pathWithTargetFramework))
            {
                _fs.Directory.CreateDirectory(pathWithTargetFramework);
            }

            return _nuget.DownloadAssembly(packageName, packageVersion, targetFramework, pathWithTargetFramework, devAssembly.CopyRuntimeAssemblies);
        }

        private InspectedAssembly InspectAssembly(string path, DevAssembly da)
        {
            return new InspectedAssembly(da, path)
            {
                AssemblyVersion = AssemblyMetadataHelper.ParseAssemblyMetadata(path).Version.ToString()
            };
        }

        private void UpdateRuntimeMetadata(IEnumerable<InspectedAssembly> assemblies, string runtimeMetadataPath)
        {
            string runtimeMetadataContent = _fs.File.ReadAllText(runtimeMetadataPath);
            int regionStart = runtimeMetadataContent.IndexOf("#region Generated", StringComparison.OrdinalIgnoreCase);
            int regionEnd = runtimeMetadataContent.IndexOf("#endregion", regionStart, StringComparison.OrdinalIgnoreCase);
            const string indent = "    ";
            StringBuilder sb = new StringBuilder();

            sb.Append(runtimeMetadataContent.Substring(0, regionStart + "#region Generated".Length));
            sb.AppendLine();
            foreach (var asm in assemblies)
            {
                var devAsm = asm.DevAssembly;
                sb.Append($"{indent}{indent}{indent}{indent}");
                sb.Append($"CreateAssembly(\"{devAsm.TargetFramework}\", \"{devAsm.PackageName}\", \"{asm.AssemblyVersion}\")");
                if (devAsm.WindowsPowerShell && !devAsm.PowerShell7Plus)
                {
                    sb.Append($".WithWindowsPowerShell()");
                }
                if (devAsm.PowerShell7Plus && !devAsm.WindowsPowerShell)
                {
                    sb.Append($".WithPowerShellCore()");
                }
                sb.AppendLine(",");
            }
            sb.Append($"{indent}{indent}{indent}{indent}");
            sb.Append(runtimeMetadataContent.Substring(regionEnd));

            _fs.File.WriteAllText(runtimeMetadataPath, sb.ToString());
        }

        /// <summary>
        /// Update the Component Governance manifest file.
        /// The manifest file is a JSON file that contains information about the assemblies used in the project
        /// that cannot be found from the csproj files.
        /// </summary>
        private void UpdateCgManifest(List<InspectedAssembly> inspectedAssemblies, string manifestPath)
        {
            var cgManifest = _fs.File.ReadAllText(manifestPath);
            var cgManifestObj = JsonConvert.DeserializeObject<CgManifest>(cgManifest);
            if (cgManifestObj == null)
            {
                throw new Exception("Error reading or parsing CG manifest file.");
            }

            cgManifestObj.Registrations = inspectedAssemblies.Select(asm =>
            {
                return new CgRegistration
                {
                    Component = new CgComponent
                    {
                        Type = "nuget",
                        Nuget = new CgNugetComponent
                        {
                            Name = asm.DevAssembly.PackageName,
                            Version = asm.DevAssembly.PackageVersion
                        }
                    }
                };
            }).ToList();

            _fs.File.WriteAllText(manifestPath, JsonConvert.SerializeObject(cgManifestObj, Formatting.Indented));
        }

        private class InspectedAssembly
        {
            public string Path { get; set; }
            public string AssemblyVersion { get; set; }
            public DevAssembly DevAssembly { get; set; }
            public InspectedAssembly(DevAssembly devAssembly, string path)
            {
                Path = path;
                DevAssembly = devAssembly;
            }
        }
    }

    internal class CgManifest
    {
        [JsonProperty("$schema")]
        public string Schema { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("registrations")]
        public List<CgRegistration> Registrations { get; set; }
    }

    internal class CgRegistration
    {
        [JsonProperty("component")]
        public CgComponent Component { get; set; }
    }

    internal class CgComponent
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("nuget")]
        public CgNugetComponent Nuget { get; set; }
    }

    internal class CgNugetComponent
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
