using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
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

        public void UpdateAssembly(string manifestFilePath, string downloadPath, string runtimeMetadataPath)
        {
            _logger.Information($"Updating assembly using manifest: {manifestFilePath}, download path: {downloadPath}, runtime metadata path: {runtimeMetadataPath}");

            if (!_fs.File.Exists(manifestFilePath))
            {
                throw new FileNotFoundException($"Manifest file does not exist", manifestFilePath);
            }

            var devAssemblies = ReadAndParseManifests(_fs.File.ReadAllText(manifestFilePath));
            CleanDownloadDirectory(downloadPath);
            DownloadDevAssemblies(devAssemblies, downloadPath);
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

        private void DownloadDevAssemblies(List<DevAssembly> devAssemblies, string downloadPath)
        {
            foreach (var devAssembly in devAssemblies)
            {
                DownloadDevAssembly(devAssembly, downloadPath);
            }
        }

        private void DownloadDevAssembly(DevAssembly devAssembly, string downloadPath)
        {
            var packageName = devAssembly.PackageName;
            var packageVersion = devAssembly.PackageVersion;
            var targetFramework = devAssembly.TargetFramework;

            string pathWithTargetFramework = Path.Combine(downloadPath, targetFramework);
            if (!_fs.Directory.Exists(pathWithTargetFramework))
            {
                _fs.Directory.CreateDirectory(pathWithTargetFramework);
            }

            _nuget.DownloadAssembly(packageName, packageVersion, targetFramework, pathWithTargetFramework, devAssembly.CopyRuntimeAssemblies);
        }
    }
}
