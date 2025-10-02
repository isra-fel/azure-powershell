// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using AzDev.Models.Assembly;
using Newtonsoft.Json;
using NuGet.Versioning;

namespace AzDev.Services.Assembly
{
    internal class DefaultAssemblyService : IAssemblyService
    {
        private readonly IFileSystem _fs;
        private readonly INugetService _nuget;
        private readonly ILogger _logger;
        private readonly IAssemblyMetadataService _assemblyMetadataService;

        public DefaultAssemblyService(IFileSystem fs, INugetService nuget, ILogger logger, IAssemblyMetadataService assemblyMetadataService)
        {
            _assemblyMetadataService = assemblyMetadataService;
            _logger = logger;
            _fs = fs;
            _nuget = nuget;
        }

        public void UpdateAssembly(string manifestFilePath, string downloadPath, string runtimeMetadataPath, string cgManifestPath)
        {
            _logger.Information($"[{nameof(DefaultAssemblyService)}] Updating assembly using manifest: {manifestFilePath}, download path: {downloadPath}, runtime metadata path: {runtimeMetadataPath}, cg manifest path: {cgManifestPath}");

            if (!_fs.File.Exists(manifestFilePath))
            {
                throw new FileNotFoundException($"Manifest file does not exist", manifestFilePath);
            }

            var devAssemblies = ParseManifest(_fs.File.ReadAllText(manifestFilePath));
            CleanDownloadDirectory(downloadPath);
            var inspectedAssemblies = devAssemblies.Select(da => DownloadAndInspect(da, downloadPath)).OrderBy(x => x.Path).ToList();
            _logger.Information($"[{nameof(DefaultAssemblyService)}] Downloaded and inspected {inspectedAssemblies.Count} assemblies.");
            UpdateRuntimeManifestFile(inspectedAssemblies, runtimeMetadataPath);
            UpdateCgManifest(inspectedAssemblies, cgManifestPath);
        }

        private static List<DevAssembly> ParseManifest(string manifestInJson)
        {
            try
            {
                var manifestDataList = JsonConvert.DeserializeObject<List<DevAssembly>>(manifestInJson);
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
                _logger.Debug($"[{nameof(DefaultAssemblyService)}] Deleting directory: {subDir}");
                _fs.Directory.Delete(subDir, true);
            }
        }

        private DevAssemblyExtended DownloadAndInspect(DevAssembly devAssembly, string downloadPath)
        {
            var packageName = devAssembly.PackageName;
            var packageVersion = devAssembly.PackageVersion;
            var targetFramework = devAssembly.TargetFramework;
            var pathWithTargetFramework = Path.Combine(downloadPath, targetFramework);

            if (!_fs.Directory.Exists(pathWithTargetFramework))
            {
                _fs.Directory.CreateDirectory(pathWithTargetFramework);
            }

            string path = _nuget.DownloadAssembly(packageName, packageVersion, targetFramework, downloadPath, devAssembly.CopyRuntimeAssemblies);

            return new DevAssemblyExtended
            {
                DevAssembly = devAssembly,
                Path = path,
                AssemblyVersion = _assemblyMetadataService.ParseAssemblyMetadata(path).Version
            };
        }

        private void UpdateRuntimeManifestFile(IEnumerable<DevAssemblyExtended> assemblies, string runtimeManifestPath)
        {
            _logger.Information($"[{nameof(DefaultAssemblyService)}] Updating runtime manifest file: {runtimeManifestPath}");
            string runtimeManifestContent = _fs.File.ReadAllText(runtimeManifestPath);
            int regionStart = runtimeManifestContent.IndexOf("#region Generated", StringComparison.OrdinalIgnoreCase);
            int regionEnd = runtimeManifestContent.IndexOf("#endregion", regionStart, StringComparison.OrdinalIgnoreCase);
            const string indent = "    ";
            StringBuilder sb = new();

            sb.Append(runtimeManifestContent[..(regionStart + "#region Generated".Length)]);
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
            sb.Append(runtimeManifestContent.AsSpan(regionEnd));

            _fs.File.WriteAllText(runtimeManifestPath, sb.ToString());
        }

