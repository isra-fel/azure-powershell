$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSapMonitorProviderInstance.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzSapMonitorProviderInstance' {
    It 'CreateExpandedByString' -skip {
        $hostName = 'hdb1-0'
        $sapIns = New-AzSapMonitorProviderInstance -ResourceGroupName $env.resourceGroup -Name $env.sapIns01 -SapMonitorName $env.sapMonitor02 -Type SapHana -HanaHostname $hostName -HanaDatabaseName 'SYSTEMDB' -HanaDatabaseSqlPort 30015 -HanaDatabaseUsername SYSTEM -HanaDatabasePassword (ConvertTo-SecureString "Manager1" -AsPlainText -Force)
        $sapIns.ProvisioningState | Should -Be 'Succeeded'
    }
    It 'ByKeyVault' {
        $hostName = 'hdb1-0'
        New-AzSapMonitorProviderInstance -ResourceGroupName $env.resourceGroup -Name $env.sapIns02 -SapMonitorName $env.sapMonitor02 -Type SapHana -HanaHostname $hostName -HanaDatabaseName 'SYSTEMDB' -HanaDatabaseSqlPort 30015 -HanaDatabaseUsername SYSTEM -HanaDatabasePasswordSecretId $env.hanaDbPasswordSecretId -HanaDatabasePasswordKeyVaultResourceId $env.hanaDbPasswordKvResourceId  -AsJob | Wait-Job
        $sapIns = Get-AzSapMonitorProviderInstance -ResourceGroupName $env.resourceGroup -SapMonitorName $env.sapMonitor02 -Name $env.sapIns02
        $sapIns.Name | Should -Be $env.sapIns02
    }

}
