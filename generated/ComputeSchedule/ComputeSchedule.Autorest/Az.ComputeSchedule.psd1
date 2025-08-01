@{
  GUID = '0b7e8529-58ce-4721-ac94-e0e474e9def5'
  RootModule = './Az.ComputeSchedule.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ComputeSchedule cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ComputeSchedule.private.dll'
  FormatsToProcess = './Az.ComputeSchedule.format.ps1xml'
  FunctionsToExport = 'Get-AzComputeScheduleOperationError', 'Get-AzComputeScheduleOperationStatus', 'Invoke-AzComputeScheduleExecuteDeallocate', 'Invoke-AzComputeScheduleExecuteHibernate', 'Invoke-AzComputeScheduleExecuteStart', 'Invoke-AzComputeScheduleSubmitDeallocate', 'Invoke-AzComputeScheduleSubmitHibernate', 'Invoke-AzComputeScheduleSubmitStart', 'Stop-AzComputeScheduleScheduledAction'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ComputeSchedule'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
