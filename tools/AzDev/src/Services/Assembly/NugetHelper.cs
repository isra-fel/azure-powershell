using NuGet.Common;
using NuGet.Packaging;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

static class NugetHelper
{
    static SourceRepository repository = Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json");
    static SourceCacheContext cache = new SourceCacheContext();
    private static NuGetVersion targetPackageVersion = new NuGetVersion(0, 0, 0);

    static async Task<Version> GetAsmVerByPkgVerAsync(string packageId, string packageVersion, string targetFramework)
    {
        Console.Write($"Trying {packageVersion}... ");
        ILogger logger = NullLogger.Instance;
        CancellationToken cancellationToken = CancellationToken.None;

        FindPackageByIdResource findResource = await repository.GetResourceAsync<FindPackageByIdResource>();

        ZipArchiveEntry entry = null;
        string targetAsmPath = null;
        using (MemoryStream packageStream = new MemoryStream())
        {
            await findResource.CopyNupkgToStreamAsync(
                packageId,
                new NuGetVersion(packageVersion),
                packageStream,
                cache,
                logger,
                cancellationToken);

            using (PackageArchiveReader packageReader = new PackageArchiveReader(packageStream))
            {

                // you can also get info about dependent packages by downloading the package and reading its nuspec file
                string targetAsmPathCompressed = $"lib/{targetFramework}/{packageId}.dll";
                if (!packageReader.GetFiles().Contains(targetAsmPathCompressed))
                {
                    Console.WriteLine("not found");
                    return null;
                }

                targetAsmPath = Path.GetTempFileName();
                entry = packageReader.GetEntry(targetAsmPathCompressed);
            }
        }

        using (var inputStream = entry.Open())
        using (var outputStream = File.OpenWrite(targetAsmPath))
        {
            inputStream.CopyTo(outputStream);
        }

        return AssemblyMetadataHelper.GetAssemblyMetadata(targetAsmPath).Version;
    }

    public static async Task<string> GetPkgVerByAsmVerAsync(string assemblyName, Version assemblyVersion, string targetFramework)
    {
        string packageId = assemblyName;
        List<NuGetVersion> availableVersions = new List<NuGetVersion>(await GetAvailableVersionsAsync(packageId));
        availableVersions.Sort((x, y) =>
        {
            // descending order
            return y.CompareTo(x);
        });
        return availableVersions.First(x =>
        {
            Version asmVer = GetAsmVerByPkgVerAsync(packageId, x.ToFullString(), targetFramework).Result;
            return asmVer != null && asmVer.Equals(assemblyVersion);
        }).ToFullString();
    }

    async static Task<IEnumerable<NuGetVersion>> GetAvailableVersionsAsync(string packageId)
    {
        ILogger logger = NullLogger.Instance;
        CancellationToken cancellationToken = CancellationToken.None;

        FindPackageByIdResource findResource = await repository.GetResourceAsync<FindPackageByIdResource>();

        return await findResource.GetAllVersionsAsync(
            packageId,
            cache,
            logger,
            cancellationToken);
    }
}
