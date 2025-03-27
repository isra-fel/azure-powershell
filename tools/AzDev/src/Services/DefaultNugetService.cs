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
using System.IO;
using System.IO.Abstractions;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NuGet.Common;
using NuGet.Packaging;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

namespace AzDev.Services
{
    internal class DefaultNugetService : INugetService
    {

        private SourceRepository _repository = Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json");
        private readonly Lazy<FindPackageByIdResource> _findPackageByIdResource;
        private SourceCacheContext _cache = new SourceCacheContext();

        public DefaultNugetService()
        {
            _findPackageByIdResource = new Lazy<FindPackageByIdResource>(_repository.GetResource<FindPackageByIdResource>, LazyThreadSafetyMode.ExecutionAndPublication);
        }

        public void DownloadAssembly(string packageName, string packageVersion, string targetFramework, FileSystemStream downloadTo)
        {
            DownloadAssemblyAsync(packageName, packageVersion, targetFramework, downloadTo).GetAwaiter().GetResult();
        }

        public async Task DownloadAssemblyAsync(string packageName, string packageVersion, string targetFramework, FileSystemStream downloadTo)
        {
            using var packageStream = new MemoryStream();
            await _findPackageByIdResource.Value.CopyNupkgToStreamAsync(
                packageName,
                new NuGetVersion(packageVersion),
                packageStream,
                _cache,
                NullLogger.Instance,
                default);

            using var packageReader = new PackageArchiveReader(packageStream);
            string assemblyPathRelativeToPackage = $"lib/{targetFramework}/{packageName}.dll";
            if (!packageReader.GetFiles().Contains(assemblyPathRelativeToPackage))
            {
                Console.WriteLine("not found");
                return;
            }
            ZipArchiveEntry entry = packageReader.GetEntry(assemblyPathRelativeToPackage);
            using var assemblyStream = entry.Open();
            assemblyStream.CopyTo(downloadTo);
        }
    }
}
