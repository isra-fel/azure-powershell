
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
Creates a provider instance for the specified subscription, resource group, SapMonitor name, and resource name.
.Description
Creates a provider instance for the specified subscription, resource group, SapMonitor name, and resource name.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IProviderInstance
.Link
https://docs.microsoft.com/en-us/powershell/module/az.hana/new-azsapproviderinstance
#>
function New-AzSapMonitorProviderInstance {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IProviderInstance])]
    [CmdletBinding(DefaultParameterSetName = 'ByString', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    [Diagnostics.CodeAnalysis.SuppressMessageAttribute('PSAvoidUsingPlainTextForPassword', 'HanaDatabasePasswordKeyVaultUrl', Justification = 'Not a password')]
    [Diagnostics.CodeAnalysis.SuppressMessageAttribute('PSAvoidUsingPlainTextForPassword', 'HanaDatabasePasswordSecretId', Justification = 'Not a password')]
    param(
        [Parameter(Mandatory)]
        [Alias('ProviderInstanceName')]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
        [System.String]
        # Name of the provider instance.
        ${Name},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
        [System.String]
        # Name of the resource group.
        ${ResourceGroupName},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
        [System.String]
        # Name of the SAP monitor resource.
        ${SapMonitorName},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String]
        # Subscription ID which uniquely identify Microsoft Azure subscription.
        # The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
        [System.Collections.Hashtable]
        # A JSON string containing metadata of the provider instance.
        ${Metadata},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
        [System.String]
        # The type of provider instance. Supported values are: "SapHana".
        ${Type},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
        [System.String]
        # The hostname of SAP HANA instance.
        ${HanaHostname},

        [Parameter(Mandatory)]
        [Alias('HanaDbName')]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
        [System.String]
        # The database name of SAP HANA instance.
        ${HanaDatabaseName},

        [Parameter(Mandatory)]
        [Alias('HanaDbSqlPort')]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
        [System.Int32]
        # The SQL port of the database of SAP HANA instance.
        ${HanaDatabaseSqlPort},

        [Parameter(Mandatory)]
        [Alias('HanaDbUsername')]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
        [System.String]
        # The username of the database of SAP HANA instance.
        ${HanaDatabaseUsername},

        [Parameter(ParameterSetName = 'ByString', Mandatory)]
        [Alias('HanaDbPassword')]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
        [SecureString]
        # The password of the database of SAP HANA instance.
        ${HanaDatabasePassword},

        [Parameter(ParameterSetName = 'ByKeyVault', Mandatory)]
        [Alias('HanaDbPasswordKeyVaultUrl', 'KeyVaultUrl')]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
        [System.String]
        # URL (DNS name) to the Key Vault secret that contains the HANA credentials.
        ${HanaDatabasePasswordKeyVaultUrl},

        [Parameter(ParameterSetName = 'ByKeyVault', Mandatory)]
        [Alias('HanaDbPasswordSecretId', 'SecretId')]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
        [System.String]
        # Secret identifier to the Key Vault secret that contains the HANA credentials.
        ${HanaDatabasePasswordSecretId},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    process {
        $null = $PSBoundParameters.Remove('HanaHostname')
        $null = $PSBoundParameters.Remove('HanaDatabaseName')
        $null = $PSBoundParameters.Remove('HanaDatabaseSqlPort')
        $null = $PSBoundParameters.Remove('HanaDatabaseUsername')
        $parameterSet = $PSCmdlet.ParameterSetName
        switch ($parameterSet) {
            'ByString' {
                $null = $PSBoundParameters.Remove('HanaDatabasePassword')
                $PSBoundParameters.Add('Metadata', ($Metadata | ConvertTo-Json))
                $property = @{
                    hanaHostname   = $HanaHostname
                    hanaDbName     = $HanaDatabaseName
                    hanaDbSqlPort  = $HanaDatabaseSqlPort
                    hanaDbUsername = $HanaDatabaseUsername
                    hanaDbPassword = ConvertFrom-SecureString $HanaDatabasePassword -AsPlainText
                }
                $PSBoundParameters.Add('ProviderInstanceProperty', ($property | ConvertTo-Json))
            }
            'ByKeyVault' {  }
        }
        Az.HanaOnAzure.internal\New-AzSapMonitorProviderInstance @PSBoundParameters
    }

}
