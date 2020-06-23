## Create a VM
See https://microsoft.sharepoint.com/:w:/t/AzureManagementExperience/Eajmg9KCQMdDp-f9tAbDSV0BscCBH0CHzdsUZyPrr9N2OA?e=IAtyum
See https://developers.sap.com/tutorials/hxe-ms-azure-marketplace-getting-started.html#4284bae7-0fc9-4e74-aa4a-a04b2551d282

## Create a log analytic workspace

How to create a workspace by cmdlet?

## Create a sap monitor workspace
New-AzSapMonitor -Name yeming -ResourceGroupName yeminghana -Location southeastasia -EnableCustomerAnalytic -LogAnalyticsWorkspaceResourceId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/yeminghana/providers/Microsoft.OperationalInsights/workspaces/yeminghana -LogAnalyticsWorkspaceId 0d877a81-36aa-4fb2-a88f-d2ee5c1d78da -LogAnalyticsWorkspaceSharedKey Vbl08OhtiISsF/4w5b74IBdWDVzz1/v5XEwKrVvBZaiog7aB4isAA2+4lsDvhtZZGblFl9SYO0Py2/t5JbCgNA==

New-AzSapMonitor -Name yeming -ResourceGroupName yeminghana -Location southeastasia -EnableCustomerAnalytic -LogAnalyticsWorkspaceResourceId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/yeminghana/providers/Microsoft.OperationalInsights/workspaces/yeminghana -LogAnalyticsWorkspaceId 0d877a81-36aa-4fb2-a88f-d2ee5c1d78da -LogAnalyticsWorkspaceSharedKey Vbl08OhtiISsF/4w5b74IBdWDVzz1/v5XEwKrVvBZaiog7aB4isAA2+4lsDvhtZZGblFl9SYO0Py2/t5JbCgNA== -MonitorSubnet "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/yeminghana/providers/Microsoft.Network/virtualNetworks/yeminghana/subnets/default"

New-AzSapMonitor -Name yeming -ResourceGroupName yeminghana -Location southeastasia -EnableCustomerAnalytic -MonitorSubnet "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/yeminghana/providers/Microsoft.Network/virtualNetworks/yeminghana/subnets/default"
OK

logAnalyticsWorkspaceSharedKey can be get by a cmdlet?

az sapmonitor create --resource-group yeminghana --subscription 9e223dbe-3399-4e19-88eb-0975f02ac87f --monitor-name yemingcli --region southeastasia --hana-subnet  "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/yeminghana/providers/Microsoft.Network/virtualNetworks/yeminghana/subnets/default" --log-analytics-workspace-arm-id "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/yeminghana/providers/Microsoft.OperationalInsights/workspaces/yeminghana" --debug
OK

New-AzSapMonitor -Name yemingmonitor -ResourceGroupName nancyc-hn1 -Location westus2 -EnableCustomerAnalytic -MonitorSubnet "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/nancyc-hn1/providers/Microsoft.Network/virtualNetworks/vnet-sap/subnets/subnet-db-a" -LogAnalyticsWorkspaceSharedKey O5IXp1MjlFqACcRNRASv3SYwQTlw+wJyrZCaX230c3/8WyWpNHct84z0L/8F1NEfRsqqjIZh+yV9aOboZX6yAA== -LogAnalyticsWorkspaceId fdeceea9-46c7-424c-8d1e-808471a2ccf4 -LogAnalyticsWorkspaceResourceId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/nancyc-hn1/providers/Microsoft.OperationalInsights/workspaces/yeminglaw"
Fail


az sapmonitor create --resource-group nancyc-hn1 --subscription 9e223dbe-3399-4e19-88eb-0975f02ac87f --monitor-name yemingmonitor --region westus2 --hana-subnet  "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/nancyc-hn1/providers/Microsoft.Network/virtualNetworks/vnet-sap/subnets/subnet-db-a" --log-analytics-workspace-arm-id "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/nancyc-hn1/providers/Microsoft.OperationalInsights/workspaces/yeminglaw" --debug --hana-db-password "Manager1" --hana-hostname "hdb1-0" --hana-db-name "SYSTEMDB" --hana-db-username "SYSTEM"
Fail