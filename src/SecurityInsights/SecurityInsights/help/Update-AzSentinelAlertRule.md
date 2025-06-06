---
external help file: Az.SecurityInsights-help.xml
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/Update-azsentinelalertrule
schema: 2.0.0
---

# Update-AzSentinelAlertRule

## SYNOPSIS
Updates the alert rule.

## SYNTAX

### UpdateScheduled (Default)
```
Update-AzSentinelAlertRule -ResourceGroupName <String> -WorkspaceName <String> -RuleId <String>
 [-SubscriptionId <String>] [-AlertRuleTemplateName <String>] [-Enabled] [-Disabled] [-Description <String>]
 [-Query <String>] [-DisplayName <String>] [-SuppressionDuration <TimeSpan>] [-SuppressionEnabled]
 [-Severity <AlertSeverity>] [-Tactic <AttackTactic>] [-CreateIncident] [-GroupingConfigurationEnabled]
 [-ReOpenClosedIncident] [-LookbackDuration <TimeSpan>] [-MatchingMethod <String>]
 [-GroupByAlertDetail <AlertDetail[]>] [-GroupByCustomDetail <String[]>] [-GroupByEntity <EntityMappingType[]>]
 [-EntityMapping <EntityMapping[]>] [-AlertDescriptionFormat <String>] [-AlertDisplayNameFormat <String>]
 [-AlertSeverityColumnName <String>] [-AlertTacticsColumnName <String>] [-QueryFrequency <TimeSpan>]
 [-QueryPeriod <TimeSpan>] [-TriggerOperator <TriggerOperator>] [-TriggerThreshold <Int32>]
 [-EventGroupingSettingAggregationKind <EventGroupingAggregationKind>] [-DefaultProfile <PSObject>]
 [-Scheduled] [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateFusionMLTI
```
Update-AzSentinelAlertRule -ResourceGroupName <String> -WorkspaceName <String> -RuleId <String>
 [-SubscriptionId <String>] [-AlertRuleTemplateName <String>] [-Enabled] [-Disabled]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-FusionMLorTI] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateMicrosoftSecurityIncidentCreation
```
Update-AzSentinelAlertRule -ResourceGroupName <String> -WorkspaceName <String> -RuleId <String>
 [-SubscriptionId <String>] [-AlertRuleTemplateName <String>] [-Enabled] [-Disabled] [-Description <String>]
 [-DisplayNamesFilter <String[]>] [-DisplayNamesExcludeFilter <String[]>]
 [-ProductFilter <MicrosoftSecurityProductName>] [-SeveritiesFilter <AlertSeverity[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-MicrosoftSecurityIncidentCreation]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateNRT
```
Update-AzSentinelAlertRule -ResourceGroupName <String> -WorkspaceName <String> -RuleId <String>
 [-SubscriptionId <String>] [-AlertRuleTemplateName <String>] [-Enabled] [-Disabled] [-Description <String>]
 [-Query <String>] [-DisplayName <String>] [-SuppressionDuration <TimeSpan>] [-SuppressionEnabled]
 [-Severity <AlertSeverity>] [-Tactic <AttackTactic>] [-CreateIncident] [-GroupingConfigurationEnabled]
 [-ReOpenClosedIncident] [-LookbackDuration <TimeSpan>] [-MatchingMethod <String>]
 [-GroupByAlertDetail <AlertDetail[]>] [-GroupByCustomDetail <String[]>] [-GroupByEntity <EntityMappingType[]>]
 [-EntityMapping <EntityMapping[]>] [-AlertDescriptionFormat <String>] [-AlertDisplayNameFormat <String>]
 [-AlertSeverityColumnName <String>] [-AlertTacticsColumnName <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-NRT] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityFusionMLTI
