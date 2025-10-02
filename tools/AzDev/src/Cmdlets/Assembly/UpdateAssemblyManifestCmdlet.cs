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

using System.IO.Abstractions;
using System.Management.Automation;
using AzDev.Services;
using AzDev.Services.Assembly;

namespace AzDev.Cmdlets.Assembly
{
    [Cmdlet("Update", "DevAssemblyManifest")]
    public class UpdateAssemblyManifestCmdlet : DevCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The name of the package to update in the assembly manifest.")]
        public string PackageName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The new version of the package to set in the assembly manifest.")]
        public string NewVersion { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            // Get required services
            var assemblyService = AzDevModule.GetService<IAssemblyService>();
            var fs = AzDevModule.GetService<IFileSystem>();

            // Build the path to the assembly manifest file
            var psRoot = Context.AzurePowerShellRepositoryRoot;
            var libPath = fs.Path.Combine(psRoot, FileOrDirNames.Src, FileOrDirNames.Lib);
            var manifestPath = fs.Path.Combine(libPath, FileOrDirNames.AssemblyManifestFileName);

            try
            {
                WriteVerbose($"Updating assembly manifest with {PackageName} version {NewVersion}");
                WriteVerbose($"Manifest file path: {manifestPath}");

                // Update the assembly manifest with the new package version
                assemblyService.UpdateAssemblyManifestWithPackage(manifestPath, PackageName, NewVersion);

                WriteObject($"Assembly manifest updated successfully with {PackageName} version {NewVersion}");
            }
            catch (System.Exception ex)
            {
                WriteError(new ErrorRecord(ex, "UpdateAssemblyManifestError", ErrorCategory.InvalidOperation, PackageName));
            }
        }
    }
}
