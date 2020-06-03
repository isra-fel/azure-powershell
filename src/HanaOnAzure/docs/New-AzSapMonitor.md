---
external help file:
Module Name: Az.Hana
online version: https://docs.microsoft.com/en-us/powershell/module/az.hana/new-azsapmonitor
schema: 2.0.0
---

# New-AzSapMonitor

## SYNOPSIS
Creates a SAP monitor for the specified subscription, resource group, and resource name.

## SYNTAX

### CreateExpanded (Default)
```
New-AzSapMonitor -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-EnableCustomerAnalytic] [-HanaDbCredentialsMsiId <String>] [-HanaDbName <String>]
 [-HanaDbPassword <String>] [-HanaDbPasswordKeyVaultUrl <String>] [-HanaDbSqlPort <Int32>]
 [-HanaDbUsername <String>] [-HanaHostname <String>] [-HanaSubnet <String>] [-KeyVaultId <String>]
 [-Location <String>] [-LogAnalyticsWorkspaceArmId <String>] [-LogAnalyticsWorkspaceId <String>]
 [-LogAnalyticsWorkspaceSharedKey <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Create1
```
New-AzSapMonitor -Name <String> -ResourceGroupName <String> -SapMonitorParameter <ISapMonitor>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateExpanded1
```
New-AzSapMonitor -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-EnableCustomerAnalytic] [-Location <String>] [-LogAnalyticsWorkspaceArmId <String>]
 [-LogAnalyticsWorkspaceId <String>] [-LogAnalyticsWorkspaceSharedKey <String>] [-MonitorSubnet <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity1
```
New-AzSapMonitor -InputObject <IHanaIdentity> -SapMonitorParameter <ISapMonitor> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded1
```
New-AzSapMonitor -InputObject <IHanaIdentity> [-EnableCustomerAnalytic] [-Location <String>]
 [-LogAnalyticsWorkspaceArmId <String>] [-LogAnalyticsWorkspaceId <String>]
 [-LogAnalyticsWorkspaceSharedKey <String>] [-MonitorSubnet <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a SAP monitor for the specified subscription, resource group, and resource name.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnableCustomerAnalytic
The value indicating whether to send analytics to Microsoft

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -HanaDbCredentialsMsiId
MSI ID passed by customer which has access to customer's KeyVault and to be assigned to the Collector VM.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -HanaDbName
Database name of the HANA instance.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -HanaDbPassword
Database password of the HANA instance.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -HanaDbPasswordKeyVaultUrl
KeyVault URL link to the password for the HANA database.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -HanaDbSqlPort
Database port of the HANA instance.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -HanaDbUsername
Database username of the HANA instance.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -HanaHostname
Hostname of the HANA instance.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -HanaSubnet
Specifies the SAP monitor unique ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Hana.Models.IHanaIdentity
Parameter Sets: CreateViaIdentity1, CreateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -KeyVaultId
Key Vault ID containing customer's HANA credentials.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Location
Resource location

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LogAnalyticsWorkspaceArmId
The ARM ID of the Log Analytics Workspace that is used for monitoring

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LogAnalyticsWorkspaceId
The workspace ID of the log analytics workspace to be used for monitoring

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LogAnalyticsWorkspaceSharedKey
The shared key of the log analytics workspace that is used for monitoring

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MonitorSubnet
The subnet which the SAP monitor will be deployed in

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
Name of the SAP monitor resource.

```yaml
Type: System.String
Parameter Sets: Create1, CreateExpanded, CreateExpanded1
Aliases: SapMonitorName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
Name of the resource group.

```yaml
Type: System.String
Parameter Sets: Create1, CreateExpanded, CreateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SapMonitorParameter
SAP monitor info on Azure (ARM properties and SAP monitor properties)
To construct, see NOTES section for SAPMONITORPARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Hana.Models.Api20200207Preview.ISapMonitor
Parameter Sets: Create1, CreateViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Subscription ID which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Create1, CreateExpanded, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Hana.Models.Api20200207Preview.ISapMonitor

### Microsoft.Azure.PowerShell.Cmdlets.Hana.Models.IHanaIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Hana.Models.Api20171103Preview.ISapMonitor

### Microsoft.Azure.PowerShell.Cmdlets.Hana.Models.Api20200207Preview.ISapMonitor

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### INPUTOBJECT <IHanaIdentity>: Identity Parameter
  - `[HanaInstanceName <String>]`: Name of the SAP HANA on Azure instance.
  - `[Id <String>]`: Resource identity path
  - `[ProviderInstanceName <String>]`: Name of the provider instance.
  - `[ResourceGroupName <String>]`: Name of the resource group.
  - `[SapMonitorName <String>]`: Name of the SAP monitor resource.
  - `[SubscriptionId <String>]`: Subscription ID which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

#### SAPMONITORPARAMETER <ISapMonitor>: SAP monitor info on Azure (ARM properties and SAP monitor properties)
  - `[Location <String>]`: The Azure Region where the resource lives
  - `[Tag <ITrackedResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[EnableCustomerAnalytic <Boolean?>]`: The value indicating whether to send analytics to Microsoft
  - `[LogAnalyticsWorkspaceArmId <String>]`: The ARM ID of the Log Analytics Workspace that is used for monitoring
  - `[LogAnalyticsWorkspaceId <String>]`: The workspace ID of the log analytics workspace to be used for monitoring
  - `[LogAnalyticsWorkspaceSharedKey <String>]`: The shared key of the log analytics workspace that is used for monitoring
  - `[MonitorSubnet <String>]`: The subnet which the SAP monitor will be deployed in

## RELATED LINKS

