## Create a VM
See https://microsoft.sharepoint.com/:w:/t/AzureManagementExperience/Eajmg9KCQMdDp-f9tAbDSV0BscCBH0CHzdsUZyPrr9N2OA?e=IAtyum

## Create a log analytic workspace

## Create a sap monitor workspace
New-AzSapMonitor -Name yeming -ResourceGroupName yemingwestus2 -Location westus2 -EnableCustomerAnalytic -LogAnalyticsWorkspaceArmId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/yemingwestus2/providers/microsoft.operationalinsights/workspaces/yeminglog -LogAnalyticsWorkspaceId 54a8072e-c6ee-4eef-b98e-9f3e05e30bad -LogAnalyticsWorkspaceSharedKey VwSfE7nkUgeO6OnbO/TQCoasIM3v2hmVBJEsdneEnSloAvnn5OJwsq7sdO3l+r92G8GSjpJ/eQxAf3SVLsMGdQ==