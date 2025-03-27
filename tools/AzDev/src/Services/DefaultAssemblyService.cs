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

        public DefaultAssemblyService(): this(new FileSystem())
        {
        }

        public DefaultAssemblyService(IFileSystem fs)
        {
            _fs = fs;
            _nuget = AzDevModule.GetService<INugetService>();
        }

        public void UpdateAssembly(string manifestFilePath, string downloadPath, string runtimeMetadataPath)
        {
            Console.WriteLine($"Updating assembly using manifest: {manifestFilePath}, download path: {downloadPath}, runtime metadata path: {runtimeMetadataPath}");

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
                Console.WriteLine("Error reading or parsing manifest file: " + ex.Message);
                return null;
            }
        }

        private void CleanDownloadDirectory(string downloadPath)
        {
            var subDirs = _fs.Directory.GetDirectories(downloadPath, "net*");
            foreach (var subDir in subDirs)
            {
                Console.WriteLine($"Deleting directory: {subDir}");
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
            var assemblyName = $"{devAssembly.PackageName}.dll";

            string targetPath = Path.Combine(downloadPath, targetFramework);
            if (!_fs.Directory.Exists(targetPath))
            {
                _fs.Directory.CreateDirectory(targetPath);
            }
            string assemblyPath = Path.Combine(targetPath, assemblyName);

            Console.WriteLine($"Downloading {packageName} v{packageVersion} ({targetFramework}) to {assemblyPath}");

            using var downloadTarget = _fs.File.Create(assemblyPath);
            _nuget.DownloadAssembly(packageName, packageVersion, targetFramework, downloadTarget);
        }
    }
}
