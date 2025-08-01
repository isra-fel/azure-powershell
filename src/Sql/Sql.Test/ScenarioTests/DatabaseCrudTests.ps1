﻿# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
	.SYNOPSIS
	Tests creating a database
#>
function Test-CreateDatabase
{
	Test-CreateDatabaseInternal "eastus"
}

<#
	.SYNOPSIS
	Tests creating a database
#>
function Test-CreateDatabaseInternal ($location = "eastus")
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location

	try
	{
		Write-Debug "Create with default values"
		$databaseName = Get-DatabaseName
		$job1 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -AsJob -Force
		$job1 | Wait-Job
		$db = $job1.Output

		Assert-AreEqual $databaseName $db.DatabaseName
		Assert-NotNull $db.MaxSizeBytes
		Assert-NotNull $db.Edition
		Assert-NotNull $db.CurrentServiceObjectiveName
		Assert-NotNull $db.CollationName

		Write-Debug "Create with default values via piping"
		$databaseName = Get-DatabaseName
		$db = $server | New-AzSqlDatabase -DatabaseName $databaseName -Force
		Assert-AreEqual $db.DatabaseName $databaseName
		Assert-NotNull $db.MaxSizeBytes
		Assert-NotNull $db.Edition
		Assert-NotNull $db.CurrentServiceObjectiveName
		Assert-NotNull $db.CollationName

		Write-Debug "Create data warehouse database with all parameters."
		$databaseName = Get-DatabaseName
		$collationName = "SQL_Latin1_General_CP1_CI_AS"
		$maxSizeBytes = 250GB
		$job2 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
				-CollationName $collationName -MaxSizeBytes $maxSizeBytes -Edition DataWarehouse -RequestedServiceObjectiveName DW100c -AsJob -Force
		$job2 | Wait-Job
		$dwdb  = $job2.Output

		Write-Debug (ConvertTo-Json $job2)

		Assert-AreEqual $dwdb.DatabaseName $databaseName
		Assert-AreEqual $dwdb.MaxSizeBytes $maxSizeBytes
		Assert-AreEqual $dwdb.Edition DataWarehouse
		Assert-AreEqual $dwdb.CurrentServiceObjectiveName DW100c
		Assert-AreEqual $dwdb.CollationName $collationName

		Write-Debug "Create with all parameters"
		$databaseName = Get-DatabaseName
		$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
			-CollationName "Japanese_Bushu_Kakusu_100_CS_AS" -MaxSizeBytes 1GB -Edition Basic -RequestedServiceObjectiveName Basic -Tags @{"tag_key"="tag_value"} -Force

		Assert-AreEqual $db.DatabaseName $databaseName
		Assert-AreEqual $db.MaxSizeBytes 1GB
		Assert-AreEqual $db.Edition Basic
		Assert-AreEqual $db.CurrentServiceObjectiveName Basic
		Assert-AreEqual $db.CollationName "Japanese_Bushu_Kakusu_100_CS_AS"
		Assert-NotNull $db.Tags
		Assert-AreEqual True $db.Tags.ContainsKey("tag_key")
		Assert-AreEqual "tag_value" $db.Tags["tag_key"]

		Write-Debug "Create with all parameters"
		$databaseName = Get-DatabaseName
		$db = $server | New-AzSqlDatabase -DatabaseName $databaseName `
			-CollationName "Japanese_Bushu_Kakusu_100_CS_AS" -MaxSizeBytes 1GB -Edition Basic -RequestedServiceObjectiveName Basic -Tags @{"tag_key"="tag_value"} -Force

		Assert-AreEqual $db.DatabaseName $databaseName
		Assert-AreEqual $db.MaxSizeBytes 1GB
		Assert-AreEqual $db.Edition Basic
		Assert-AreEqual $db.CurrentServiceObjectiveName Basic
		Assert-AreEqual $db.CollationName "Japanese_Bushu_Kakusu_100_CS_AS"
		Assert-NotNull $db.Tags
		Assert-AreEqual True $db.Tags.ContainsKey("tag_key")
		Assert-AreEqual "tag_value" $db.Tags["tag_key"]
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests creating a Vcore based database
#>
function Test-CreateVcoreDatabase
{
	# Setup
	$location = "eastus2euap"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location

	try
	{
		# Create with Edition and RequestedServiceObjectiveName
		$databaseName = Get-DatabaseName
		$job1 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -RequestedServiceObjectiveName GP_Gen5_2 -Edition GeneralPurpose -AsJob -Force
		$job1 | Wait-Job
		$db = $job1.Output

		Write-Debug (ConvertTo-Json $job1)

		Assert-AreEqual $databaseName $db.DatabaseName
		Assert-NotNull $db.MaxSizeBytes
		Assert-AreEqual GP_Gen5_2 $db.CurrentServiceObjectiveName
		Assert-AreEqual 2 $db.Capacity
		Assert-AreEqual GeneralPurpose $db.Edition

		# Create with VCore parameter set
		$databaseName = Get-DatabaseName
		$job1 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -VCore 2 -ComputeGeneration Gen5 -Edition GeneralPurpose -AsJob -Force
		$job1 | Wait-Job
		$db = $job1.Output

		Assert-AreEqual $databaseName $db.DatabaseName
		Assert-NotNull $db.MaxSizeBytes
		Assert-AreEqual GP_Gen5_2 $db.CurrentServiceObjectiveName
		Assert-AreEqual 2 $db.Capacity
		Assert-AreEqual GeneralPurpose $db.Edition
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests creating a database with license type.
#>
function Test-CreateVcoreDatabaseWithLicenseType
{
	# Setup
	$location = "eastus"
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location

	try
	{
		# Create with Edition and RequestedServiceObjectiveName - Base Price
		$databaseName = Get-DatabaseName
		$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -RequestedServiceObjectiveName GP_Gen5_2 -Edition GeneralPurpose -LicenseType BasePrice -Force
		Assert-AreEqual BasePrice $db.LicenseType

		# Create with Edition and RequestedServiceObjectiveName - LicenseIncluded
		$databaseName = Get-DatabaseName
		$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -RequestedServiceObjectiveName GP_Gen5_2 -Edition GeneralPurpose -LicenseType LicenseIncluded -Force
		Assert-AreEqual LicenseIncluded $db.LicenseType

		# Create with VCore parameter set - BasePrice
		$databaseName = Get-DatabaseName
		$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -VCore 2 -ComputeGeneration Gen5 -Edition GeneralPurpose -LicenseType BasePrice -Force
		Assert-AreEqual BasePrice $db.LicenseType

		# Create with VCore parameter set - LicenseIncluded
		$databaseName = Get-DatabaseName
		$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -VCore 2 -ComputeGeneration Gen5 -Edition GeneralPurpose -LicenseType LicenseIncluded -Force
		Assert-AreEqual LicenseIncluded $db.LicenseType
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests creating a Serverless based database
#>
function Test-CreateServerlessDatabase
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "operations" "East US"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location

	try
	{
		# Create with Edition and RequestedServiceObjectiveName
		$databaseName = Get-DatabaseName
		$job1 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -RequestedServiceObjectiveName GP_S_Gen5_2 -AutoPauseDelayInMinutes 360 -MinVCore 0.5 -AsJob
		$job1 | Wait-Job
		$db = $job1.Output

		Assert-AreEqual $databaseName $db.DatabaseName
		Assert-NotNull $db.MaxSizeBytes
		Assert-AreEqual GP_S_Gen5_2 $db.CurrentServiceObjectiveName
		Assert-AreEqual 2 $db.Capacity
		Assert-AreEqual 360 $db.AutoPauseDelayInMinutes
		Assert-AreEqual 0.5 $db.MinimumCapacity
		Assert-AreEqual GeneralPurpose $db.Edition
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests creating a database with sample name.
#>
function Test-CreateDatabaseWithSampleName
{
	# Setup
	$location = "eastus"
	$rg = Create-ResourceGroupForTest
	try
	{
		$server = Create-ServerForTest $rg $location

		# Create with samplename
		$databaseName = Get-DatabaseName
		$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
			-DatabaseName $databaseName -SampleName "AdventureWorksLT" -RequestedServiceObjectiveName Basic `
			-Tags @{"tag_key"="tag_value"} -Force
		Assert-AreEqual $db.DatabaseName $databaseName
		Assert-AreEqual $db.CurrentServiceObjectiveName Basic
		Assert-NotNull $db.MaxSizeBytes
		Assert-NotNull $db.Edition
		Assert-NotNull $db.CurrentServiceObjectiveName
		Assert-NotNull $db.CollationName
		Assert-NotNull $db.Tags
		Assert-AreEqual True $db.Tags.ContainsKey("tag_key")
		Assert-AreEqual "tag_value" $db.Tags["tag_key"]
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests creating a database with zone redundancy.
#>
function Test-CreateDatabaseWithZoneRedundancy
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "operations" "East US"
	$rg = Create-ResourceGroupForTest $location
	try
	{
		$server = Create-ServerForTest $rg $location

		# Create database with no zone redundancy set
		$databaseName = Get-DatabaseName
		$job = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
			-DatabaseName $databaseName -Edition Premium -AsJob -Force
		$job | Wait-Job
		$db = $job.Output

		Assert-AreEqual $db.DatabaseName $databaseName
		Assert-NotNull $db.Edition
		Assert-NotNull $db.ZoneRedundant
		Assert-AreEqual "false" $db.ZoneRedundant

		# Create database with zone redundancy true
		$databaseName = Get-DatabaseName
		$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
			-DatabaseName $databaseName -Edition Premium -ZoneRedundant -Force
		Assert-AreEqual $db.DatabaseName $databaseName
		Assert-NotNull $db.Edition
		Assert-NotNull $db.ZoneRedundant
		Assert-AreEqual "true" $db.ZoneRedundant

		# Create database with zone redundancy false
		$databaseName = Get-DatabaseName
		$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
			-DatabaseName $databaseName -Edition Premium -ZoneRedundant:$false -Force
		Assert-AreEqual $db.DatabaseName $databaseName
		Assert-NotNull $db.Edition
		Assert-NotNull $db.ZoneRedundant
		Assert-AreEqual "false" $db.ZoneRedundant
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests creating a database with maintenance.
#>
function Test-CreateDatabaseWithMaintenanceConfigurationId
{
	# Setup
	# Further actions required if you use Microsoft internal subscription. Please contact feature owners
	$location = Get-Location "Microsoft.Sql" "operations" "East US"
	$rg = Create-ResourceGroupForTest $location

	try
	{
		$server = Create-ServerForTest $rg $location

		# Create database with default maintenance
		$databaseName = Get-DatabaseName
		$mId = Get-DefaultPublicMaintenanceConfigurationId $location
        $serverResourceId = "/subscriptions/${subscriptionId}/resourceGroups/${rgname}/providers/Microsoft.Sql/servers/${serverName}"
		$job = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
			-DatabaseName $databaseName -Edition Premium -MaintenanceConfigurationId $mId -AsJob -Force
		$job | Wait-Job
		$db = $job.Output

		Assert-AreEqual $db.DatabaseName $databaseName
		Assert-NotNull $db.Edition
		Assert-NotNull $db.MaintenanceConfigurationId
		Assert-AreEqual $mId.ToLower() $db.MaintenanceConfigurationId.ToLower()

		# Create database with non-default maintenance
		$databaseName = Get-DatabaseName
		$mId = Get-PublicMaintenanceConfigurationId $location "DB_1"
		$mName = Get-PublicMaintenanceConfigurationName $location "DB_1"
		$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
			-DatabaseName $databaseName -Edition Premium -MaintenanceConfigurationId $mName -Force
		Assert-AreEqual $db.DatabaseName $databaseName
		Assert-NotNull $db.Edition
		Assert-NotNull $db.MaintenanceConfigurationId
		Assert-AreEqual $mId.ToLower() $db.MaintenanceConfigurationId.ToLower()
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests creating a database with Backup Storage Redundancy
#>
function Test-CreateDatabaseWithBackupStorageRedundancy
{
	# Setup
	$location = "eastus"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location

	try
	{
		$databaseName = Get-DatabaseName
		$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
			-DatabaseName $databaseName -BackupStorageRedundancy "Local"
		Assert-AreEqual $db.DatabaseName $databaseName
		Assert-NotNull $db.CurrentBackupStorageRedundancy
		Assert-AreEqual $db.RequestedBackupStorageRedundancy "Local"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests creating a database with GeoZone as the Backup Storage Redundancy
#>
function Test-CreateDatabaseWithGeoZoneBackupStorageRedundancy
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "operations" "East US"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location

	try
	{
		$databaseName = Get-DatabaseName
		$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
			-DatabaseName $databaseName -BackupStorageRedundancy "GeoZone" -Edition HyperScale -VCore 2 -ComputeGeneration Gen5
		Assert-AreEqual $db.DatabaseName $databaseName
		Assert-AreEqual $db.Edition "Hyperscale"
		Assert-NotNull $db.CurrentBackupStorageRedundancy
		Assert-AreEqual $db.RequestedBackupStorageRedundancy "GeoZone"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests creating a database with preferred enclave type.
#>
function Test-CreateDatabaseWithPreferredEnclaveType
{
	# Setup
	$location = "eastus2euap"
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location

	try
	{
		# Create database with PreferredEnclaveType as Default
		$databaseName = Get-DatabaseName
		$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -RequestedServiceObjectiveName GP_Gen5_2 -Edition GeneralPurpose -PreferredEnclaveType Default -Force
		Assert-AreEqual Default $db.PreferredEnclaveType

		# Create database with PreferredEnclaveType as VBS
		$databaseName = Get-DatabaseName
		$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -RequestedServiceObjectiveName GP_Gen5_2 -Edition GeneralPurpose -PreferredEnclaveType VBS -Force
		Assert-AreEqual VBS $db.PreferredEnclaveType

		# Create database with VCore parameter along with PreferredEnclaveType as Default
		$databaseName = Get-DatabaseName
		$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -VCore 2 -ComputeGeneration Gen5 -Edition GeneralPurpose -PreferredEnclaveType Default -Force
		Assert-AreEqual Default $db.PreferredEnclaveType

		# Create database with VCore parameter along with PreferredEnclaveType as VBS
		$databaseName = Get-DatabaseName
		$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -VCore 2 -ComputeGeneration Gen5 -Edition GeneralPurpose -PreferredEnclaveType VBS -Force
		Assert-AreEqual VBS $db.PreferredEnclaveType
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Test-FreeLimitDatabaseCreate
{
	#Setup 
	$location = "eastus2euap"
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location

	try
	{
		$databaseName = Get-DatabaseName
		$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -RequestedServiceObjectiveName GP_S_Gen5_2 -Edition GeneralPurpose -UseFreeLimit -FreeLimitExhaustionBehavior AutoPause
		Assert-AreEqual true $db.UseFreeLimit
		Assert-AreEqual AutoPause $db.FreeLimitExhaustionBehavior
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Test-FreeLimitDatabaseUpdateFreeLimitExhaustionBehavior
{
	#Setup 
	$location = "eastus"
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location

	$databaseName = Get-DatabaseName 

	$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
		-RequestedServiceObjectiveName GP_S_Gen5_2 -Edition GeneralPurpose -UseFreeLimit -FreeLimitExhaustionBehavior AutoPause
	Assert-AreEqual $db.DatabaseName $databaseName

	try
	{
		$job = Set-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -FreeLimitExhaustionBehavior BillOverUsage -AsJob
		$job | Wait-Job
		$db1 = $job.Output

		Assert-AreEqual true $db1.UseFreeLimit
		Assert-AreEqual BillOverUsage $db1.FreeLimitExhaustionBehavior
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests updating a database
#>
function Test-UpdateDatabase
{
	Test-UpdateDatabaseInternal "eastus"
}

<#
	.SYNOPSIS
	Tests updating a database
#>
function Test-UpdateDatabaseInternal ($location = "eastus")
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location

	$databaseName = Get-DatabaseName
	$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
		-Edition Standard -MaxSizeBytes 250GB -RequestedServiceObjectiveName S0 -Force
	Assert-AreEqual $db.DatabaseName $databaseName

	# Database will be Standard s0 with maxsize: 268435456000 (250GB)

	try
	{
		# Alter all properties
		$job = Set-AzSqlDatabase -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName `
			-MaxSizeBytes 1GB -Edition Basic -RequestedServiceObjectiveName Basic -Tags @{"tag_key"="tag_new_value"} -AsJob
		$job | Wait-Job
		$db1 = $job.Output

		Assert-AreEqual $db1.DatabaseName $db.DatabaseName
		Assert-AreEqual $db1.MaxSizeBytes 1GB
		Assert-AreEqual $db1.Edition Basic
		Assert-AreEqual $db1.CurrentServiceObjectiveName Basic
		Assert-AreEqual $db1.CollationName $db.CollationName
		Assert-NotNull $db1.Tags
		Assert-AreEqual True $db1.Tags.ContainsKey("tag_key")
		Assert-AreEqual "tag_new_value" $db1.Tags["tag_key"]

		# Alter all properties using piping
		$db2 = $db1 | Set-AzSqlDatabase -MaxSizeBytes 100GB -Edition Standard -RequestedServiceObjectiveName S1 -Tags @{"tag_key"="tag_new_value2"}
		Assert-AreEqual $db2.DatabaseName $db.DatabaseName
		Assert-AreEqual $db2.MaxSizeBytes 100GB
		Assert-AreEqual $db2.Edition Standard
		Assert-AreEqual $db2.CurrentServiceObjectiveName S1
		Assert-AreEqual $db2.CollationName $db.CollationName
		Assert-NotNull $db2.Tags
		Assert-AreEqual True $db2.Tags.ContainsKey("tag_key")
		Assert-AreEqual "tag_new_value2" $db2.Tags["tag_key"]

		# Create and alter data warehouse database.
		$databaseName = Get-DatabaseName
		$collationName = "SQL_Latin1_General_CP1_CI_AS"
		$maxSizeBytes = 250GB
		$dwdb = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
		-CollationName $collationName -MaxSizeBytes $maxSizeBytes -Edition DataWarehouse -RequestedServiceObjectiveName DW100c -Force

		$job = Set-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $dwdb.DatabaseName `
				-MaxSizeBytes $maxSizeBytes -RequestedServiceObjectiveName DW200c -Edition DataWarehouse -AsJob
		$job | Wait-Job
		$dwdb2 = $job.Output

		Assert-AreEqual $dwdb2.DatabaseName $dwdb.DatabaseName
		Assert-AreEqual $dwdb2.MaxSizeBytes $maxSizeBytes
		Assert-AreEqual $dwdb2.Edition DataWarehouse
		Assert-AreEqual $dwdb2.CurrentServiceObjectiveName DW200c
		Assert-AreEqual $dwdb2.CollationName $collationName
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests updating a vcore database
#>
function Test-UpdateVcoreDatabase()
{
	# Setup
	$location = "eastus"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location

	$databaseName = Get-DatabaseName
	$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
		-VCore 2 -Edition GeneralPurpose -ComputeGeneration Gen5 -MaxSizeBytes 250GB -Force
	Assert-AreEqual $db.DatabaseName $databaseName

	try
	{
		# Alter with defaults
		$job = Set-AzSqlDatabase -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName `
			 -AsJob
		$job | Wait-Job
		$db1 = $job.Output

		Assert-AreEqual $db1.DatabaseName $db.DatabaseName
		Assert-NotNull $db1.MaxSizeBytes
		Assert-NotNull $db1.Edition
		Assert-NotNull $db1.CurrentServiceObjectiveName

		# Alter with all properties
		$job = Set-AzSqlDatabase -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName `
			-MaxSizeBytes 5GB -VCore 2 -Edition GeneralPurpose -ComputeGeneration Gen5 -Tags @{"tag_key"="tag_new_value"} -AsJob
		$job | Wait-Job
		$db1 = $job.Output

		Assert-AreEqual $db1.DatabaseName $db.DatabaseName
		Assert-AreEqual $db1.MaxSizeBytes 5GB
		Assert-AreEqual $db1.Edition GeneralPurpose
		Assert-AreEqual $db1.CurrentServiceObjectiveName GP_Gen5_2
		Assert-AreEqual $db1.CollationName $db.CollationName
		Assert-NotNull $db1.Tags
		Assert-AreEqual True $db1.Tags.ContainsKey("tag_key")
		Assert-AreEqual "tag_new_value" $db1.Tags["tag_key"]

		# Alter Edition only (can't only specify -Edition since Edition is shared parameter in two difference parameter sets)
		$job = Set-AzSqlDatabase -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName `
			-Edition BusinessCritical -ComputeGeneration Gen5 -AsJob
		$job | Wait-Job
		$db1 = $job.Output
		Assert-AreEqual $db1.DatabaseName $db.DatabaseName
		Assert-AreEqual $db1.Edition BusinessCritical
		Assert-AreEqual $db1.CurrentServiceObjectiveName BC_Gen5_2

		# Alter Vcore only
		$job = Set-AzSqlDatabase -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName `
			-VCore 2 -AsJob
		$job | Wait-Job
		$db1 = $job.Output
		Assert-AreEqual $db1.DatabaseName $db.DatabaseName
		Assert-AreEqual $db1.Edition BusinessCritical
		Assert-AreEqual $db1.CurrentServiceObjectiveName BC_Gen5_2

		# Alter with Dtu based parameters (-Edition and -RequestedServiceObjectiveName)
		$job = Set-AzSqlDatabase -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName `
			-Edition GeneralPurpose -RequestedServiceObjectiveName GP_Gen5_2 -AsJob
		$job | Wait-Job
		$db1 = $job.Output
		Assert-AreEqual $db1.DatabaseName $db.DatabaseName
		Assert-AreEqual $db1.Edition GeneralPurpose
		Assert-AreEqual $db1.CurrentServiceObjectiveName GP_Gen5_2

		# Alter ComputeGeneration only
		# Need to add later, currently the service not support other Generations besides Gen4
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests updating a vcore database license type
#>
function Test-UpdateVcoreDatabaseLicenseType()
{
	# Setup
	$location = "eastus"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location

	# Create vcore database
	$databaseName = Get-DatabaseName
	$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -RequestedServiceObjectiveName GP_Gen5_2 -Edition GeneralPurpose -Force
	Assert-AreEqual $db.DatabaseName $databaseName
	Assert-AreEqual $db.LicenseType LicenseIncluded # Default license type

	try
	{
		# Alter with license type - License Included
		$db1 = Set-AzSqlDatabase -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName -LicenseType LicenseIncluded
		Assert-AreEqual LicenseIncluded $db1.LicenseType

		# Alter with license type - Base Price
		$db1 = Set-AzSqlDatabase -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName -LicenseType BasePrice
		Assert-AreEqual BasePrice $db1.LicenseType

		# Test piping - LicenseIncluded
		$db1 = $db1 | Set-AzSqlDatabase -LicenseType LicenseIncluded
		Assert-AreEqual LicenseIncluded $db1.LicenseType

		# Test piping - BasePrice
		$db1 = $db1 | Set-AzSqlDatabase -LicenseType BasePrice
		Assert-AreEqual BasePrice $db1.LicenseType
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests updating a database with zone redundancy
#>
function Test-UpdateDatabaseWithZoneRedundant ()
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "operations" "East US"
	Write-Debug $location
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location

	$databaseName = Get-DatabaseName
	$db1 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
		-Edition Premium -Force
	Assert-AreEqual $db1.DatabaseName $databaseName
	Assert-NotNull $db1.ZoneRedundant
	Assert-AreEqual "false" $db1.ZoneRedundant

	$databaseName = Get-DatabaseName
	$db2 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
		-Edition Premium -ZoneRedundant -Force
	Assert-AreEqual $db2.DatabaseName $databaseName
	Assert-NotNull $db2.ZoneRedundant
	Assert-AreEqual "true" $db2.ZoneRedundant

	try
	{
		# Alter database with zone redundancy to true
		$sdb1 = Set-AzSqlDatabase -ResourceGroupName $db1.ResourceGroupName -ServerName $db1.ServerName -DatabaseName $db1.DatabaseName `
			-ZoneRedundant
		Assert-AreEqual $sdb1.DatabaseName $db1.DatabaseName
		Assert-NotNull $sdb1.ZoneRedundant
		Assert-AreEqual "true" $sdb1.ZoneRedundant

		# Alter database with zone redundancy to false
		$sdb2 = Set-AzSqlDatabase -ResourceGroupName $db2.ResourceGroupName -ServerName $db2.ServerName -DatabaseName $db2.DatabaseName `
			-ZoneRedundant:$false
		Assert-AreEqual $sdb2.DatabaseName $db2.DatabaseName
		Assert-NotNull $sdb2.ZoneRedundant
		Assert-AreEqual "false" $sdb2.ZoneRedundant
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests updating a database with maintenance
#>
function Test-UpdateDatabaseWithMaintenanceConfigurationId
{
	# Setup
	# Further actions required if you use Microsoft internal subscription. Please contact feature owners
	$location = Get-Location "Microsoft.Sql" "operations" "East US"
	$rg = Create-ResourceGroupForTest $location	

	try
	{
		$server = Create-ServerForTest $rg $location

		# Create database without specifying maintenance
		$defaultMId = Get-DefaultPublicMaintenanceConfigurationId $location
		$databaseName = Get-DatabaseName
		$db1 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
			-Edition Premium -Force
		Assert-AreEqual $db1.DatabaseName $databaseName
		Assert-NotNull $db1.MaintenanceConfigurationId
		Assert-AreEqual $defaultMId.ToLower() $db1.MaintenanceConfigurationId.ToLower()

		# Alter database maintenance
		$mId = Get-PublicMaintenanceConfigurationId $location "DB_1"
		$mName = Get-PublicMaintenanceConfigurationName $location "DB_1"
		$sdb1 = Set-AzSqlDatabase -ResourceGroupName $db1.ResourceGroupName -ServerName $db1.ServerName -DatabaseName $db1.DatabaseName `
			-MaintenanceConfigurationId $mName

		Assert-AreEqual $sdb1.DatabaseName $databaseName
		Assert-NotNull $sdb1.MaintenanceConfigurationId
		Assert-AreEqual $mId.ToLower() $sdb1.MaintenanceConfigurationId.ToLower()
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests updating a database with preferred enclave type
#>
function Test-UpdateDatabaseWithPreferredEnclaveType()
{
	# Setup
	$location = "uksouth"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location

	# Create vcore database
	$databaseName = Get-DatabaseName
	$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -RequestedServiceObjectiveName GP_Gen5_2 -Edition GeneralPurpose -PreferredEnclaveType Default -Force
	Assert-AreEqual $databaseName $db.DatabaseName
	Assert-AreEqual Default $db.PreferredEnclaveType

	try
	{
		# Alter with preferred enclave type - VBS
		$db1 = Set-AzSqlDatabase -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName -PreferredEnclaveType VBS
		Assert-AreEqual VBS $db1.PreferredEnclaveType

		# Test piping - Default PreferredEnclaveType
		$db1 = $db1 | Set-AzSqlDatabase -PreferredEnclaveType Default
		Assert-AreEqual Default $db1.PreferredEnclaveType

		# Test piping - VBS PreferredEnclaveType
		$db1 = $db1 | Set-AzSqlDatabase -PreferredEnclaveType VBS
		Assert-AreEqual VBS $db1.PreferredEnclaveType
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests updating a vcore database
#>
function Test-UpdateServerlessDatabase()
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "operations" "East US"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location

	$databaseName = Get-DatabaseName
	$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
		-VCore 2 -Edition GeneralPurpose -ComputeGeneration Gen5 -MaxSizeBytes 250GB -ComputeModel Serverless
	Assert-AreEqual $db.DatabaseName $databaseName

	try
	{
		# Alter with defaults
		$job = Set-AzSqlDatabase -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName `
			 -AsJob
		$job | Wait-Job
		$db1 = $job.Output

		Assert-AreEqual $db1.DatabaseName $db.DatabaseName
		Assert-NotNull $db1.MaxSizeBytes
		Assert-NotNull $db1.Edition
		Assert-NotNull $db1.CurrentServiceObjectiveName
		Assert-NotNull $db1.MinimumCapacity
		Assert-NotNull $db1.AutoPauseDelayInMinutes

		# Alter to dtu database
		$job = Set-AzSqlDatabase -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName `
			-Edition Premium -AsJob
		$job | Wait-Job
		$db1 = $job.Output
		Assert-AreEqual $db1.DatabaseName $db.DatabaseName
		Assert-AreEqual $db1.Edition Premium
		Assert-Null $db1.MinimumCapacity
		Assert-Null $db1.AutoPauseDelayInMinutes

		# Alter back to Serverless
		$job = Set-AzSqlDatabase -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName `
			-VCore 2 -Edition GeneralPurpose -ComputeModel Serverless -ComputeGeneration Gen5 -AsJob
		$job | Wait-Job
		$db1 = $job.Output
		Assert-AreEqual $db1.DatabaseName $db.DatabaseName
		Assert-AreEqual $db1.Edition GeneralPurpose
		Assert-AreEqual $db1.CurrentServiceObjectiveName GP_S_Gen5_2
		Assert-NotNull $db1.MinimumCapacity
		Assert-NotNull $db1.AutoPauseDelayInMinutes

		# Alter mincapacity and AutoPauseDelayInMinutes
		$job = Set-AzSqlDatabase -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName `
			-Vcore 2 -Edition GeneralPurpose -ComputeModel Serverless -ComputeGeneration Gen5 -MinimumCapacity 2 -AutoPauseDelayInMinutes 1440 -AsJob
		$job | Wait-Job
		$db1 = $job.Output
		Assert-AreEqual $db1.DatabaseName $db.DatabaseName
		Assert-AreEqual $db1.Edition GeneralPurpose
		Assert-AreEqual $db1.CurrentServiceObjectiveName GP_S_Gen5_2
		Assert-AreEqual $db1.MinimumCapacity 2
		Assert-AreEqual $db1.AutoPauseDelayInMinutes 1440
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests updating a database from Sterling to Hyperscale with Manual Cutover {Azure SQL Forward Migration V2} 
#>
function Test-UpdateDatabaseFromSterlingToHyperscaleWithManualCutover ()
{
	# Setup
	$location = "eastus2euap"
	$targetEdition = "Hyperscale"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location
	$databaseName = Get-DatabaseName
	$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
		-VCore 2 -Edition GeneralPurpose -ComputeGeneration Gen5 -MaxSizeBytes 250GB -ComputeModel Serverless
	Assert-AreEqual $db.DatabaseName $databaseName

	try
	{
		# Update Sterling database to Hyperscale with manual cutover
		$job = Set-AzSqlDatabase -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName `
			-Edition $targetEdition -RequestedServiceObjectiveName "HS_Gen5_8" -ManualCutover -AsJob

		$startTime = Get-Date
		$timeout = New-TimeSpan -Minutes 20

		do 
		{  
			# list database operation to check if the db is ready for cutover
			$dbactivity = Get-AzSqlDatabaseActivity -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName
			Write-Output $dbactivity
	    
			if($dbactivity.Length -gt 0)
			{
					Assert-AreEqual $dbactivity[0].DatabaseName $databaseName
					Assert-AreEqual $dbactivity[0].Operation "UpdateLogicalDatabase"
					if($dbactivity[0].OperationPhaseDetails.Phase -eq "WaitingForCutover")
					{						
						break
					}
			}

			if ((Get-Date) - $startTime -ge $timeout) {  
					break
			}
		}while ($true) 
		
		# Trigger Perform Cutover on the db once the db is waitingforcutover and verify the target db name/slo
		$db1 = Set-AzSqlDatabase -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName `
				-PerformCutover
		Assert-AreEqual $db1.DatabaseName $db.DatabaseName
		Assert-AreEqual $db1.CurrentServiceObjectiveName HS_Gen5_8

		$job | Wait-Job
		$db2 = $job.Output
		Assert-AreEqual $db2.DatabaseName $db.DatabaseName
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests updating a database with zone redundancy not specified
#>
function Test-UpdateDatabaseWithZoneRedundantNotSpecified ()
{
	# Setup
	$location = "eastus"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location
	$databaseName = Get-DatabaseName
	$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
		-Edition Premium -ZoneRedundant -Force
	Assert-AreEqual $db.DatabaseName $databaseName
	Assert-NotNull $db.ZoneRedundant
	Assert-AreEqual "true" $db.ZoneRedundant

	try
	{
		# Alter database with no zone redundancy set
		$db1 = Set-AzSqlDatabase -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName `
			-Tags @{"tag_key"="tag_new_value2"}
		Assert-AreEqual $db1.DatabaseName $db.DatabaseName
		Assert-AreEqual True $db1.Tags.ContainsKey("tag_key")
		Assert-AreEqual "tag_new_value2" $db1.Tags["tag_key"]
		Assert-NotNull $db1.ZoneRedundant
		Assert-AreEqual "true" $db1.ZoneRedundant
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests renaming a database
#>
function Test-RenameDatabase
{
	# Setup
	$rg = Create-ResourceGroupForTest

	try
	{
		$location = "eastus"
		$server = Create-ServerForTest $rg $location

		# Create with default values
		$databaseName = Get-DatabaseName
		$db1 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -MaxSizeBytes 1GB -Force
		Assert-AreEqual $db1.DatabaseName $databaseName

		# Rename with params
		$name2 = "name2"
		$db2 = Set-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -NewName $name2
		Assert-AreEqual $db2.DatabaseName $name2

		Assert-ThrowsContains -script { $db1 | Get-AzSqlDatabase } -message "not found"
		$db2 | Get-AzSqlDatabase

		# Rename with piping
		$name3 = "name3"
		$db3 = $db2 | Set-AzSqlDatabase -NewName $name3
		Assert-AreEqual $db3.DatabaseName $name3

		Assert-ThrowsContains -script { $db1 | Get-AzSqlDatabase } -message "not found"
		Assert-ThrowsContains -script { $db2 | Get-AzSqlDatabase } -message "not found"
		$db3 | Get-AzSqlDatabase
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}


<#
	.SYNOPSIS
	Tests Getting a database
#>
function Test-GetDatabase
{
	Test-GetDatabaseInternal "eastus"
}

<#
	.SYNOPSIS
	Tests Getting a database
#>
function Test-GetDatabaseInternal  ($location = "eastus")
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location

	# Create with default values
	$databaseName = Get-DatabaseName
	$db1 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -MaxSizeBytes 1GB -Force
	Assert-AreEqual $db1.DatabaseName $databaseName

	# Create database with non-defaults
	$databaseName = Get-DatabaseName
	$db2 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
		-CollationName "Japanese_Bushu_Kakusu_100_CS_AS" -MaxSizeBytes 1GB -Edition Basic -RequestedServiceObjectiveName Basic -Force
	Assert-AreEqual $db2.DatabaseName $databaseName

	try
	{
		# Create data warehouse database.
		$databaseName = Get-DatabaseName
		$dwdb = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
				-CollationName SQL_Latin1_General_CP1_CI_AS -MaxSizeBytes 250GB -Edition DataWarehouse -RequestedServiceObjectiveName DW100c -Force
		$dwdb2 = Get-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupname -ServerName $server.ServerName -DatabaseName $dwdb.DatabaseName 
		Assert-AreEqual $dwdb2.DatabaseName $dwdb.DatabaseName
		Assert-AreEqual $dwdb2.MaxSizeBytes $dwdb.MaxSizeBytes
		Assert-AreEqual $dwdb2.Edition $dwdb.Edition
		Assert-AreEqual $dwdb2.CurrentServiceObjectiveName $dwdb.CurrentServiceObjectiveName
		Assert-AreEqual $dwdb2.CollationName $dwdb.CollationName

		$all = $server | Get-AzSqlDatabase
		Assert-AreEqual $all.Count 4 # 4 because master database is included

		$gdb1 = Get-AzSqlDatabase -ResourceGroupName $server.ResourceGroupname -ServerName $server.ServerName -DatabaseName $db1.DatabaseName
		Assert-NotNull $gdb1
		Assert-AreEqual $db1.DatabaseName $gdb1.DatabaseName
		Assert-AreEqual $db1.Edition $gdb1.Edition
		Assert-AreEqual $db1.CollationName $gdb1.CollationName
		Assert-AreEqual $db1.CurrentServiceObjectiveName $gdb1.CurrentServiceObjectiveName
		Assert-AreEqual $db1.MaxSizeBytes $gdb1.MaxSizeBytes

		$gdb2 = $db2 | Get-AzSqlDatabase
		Assert-NotNull $gdb2
		Assert-AreEqual $db2.DatabaseName $gdb2.DatabaseName
		Assert-AreEqual $db2.Edition $gdb2.Edition
		Assert-AreEqual $db2.CollationName $gdb2.CollationName
		Assert-AreEqual $db2.CurrentServiceObjectiveName $gdb2.CurrentServiceObjectiveName
		Assert-AreEqual $db2.MaxSizeBytes $gdb2.MaxSizeBytes
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests Getting a database
#>
function Test-GetDatabaseWithBackupStorageRedundancy ($location = "eastus")
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location

	# Create with default values
	$databaseName = Get-DatabaseName
	$db1 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -BackupStorageRedundancy Geo -Force
	Assert-AreEqual $db1.DatabaseName $databaseName
	Assert-NotNull $db1.CurrentBackupStorageRedundancy
	Assert-AreEqual	$db1.CurrentBackupStorageRedundancy "Geo"

	Remove-ResourceGroupForTest $rg
}

<#
	.SYNOPSIS
	Tests getting a database with zone redundancy.
#>
function Test-GetDatabaseWithZoneRedundancy
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "operations" "East US"
	$rg = Create-ResourceGroupForTest $location
	try
	{
		$server = Create-ServerForTest $rg $location

		# Create database with no zone redundancy set
		$databaseName = Get-DatabaseName
		$db1 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
			-DatabaseName $databaseName -Edition Premium -ZoneRedundant

		$gdb1 = Get-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupname -ServerName $server.ServerName -DatabaseName $db1.DatabaseName
		Assert-AreEqual $gdb1.DatabaseName $db1.DatabaseName
		Assert-AreEqual "true" $gdb1.ZoneRedundant

		# Create database with zone redundancy true
		$databaseName = Get-DatabaseName
		$db2 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
			-DatabaseName $databaseName -Edition Premium

		$gdb2 = Get-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupname -ServerName $server.ServerName -DatabaseName $db2.DatabaseName
		Assert-AreEqual $gdb2.DatabaseName $db2.DatabaseName
		Assert-AreEqual "false" $gdb2.ZoneRedundant
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests getting a database with maintenance
#>
function Test-GetDatabaseWithMaintenanceConfigurationId
{
	# Setup
	# Further actions required if you use Microsoft internal subscription. Please contact feature owners
	$location = Get-Location "Microsoft.Sql" "operations" "East US"
	$rg = Create-ResourceGroupForTest $location
	try
	{
		$server = Create-ServerForTest $rg $location

		# Create database without specifying maintenance
		$defaultMId = Get-DefaultPublicMaintenanceConfigurationId $location
		$databaseName = Get-DatabaseName
		$db1 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
			-Edition Premium -Force

		$gdb1 = Get-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupname -ServerName $server.ServerName -DatabaseName $db1.DatabaseName
		Assert-AreEqual $gdb1.DatabaseName $db1.DatabaseName
		Assert-AreEqual $defaultMId.ToLower() $gdb1.MaintenanceConfigurationId.ToLower()

		# Create database with maintenance (try using name instead of full id)
		$databaseName = Get-DatabaseName
		$mName = Get-PublicMaintenanceConfigurationName $location "DB_1"
		$mId = Get-PublicMaintenanceConfigurationId $location "DB_1"
		$db2 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
			-DatabaseName $databaseName -Edition Premium -MaintenanceConfigurationId $mName -Force

		$gdb2 = Get-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupname -ServerName $server.ServerName -DatabaseName $db2.DatabaseName
		Assert-AreEqual $gdb2.DatabaseName $db2.DatabaseName
		Assert-AreEqual $mId.ToLower() $gdb2.MaintenanceConfigurationId.ToLower()
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests Getting a database with preferred enclave type
#>
function Test-GetDatabaseWithPreferredEnclaveType ($location = "eastus2euap")
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location

	try
	{
		# Create with preferred enclave type as Default
		$databaseName = Get-DatabaseName
		$db1 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -PreferredEnclaveType Default -Force
		$gdb1 = Get-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupname -ServerName $server.ServerName -DatabaseName $db1.DatabaseName
		Assert-AreEqual $db1.DatabaseName $gdb1.DatabaseName
		Assert-AreEqual	Default $gdb1.PreferredEnclaveType

		# Create with preferred enclave type as VBS
		$databaseName = Get-DatabaseName
		$db2 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -PreferredEnclaveType VBS -Force
		$gdb2 = Get-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupname -ServerName $server.ServerName -DatabaseName $db2.DatabaseName
		Assert-AreEqual $db2.DatabaseName $gdb2.DatabaseName
		Assert-AreEqual	VBS $gdb2.PreferredEnclaveType
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests creating a database with ledger enabled
#>
function Test-DatabaseCreateWithLedgerEnabled ($location = "eastus")
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location

	# Create with ledger enabled
	$databaseName = Get-DatabaseName
	$db1 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -EnableLedger -Force
	Assert-AreEqual $db1.DatabaseName $databaseName
	Assert-AreEqual	"True" $db1.EnableLedger

	# Validate Get-AzSqlDatabase returns ledger property
	$databaseFromGet = Get-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName
	Assert-AreEqual	"True" $databaseFromGet.EnableLedger

	Remove-ResourceGroupForTest $rg
}

<#
	.SYNOPSIS
	Tests Deleting a database
#>
function Test-RemoveDatabase
{
	Test-RemoveDatabaseInternal "eastus"
}

<#
	.SYNOPSIS
	Tests Deleting a database
#>
function Test-RemoveDatabaseInternal  ($location = "eastus")
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location

	# Create with default values
	$databaseName = Get-DatabaseName
	$db1 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -MaxSizeBytes 1GB -Force
	Assert-AreEqual $db1.DatabaseName $databaseName 

	# Create database with non-defaults
	$databaseName = Get-DatabaseName
	$db2 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
		-CollationName "Japanese_Bushu_Kakusu_100_CS_AS" -MaxSizeBytes 1GB -Edition Basic -RequestedServiceObjectiveName Basic -Force
	Assert-AreEqual $db2.DatabaseName $databaseName

	try
	{
		# Create data warehouse database
		$databaseName = Get-DatabaseName
		$dwdb = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
			-CollationName "SQL_Latin1_General_CP1_CI_AS" -MaxSizeBytes 250GB -Edition DataWarehouse -RequestedServiceObjectiveName DW100c -Force
		Assert-AreEqual $dwdb.DatabaseName $databaseName

		Remove-AzSqlDatabase -ResourceGroupName $server.ResourceGroupname -ServerName $server.ServerName -DatabaseName $dwdb.DatabaseName -Force

		$all = $server | Get-AzSqlDatabase
		Assert-AreEqual $all.Count 3 # 3 because master database is included

		Remove-AzSqlDatabase -ResourceGroupName $server.ResourceGroupname -ServerName $server.ServerName -DatabaseName $db1.DatabaseName -Force

		$db2 | Remove-AzSqlDatabase -Force

		$all = $server | Get-AzSqlDatabase
		Assert-AreEqual $all.Count 1 # 1 because master database is included
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}


<#
	.SYNOPSIS
	Tests listing and cancelling a database operation
#>
function Test-CancelDatabaseOperation
{
	Test-CancelDatabaseOperationInternal
}

<#
	.SYNOPSIS
	Tests listing and cancelling a database operation
#>
function Test-CancelDatabaseOperationInternal
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "servers"  "East US"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location

	$databaseName = Get-DatabaseName
	$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
		-Edition Standard -MaxSizeBytes 250GB -RequestedServiceObjectiveName S0
	Assert-AreEqual $db.DatabaseName $databaseName 'Create database failed.'

	# Database will be Standard s0 with maxsize: 268435456000 (250GB)

	try
	{
		# Alter all properties
		$db1 = Set-AzSqlDatabase -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName `
			-Edition Standard -RequestedServiceObjectiveName S1
		Assert-AreEqual $db1.DatabaseName $db.DatabaseName 'Alter db name not equal'
		Assert-AreEqual $db1.Edition Standard 'Alter db edition not equal'
		Assert-AreEqual $db1.CurrentServiceObjectiveName S1 'Alter db slo not equal'

		# list and cancel a database operation
		$dbactivity = Get-AzSqlDatabaseActivity -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName
		Assert-AreEqual $dbactivity.DatabaseName $db.DatabaseName
		Assert-AreEqual $dbactivity.Operation "UpdateLogicalDatabase"

		$dbactivityId = $dbactivity.OperationId
		try
		{
			$dbactivityCancel = Stop-AzSqlDatabaseActivity -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName -OperationId $dbactivityId
		}
		Catch
		{
			$ErrorMessage = (ConvertFrom-Json $_.Exception.Response.Content).error.message
			Assert-AreEqual True $ErrorMessage.Contains("Cannot cancel management operation '" + $dbactivityId + "' in the current state")
		}
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests creating a database with db level cmk and identity
#>
function Test-DatabaseCreateWithPerDBCMK ($location = "eastus2euap")
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location
	$encryptionProtector = "https://pstestkv.vault.azure.net/keys/testkey/f62d937858464f329ab4a8c2dc7e0fa4"
	$umi = "/subscriptions/2c647056-bab2-4175-b172-493ff049eb29/resourceGroups/pstest/providers/Microsoft.ManagedIdentity/userAssignedIdentities/pstestumi"

	# Create with per db cmk enabled
	$databaseName = Get-DatabaseName
	$db1 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -AssignIdentity -EncryptionProtector $encryptionProtector -UserAssignedIdentityId $umi -EncryptionProtectorAutoRotation

	# Validate Get-AzSqlDatabase returns cmk properties
	$databaseFromGet = Get-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName
	Assert-NotNull $databaseFromGet
	Assert-AreEqual $databaseFromGet.EncryptionProtector $encryptionProtector
	Assert-AreEqual $databaseFromGet.EncryptionProtectorAutoRotation $true

	Remove-ResourceGroupForTest $rg
}

<#
	.SYNOPSIS
	Tests updating a database with db level cmk and identity
#>
function Test-DatabaseUpdateWithPerDBCMK ($location = "eastus2euap")
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location
	$encryptionProtector = "https://kvpstest.vault.azure.net/keys/pstestkey/1493a5e6d9e34b429276c02457e42c0c"
	$umi = "/subscriptions/10a238d6-a139-46d0-818d-d091394072b6/resourceGroups/pstest/providers/Microsoft.ManagedIdentity/userAssignedIdentities/pstestumi"

	# Create with per db cmk enabled
	$databaseName = Get-DatabaseName
	$db1 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -AssignIdentity -EncryptionProtector $encryptionProtector -UserAssignedIdentityId $umi -EncryptionProtectorAutoRotation

	# Validate Get-AzSqlDatabase returns cmk properties
	$databaseFromGet = Get-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName
	Assert-AreEqual $databaseFromGet.EncryptionProtector $encryptionProtector

	# Update the db with new EncryptionProtector
	$encryptionProtector2 = "https://kvpstest.vault.azure.net/keys/pstestkey1/f6143120ccd3400c94e244799d6d00d1"
	$dbAfterUpdate = Set-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -EncryptionProtector $encryptionProtector2 -EncryptionProtectorAutoRotation:$false
	
	$databaseGetAfterUpdate = Get-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName
	Assert-AreEqual $databaseGetAfterUpdate.EncryptionProtector $encryptionProtector2
	Assert-AreEqual $databaseGetAfterUpdate.EncryptionProtectorAutoRotation $false

	Remove-ResourceGroupForTest $rg
}

<#
	.SYNOPSIS
	Test to revalidae the encryption protector of a database with db level cmk and identity
#>
function Test-RevalidateAndRevertAKVKeyForDatabaseWithPerDBCMK ($location = "eastus2euap")
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location
	$encryptionProtector = "https://pstestkv.vault.azure.net/keys/testkey/f62d937858464f329ab4a8c2dc7e0fa4"
	$umi = "/subscriptions/2c647056-bab2-4175-b172-493ff049eb29/resourceGroups/pstest/providers/Microsoft.ManagedIdentity/userAssignedIdentities/pstestumi"
	$akvRg =  "pstest"
	$akvName = "pstestkv"
	$umiObjectId = "781be676-54b8-46e5-ba30-4d9a18b13bf6"

	# Create with per db cmk enabled
	$databaseName = Get-DatabaseName
	$db1 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -AssignIdentity -EncryptionProtector $encryptionProtector -UserAssignedIdentityId $umi

	# Validate Get-AzSqlDatabase returns cmk properties
	$databaseFromGet = Get-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName
	Assert-AreEqual $databaseFromGet.EncryptionProtector $encryptionProtector

	# Revalidate AKV key
	Invoke-AzSqlDatabaseTransparentDataEncryptionProtectorRevalidation -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName

	# Revert encryption protector
	Invoke-AzSqlDatabaseTransparentDataEncryptionProtectorRevert -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName

	Remove-ResourceGroupForTest $rg
}