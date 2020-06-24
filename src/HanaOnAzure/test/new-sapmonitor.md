## Create a VM
~~See https://microsoft.sharepoint.com/:w:/t/AzureManagementExperience/Eajmg9KCQMdDp-f9tAbDSV0BscCBH0CHzdsUZyPrr9N2OA?e=IAtyum~~

~~See https://developers.sap.com/tutorials/hxe-ms-azure-marketplace-getting-started.html#4284bae7-0fc9-4e74-aa4a-a04b2551d282~~

It's very difficult to deploy a HANA instance. Please use this one for testing:

Subscription: 9e223dbe-3399-4e19-88eb-0975f02ac87f
ResourceGroup: nancyc-hn1
Location: westus2

## Create a log analytic workspace (Operational Insights workspace)

```powershell
New-AzOperationalInsightsWorkspace -ResourceGroupName nancyc-hn1 -Name yeminglaw -Location westus2
```

## Create a sap monitor and a provider instance

```powershell
New-AzSapMonitor -Name yemingmonitor -ResourceGroupName nancyc-hn1 -Location westus2 -EnableCustomerAnalytic -MonitorSubnet "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/nancyc-hn1/providers/Microsoft.Network/virtualNetworks/vnet-sap/subnets/subnet-admin" -LogAnalyticsWorkspaceSharedKey O5IXp1MjlFqACcRNRASv3SYwQTlw+wJyrZCaX230c3/8WyWpNHct84z0L/8F1NEfRsqqjIZh+yV9aOboZX6yAA== -LogAnalyticsWorkspaceId fdeceea9-46c7-424c-8d1e-808471a2ccf4 -LogAnalyticsWorkspaceResourceId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/nancyc-hn1/providers/Microsoft.OperationalInsights/workspaces/yeminglaw"

New-AzSapMonitorProviderInstance -Name "yeminginstance" -ResourceGroupName "nancyc-hn1" -SapMonitorName "yemingmonitor" -PropertiesType "SapHana" -ProviderInstanceProperty '{"hanaHostname":"hdb1-0","hanaDbName":"SYSTEMDB","hanaDbSqlPort":30015,"hanaDbUsername":"SYSTEM","hanaDbPassword":"Manager1"}'
```

1. LogAnalyticsWorkspaceSharedKey can be get by `Get-AzOperationalInsightsWorkspaceSharedKey -ResourceGroupName nancyc-hn1 -Name yeminglaw` (use PrimarySharedKey)
1. The subnet must be the subnet of the hana instance (you can navigate to the vm and see its subnet in networking properties)

## Notes

1. When writing docs, use `SAP` instead of `sap` or `Sap`; use `HANA` instead of `Hana` or `hana`.