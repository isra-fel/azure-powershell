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

using System.Management.Automation;
using AzDev.Services;

namespace AzDev.Cmdlets.Assembly
{
    [Cmdlet("Update", "DevAssembly")]
    public class UpdateAssemblyCmdlet : DevCmdletBase
    {
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var assemblyService = AzDevModule.GetService<IAssemblyService>();
            assemblyService.UpdateAssembly(
                @"C:\Users\yeliu\code\azure-powershell\src\lib\manifest.json",
                @"C:\Users\yeliu\code\azure-powershell\src\lib",
                @"C:\Users\yeliu\code\azure-powershell\src\Accounts\AssemblyLoading\ConditionalAssemblyProvider.cs",
                @"C:\Users\yeliu\code\azure-powershell\src\lib\cgManifest.json");
        }
    }
}
