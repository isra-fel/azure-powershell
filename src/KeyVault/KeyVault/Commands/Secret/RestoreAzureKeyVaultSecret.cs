﻿// ----------------------------------------------------------------------------------
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
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.Models.Secret;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Restores the backup secret into a vault 
    /// </summary>
    [Cmdlet("Restore", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultSecret",SupportsShouldProcess = true,DefaultParameterSetName = ByVaultNameParameterSet)]
    [OutputType( typeof(PSKeyVaultSecret) )]
    public class RestoreAzureKeyVaultSecret : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string ByVaultNameParameterSet = "ByVaultName";
        private const string ByInputObjectParameterSet = "ByInputObject";
        private const string ByParentResourceIdParameterSet = "ByParentResourceId";
        private const string BySecretUriParameterSet = "BySecretUri";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   ParameterSetName = ByVaultNameParameterSet,
                   HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment." )]
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// KeyVault Secret ID (uri of the secret)
        /// </summary>
        [Parameter(Mandatory = true,
           Position = 0,
           ParameterSetName = BySecretUriParameterSet,
           HelpMessage = "The URI of the KeyVault Secret.")]
        [Alias("SecretId")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// KeyVault object
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   ParameterSetName = ByInputObjectParameterSet,
                   ValueFromPipeline = true,
                   HelpMessage = "KeyVault object")]
        [ValidateNotNullOrEmpty]
        public PSKeyVault InputObject { get; set; }

        /// <summary>
        /// KeyVault's ResourceId
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   ParameterSetName = ByParentResourceIdParameterSet,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "KeyVault Resource Id")]
        [Alias("ResourceId")]
        [ValidateNotNullOrEmpty]
        public string ParentResourceId { get; set; }

        /// <summary>
        /// The input file in which the backup blob is stored
        /// </summary>
        [Parameter( Mandatory = true,
                   Position = 1,
                   HelpMessage = "Input file. The input file containing the backed-up blob" )]
        [ValidateNotNullOrEmpty]
        public string InputFile { get; set; }

        #endregion Input Parameter Definitions

        public override void ExecuteCmdlet( )
        {
            if (InputObject != null)
            {
                VaultName = InputObject.VaultName;
            }
            else if (ParentResourceId != null)
            {
                var ParentResourceIdentifier = new ResourceIdentifier(ParentResourceId);
                VaultName = ParentResourceIdentifier.ResourceName;
            }

            if (ParameterSetName == BySecretUriParameterSet)
            {
                SecretUriComponents splitUri = new SecretUriComponents(Id);

                VaultName = splitUri.VaultName;
            }

            if (ShouldProcess(VaultName, Properties.Resources.RestoreSecret))
            {
                var resolvedFilePath = this.ResolveUserPath(InputFile);

                if (!AzureSession.Instance.DataStore.FileExists(resolvedFilePath))
                {
                    throw new FileNotFoundException(string.Format(Resources.BackupSecretFileNotFound, resolvedFilePath));
                }

                var restoredSecret = this.DataServiceClient.RestoreSecret(VaultName, resolvedFilePath);

                this.WriteObject(restoredSecret);
            }
        }
    }
}
