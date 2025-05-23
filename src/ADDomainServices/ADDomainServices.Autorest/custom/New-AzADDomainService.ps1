
# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# Code generated by Microsoft (R) AutoRest Code Generator.Changes may cause incorrect behavior and will be lost if the code
# is regenerated.
# ----------------------------------------------------------------------------------

<#
.Synopsis
The create Domain Service operation create a new domain service with the specified parameters.
If the specific service already exists, then any patchable properties will be updated and any immutable properties will remain unchanged.
.Description
The create Domain Service operation create a new domain service with the specified parameters.
If the specific service already exists, then any patchable properties will be updated and any immutable properties will remain unchanged.
.Example
$replicaSet = New-AzADDomainServiceReplicaSetObject -Location westus -SubnetId /subscriptions/********-****-****-****-**********/resourceGroups/test-rg/providers/Microsoft.Network/virtualNetworks/test-vnet/subnets/default
New-AzADDomainService -Name youriADdomain -ResourceGroupName youriAddomain -DomainName youriAddomain.com -ReplicaSet $replicaSet
.Example
# Variables
$replicaSet = New-AzADDomainServiceReplicaSet -Location westus -SubnetId /subscriptions/********-****-****-****-**********/resourceGroups/yishitest/providers/Microsoft.Network/virtualNetworks/aadds-vnet/subnets/default\
$certificateBytes = Get-Content "certificate.pfx" -AsByteStream
$base64String = [System.Convert]::ToBase64String($certificateBytes) 
$ldaps_pfx_pass = "MyStrongPassword"

New-AzADDomainService -Name youriADdomain -ResourceGroupName youriAddomain -DomainName youriAddomain.com -ReplicaSet $replicaSet -LdapSettingLdaps Enabled -LdapSettingPfxCertificate $base64String -LdapSettingPfxCertificatePassword $($ldaps_pfx_pass | ConvertTo-SecureString -Force -AsPlainText)

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.IDomainService
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

FORESTTRUST <IForestTrust[]>: List of settings for Resource Forest
  [FriendlyName <String>]: Friendly Name
  [RemoteDnsIP <String>]: Remote Dns ips
  [TrustDirection <String>]: Trust Direction
  [TrustPassword <SecureString>]: Trust Password
  [TrustedDomainFqdn <String>]: Trusted Domain FQDN

REPLICASET <IReplicaSet[]>: List of ReplicaSets
  [Location <String>]: Virtual network location
  [SubnetId <String>]: The name of the virtual network that Domain Services will be deployed on. The id of the subnet that Domain Services will be deployed on. /virtualNetwork/vnetName/subnets/subnetName.
.Link
https://learn.microsoft.com/powershell/module/az.addomainservices/new-azaddomainservice
#>
function New-AzADDomainService {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.IDomainService])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Parameter(ParameterSetName='CreateViaJsonFilePath', Mandatory)]
    [Parameter(ParameterSetName='CreateViaJsonString', Mandatory)]
    [Alias('DomainServiceName')]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Path')]
    [System.String]
    # The name of the domain service.
    ${Name},

    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Parameter(ParameterSetName='CreateViaJsonFilePath', Mandatory)]
    [Parameter(ParameterSetName='CreateViaJsonString', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Path')]
    [System.String]
    # The name of the resource group within the user's subscription.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaJsonFilePath')]
    [Parameter(ParameterSetName='CreateViaJsonString')]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Gets subscription credentials which uniquely identify the Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='CreateExpanded')]
    [ArgumentCompleter({'FullySynced', 'ResourceTrusting'})]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.String]
    # Domain Configuration Type
    ${DomainConfigurationType},

    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.String]
    # The name of the Azure domain that the user would like to deploy Domain Services to.
    ${DomainName},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PSArgumentCompleterAttribute("Enabled", "Disabled")]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.String]
    # A flag to determine whether or not NtlmV1 is enabled or disabled.
    ${DomainSecuritySettingNtlmV1},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PSArgumentCompleterAttribute("Enabled", "Disabled")]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.String]
    # A flag to determine whether or not SyncKerberosPasswords is enabled or disabled.
    ${DomainSecuritySettingSyncKerberosPassword},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PSArgumentCompleterAttribute("Enabled", "Disabled")]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.String]
    # A flag to determine whether or not SyncNtlmPasswords is enabled or disabled.
    ${DomainSecuritySettingSyncNtlmPassword},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PSArgumentCompleterAttribute("Enabled", "Disabled")]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.String]
    # A flag to determine whether or not SyncOnPremPasswords is enabled or disabled.
    ${DomainSecuritySettingSyncOnPremPassword},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PSArgumentCompleterAttribute("Enabled", "Disabled")]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.String]
    # A flag to determine whether or not TlsV1 is enabled or disabled.
    ${DomainSecuritySettingTlsV1},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.String]
    # Resource etag
    ${Etag},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PSArgumentCompleterAttribute("Enabled", "Disabled")]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.String]
    # Enabled or Disabled flag to turn on Group-based filtered sync
    ${FilteredSync},

    [Parameter(ParameterSetName='CreateExpanded')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.IForestTrust[]]
    # List of settings for Resource Forest
    ${ForestTrust},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PSArgumentCompleterAttribute("Enabled", "Disabled")]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.String]
    # A flag to determine whether or not Secure LDAP access over the internet is enabled or disabled.
    ${LdapSettingExternalAccess},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PSArgumentCompleterAttribute("Enabled", "Disabled")]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.String]
    # A flag to determine whether or not Secure LDAP is enabled or disabled.
    ${LdapSettingLdaps},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.String]
    # Input File for LdapSettingPfxCertificate (The certificate required to configure Secure LDAP.
    # The parameter passed here should be a base64encoded representation of the certificate pfx file.)
    ${LdapSettingPfxCertificateInputFile},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.Security.SecureString]
    # The password to decrypt the provided Secure LDAP certificate pfx file.
    ${LdapSettingPfxCertificatePassword},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.DefaultInfo(Name='Location Default', Description='Gets the Location from the first element in ReplicaSets.', Script='$ReplicaSet[0].Location')]
    [System.String]
    # Resource location
    ${Location},

    [Parameter(ParameterSetName='CreateExpanded')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.String[]]
    # The list of additional recipients
    ${NotificationSettingAdditionalRecipient},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PSArgumentCompleterAttribute("Enabled", "Disabled")]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.String]
    # Should domain controller admins be notified
    ${NotificationSettingNotifyDcAdmin},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PSArgumentCompleterAttribute("Enabled", "Disabled")]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.String]
    # Should global admins be notified
    ${NotificationSettingNotifyGlobalAdmin},

    [Parameter(ParameterSetName='CreateExpanded')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.IReplicaSet[]]
    # List of ReplicaSets
    ${ReplicaSet},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.String]
    # Resource Forest
    ${ResourceForest},

    [Parameter(ParameterSetName='CreateExpanded')]
    [ArgumentCompleter({'Standard', 'Enterprise', 'Premium'})]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.String]
    # Sku Type
    ${Sku},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.IResourceTags]))]
    [System.Collections.Hashtable]
    # Resource tags
    ${Tag},

    [Parameter(ParameterSetName='CreateViaJsonFilePath', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.String]
    # Path of Json file supplied to the Create operation
    ${JsonFilePath},

    [Parameter(ParameterSetName='CreateViaJsonString', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Body')]
    [System.String]
    # Json string supplied to the Create operation
    ${JsonString},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The DefaultProfile parameter is not functional.
    # Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

    process {
        Az.ADDomainServices.internal\New-AzADDomainService @PSBoundParameters
    }
}
