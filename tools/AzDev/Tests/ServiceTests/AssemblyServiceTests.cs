using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using AzDev.Models.Assembly;
using AzDev.Services;
using AzDev.Services.Assembly;
using Moq;
using Xunit.Sdk;

namespace AzDev.Tests;

public class AssemblyServiceTests
{
    [Fact]
    public void DownloadAndInspectAssembly()
    {
        IFileSystem mockFs = new MockFileSystem(new Dictionary<string, MockFileData>
        {
            { @"C:\manifest.json", new MockFileData(@"[
                {
                    ""PackageName"": ""Azure.Core"",
                    ""PackageVersion"": ""1.44.1"",
                    ""TargetFramework"": ""netstandard2.0"",
                    ""WindowsPowerShell"": true,
                    ""PowerShell7Plus"": true
                }
            ]") },
            { @"C:\lib\netstandard2.0\Azure.Core.dll", new MockFileData(@"") },
            { @"C:\runtime.cs", new MockFileData(@"
            #region Generated
            #endregion
            ") },
            { @"C:\CgManifest.json", new MockFileData(@"{
                ""registrations"": []
            }") }
        });
        var mockNugetService = new Mock<INugetService>();
        mockNugetService.Setup(x => x.DownloadAssembly("Azure.Core", "1.44.1", "netstandard2.0", @"C:\lib", false))
            .Returns(@"C:\lib\netstandard2.0\Azure.Core.dll");
        var mockAssemblyMetadataService = new Mock<IAssemblyMetadataService>();
        mockAssemblyMetadataService.Setup(x => x.ParseAssemblyMetadata(@"C:\lib\netstandard2.0\Azure.Core.dll"))
            .Returns(new RuntimeAssembly
            {
                Name = "Azure.Core",
                Version = new Version(1, 44, 1),
                TargetFramework = "netstandard2.0"
            });
        var assemblyService = new DefaultAssemblyService(mockFs, mockNugetService.Object, NoopLogger.Instance, mockAssemblyMetadataService.Object);

        assemblyService.UpdateAssembly(@"C:\manifest.json", @"C:\lib", @"C:\runtime.cs", @"C:\CgManifest.json");
        mockNugetService.Verify(x => x.DownloadAssembly("Azure.Core", "1.44.1", "netstandard2.0", @"C:\lib", false), Times.Once);
        mockAssemblyMetadataService.Verify(x => x.ParseAssemblyMetadata(@"C:\lib\netstandard2.0\Azure.Core.dll"), Times.Once);
    }

    [Fact]
    public void UpdateAssemblyManifestWithPackage_UpdatesExistingAssembly()
    {
        IFileSystem mockFs = new MockFileSystem(new Dictionary<string, MockFileData>
        {
            { @"C:\manifest.json", new MockFileData(@"[
                {
                    ""PackageName"": ""Azure.Core"",
                    ""PackageVersion"": ""1.44.1"",
                    ""TargetFramework"": ""netstandard2.0"",
                    ""WindowsPowerShell"": true,
                    ""PowerShell7Plus"": true,
                    ""DependantPackages"": []
                },
                {
                    ""PackageName"": ""System.Text.Json"",
                    ""PackageVersion"": ""6.0.0"",
                    ""TargetFramework"": ""netstandard2.0"",
                    ""WindowsPowerShell"": true,
                    ""PowerShell7Plus"": true,
                    ""DependantPackages"": [""Azure.Core""]
                }
            ]") }
        });

        var mockNugetService = new Mock<INugetService>();
        mockNugetService.Setup(x => x.GetPackageDependencies("Azure.Core", "1.45.0", "netstandard2.0"))
            .Returns(new Dictionary<string, string>
            {
                { "System.Text.Json", "8.0.0" },
                { "System.Memory", "4.5.5" }
            });

        var mockAssemblyMetadataService = new Mock<IAssemblyMetadataService>();
        var assemblyService = new DefaultAssemblyService(mockFs, mockNugetService.Object, NoopLogger.Instance, mockAssemblyMetadataService.Object);

        assemblyService.UpdateAssemblyManifestWithPackage(@"C:\manifest.json", "Azure.Core", "1.45.0");

        // Verify the manifest was updated
        var updatedManifestContent = mockFs.File.ReadAllText(@"C:\manifest.json");
        Assert.Contains("1.45.0", updatedManifestContent); // Azure.Core version updated
        Assert.Contains("8.0.0", updatedManifestContent);  // System.Text.Json version updated
        Assert.Contains("System.Memory", updatedManifestContent); // New dependency added
        Assert.Contains("DependantPackages", updatedManifestContent); // Dependency tracking included
    }

    [Fact]
    public void UpdateAssemblyManifestWithPackage_ThrowsWhenPackageNotFound()
    {
        IFileSystem mockFs = new MockFileSystem(new Dictionary<string, MockFileData>
        {
            { @"C:\manifest.json", new MockFileData(@"[
                {
                    ""PackageName"": ""SomeOtherPackage"",
                    ""PackageVersion"": ""1.0.0"",
                    ""TargetFramework"": ""netstandard2.0"",
                    ""WindowsPowerShell"": true,
                    ""PowerShell7Plus"": true,
                    ""DependantPackages"": []
                }
            ]") }
        });

        var mockNugetService = new Mock<INugetService>();
        var mockAssemblyMetadataService = new Mock<IAssemblyMetadataService>();
        var assemblyService = new DefaultAssemblyService(mockFs, mockNugetService.Object, NoopLogger.Instance, mockAssemblyMetadataService.Object);

        Assert.Throws<InvalidOperationException>(() =>
            assemblyService.UpdateAssemblyManifestWithPackage(@"C:\manifest.json", "Azure.Core", "1.45.0"));
    }

    [Fact]
    public void UpdateAssemblyManifestWithPackage_NoUpdateNeededWhenVersionsSame()
    {
        IFileSystem mockFs = new MockFileSystem(new Dictionary<string, MockFileData>
        {
            { @"C:\manifest.json", new MockFileData(@"[
                {
                    ""PackageName"": ""Azure.Core"",
                    ""PackageVersion"": ""1.45.0"",
                    ""TargetFramework"": ""netstandard2.0"",
                    ""WindowsPowerShell"": true,
                    ""PowerShell7Plus"": true,
                    ""DependantPackages"": []
                }
            ]") }
        });

        var mockNugetService = new Mock<INugetService>();
        var mockAssemblyMetadataService = new Mock<IAssemblyMetadataService>();
        var assemblyService = new DefaultAssemblyService(mockFs, mockNugetService.Object, NoopLogger.Instance, mockAssemblyMetadataService.Object);

        assemblyService.UpdateAssemblyManifestWithPackage(@"C:\manifest.json", "Azure.Core", "1.45.0");

        // Verify GetPackageDependencies was never called since version is the same
        mockNugetService.Verify(x => x.GetPackageDependencies(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
    }
}