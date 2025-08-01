---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/get-azcomputeresourcesku
schema: 2.0.0
---

# Get-AzComputeResourceSku

## SYNOPSIS
List all compute resource Skus

## SYNTAX

```
Get-AzComputeResourceSku [[-Location] <String>] [-EdgeZone <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
List all compute resource Skus

## EXAMPLES

### Example 1
```powershell
Get-AzComputeResourceSku "westus";
```

List all compute resource skus in West US region

### Example 2
```powershell
Get-AzComputeResourceSku -Location "westus" | Where-Object {
    $_.Name -like 'Standard_A*' -and
    ([int]($_.Capabilities | Where-Object { $_.Name -eq 'vCPUs' }).Value) -le 4
} | Select-Object -ExpandProperty Name
```

```output
Standard_A0
Standard_A1
Standard_A1_v2
Standard_A2
Standard_A2m_v2
Standard_A2_v2
Standard_A3
Standard_A4m_v2
Standard_A4_v2
Standard_A5
Standard_A6
```

Get all compute resource skus in West US region, filter by name and vCPUs capability, and select the name property.

### Example 3
```powershell
$vmSizes = Get-AzComputeResourceSku -Location "WestUS" | Where-Object {
    $_.ResourceType -eq "virtualMachines" -and
    ([int]($_.Capabilities | Where-Object { $_.Name -eq "vCPUs" }).Value) -ge 4 -and
    ([int]($_.Capabilities | Where-Object { $_.Name -eq "MaxDataDiskCount" }).Value) -ge 8
}
$vmSizes.count
```

```output
812
```

Get all compute resource skus in West US region, filter by resource type, vCPUs capability, and MaxDataDiskCount capability, and count the number of results.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EdgeZone
Sets the edge zone name. If set, the query will be routed to the specified edgezone instead of the main region.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Location
Specifies a location of the available skus to list.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSResourceSku

## NOTES

## RELATED LINKS
