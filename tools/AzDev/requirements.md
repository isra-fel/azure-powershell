# Assembly Manifest Update Cmdlet

This requirement doc describes a new cmdlet `Update-DevAssemblyManifest` that updates the assembly manifest file with a new version of any dependencies. This cmdlet is intended to be used in the AzDev PowerShell module to facilitate the updating of assembly manifests during development.

## Background

The assembly manifest file is a crucial component in managing dependencies for Azure PowerShell modules. It specifies the versions of nuget packages (which contain the necessary assemblies) that the module depends on (including sub-dependencies), such as `Azure.Core`. Keeping this manifest up-to-date is essential for ensuring compatibility and leveraging the latest features and fixes.

When a new version of a package is released, developers need to update the assembly manifest to reflect this change. The `Update-DevAssemblyManifest` cmdlet will automate this process, making it easier and less error-prone.

## Cmdlet Specification

### Name
`Update-DevAssemblyManifest`

### Input Parameters
- `-PackageName`: The name of the package to update. For example, `Azure.Core` or `Azure.Identity`.
- `-NewVersion`: The new version of the package to set in the assembly manifest. For example, `1.45.0`.

### Output
- Updates the assembly manifest file, refresh the packages and versions.

## Implementation Details

1. The cmdlet will read the current assembly manifest file and work out the current version of `PackageName`.
2. It will then work out the difference between the current version and the new version provided as input, and update the manifest accordingly. This is done by
    - Fetching the dependencies of the new `PackageName` version from NuGet (recursively).
    - Comparing the fetched dependencies with the existing ones in the manifest (honoring target framework).
        - If the new version has a higher version of a dependency, update it in the manifest.
        - If the new version has a lower version of a dependency, leave it unchanged in the manifest.
        - If the new version has a dependency that is not present in the manifest, add it to the manifest (default target framework is netstandard2.0).
    - Repeating step 2 for all updated dependencies recursively.

### Miscellaneous

- The cmdlet will use the `IAssemblyService` to update the assembly manifest.
- The cmdlet will be implemented in the `UpdateAssemblyManifestCmdlet` class.
- For the record, note in the manifest the dependant(s) of each dependency, so that we can trace why a dependency is included and remove it if no longer needed.
