---
external help file: Az.MachineLearningServices-help.xml
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/Az.MachineLearningServices/new-AzMLWorkspaceTritonModelJobInputObject
schema: 2.0.0
---

# New-AzMLWorkspaceTritonModelJobInputObject

## SYNOPSIS
Create an in-memory object for TritonModelJobInput.

## SYNTAX

```
New-AzMLWorkspaceTritonModelJobInputObject -Uri <String> -Type <JobInputType> [-Mode <InputDeliveryMode>]
 [-Description <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for TritonModelJobInput.

## EXAMPLES

### Example 1: Create an in-memory object for TritonModelJobInput
```powershell
New-AzMLWorkspaceTritonModelJobInputObject -Type <JobInputType> -Uri <String>
```

Create an in-memory object for TritonModelJobInput

## PARAMETERS

### -Description
Description for the input.

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

### -Mode
Input Asset Delivery Mode.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.InputDeliveryMode
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
[Required] Specifies the type of job.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.JobInputType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Uri
[Required] Input Asset URI.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.TritonModelJobInput

## NOTES

## RELATED LINKS