        /// <summary>
        /// Update the Component Governance manifest file.
        /// The manifest file is a JSON file that contains information about the assemblies used in the project
        /// that cannot be found from the csproj files.
        /// </summary>
        private void UpdateCgManifest(List<DevAssemblyExtended> inspectedAssemblies, string manifestPath)
        {
            _logger.Information($"[{nameof(DefaultAssemblyService)}] Updating Component Governance manifest file: {manifestPath}");
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

        public void UpdateAssemblyManifestWithPackage(string manifestFilePath, string packageName, string newVersion)
        {
            _logger.Information($"[{nameof(DefaultAssemblyService)}] Updating assembly manifest with {packageName} version {newVersion}");

            if (!_fs.File.Exists(manifestFilePath))
            {
                throw new FileNotFoundException($"Manifest file does not exist", manifestFilePath);
            }

            // Parse the existing manifest
            var manifestContent = _fs.File.ReadAllText(manifestFilePath);
            var existingAssemblies = ParseManifest(manifestContent);

            // Find the target package in the manifest
            var targetAssembly = existingAssemblies.FirstOrDefault(a =>
                string.Equals(a.PackageName, packageName, StringComparison.OrdinalIgnoreCase));

            if (targetAssembly == null)
            {
                throw new InvalidOperationException($"{packageName} package not found in the current manifest");
            }

            var currentVersion = targetAssembly.PackageVersion;
            _logger.Information($"[{nameof(DefaultAssemblyService)}] Current {packageName} version: {currentVersion}");

            // Check if the new version is different from the current one
            if (string.Equals(currentVersion, newVersion, StringComparison.OrdinalIgnoreCase))
            {
                _logger.Information($"[{nameof(DefaultAssemblyService)}] {packageName} is already at version {newVersion}. No update needed.");
                return;
            }

            // Get dependencies for the new package version
            var targetFramework = targetAssembly.TargetFramework ?? "netstandard2.0";
            var newDependencies = _nuget.GetPackageDependencies(packageName, newVersion, targetFramework);
            _logger.Information($"[{nameof(DefaultAssemblyService)}] Found {newDependencies.Count} dependencies for {packageName} {newVersion}");

            // Create a dictionary of existing assemblies for easy lookup
            var existingAssembliesDict = existingAssemblies.ToDictionary(a => a.PackageName, StringComparer.OrdinalIgnoreCase);

            // Update the target package itself
            targetAssembly.PackageVersion = newVersion;
            _logger.Information($"[{nameof(DefaultAssemblyService)}] Updated {packageName} from {currentVersion} to {newVersion}");

            // Process each dependency
            foreach (var dependency in newDependencies)
            {
                var depName = dependency.Key;
                var depNewVersion = dependency.Value;

                if (existingAssembliesDict.TryGetValue(depName, out var existingAssembly))
                {
                    // Compare versions and update if the new version is higher
                    var existingVersion = NuGetVersion.Parse(existingAssembly.PackageVersion);
                    var candidateVersion = NuGetVersion.Parse(depNewVersion);

                    if (candidateVersion.CompareTo(existingVersion) > 0)
                    {
                        _logger.Information($"[{nameof(DefaultAssemblyService)}] Updating {depName} from {existingAssembly.PackageVersion} to {depNewVersion}");
                        existingAssembly.PackageVersion = depNewVersion;

                        // Update dependant tracking
                        if (!existingAssembly.DependantPackages.Contains(packageName))
                        {
                            existingAssembly.DependantPackages.Add(packageName);
                        }
                    }
                    else
                    {
                        _logger.Debug($"[{nameof(DefaultAssemblyService)}] Keeping {depName} at {existingAssembly.PackageVersion} (new version {depNewVersion} is not higher)");

                        // Still update dependant tracking even if version doesn't change
                        if (!existingAssembly.DependantPackages.Contains(packageName))
                        {
                            existingAssembly.DependantPackages.Add(packageName);
                        }
                    }
                }
                else
                {
                    // Add new dependency to the manifest with default settings
                    var newAssembly = new DevAssembly
                    {
                        PackageName = depName,
                        PackageVersion = depNewVersion,
                        TargetFramework = targetFramework,
                        CopyRuntimeAssemblies = false,
                        WindowsPowerShell = targetAssembly.WindowsPowerShell,
                        PowerShell7Plus = targetAssembly.PowerShell7Plus,
                        DependantPackages = new List<string> { packageName }
                    };

                    existingAssemblies.Add(newAssembly);
                    _logger.Information($"[{nameof(DefaultAssemblyService)}] Added new dependency {depName} version {depNewVersion} (required by {packageName})");
                }
            }

            // Process dependencies of updated packages recursively
            var updatedPackages = new List<string> { packageName };
            foreach (var dependency in newDependencies.Where(d => existingAssembliesDict.ContainsKey(d.Key)))
            {
                var existingAssembly = existingAssembliesDict[dependency.Key];
                if (existingAssembly.PackageVersion == dependency.Value)
                {
                    updatedPackages.Add(dependency.Key);
                }
            }

            // Update dependencies of all updated packages
            UpdateDependenciesRecursively(updatedPackages, existingAssemblies, targetFramework);

            // Sort assemblies by name for consistent output
            existingAssemblies.Sort((a, b) => string.Compare(a.PackageName, b.PackageName, StringComparison.OrdinalIgnoreCase));

            // Write the updated manifest back to the file
            var updatedManifestJson = JsonConvert.SerializeObject(existingAssemblies, Formatting.Indented);
            _fs.File.WriteAllText(manifestFilePath, updatedManifestJson);

            _logger.Information($"[{nameof(DefaultAssemblyService)}] Assembly manifest updated successfully");
        }

        private void UpdateDependenciesRecursively(List<string> updatedPackages, List<DevAssembly> existingAssemblies, string targetFramework)
        {
            var existingAssembliesDict = existingAssemblies.ToDictionary(a => a.PackageName, StringComparer.OrdinalIgnoreCase);
            var processedPackages = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var packageName in updatedPackages)
            {
                if (processedPackages.Contains(packageName) || !existingAssembliesDict.TryGetValue(packageName, out var assembly))
                    continue;

                processedPackages.Add(packageName);

                try
                {
                    var dependencies = _nuget.GetPackageDependencies(packageName, assembly.PackageVersion, targetFramework);

                    foreach (var dependency in dependencies)
                    {
                        var depName = dependency.Key;
                        var depVersion = dependency.Value;

                        if (existingAssembliesDict.TryGetValue(depName, out var existingDep))
                        {
                            var existingVersion = NuGetVersion.Parse(existingDep.PackageVersion);
                            var candidateVersion = NuGetVersion.Parse(depVersion);

                            if (candidateVersion.CompareTo(existingVersion) > 0)
                            {
                                _logger.Information($"[{nameof(DefaultAssemblyService)}] Recursively updating {depName} from {existingDep.PackageVersion} to {depVersion}");
                                existingDep.PackageVersion = depVersion;

                                // Add to updated packages for further recursive processing
                                if (!updatedPackages.Contains(depName))
                                {
                                    updatedPackages.Add(depName);
                                }
                            }

                            // Update dependant tracking
                            if (!existingDep.DependantPackages.Contains(packageName))
                            {
                                existingDep.DependantPackages.Add(packageName);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.Debug($"[{nameof(DefaultAssemblyService)}] Warning: Could not process dependencies for {packageName}: {ex.Message}");
                }
            }
        }
    }

    #region Component Governance Manifest Models
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
    #endregion
}
