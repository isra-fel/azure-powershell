## Create a VM
See https://microsoft.sharepoint.com/:w:/t/AzureManagementExperience/Eajmg9KCQMdDp-f9tAbDSV0BscCBH0CHzdsUZyPrr9N2OA?e=IAtyum

## Create a log analytic workspace

How to create a workspace by cmdlet?

## Create a sap monitor workspace
New-AzSapMonitor -Name yeming -ResourceGroupName yeminghana -Location southeastasia -EnableCustomerAnalytic -LogAnalyticsWorkspaceArmId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/yeminghana/providers/microsoft.operationalinsights/workspaces/yeminghana -LogAnalyticsWorkspaceId 0d877a81-36aa-4fb2-a88f-d2ee5c1d78da -LogAnalyticsWorkspaceSharedKey Vbl08OhtiISsF/4w5b74IBdWDVzz1/v5XEwKrVvBZaiog7aB4isAA2+4lsDvhtZZGblFl9SYO0Py2/t5JbCgNA==

New-AzSapMonitor -Name yeming -ResourceGroupName yeminghana -Location southeastasia -EnableCustomerAnalytic -LogAnalyticsWorkspaceArmId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/yeminghana/providers/microsoft.operationalinsights/workspaces/yeminghana -LogAnalyticsWorkspaceId 0d877a81-36aa-4fb2-a88f-d2ee5c1d78da -LogAnalyticsWorkspaceSharedKey Vbl08OhtiISsF/4w5b74IBdWDVzz1/v5XEwKrVvBZaiog7aB4isAA2+4lsDvhtZZGblFl9SYO0Py2/t5JbCgNA== -MonitorSubnet "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/yeminghana/providers/Microsoft.Network/virtualNetworks/yeminghana/subnets/default"

logAnalyticsWorkspaceSharedKey can be get by a cmdlet?

