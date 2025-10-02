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

namespace AzDev.Services.Assembly
{
    interface IAssemblyService
    {
        void UpdateAssembly(string manifestFilePath, string downloadPath, string runtimeMetadataPath, string cgManifestPath);

        /// <summary>
        /// Updates the assembly manifest with a new version of a package and its dependencies.
        /// </summary>
        /// <param name="manifestFilePath">Path to the assembly manifest file</param>
        /// <param name="packageName">The name of the package to update</param>
        /// <param name="newVersion">The new version of the package</param>
        void UpdateAssemblyManifestWithPackage(string manifestFilePath, string packageName, string newVersion);
    }
}