```
Update-AzSentinelAlertRule -InputObject <ISecurityInsightsIdentity> [-AlertRuleTemplateName <String>]
 [-Enabled] [-Disabled] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-FusionMLorTI]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityMicrosoftSecurityIncidentCreation
```
Update-AzSentinelAlertRule -InputObject <ISecurityInsightsIdentity> [-AlertRuleTemplateName <String>]
 [-Enabled] [-Disabled] [-Description <String>] [-DisplayNamesFilter <String[]>]
 [-DisplayNamesExcludeFilter <String[]>] [-ProductFilter <MicrosoftSecurityProductName>]
 [-SeveritiesFilter <AlertSeverity[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-MicrosoftSecurityIncidentCreation] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityNRT
```
Update-AzSentinelAlertRule -InputObject <ISecurityInsightsIdentity> [-AlertRuleTemplateName <String>]
 [-Enabled] [-Disabled] [-Description <String>] [-Query <String>] [-DisplayName <String>]
 [-SuppressionDuration <TimeSpan>] [-SuppressionEnabled] [-Severity <AlertSeverity>] [-Tactic <AttackTactic>]
 [-CreateIncident] [-GroupingConfigurationEnabled] [-ReOpenClosedIncident] [-LookbackDuration <TimeSpan>]
 [-MatchingMethod <String>] [-GroupByAlertDetail <AlertDetail[]>] [-GroupByCustomDetail <String[]>]
 [-GroupByEntity <EntityMappingType[]>] [-EntityMapping <EntityMapping[]>] [-AlertDescriptionFormat <String>]
 [-AlertDisplayNameFormat <String>] [-AlertSeverityColumnName <String>] [-AlertTacticsColumnName <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-NRT] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityUpdateScheduled
```
Update-AzSentinelAlertRule -InputObject <ISecurityInsightsIdentity> [-AlertRuleTemplateName <String>]
 [-Enabled] [-Disabled] [-Description <String>] [-Query <String>] [-DisplayName <String>]
 [-SuppressionDuration <TimeSpan>] [-SuppressionEnabled] [-Severity <AlertSeverity>] [-Tactic <AttackTactic>]
 [-CreateIncident] [-GroupingConfigurationEnabled] [-ReOpenClosedIncident] [-LookbackDuration <TimeSpan>]
 [-MatchingMethod <String>] [-GroupByAlertDetail <AlertDetail[]>] [-GroupByCustomDetail <String[]>]
 [-GroupByEntity <EntityMappingType[]>] [-EntityMapping <EntityMapping[]>] [-AlertDescriptionFormat <String>]
 [-AlertDisplayNameFormat <String>] [-AlertSeverityColumnName <String>] [-AlertTacticsColumnName <String>]
 [-QueryFrequency <TimeSpan>] [-QueryPeriod <TimeSpan>] [-TriggerOperator <TriggerOperator>]
 [-TriggerThreshold <Int32>] [-EventGroupingSettingAggregationKind <EventGroupingAggregationKind>]
 [-DefaultProfile <PSObject>] [-Scheduled] [-AsJob] [-NoWait] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates the alert rule.

## EXAMPLES

### Example 1: Update an scheduled alert rule
```powershell
Update-AzSentinelAlertRule -ResourceGroupName "myResourceGroupName" -WorkspaceName "myWorkspaceName" -ruleId "4a21e485-75ae-48b3-a7b9-e6a92bcfe434" -Query "SecurityAlert | take 2"
```

This command updates a scheduled alert rule

## PARAMETERS

### -AlertDescriptionFormat

```yaml
Type: System.String
Parameter Sets: UpdateScheduled, UpdateNRT, UpdateViaIdentityNRT, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AlertDisplayNameFormat

```yaml
Type: System.String
Parameter Sets: UpdateScheduled, UpdateNRT, UpdateViaIdentityNRT, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AlertRuleTemplateName

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AlertSeverityColumnName

```yaml
Type: System.String
Parameter Sets: UpdateScheduled, UpdateNRT, UpdateViaIdentityNRT, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AlertTacticsColumnName

```yaml
Type: System.String
Parameter Sets: UpdateScheduled, UpdateNRT, UpdateViaIdentityNRT, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
```

### -CreateIncident

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateScheduled, UpdateNRT, UpdateViaIdentityNRT, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -Description

```yaml
Type: System.String
Parameter Sets: UpdateScheduled, UpdateMicrosoftSecurityIncidentCreation, UpdateNRT, UpdateViaIdentityMicrosoftSecurityIncidentCreation, UpdateViaIdentityNRT, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Disabled

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName

```yaml
Type: System.String
Parameter Sets: UpdateScheduled, UpdateNRT, UpdateViaIdentityNRT, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayNamesExcludeFilter

```yaml
Type: System.String[]
Parameter Sets: UpdateMicrosoftSecurityIncidentCreation, UpdateViaIdentityMicrosoftSecurityIncidentCreation
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayNamesFilter

```yaml
Type: System.String[]
Parameter Sets: UpdateMicrosoftSecurityIncidentCreation, UpdateViaIdentityMicrosoftSecurityIncidentCreation
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Enabled

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EntityMapping
'Account', 'Host', 'IP', 'Malware', 'File', 'Process', 'CloudApplication', 'DNS', 'AzureResource', 'FileHash', 'RegistryKey', 'RegistryValue', 'SecurityGroup', 'URL', 'Mailbox', 'MailCluster', 'MailMessage', 'SubmissionMail'
To construct, see NOTES section for ENTITYMAPPING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.EntityMapping[]
Parameter Sets: UpdateScheduled, UpdateNRT, UpdateViaIdentityNRT, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventGroupingSettingAggregationKind

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.EventGroupingAggregationKind
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FusionMLorTI

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateFusionMLTI, UpdateViaIdentityFusionMLTI
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupByAlertDetail

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AlertDetail[]
Parameter Sets: UpdateScheduled, UpdateNRT, UpdateViaIdentityNRT, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupByCustomDetail

```yaml
Type: System.String[]
Parameter Sets: UpdateScheduled, UpdateNRT, UpdateViaIdentityNRT, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupByEntity

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.EntityMappingType[]
Parameter Sets: UpdateScheduled, UpdateNRT, UpdateViaIdentityNRT, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupingConfigurationEnabled

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateScheduled, UpdateNRT, UpdateViaIdentityNRT, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity
Parameter Sets: UpdateViaIdentityFusionMLTI, UpdateViaIdentityMicrosoftSecurityIncidentCreation, UpdateViaIdentityNRT, UpdateViaIdentityUpdateScheduled
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LookbackDuration

```yaml
Type: System.TimeSpan
Parameter Sets: UpdateScheduled, UpdateNRT, UpdateViaIdentityNRT, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: New-TimeSpan -Hours 5
Accept pipeline input: False
Accept wildcard characters: False
```

### -MatchingMethod

```yaml
Type: System.String
Parameter Sets: UpdateScheduled, UpdateNRT, UpdateViaIdentityNRT, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: "AllEntities"
Accept pipeline input: False
Accept wildcard characters: False
```

### -MicrosoftSecurityIncidentCreation

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateMicrosoftSecurityIncidentCreation, UpdateViaIdentityMicrosoftSecurityIncidentCreation
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -NRT

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateNRT, UpdateViaIdentityNRT
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProductFilter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.MicrosoftSecurityProductName
Parameter Sets: UpdateMicrosoftSecurityIncidentCreation, UpdateViaIdentityMicrosoftSecurityIncidentCreation
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Query

```yaml
Type: System.String
Parameter Sets: UpdateScheduled, UpdateNRT, UpdateViaIdentityNRT, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -QueryFrequency

```yaml
Type: System.TimeSpan
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -QueryPeriod

```yaml
Type: System.TimeSpan
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReOpenClosedIncident

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateScheduled, UpdateNRT, UpdateViaIdentityNRT, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The Resource Group Name.

```yaml
Type: System.String
Parameter Sets: UpdateScheduled, UpdateFusionMLTI, UpdateMicrosoftSecurityIncidentCreation, UpdateNRT
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RuleId
[Alias('RuleId')]
 The name of Operational Insights Resource Provider.

```yaml
Type: System.String
Parameter Sets: UpdateScheduled, UpdateFusionMLTI, UpdateMicrosoftSecurityIncidentCreation, UpdateNRT
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scheduled

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SeveritiesFilter
High, Medium, Low, Informational

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AlertSeverity[]
Parameter Sets: UpdateMicrosoftSecurityIncidentCreation, UpdateViaIdentityMicrosoftSecurityIncidentCreation
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Severity

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AlertSeverity
Parameter Sets: UpdateScheduled, UpdateNRT, UpdateViaIdentityNRT, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: UpdateScheduled, UpdateFusionMLTI, UpdateMicrosoftSecurityIncidentCreation, UpdateNRT
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -SuppressionDuration

```yaml
Type: System.TimeSpan
Parameter Sets: UpdateScheduled, UpdateNRT, UpdateViaIdentityNRT, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: New-TimeSpan -Hours 5
Accept pipeline input: False
Accept wildcard characters: False
```

### -SuppressionEnabled

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateScheduled, UpdateNRT, UpdateViaIdentityNRT, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tactic

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AttackTactic
Parameter Sets: UpdateScheduled, UpdateNRT, UpdateViaIdentityNRT, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TriggerOperator

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.TriggerOperator
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TriggerThreshold

```yaml
Type: System.Int32
Parameter Sets: UpdateScheduled, UpdateViaIdentityUpdateScheduled
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
The name of the workspace.

```yaml
Type: System.String
Parameter Sets: UpdateScheduled, UpdateFusionMLTI, UpdateMicrosoftSecurityIncidentCreation, UpdateNRT
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.AlertRule

## NOTES

## RELATED LINKS
