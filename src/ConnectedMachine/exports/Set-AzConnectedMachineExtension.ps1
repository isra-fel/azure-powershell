
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
The operation to create or update the extension.
.Description
The operation to create or update the extension.
.Example
PS C:\> $Settings = @{ "commandToExecute" = "powershell.exe -c Get-Process" }
PS C:\> Set-AzConnectedMachineExtension -Name custom -ResourceGroupName ContosoTest -MachineName win-eastus1 -Location eastus -Publisher "Microsoft.Compute" -TypeHandlerVersion 1.10 -Settings $Settings -ExtensionType CustomScriptExtension

Name   Location ProvisioningState
----   -------- -----------------
custom eastus   Succeeded
.Example
PS C:\> $otherExtension = Get-AzConnectedMachineExtension -Name custom -ResourceGroupName ContosoTest -MachineName other
PS C:\> $otherExtension | Set-AzConnectedMachineExtension -Name custom -ResourceGroupName ContosoTest -MachineName important

Name   Location ProvisioningState
----   -------- -----------------
custom eastus   Succeeded

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtension
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtension
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

EXTENSIONPARAMETER <IMachineExtension>: Describes a Machine Extension.
  Location <String>: The geo-location where the resource lives
  [Tag <ITrackedResourceTags>]: Resource tags.
    [(Any) <String>]: This indicates any property can be added to this object.
  [AutoUpgradeMinorVersion <Boolean?>]: Indicates whether the extension should use a newer minor version if one is available at deployment time. Once deployed, however, the extension will not upgrade minor versions unless redeployed, even with this property set to true.
  [ForceUpdateTag <String>]: How the extension handler should be forced to update even if the extension configuration has not changed.
  [MachineExtensionType <String>]: Specifies the type of the extension; an example is "CustomScriptExtension".
  [ProtectedSetting <IMachineExtensionPropertiesProtectedSettings>]: The extension can contain either protectedSettings or protectedSettingsFromKeyVault or no protected settings at all.
  [Publisher <String>]: The name of the extension handler publisher.
  [Setting <IMachineExtensionPropertiesSettings>]: Json formatted public settings for the extension.
  [TypeHandlerVersion <String>]: Specifies the version of the script handler.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.connectedmachine/set-azconnectedmachineextension
#>
function Set-AzConnectedMachineExtension {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtension])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Path')]
    [System.String]
    # The name of the machine where the extension should be created or updated.
    ${MachineName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Path')]
    [System.String]
    # The name of the machine extension.
    ${Name},

    [Parameter(Mandatory)]
    [ArgumentCompleter({Get-AzResourceGroup | Select-Object -ExpandProperty ResourceGroupName})]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Path')]
    [System.String]
    # The name of the resource group.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription credentials which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='Update', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtension]
    # Describes a Machine Extension.
    # To construct, see NOTES section for EXTENSIONPARAMETER properties and create a hash table.
    ${ExtensionParameter},

    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [ArgumentCompleter({Get-AzLocation | Where-Object Providers -Contains "Microsoft.HybridCompute" | Select-Object -ExpandProperty Location})]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Body')]
    [System.String]
    # The geo-location where the resource lives
    ${Location},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Indicates whether the extension should use a newer minor version if one is available at deployment time.
    # Once deployed, however, the extension will not upgrade minor versions unless redeployed, even with this property set to true.
    ${AutoUpgradeMinorVersion},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Body')]
    [System.String]
    # Specifies the type of the extension; an example is "CustomScriptExtension".
    ${ExtensionType},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Body')]
    [System.String]
    # How the extension handler should be forced to update even if the extension configuration has not changed.
    ${ForceRerun},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Alias('ProtectedSettings')]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionPropertiesProtectedSettings]
    # The extension can contain either protectedSettings or protectedSettingsFromKeyVault or no protected settings at all.
    ${ProtectedSetting},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Body')]
    [System.String]
    # The name of the extension handler publisher.
    ${Publisher},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Alias('Settings')]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineExtensionPropertiesSettings]
    # Json formatted public settings for the extension.
    ${Setting},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ITrackedResourceTags]))]
    [System.Collections.Hashtable]
    # Resource tags.
    ${Tag},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Body')]
    [System.String]
    # Specifies the version of the script handler.
    ${TypeHandlerVersion},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            Update = 'Az.ConnectedMachine.private\Set-AzConnectedMachineExtension_Update';
            UpdateExpanded = 'Az.ConnectedMachine.private\Set-AzConnectedMachineExtension_UpdateExpanded';
        }
        if (('Update', 'UpdateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($MyInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {
        throw
    }
}

end {
    try {
        $steppablePipeline.End()
    } catch {
        throw
    }
}
}
