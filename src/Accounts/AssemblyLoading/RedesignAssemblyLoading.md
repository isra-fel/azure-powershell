## Goal

1. Easy to update or add dependencies
2. Track vulnerabilities of dependencies (via [cgmanifest.json](https://docs.opensource.microsoft.com/tools/cg/component-detection/cgmanifest/))

## Solution

1. Define the list of dependencies in a easy-to-edit file (e.g., `dependencies.txt`).
2. Create a script to read this file and generate a `cgmanifest.json` file.
   1. This is trivial. It only needs package name and package version. Can be directly generated.
3. Create another script to read this file and
   1. update the assembly list in `ConditionalAssemblyProvider.cs`
   2. update `src/lib` accordingly
   3. detailed steps
      1. Download the package from nuget by name and version.
      2. Get corresponding dll from nuget by name and target framework
      3. Get assembly version from the dll
      4. update `ConditionalAssemblyProvider.cs`
      5. if updated, copy the dll to the target folder (`netstandard2.0` or `netfx`)