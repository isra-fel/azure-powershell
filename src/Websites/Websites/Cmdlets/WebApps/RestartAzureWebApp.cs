﻿
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


using Microsoft.Azure.Commands.WebApps.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// this commandlet will let you restart an Azure Web app
    /// </summary>
    [Cmdlet("Restart", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "WebApp"), OutputType(typeof(PSSite))]
    public class RestartAzureWebAppCmdlet : WebAppBaseCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "Specify true to apply the configuration settings and restarts the app only if necessary.")]
        public SwitchParameter SoftRestart { get; set; }
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            WebsitesClient.RestartWebApp(ResourceGroupName, Name, null, SoftRestart);
            WriteObject(new PSSite(WebsitesClient.GetWebApp(ResourceGroupName, Name, null)));
        }
    }
}
