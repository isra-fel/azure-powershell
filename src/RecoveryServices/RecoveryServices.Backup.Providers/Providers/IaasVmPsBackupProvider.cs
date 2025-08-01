﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Rest.Azure.OData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Text.RegularExpressions;
using CmdletModel = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using RestAzureNS = Microsoft.Rest.Azure;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using CrrModel = Microsoft.Azure.Management.RecoveryServices.Backup.CrossRegionRestore.Models;
using SystemNet = System.Net;
using Microsoft.Azure.Commands.Common.Exceptions;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel
{
    /// <summary>
    /// This class implements implements methods for IaasVm backup provider
    /// </summary>
    public class IaasVmPsBackupProvider : IPsBackupProvider
    {
        private const int defaultOperationStatusRetryTimeInMilliSec = 5 * 1000; // 5 sec
        private const string separator = ";";
        private const string computeAzureVMVersion = "Microsoft.Compute";
        private const string classicComputeAzureVMVersion = "Microsoft.ClassicCompute";

        Dictionary<Enum, object> ProviderData { get; set; }
        ServiceClientAdapter ServiceClientAdapter { get; set; }
        AzureWorkloadProviderHelper AzureWorkloadProviderHelper { get; set; }

        /// <summary>
        /// Initializes the provider with the data received from the cmdlet layer
        /// </summary>
        /// <param name="providerData">Data from the cmdlet layer intended for the provider</param>
        /// <param name="serviceClientAdapter">Service client adapter for communicating with the backend service</param>
        public void Initialize(
            Dictionary<Enum, object> providerData, ServiceClientAdapter serviceClientAdapter)
        {
            ProviderData = providerData;
            ServiceClientAdapter = serviceClientAdapter;
            AzureWorkloadProviderHelper = new AzureWorkloadProviderHelper(ServiceClientAdapter);
        }

        /// <summary>
        /// Triggers the enable protection operation for the given item
        /// </summary>
        /// <returns>The job response returned from the service</returns>
        public RestAzureNS.AzureOperationResponse<ProtectedItemResource> EnableProtection()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            string azureVMName = (string)ProviderData[ItemParams.ItemName];
            string azureVMCloudServiceName = (string)ProviderData[ItemParams.AzureVMCloudServiceName];
            string azureVMResourceGroupName = (string)ProviderData[ItemParams.AzureVMResourceGroupName];
            string parameterSetName = (string)ProviderData[ItemParams.ParameterSetName];
            string[] inclusionDisksList = (string[])ProviderData[ItemParams.InclusionDisksList];
            string[] exclusionDisksList = (string[])ProviderData[ItemParams.ExclusionDisksList];
            SwitchParameter resetDiskExclusionSetting = (SwitchParameter)ProviderData[ItemParams.ResetExclusionSettings];
            bool excludeAllDataDisks = (bool)ProviderData[ItemParams.ExcludeAllDataDisks];
            PolicyBase policy = (PolicyBase)ProviderData[ItemParams.Policy];
            ItemBase itemBase = (ItemBase)ProviderData[ItemParams.Item];
            AzureVmItem item = (AzureVmItem)ProviderData[ItemParams.Item];

            string auxiliaryAccessToken = ProviderData.ContainsKey(ResourceGuardParams.Token) ? (string)ProviderData[ResourceGuardParams.Token] : null;
            bool isMUAOperation = ProviderData.ContainsKey(ResourceGuardParams.IsMUAOperation) ? (bool)ProviderData[ResourceGuardParams.IsMUAOperation] : false;

            Logger.Instance.WriteWarning(String.Format(Resources.TrustedLaunchDefaultWarning));

            ProtectionPolicyResource oldPolicy = null;
            ProtectionPolicyResource newPolicy = null;
            if (parameterSetName.Contains("Modify") && item.PolicyId != null && item.PolicyId != "")
            {
                Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(item.PolicyId);
                string oldPolicyName = HelperUtils.GetPolicyNameFromPolicyId(keyValueDict, item.PolicyId);

                keyValueDict = HelperUtils.ParseUri(policy.Id);
                string newPolicyName = HelperUtils.GetPolicyNameFromPolicyId(keyValueDict, policy.Id);
                
                // fetch old and new Policy 
                oldPolicy = ServiceClientAdapter.GetProtectionPolicy(
                    oldPolicyName,
                    vaultName: vaultName,
                    resourceGroupName: resourceGroupName);
                
                newPolicy = ServiceClientAdapter.GetProtectionPolicy(
                    newPolicyName,
                    vaultName: vaultName,
                    resourceGroupName: resourceGroupName);                
            }

            bool isDiskExclusionParamPresent = ValidateDiskExclusionParameters(
                inclusionDisksList, exclusionDisksList, resetDiskExclusionSetting, excludeAllDataDisks);

            // do validations
            string containerUri = "";
            string protectedItemUri = "";
            bool isComputeAzureVM = false;
            string sourceResourceId = null;

            AzureVmPolicy azureVmPolicy = (AzureVmPolicy)ProviderData[ItemParams.Policy];
            if (azureVmPolicy != null)
            {
                ValidateProtectedItemCount(azureVmPolicy);
            }
                        
            if (itemBase == null)
            {
                isComputeAzureVM = string.IsNullOrEmpty(azureVMCloudServiceName) ? true : false;
                string azureVMRGName = (isComputeAzureVM) ?
                    azureVMResourceGroupName : azureVMCloudServiceName;

                ValidateAzureVMWorkloadType(policy.WorkloadType);
                
                ValidateAzureVMEnableProtectionRequest(
                    azureVMName,
                    azureVMCloudServiceName,
                    azureVMResourceGroupName,
                    policy);

                WorkloadProtectableItemResource protectableObjectResource =
                    GetAzureVMProtectableObject(
                        azureVMName,
                        azureVMRGName,
                        isComputeAzureVM,
                        vaultName: vaultName,
                        resourceGroupName: resourceGroupName);

                Dictionary<UriEnums, string> keyValueDict =
                    HelperUtils.ParseUri(protectableObjectResource.Id);
                containerUri = HelperUtils.GetContainerUri(
                    keyValueDict, protectableObjectResource.Id);
                protectedItemUri = HelperUtils.GetProtectableItemUri(
                    keyValueDict, protectableObjectResource.Id);

                IaaSVMProtectableItem iaasVmProtectableItem =
                    (IaaSVMProtectableItem)protectableObjectResource.Properties;                

                if (iaasVmProtectableItem != null)
                {
                    sourceResourceId = iaasVmProtectableItem.VirtualMachineId;                    
                }
            }
            else if(isDiskExclusionParamPresent && parameterSetName.Contains("Modify"))
            {
                isComputeAzureVM = IsComputeAzureVM(item.VirtualMachineId);
                                
                Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(item.Id);
                containerUri = HelperUtils.GetContainerUri(keyValueDict, item.Id);
                protectedItemUri = HelperUtils.GetProtectedItemUri(keyValueDict, item.Id);
                sourceResourceId = item.SourceResourceId;               
            }
            else
            {
                ValidateAzureVMWorkloadType(item.WorkloadType, policy.WorkloadType);
                ValidateAzureVMModifyProtectionRequest(itemBase, policy);

                isComputeAzureVM = IsComputeAzureVM(item.VirtualMachineId);

                Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(item.Id);
                containerUri = HelperUtils.GetContainerUri(keyValueDict, item.Id);
                protectedItemUri = HelperUtils.GetProtectedItemUri(keyValueDict, item.Id);
                sourceResourceId = item.SourceResourceId;
            }

            // construct Service Client protectedItem request
            AzureIaaSVMProtectedItem properties;
            if (isComputeAzureVM == false)
            {
                properties = new AzureIaaSClassicComputeVMProtectedItem();
            }
            else
            {
                properties = new AzureIaaSComputeVMProtectedItem();
            }
            
            if (policy != null)
            {
                properties.PolicyId = policy.Id;
            }
            else
            {
                properties.PolicyId = item.PolicyId;
            }
            properties.SourceResourceId = sourceResourceId;

            ExtendedProperties extendedProperties = null;
            if (resetDiskExclusionSetting.IsPresent)
            {
                extendedProperties = new ExtendedProperties();
                extendedProperties.DiskExclusionProperties = null;
            }
            else
            {
                if(inclusionDisksList != null)
                {
                    IList<int?> inclusionList = Array.ConvertAll(inclusionDisksList, s => int.Parse(s)).OfType<int?>().ToList();
                    DiskExclusionProperties diskExclusionProperties = new DiskExclusionProperties(inclusionList, true);
                    extendedProperties = new ExtendedProperties();
                    extendedProperties.DiskExclusionProperties = diskExclusionProperties;
                }
                else if(exclusionDisksList != null)
                {
                    IList<int?> exclusionList = Array.ConvertAll(exclusionDisksList, s => int.Parse(s)).OfType<int?>().ToList();
                    DiskExclusionProperties diskExclusionProperties = new DiskExclusionProperties(exclusionList, false);
                    extendedProperties = new ExtendedProperties();
                    extendedProperties.DiskExclusionProperties = diskExclusionProperties;
                }
                else if(excludeAllDataDisks == true)
                {
                    IList<int?> exclusionList = new List<int?>();
                    DiskExclusionProperties diskExclusionProperties = new DiskExclusionProperties(exclusionList, true);
                    extendedProperties = new ExtendedProperties();
                    extendedProperties.DiskExclusionProperties = diskExclusionProperties;
                }
            }

            properties.ExtendedProperties = extendedProperties;

            ProtectedItemResource serviceClientRequest = new ProtectedItemResource()
            {
                Properties = properties
            };

            // check for MUA
            bool isMUAProtected = false;
            if (parameterSetName.Contains("Modify") && oldPolicy != null && newPolicy != null)
            {
                isMUAProtected = AzureWorkloadProviderHelper.checkMUAForModifyPolicy(oldPolicy, newPolicy, isMUAOperation);

                #region validate Std to Enh policy migration
                string oldPolicyType = ((ServiceClientModel.AzureIaaSVMProtectionPolicy)oldPolicy.Properties).PolicyType;

                PSPolicyType oldPolicySubType = (oldPolicyType != null && oldPolicyType.ToLower().Contains("v2")) ? PSPolicyType.Enhanced : PSPolicyType.Standard;

                string newPolicyType = ((ServiceClientModel.AzureIaaSVMProtectionPolicy)newPolicy.Properties).PolicyType;

                PSPolicyType newPolicySubType = (newPolicyType != null && newPolicyType.ToLower().Contains("v2")) ? PSPolicyType.Enhanced : PSPolicyType.Standard;

                if (oldPolicySubType == PSPolicyType.Standard && newPolicySubType == PSPolicyType.Enhanced)
                {
                    Logger.Instance.WriteWarning(String.Format(Resources.StdToEnhPolicyMigrationWarning));
                }
                #endregion
            }

            return ServiceClientAdapter.CreateOrUpdateProtectedItem(
                containerUri,
                protectedItemUri,
                serviceClientRequest,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName,
                auxiliaryAccessToken,
                isMUAProtected);
        }

        /// <summary>
        /// Triggers the disable protection operation for the given item
        /// </summary>
        /// <returns>The job response returned from the service</returns>
        public RestAzureNS.AzureOperationResponse<ProtectedItemResource> SuspendBackup()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
                        
            ItemBase itemBase = (ItemBase)ProviderData[ItemParams.Item];

            string auxiliaryAccessToken = ProviderData.ContainsKey(ResourceGuardParams.Token) ? (string)ProviderData[ResourceGuardParams.Token] : null;
            bool isMUAProtected = true;

            // do validations
            ValidateAzureVMDisableProtectionRequest(itemBase);

            Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(itemBase.Id);
            string containerUri = HelperUtils.GetContainerUri(keyValueDict, itemBase.Id);
            string protectedItemUri = HelperUtils.GetProtectedItemUri(keyValueDict, itemBase.Id);

            AzureIaaSVMProtectedItem properties = new AzureIaaSVMProtectedItem();

            properties.ProtectionState = ProtectionState.BackupsSuspended;
            properties.SourceResourceId = itemBase.SourceResourceId;

            ProtectedItemResource serviceClientRequest = new ProtectedItemResource()
            {
                Properties = properties,
            };

            return ServiceClientAdapter.CreateOrUpdateProtectedItem(
                containerUri,
                protectedItemUri,
                serviceClientRequest,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName,
                auxiliaryAccessToken,
                isMUAProtected,
                true);
        }

        /// <summary>
        /// Triggers the disable protection operation for the given item
        /// </summary>
        /// <returns>The job response returned from the service</returns>
        public RestAzureNS.AzureOperationResponse<ProtectedItemResource> DisableProtection()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            bool deleteBackupData = (bool)ProviderData[ItemParams.DeleteBackupData];

            ItemBase itemBase = (ItemBase)ProviderData[ItemParams.Item];

            AzureVmItem item = (AzureVmItem)ProviderData[ItemParams.Item];

            string auxiliaryAccessToken = ProviderData.ContainsKey(ResourceGuardParams.Token) ? (string)ProviderData[ResourceGuardParams.Token] : null;
            bool isMUAProtected = true;

            // do validations
            ValidateAzureVMDisableProtectionRequest(itemBase);

            Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(keyValueDict, item.Id);
            string protectedItemUri = HelperUtils.GetProtectedItemUri(keyValueDict, item.Id);

            bool isComputeAzureVM = false;
            isComputeAzureVM = IsComputeAzureVM(item.VirtualMachineId);

            // construct Service Client protectedItem request

            AzureIaaSVMProtectedItem properties;
            if (isComputeAzureVM == false)
            {
                properties = new AzureIaaSClassicComputeVMProtectedItem();
            }
            else
            {
                properties = new AzureIaaSComputeVMProtectedItem();
            }

            properties.PolicyId = string.Empty;
            properties.ProtectionState = ProtectionState.ProtectionStopped;
            properties.SourceResourceId = item.SourceResourceId;

            ProtectedItemResource serviceClientRequest = new ProtectedItemResource()
            {
                Properties = properties,
            };

            return ServiceClientAdapter.CreateOrUpdateProtectedItem(
                containerUri,
                protectedItemUri,
                serviceClientRequest,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName,
                auxiliaryAccessToken,
                isMUAProtected,
                true);
        }

        public RestAzureNS.AzureOperationResponse DisableProtectionWithDeleteData()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            bool deleteBackupData = (bool)ProviderData[ItemParams.DeleteBackupData];
            string auxiliaryAccessToken = ProviderData.ContainsKey(ResourceGuardParams.Token) ? (string)ProviderData[ResourceGuardParams.Token] : null;
            ItemBase itemBase = (ItemBase)ProviderData[ItemParams.Item];

            AzureVmItem item = (AzureVmItem)ProviderData[ItemParams.Item];
            // do validations

            ValidateAzureVMDisableProtectionRequest(itemBase);

            Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(keyValueDict, item.Id);
            string protectedItemUri = HelperUtils.GetProtectedItemUri(keyValueDict, item.Id);

            return ServiceClientAdapter.DeleteProtectedItem(
                                containerUri,
                                protectedItemUri,
                                vaultName: vaultName,
                                resourceGroupName: resourceGroupName,
                                auxiliaryAccessToken,
                                item.Id);
        }

        /// <summary>
        /// Triggers the backup operation for the given item
        /// </summary>
        /// <returns>The job response returned from the service</returns>
        public RestAzureNS.AzureOperationResponse TriggerBackup()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            ItemBase item = (ItemBase)ProviderData[ItemParams.Item];
            // setting the default expiry time of 30 days for AzureVM workload, this doesn't apply to MSSQL workload as the default value for SQL is 45 days.
            DateTime? expiryDateTime = (ProviderData[ItemParams.ExpiryDateTimeUTC] != null) ? (DateTime?)ProviderData[ItemParams.ExpiryDateTimeUTC] : DateTime.UtcNow.AddDays(30);
            AzureVmItem iaasVmItem = item as AzureVmItem;
            BackupRequestResource triggerBackupRequest = new BackupRequestResource();
            IaasVMBackupRequest iaasVmBackupRequest = new IaasVMBackupRequest();
            iaasVmBackupRequest.RecoveryPointExpiryTimeInUtc = expiryDateTime;
            triggerBackupRequest.Properties = iaasVmBackupRequest;

            return ServiceClientAdapter.TriggerBackup(
                IdUtils.GetValueByName(iaasVmItem.Id, IdUtils.IdNames.ProtectionContainerName),
                IdUtils.GetValueByName(iaasVmItem.Id, IdUtils.IdNames.ProtectedItemName),
                triggerBackupRequest,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);
        }

        public RestAzureNS.AzureOperationResponse<ProtectedItemResource> UndeleteProtection()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            AzureVmItem item = (AzureVmItem)ProviderData[ItemParams.Item];

            Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(keyValueDict, item.Id);
            string protectedItemUri = HelperUtils.GetProtectedItemUri(keyValueDict, item.Id);

            bool isComputeAzureVM = false;
            isComputeAzureVM = IsComputeAzureVM(item.VirtualMachineId);

            AzureIaaSVMProtectedItem properties;
            if (isComputeAzureVM == false)
            {
                properties = new AzureIaaSClassicComputeVMProtectedItem();
            }
            else
            {
                properties = new AzureIaaSComputeVMProtectedItem();
            }

            properties.PolicyId = null;
            properties.ProtectionState = ProtectionState.ProtectionStopped;
            properties.SourceResourceId = item.SourceResourceId;
            properties.IsRehydrate = true;

            ProtectedItemResource serviceClientRequest = new ProtectedItemResource()
            {
                Properties = properties,
            };

            return ServiceClientAdapter.CreateOrUpdateProtectedItem(
                containerUri,
                protectedItemUri,
                serviceClientRequest,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);
        }

        /// <summary>
        /// Triggers the recovery operation for the given recovery point
        /// </summary>
        /// <returns>The job response returned from the service</returns>
        public RestAzureNS.AzureOperationResponse TriggerRestore()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            string vaultLocation = (string)ProviderData[VaultParams.VaultLocation];
            AzureVmRecoveryPoint rp = ProviderData[RestoreBackupItemParams.RecoveryPoint]
                as AzureVmRecoveryPoint;
            string storageAccountName = ProviderData[RestoreBackupItemParams.StorageAccountName].ToString();
            string storageAccountResourceGroupName =
                ProviderData[RestoreBackupItemParams.StorageAccountResourceGroupName].ToString();
            string targetResourceGroupName =
                ProviderData.ContainsKey(RestoreVMBackupItemParams.TargetResourceGroupName) ?
                ProviderData[RestoreVMBackupItemParams.TargetResourceGroupName].ToString() : null;
            bool osaOption = (bool)ProviderData[RestoreVMBackupItemParams.OsaOption];
            string[] restoreDiskList = (string[])ProviderData[RestoreVMBackupItemParams.RestoreDiskList];
            SwitchParameter restoreOnlyOSDisk = (SwitchParameter)ProviderData[RestoreVMBackupItemParams.RestoreOnlyOSDisk];
            SwitchParameter restoreAsUnmanagedDisks = (SwitchParameter)ProviderData[RestoreVMBackupItemParams.RestoreAsUnmanagedDisks];
            String DiskEncryptionSetId = ProviderData.ContainsKey(RestoreVMBackupItemParams.DiskEncryptionSetId) ?
                (string)ProviderData[RestoreVMBackupItemParams.DiskEncryptionSetId].ToString() : null;
            bool useSecondaryRegion = (bool)ProviderData[CRRParams.UseSecondaryRegion];                        
            String secondaryRegion = useSecondaryRegion ? (string)ProviderData[CRRParams.SecondaryRegion]: null;
            IList<string> targetZones = ProviderData.ContainsKey(RecoveryPointParams.TargetZone) ?
                new List<string>(new string[]{(ProviderData[RecoveryPointParams.TargetZone].ToString())}) : null;
            bool restoreWithManagedDisks = (bool)ProviderData[RestoreVMBackupItemParams.RestoreAsManagedDisk];
            string rehydrateDuration = ProviderData.ContainsKey(RecoveryPointParams.RehydrateDuration) ?
                ProviderData[RecoveryPointParams.RehydrateDuration].ToString() : "15";
            string rehydratePriority = ProviderData.ContainsKey(RecoveryPointParams.RehydratePriority) ?
                ProviderData[RecoveryPointParams.RehydratePriority].ToString() : null;            
            bool useSystemAssignedIdentity = (bool)ProviderData[RestoreVMBackupItemParams.UseSystemAssignedIdentity];
            string userAssignedIdentityId = (string) ProviderData[RestoreVMBackupItemParams.UserAssignedIdentityId];
            string restoreType = (string)ProviderData[RestoreVMBackupItemParams.RestoreType];
            string targetVMName = (string)ProviderData[RestoreVMBackupItemParams.TargetVMName];
            string targetVNetName = (string)ProviderData[RestoreVMBackupItemParams.TargetVNetName];
            string targetVNetResourceGroup = (string)ProviderData[RestoreVMBackupItemParams.TargetVNetResourceGroup];
            string targetSubnetName = (string)ProviderData[RestoreVMBackupItemParams.TargetSubnetName];
            string targetSubscriptionId = (string)ProviderData[RestoreVMBackupItemParams.TargetSubscriptionId];
            bool restoreToEdgeZone = (bool)ProviderData[RestoreVMBackupItemParams.RestoreToEdgeZone];
            string auxiliaryAccessToken = ProviderData.ContainsKey(ResourceGuardParams.Token) ? (string)ProviderData[ResourceGuardParams.Token] : null;
            bool isMUAOperation = ProviderData.ContainsKey(ResourceGuardParams.IsMUAOperation) ? (bool)ProviderData[ResourceGuardParams.IsMUAOperation] : false;
            ServiceClientModel.TargetDiskNetworkAccessOption? diskAccessOption = ProviderData.ContainsKey(RestoreVMBackupItemParams.DiskAccessOption) ? (ServiceClientModel.TargetDiskNetworkAccessOption?)ProviderData[RestoreVMBackupItemParams.DiskAccessOption] : null;
            string targetDiskAccessId = ProviderData.ContainsKey(RestoreVMBackupItemParams.TargetDiskAccessId) ? (string)ProviderData[RestoreVMBackupItemParams.TargetDiskAccessId] : null;

            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(rp.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, rp.Id);
            string cVMOsDiskEncryptionSetId = ProviderData.ContainsKey(RestoreVMBackupItemParams.CVMOsDiskEncryptionSetId) ?
                ProviderData[RestoreVMBackupItemParams.CVMOsDiskEncryptionSetId].ToString() : null;

            if (targetSubscriptionId == null || targetSubscriptionId == "") targetSubscriptionId = ServiceClientAdapter.SubscriptionId;

            GenericResource storageAccountResource = ServiceClientAdapter.GetStorageAccountResource(storageAccountName, targetSubscriptionId);

            if(storageAccountResource == null)
            {
                throw new ArgumentException(String.Format(Resources.RestoreAzureStorageNotFound));
            }

            var useOsa = ShouldUseOsa(rp, osaOption);

            string vmType = containerUri.Split(';')[1].Equals("iaasvmcontainer", StringComparison.OrdinalIgnoreCase)
                ? "Classic" : "Compute";
            string strType = storageAccountResource.Type.Equals("Microsoft.ClassicStorage/StorageAccounts",
                StringComparison.OrdinalIgnoreCase) ? "Classic" : "Compute";
            if (vmType != strType)
            {
                throw new Exception(string.Format(Resources.RestoreDiskStorageTypeError, vmType));
            }

            // if the vm is managed virtual machine then either target rg or the unmanaged restore intent should be provided unless it is OLR
            if(rp.IsManagedVirtualMachine == true && targetResourceGroupName == null && (string.Compare(restoreType, "OriginalLocation") != 0) 
                && restoreAsUnmanagedDisks.IsPresent == false)
            {
                throw new Exception(Resources.UnmanagedVMRestoreWarning);
            }

            // if the vm is unmanaged, target rg should not be provided
            if(rp.IsManagedVirtualMachine == false && targetResourceGroupName != null && !restoreWithManagedDisks)
            {
                Logger.Instance.WriteWarning(Resources.TargetResourcegroupNotSupported);
            }

            IList<int?> restoreDiskLUNS;
            if(restoreOnlyOSDisk.IsPresent)
            {
                restoreDiskLUNS = new List<int?>();
            }
            else if(restoreDiskList != null)
            {
                restoreDiskLUNS = Array.ConvertAll(restoreDiskList, s => int.Parse(s)).OfType<int?>().ToList();
            }
            else
            {
                restoreDiskLUNS = null;
            }

            // Vanguard M9 requirement: restores using MSI
            IdentityInfo identityInfo = null;
            IdentityBasedRestoreDetails identityBasedRestoreDetails = null;
            if (useSystemAssignedIdentity || (userAssignedIdentityId != null && userAssignedIdentityId != ""))
            {
                if (rp.IsManagedVirtualMachine)
                {
                    identityInfo = new IdentityInfo();
                    if (useSystemAssignedIdentity)
                    {
                        identityInfo.IsSystemAssignedIdentity = true;
                    }
                    else
                    {
                        identityInfo.IsSystemAssignedIdentity = false;
                        identityInfo.ManagedIdentityResourceId = userAssignedIdentityId;
                    }

                    // target storage account for MSI based restore 
                    identityBasedRestoreDetails = new IdentityBasedRestoreDetails();
                    identityBasedRestoreDetails.TargetStorageAccountId = storageAccountResource.Id;
                }
                else
                {
                    throw new NotSupportedException(Resources.MSIRestoreNotSupportedForUnmanagedVM);
                }
            }

            IaasVMRestoreRequest restoreRequest = new IaasVMRestoreRequest()
            {
                CreateNewCloudService = false,
                RecoveryPointId = rp.RecoveryPointId,
                RecoveryType = RecoveryType.RestoreDisks,
                Region = vaultLocation ?? ServiceClientAdapter.BmsAdapter.GetResourceLocation(),
                StorageAccountId = storageAccountResource.Id,
                SourceResourceId = rp.SourceResourceId,
                TargetResourceGroupId = targetResourceGroupName != null ? "/subscriptions/" + targetSubscriptionId + "/resourceGroups/" + targetResourceGroupName : null,
                OriginalStorageAccountOption = useOsa,
                RestoreDiskLunList = restoreDiskLUNS,
                DiskEncryptionSetId = DiskEncryptionSetId,
                RestoreWithManagedDisks = restoreWithManagedDisks,
                IdentityInfo = identityInfo,
                IdentityBasedRestoreDetails = identityBasedRestoreDetails
            };

            // make StorageAccountId null in case of MSI based restore
            if (identityBasedRestoreDetails != null)
            {
                restoreRequest.StorageAccountId = null;
            }

            if(targetZones != null)
            {
                restoreRequest.Zones = targetZones;
            }

            // edge zones restore
            if (restoreToEdgeZone)
            {
                if (useSecondaryRegion || targetSubscriptionId != ServiceClientAdapter.SubscriptionId) {                    
                    throw new ArgumentException(String.Format(Resources.CSRAndCRRNotSupportedWithEdgeZoneRestore));
                }
                if(rp.ExtendedLocation == null || rp.ExtendedLocation.Name == null || rp.ExtendedLocation.Name == "")
                {
                    throw new ArgumentException(String.Format(Resources.InvalidEdgeZoneVM));
                }

                restoreRequest.ExtendedLocation = rp.ExtendedLocation;
            }

            if (diskAccessOption != null)
            {
                restoreRequest.TargetDiskNetworkAccessSettings = new TargetDiskNetworkAccessSettings();
                restoreRequest.TargetDiskNetworkAccessSettings.TargetDiskNetworkAccessOption = diskAccessOption;

                if(!string.IsNullOrEmpty(targetDiskAccessId))
                {
                    restoreRequest.TargetDiskNetworkAccessSettings.TargetDiskAccessId = targetDiskAccessId;
                }                
            }

            if (!string.IsNullOrWhiteSpace(cVMOsDiskEncryptionSetId))
            {
                restoreRequest.SecuredVMDetails = new SecuredVMDetails(cVMOsDiskEncryptionSetId);
            }

            if (restoreType == "OriginalLocation") // replace existing
            {
                restoreRequest.RecoveryType = RecoveryType.OriginalLocation;

                if(targetResourceGroupName != null || restoreRequest.TargetResourceGroupId != null)
                {                    
                    throw new ArgumentException(String.Format(Resources.TargetRGNotRequiredException));
                }

                if (rp.ExtendedLocation != null && rp.ExtendedLocation.Name != null && rp.ExtendedLocation.Name != "")
                {
                    restoreRequest.ExtendedLocation = rp.ExtendedLocation;
                }
            }
            else if ( targetVMName != null || targetVNetName != null || targetVNetResourceGroup != null || targetSubnetName != null ) // create new VM
            {
                if(targetVMName == null || targetVNetName == null || targetVNetResourceGroup == null || targetSubnetName == null)
                {                    
                    throw new ArgumentException(String.Format(Resources.TargetParamsMissingException)); 
                }

                restoreRequest.RecoveryType = RecoveryType.AlternateLocation;
                restoreRequest.TargetVirtualMachineId = "/subscriptions/" + targetSubscriptionId + "/resourceGroups/" + targetResourceGroupName + "/providers/Microsoft.Compute/virtualMachines/" + targetVMName;
                restoreRequest.VirtualNetworkId = "/subscriptions/" + targetSubscriptionId + "/resourceGroups/" + targetVNetResourceGroup + "/providers/Microsoft.Network/virtualNetworks/" + targetVNetName;
                restoreRequest.SubnetId = restoreRequest.VirtualNetworkId + "/subnets/" + targetSubnetName;
            }

            RestoreRequestResource triggerRestoreRequest = new RestoreRequestResource();
            triggerRestoreRequest.Properties = restoreRequest;
            
            // Cross Region Restore
            if (useSecondaryRegion)
            {
                // get access token
                CrrModel.CrrAccessToken accessToken = ServiceClientAdapter.GetCRRAccessToken(rp, secondaryRegion, vaultName: vaultName, resourceGroupName: resourceGroupName);

                // Iaas VM CRR Request
                Logger.Instance.WriteDebug("Triggering Restore to secondary region: " + secondaryRegion);
                restoreRequest.Region = secondaryRegion;
                restoreRequest.AffinityGroup = "";

                CrrModel.CrossRegionRestoreRequest crrRestoreRequest = new CrrModel.CrossRegionRestoreRequest();
                crrRestoreRequest.CrossRegionRestoreAccessDetails = accessToken;

                // convert restore request to CRR restore request
                var restoreRequestSerialized = JsonConvert.SerializeObject(restoreRequest);
                CrrModel.IaasVMRestoreRequest restoreRequestForSecondaryRegion = JsonConvert.DeserializeObject<CrrModel.IaasVMRestoreRequest>(restoreRequestSerialized);
                crrRestoreRequest.RestoreRequest = restoreRequestForSecondaryRegion;
                
                var response = ServiceClientAdapter.RestoreDiskSecondryRegion(
                    rp,
                    crrRestoreRequest,
                    storageAccountResource.Location,
                    secondaryRegion: secondaryRegion);
                
                return response;
            }
            else
            {
                #region Rehydrate Restore 
                if (rp.RecoveryPointTier == RecoveryPointTier.VaultArchive && rehydratePriority == null)
                {
                    throw new ArgumentException(Resources.InvalidRehydration);
                }

                if (rp.RecoveryPointTier == RecoveryPointTier.VaultArchive && rehydratePriority != null)
                {
                    // rehydrate restore request                    
                    var iaasVmRestoreRequestSerialized = JsonConvert.SerializeObject(triggerRestoreRequest.Properties);
                    IaasVMRestoreWithRehydrationRequest iaasVMRestoreWithRehydrationRequest = JsonConvert.DeserializeObject<IaasVMRestoreWithRehydrationRequest>(iaasVmRestoreRequestSerialized);
                    
                    iaasVMRestoreWithRehydrationRequest.RecoveryPointRehydrationInfo = new RecoveryPointRehydrationInfo();
                    iaasVMRestoreWithRehydrationRequest.RecoveryPointRehydrationInfo.RehydrationRetentionDuration = "P" + rehydrateDuration + "D"; // P <val> D
                    iaasVMRestoreWithRehydrationRequest.RecoveryPointRehydrationInfo.RehydrationPriority = rehydratePriority;
                    
                    triggerRestoreRequest.Properties = iaasVMRestoreWithRehydrationRequest;                    
                }
                #endregion

                // check for MUA
                bool isMUAProtected = isMUAOperation;

                var response = ServiceClientAdapter.RestoreDisk(
                rp,
                storageAccountResource.Location,
                triggerRestoreRequest,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName,
                vaultLocation: vaultLocation ?? ServiceClientAdapter.BmsAdapter.GetResourceLocation(),
                auxiliaryAccessToken,
                isMUAProtected);

                return response;
            }    
        }

        public ProtectedItemResource GetProtectedItem()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fetches the detail info for the given recovery point
        /// </summary>
        /// <returns>Recovery point detail as returned by the service</returns>
        public RecoveryPointBase GetRecoveryPointDetails()
        {
            return AzureWorkloadProviderHelper.GetRecoveryPointDetails(ProviderData);
        }

        /// <summary>
        /// Provisioning Item Level Recovery Access for the given recovery point
        /// </summary>
        /// <returns>Azure VM client script details as returned by the service</returns>
        public RPMountScriptDetails ProvisionItemLevelRecoveryAccess()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            string content = string.Empty;
            AzureVmRecoveryPoint rp = ProviderData[RestoreBackupItemParams.RecoveryPoint]
                as AzureVmRecoveryPoint;
            if (rp.EncryptionEnabled == true)
            {
                throw new ArgumentException(Resources.ILREncryptedVmError);
            }
            content = string.Empty;

            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(rp.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, rp.Id);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, rp.Id);

            IaasVmilrRegistrationRequest registrationRequest =
                new IaasVmilrRegistrationRequest();
            registrationRequest.RecoveryPointId = rp.RecoveryPointId;
            registrationRequest.VirtualMachineId = rp.SourceResourceId;
            registrationRequest.RenewExistingRegistration = (rp.IlrSessionActive == false) ? false : true;

            var ilRResponse = ServiceClientAdapter.ProvisioninItemLevelRecoveryAccess(
                containerUri,
                protectedItemName,
                rp.RecoveryPointId,
                registrationRequest,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);

            IEnumerable<string> ie =
                    ilRResponse.Response.Headers.GetValues("Azure-AsyncOperation");
            string asyncHeader = string.Empty;
            foreach (string s in ie)
            {
                asyncHeader = s;
            }

            AzureVmRPMountScriptDetails result = null;
            var response = TrackingHelpers.GetOperationStatus(
                ilRResponse,
                operationId => ServiceClientAdapter.GetProtectedItemOperationStatus(
                    operationId,
                    vaultName: vaultName,
                    resourceGroupName: resourceGroupName));

            if (response != null && response.Status != null &&
                   response.Properties != null && ((OperationStatusProvisionILRExtendedInfo)
                   response.Properties).RecoveryTarget != null)
            {
                InstantItemRecoveryTarget recoveryTarget =
                    ((OperationStatusProvisionILRExtendedInfo)
                    response.Properties).RecoveryTarget;

                if (recoveryTarget.ClientScripts.Count != 0)
                {
                    if (recoveryTarget.ClientScripts.Count == 2)
                    {
                        // clientScriptForConnection.OsType == "Windows"
                        result = this.GenerateILRResponseForWindowsVMs(
                                recoveryTarget.ClientScripts[1], out content);
                    }
                    else
                    {
                        // clientScriptForConnection.OsType == "Linux"
                        result = this.GenerateILRResponseForLinuxVMs(
                                recoveryTarget.ClientScripts[0],
                                protectedItemName, rp.RecoveryPointTime.ToString(), out content);
                    }
                }
            }

            string scriptDownloadLocation =
                    (string)ProviderData[RecoveryPointParams.FileDownloadLocation];
            if (string.IsNullOrEmpty(scriptDownloadLocation))
            {
                scriptDownloadLocation = Directory.GetCurrentDirectory();
            }
            result.FilePath = Path.Combine(scriptDownloadLocation, result.Filename);
            AzureSession.Instance.DataStore.WriteFile(result.FilePath, Convert.FromBase64String(content));

            Logger.Instance.WriteVerbose(string.Format(
                Resources.MountRecoveryPointInfoMessage, result.FilePath, result.Password));
            return result;
        }

        /// <summary>
        /// Revoke Item Level Recovery Access for the given recovery point
        /// </summary>
        /// <returns></returns>
        public void RevokeItemLevelRecoveryAccess()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            AzureVmRecoveryPoint rp = ProviderData[RestoreBackupItemParams.RecoveryPoint]
                as AzureVmRecoveryPoint;

            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(rp.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, rp.Id);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, rp.Id);

            var ilRResponse = ServiceClientAdapter.RevokeItemLevelRecoveryAccess(
                containerUri,
                protectedItemName,
                rp.RecoveryPointId,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);

            IEnumerable<string> ie =
                    ilRResponse.Response.Headers.GetValues("Azure-AsyncOperation");
            string asyncHeader = string.Empty;
            foreach (string s in ie)
            {
                asyncHeader = s;
            }

            var response = TrackingHelpers.GetOperationStatus(
                ilRResponse,
                operationId => ServiceClientAdapter.GetProtectedItemOperationStatus(
                    operationId,
                    vaultName: vaultName,
                    resourceGroupName: resourceGroupName));

            if (response != null && response.Status != null)
            {
                Logger.Instance.WriteDebug("Completed the call with status code" + response.Status.ToString());
            }
        }

        /// <summary>
        /// Lists recovery points generated for the given item
        /// </summary>
        /// <returns>List of recovery point PowerShell model objects</returns>
        public List<RecoveryPointBase> ListRecoveryPoints()
        {
            return AzureWorkloadProviderHelper.ListRecoveryPoints(ProviderData);
        }

        /// <summary>
        /// Creates policy given the provider data
        /// </summary>
        /// <returns>Created policy object as returned by the service</returns>
        public ProtectionPolicyResource CreatePolicy()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            string policyName = (string)ProviderData[PolicyParams.PolicyName];
            CmdletModel.WorkloadType workloadType =
                (CmdletModel.WorkloadType)ProviderData[PolicyParams.WorkloadType];
            RetentionPolicyBase retentionPolicy =
                ProviderData.ContainsKey(PolicyParams.RetentionPolicy) ?
                (RetentionPolicyBase)ProviderData[PolicyParams.RetentionPolicy] :
                null;
            SchedulePolicyBase schedulePolicy =
                ProviderData.ContainsKey(PolicyParams.SchedulePolicy) ?
                (SchedulePolicyBase)ProviderData[PolicyParams.SchedulePolicy] :
                null;
            CmdletModel.TieringPolicy tieringDetails = ProviderData.ContainsKey(PolicyParams.TieringPolicy) ? (CmdletModel.TieringPolicy)ProviderData[PolicyParams.TieringPolicy] : null;
            bool isSmartTieringEnabled = ProviderData.ContainsKey(PolicyParams.IsSmartTieringEnabled) ? (bool)ProviderData[PolicyParams.IsSmartTieringEnabled] : false;

            string snapshotRGName = (string)ProviderData[PolicyParams.BackupSnapshotResourceGroup];
            string snapshotRGNameSuffix = (string)ProviderData[PolicyParams.BackupSnapshotResourceGroupSuffix];
            SnapshotConsistencyType snapshotConsistencyType = (SnapshotConsistencyType)ProviderData[PolicyParams.SnapshotConsistencyType];

            // do validations
            ValidateAzureVMWorkloadType(workloadType);                       

            AzureWorkloadProviderHelper.ValidateSimpleSchedulePolicy(schedulePolicy, ServiceClientModel.BackupManagementType.AzureIaasVM);
            
            Logger.Instance.WriteDebug("Validation of Schedule policy is successful");

            // validate RetentionPolicy
            AzureWorkloadProviderHelper.ValidateLongTermRetentionPolicy(retentionPolicy);
            Logger.Instance.WriteDebug("Validation of Retention policy is successful");
                        
            // update the retention times from backupSchedule to retentionPolicy after converting to UTC           
            AzureWorkloadProviderHelper.CopyScheduleTimeToRetentionTimes((CmdletModel.LongTermRetentionPolicy)retentionPolicy,
                                             schedulePolicy); 

            Logger.Instance.WriteDebug("Copy of RetentionTime from with SchedulePolicy to RetentionPolicy is successful");
            
            // Now validate both RetentionPolicy and SchedulePolicy together
            if (schedulePolicy.GetType() == typeof(CmdletModel.SimpleSchedulePolicy))
            {
                PolicyHelpers.ValidateLongTermRetentionPolicyWithSimpleSchedulePolicy(
                                (CmdletModel.LongTermRetentionPolicy)retentionPolicy,
                                (CmdletModel.SimpleSchedulePolicy)schedulePolicy); 
            }
            else if (schedulePolicy.GetType() == typeof(CmdletModel.SimpleSchedulePolicyV2))
            {
                PolicyHelpers.ValidateLongTermRetentionPolicyWithSimpleSchedulePolicy(
                                (CmdletModel.LongTermRetentionPolicy)retentionPolicy,
                                (CmdletModel.SimpleSchedulePolicyV2)schedulePolicy);
            }
                
            Logger.Instance.WriteDebug("Validation of Retention policy with Schedule policy is successful");

            PolicyHelpers.ValidateLongTermRetentionPolicyWithTieringPolicy((CmdletModel.LongTermRetentionPolicy)retentionPolicy, tieringDetails);            
            Logger.Instance.WriteDebug("Validation of Retention policy with Tiering policy is successful");

            int snapshotRetentionInDays = 2;
            if (schedulePolicy.GetType() == typeof(CmdletModel.SimpleSchedulePolicy) && ((CmdletModel.SimpleSchedulePolicy)schedulePolicy).ScheduleRunFrequency == CmdletModel.ScheduleRunType.Weekly)
            {
                snapshotRetentionInDays = 5;
            }
            else if (schedulePolicy.GetType() == typeof(CmdletModel.SimpleSchedulePolicyV2))
            {
                snapshotRetentionInDays = 7;
            }

            // timeZone should be customizable 
            string timeZone = DateTimeKind.Utc.ToString().ToUpper(); 
            if (schedulePolicy.GetType() == typeof(CmdletModel.SimpleSchedulePolicyV2))
            {
                string timeZoneInput = ((CmdletModel.SimpleSchedulePolicyV2)schedulePolicy).ScheduleRunTimeZone;
                
                if(timeZoneInput != null)
                {
                    timeZone = timeZoneInput;
                }                
            }
            else if(schedulePolicy.GetType() == typeof(CmdletModel.SimpleSchedulePolicy))
            {
                string timeZoneInput = ((CmdletModel.SimpleSchedulePolicy)schedulePolicy).ScheduleRunTimeZone;

                if (timeZoneInput != null)
                {
                    timeZone = timeZoneInput;
                }
            }

            InstantRPAdditionalDetails instantRPAdditionalDetails = null;
            if (snapshotRGName != null)
            {
                instantRPAdditionalDetails = new InstantRPAdditionalDetails();

                instantRPAdditionalDetails.AzureBackupRgNamePrefix = snapshotRGName;
                if (snapshotRGNameSuffix != null) instantRPAdditionalDetails.AzureBackupRgNameSuffix = snapshotRGNameSuffix;
            }
            else if(snapshotRGNameSuffix != null)
            {                
                throw new ArgumentException(String.Format(Resources.RequiredBackupSnapshotResourceGroup));
            }

            string consistencyType = null;
            if (snapshotConsistencyType != 0)
            {
                if (!((schedulePolicy.GetType() == typeof(CmdletModel.SimpleSchedulePolicyV2))))
                {
                    throw new ArgumentException(string.Format(Resources.SnapshotConsistencyTypeCantBeSetForStandardPolicy));
                }

                if (snapshotConsistencyType == SnapshotConsistencyType.OnlyCrashConsistent)
                {
                    consistencyType = snapshotConsistencyType.ToString();
                }
            }

            // construct Service Client policy request            
            ProtectionPolicyResource serviceClientRequest = new ProtectionPolicyResource()
            {
                Properties = new AzureIaaSVMProtectionPolicy()
                {
                    RetentionPolicy = PolicyHelpers.GetServiceClientLongTermRetentionPolicy(
                                                (CmdletModel.LongTermRetentionPolicy)retentionPolicy),
                    SchedulePolicy = PolicyHelpers.GetServiceClientSimpleSchedulePolicy(schedulePolicy),
                    TieringPolicy = PolicyHelpers.GetServiceClientTieringPolicy(tieringDetails, isSmartTieringEnabled),
                    PolicyType = (schedulePolicy.GetType() == typeof(CmdletModel.SimpleSchedulePolicyV2)) ? "V2" : null,
                    TimeZone = timeZone,
                    InstantRpRetentionRangeInDays = snapshotRetentionInDays,
                    InstantRpDetails = instantRPAdditionalDetails,
                    SnapshotConsistencyType = consistencyType
                }
            };

            return ServiceClientAdapter.CreateOrUpdateProtectionPolicy(
                policyName,
                serviceClientRequest,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName).Body;
        }

        /// <summary>
        /// Modifies policy using the provider data
        /// </summary>
        /// <returns>Modified policy object as returned by the service</returns>
        public RestAzureNS.AzureOperationResponse<ProtectionPolicyResource> ModifyPolicy()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];

            string auxiliaryAccessToken = ProviderData.ContainsKey(ResourceGuardParams.Token) ? (string)ProviderData[ResourceGuardParams.Token] : null;
            bool isMUAOperation = ProviderData.ContainsKey(ResourceGuardParams.IsMUAOperation) ? (bool)ProviderData[ResourceGuardParams.IsMUAOperation] : false;            
            ProtectionPolicyResource existingPolicy = ProviderData.ContainsKey(PolicyParams.ExistingPolicy) ? (ProtectionPolicyResource)ProviderData[PolicyParams.ExistingPolicy] : null;

            RetentionPolicyBase retentionPolicy = ProviderData.ContainsKey(PolicyParams.RetentionPolicy) ? (RetentionPolicyBase)ProviderData[PolicyParams.RetentionPolicy] : null;
            SchedulePolicyBase schedulePolicy = ProviderData.ContainsKey(PolicyParams.SchedulePolicy) ? (SchedulePolicyBase)ProviderData[PolicyParams.SchedulePolicy] : null;
            PolicyBase policy = ProviderData.ContainsKey(PolicyParams.ProtectionPolicy) ? (PolicyBase)ProviderData[PolicyParams.ProtectionPolicy] : null;

            CmdletModel.TieringPolicy tieringDetails = ProviderData.ContainsKey(PolicyParams.TieringPolicy) ? (CmdletModel.TieringPolicy)ProviderData[PolicyParams.TieringPolicy] : null;
            bool isSmartTieringEnabled = ProviderData.ContainsKey(PolicyParams.IsSmartTieringEnabled) ? (bool)ProviderData[PolicyParams.IsSmartTieringEnabled] : false;

            string snapshotRGName = (string)ProviderData[PolicyParams.BackupSnapshotResourceGroup];
            string snapshotRGNameSuffix = (string)ProviderData[PolicyParams.BackupSnapshotResourceGroupSuffix];
            SnapshotConsistencyType snapshotConsistencyType = (SnapshotConsistencyType)ProviderData[PolicyParams.SnapshotConsistencyType];

            // do validations
            ValidateAzureVMProtectionPolicy(policy);
            Logger.Instance.WriteDebug("Validation of Protection Policy is successful");

            // validate RetentionPolicy and SchedulePolicy
            if (schedulePolicy != null)
            {
                AzureWorkloadProviderHelper.ValidateSimpleSchedulePolicy(schedulePolicy, ServiceClientModel.BackupManagementType.AzureIaasVM);
                ((AzureVmPolicy)policy).SchedulePolicy = schedulePolicy;
                Logger.Instance.WriteDebug("Validation of Schedule policy is successful");
            }
            if (retentionPolicy != null)
            {
                AzureWorkloadProviderHelper.ValidateLongTermRetentionPolicy(retentionPolicy);
                ((AzureVmPolicy)policy).RetentionPolicy = retentionPolicy;
                Logger.Instance.WriteDebug("Validation of Retention policy is successful");
            }

            // copy the backupSchedule time to retentionPolicy after converting to UTC
            AzureWorkloadProviderHelper.CopyScheduleTimeToRetentionTimes((CmdletModel.LongTermRetentionPolicy)((AzureVmPolicy)policy).RetentionPolicy,
                            ((AzureVmPolicy)policy).SchedulePolicy);

            Logger.Instance.WriteDebug("Copy of RetentionTime from with SchedulePolicy to RetentionPolicy is successful");

            // Now validate both RetentionPolicy and SchedulePolicy matches or not
            if (((AzureVmPolicy)policy).SchedulePolicy.GetType() == typeof(CmdletModel.SimpleSchedulePolicy))
            {
                PolicyHelpers.ValidateLongTermRetentionPolicyWithSimpleSchedulePolicy(
                                (CmdletModel.LongTermRetentionPolicy)((AzureVmPolicy)policy).RetentionPolicy,
                                (CmdletModel.SimpleSchedulePolicy)((AzureVmPolicy)policy).SchedulePolicy);
            }
            else if (((AzureVmPolicy)policy).SchedulePolicy.GetType() == typeof(CmdletModel.SimpleSchedulePolicyV2))
            {
                PolicyHelpers.ValidateLongTermRetentionPolicyWithSimpleSchedulePolicy(
                                (CmdletModel.LongTermRetentionPolicy)((AzureVmPolicy)policy).RetentionPolicy,
                                (CmdletModel.SimpleSchedulePolicyV2)((AzureVmPolicy)policy).SchedulePolicy);
            }

            Logger.Instance.WriteDebug("Validation of Retention policy with Schedule policy is successful");


            if (tieringDetails != null)
            {                
                PolicyHelpers.ValidateLongTermRetentionPolicyWithTieringPolicy((CmdletModel.LongTermRetentionPolicy)((AzureVmPolicy)policy).RetentionPolicy, tieringDetails);

                ((AzureVmPolicy)policy).TieringPolicy = tieringDetails;
                Logger.Instance.WriteDebug("Validation of Retention policy with Tiering policy is successful");
            }
            else if(((AzureVmPolicy)policy).TieringPolicy != null)
            {
                PolicyHelpers.ValidateLongTermRetentionPolicyWithTieringPolicy((CmdletModel.LongTermRetentionPolicy)((AzureVmPolicy)policy).RetentionPolicy, ((AzureVmPolicy)policy).TieringPolicy, true);
            }

            //Validate instant RP retention days
            ValidateInstantRPRetentionDays(((AzureVmPolicy)policy));

            // timeZone should be customizable
            string timeZone = DateTimeKind.Utc.ToString().ToUpper();
            if (((AzureVmPolicy)policy).SchedulePolicy.GetType() == typeof(CmdletModel.SimpleSchedulePolicyV2))
            {
                string timeZoneInput = ((CmdletModel.SimpleSchedulePolicyV2)((AzureVmPolicy)policy).SchedulePolicy).ScheduleRunTimeZone;

                if (timeZoneInput != null)
                {
                    timeZone = timeZoneInput;
                }
            }
            else if (((AzureVmPolicy)policy).SchedulePolicy.GetType() == typeof(CmdletModel.SimpleSchedulePolicy))
            {
                string timeZoneInput = ((CmdletModel.SimpleSchedulePolicy)((AzureVmPolicy)policy).SchedulePolicy).ScheduleRunTimeZone;

                if (timeZoneInput != null)
                {
                    timeZone = timeZoneInput;
                }
            }

            InstantRPAdditionalDetails instantRPAdditionalDetails = null;
            if (snapshotRGName != null)
            {
                instantRPAdditionalDetails = new InstantRPAdditionalDetails();

                instantRPAdditionalDetails.AzureBackupRgNamePrefix = snapshotRGName;
                if (snapshotRGNameSuffix != null) instantRPAdditionalDetails.AzureBackupRgNameSuffix = snapshotRGNameSuffix;
            }
            else if (snapshotRGNameSuffix != null)
            {
                throw new ArgumentException(String.Format(Resources.RequiredBackupSnapshotResourceGroup));
            }

            string consistencyType = ((AzureVmPolicy)policy).SnapshotConsistencyType;
            if(snapshotConsistencyType != 0)
            {
                if(!(((AzureVmPolicy)policy).SchedulePolicy.GetType() == typeof(CmdletModel.SimpleSchedulePolicyV2)))
                {                    
                    throw new ArgumentException(string.Format(Resources.SnapshotConsistencyTypeCantBeSetForStandardPolicy));
                }

                if (snapshotConsistencyType == SnapshotConsistencyType.Default){
                    consistencyType = null;
                }
                else
                {
                    consistencyType = snapshotConsistencyType.ToString();
                }
            }

            // construct Service Client policy request            
            ProtectionPolicyResource serviceClientRequest = new ProtectionPolicyResource()
            {
                Properties = new AzureIaaSVMProtectionPolicy()
                {
                    RetentionPolicy = PolicyHelpers.GetServiceClientLongTermRetentionPolicy(
                                  (CmdletModel.LongTermRetentionPolicy)((AzureVmPolicy)policy).RetentionPolicy),
                    SchedulePolicy = PolicyHelpers.GetServiceClientSimpleSchedulePolicy(((AzureVmPolicy)policy).SchedulePolicy),
                    TieringPolicy = PolicyHelpers.GetServiceClientTieringPolicy(((AzureVmPolicy)policy).TieringPolicy, isSmartTieringEnabled),
                    TimeZone = timeZone,
                    PolicyType = (((AzureVmPolicy)policy).SchedulePolicy.GetType() == typeof(CmdletModel.SimpleSchedulePolicyV2)) ? "V2" : null,
                    InstantRpRetentionRangeInDays = ((AzureVmPolicy)policy).SnapshotRetentionInDays,
                    InstantRpDetails = (instantRPAdditionalDetails != null)? instantRPAdditionalDetails : new InstantRPAdditionalDetails(
                        ((AzureVmPolicy)policy).AzureBackupRGName,
                        ((AzureVmPolicy)policy).AzureBackupRGNameSuffix),
                    SnapshotConsistencyType = consistencyType
                }
            };

            // check for MUA
            bool isMUAProtected = false;
            if (existingPolicy != null)
            {
                isMUAProtected = AzureWorkloadProviderHelper.checkMUAForModifyPolicy(existingPolicy, serviceClientRequest, isMUAOperation);
            }

            return ServiceClientAdapter.CreateOrUpdateProtectionPolicy(
                policy.Name,
                serviceClientRequest,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName,
                auxiliaryAccessToken, 
                isMUAProtected);
        }

        /// <summary>
        /// Lists protection containers according to the provider data
        /// </summary>
        /// <returns>List of protection containers</returns>
        public List<ContainerBase> ListProtectionContainers()
        {
            string resourceGroupName = (string)ProviderData[ContainerParams.ResourceGroupName];
            CmdletModel.BackupManagementType? backupManagementTypeNullable =
                (CmdletModel.BackupManagementType?)
                    ProviderData[ContainerParams.BackupManagementType];

            if (backupManagementTypeNullable.HasValue)
            {
                ValidateAzureVMBackupManagementType(backupManagementTypeNullable.Value);
            }

            var containerModels = AzureWorkloadProviderHelper.ListProtectionContainers(
                ProviderData,
                ServiceClientModel.BackupManagementType.AzureIaasVM);

            // Filter by RG Name
            if (!string.IsNullOrEmpty(resourceGroupName))
            {
                containerModels = containerModels.Where(
                    containerModel =>
                    {
                        return string.Compare(
                            (containerModel as AzureVmContainer).ResourceGroupName,
                            resourceGroupName,
                            true) == 0;
                    }).ToList();
            }

            return containerModels;
        }

        public List<CmdletModel.BackupEngineBase> ListBackupManagementServers()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lists protected items protected by the recovery services vault according to the provider data
        /// </summary>
        /// <returns>List of protected items</returns>
        public List<ItemBase> ListProtectedItems()
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            ContainerBase container = (ContainerBase)ProviderData[ItemParams.Container];
            string itemName = (string)ProviderData[ItemParams.ItemName];
            ItemProtectionStatus protectionStatus =
                (ItemProtectionStatus)ProviderData[ItemParams.ProtectionStatus];
            ItemProtectionState status =
                (ItemProtectionState)ProviderData[ItemParams.ProtectionState];
            CmdletModel.WorkloadType workloadType =
                (CmdletModel.WorkloadType)ProviderData[ItemParams.WorkloadType];
            ItemDeleteState deleteState =
               (ItemDeleteState)ProviderData[ItemParams.DeleteState];
            bool UseSecondaryRegion = (bool)ProviderData[CRRParams.UseSecondaryRegion];            
            PolicyBase policy = (PolicyBase)ProviderData[PolicyParams.ProtectionPolicy];            
                        
            // 1. Filter by container
            List<CrrModel.ProtectedItemResource> protectedItemsCrr = null;
            List<ProtectedItemResource> protectedItems = null;
            List<ItemBase> itemModels = null;
            if (UseSecondaryRegion)
            {
                protectedItemsCrr = AzureWorkloadProviderHelper.ListProtectedItemsByContainerCrr(
                vaultName,
                resourceGroupName,
                container,
                policy,
                ServiceClientModel.BackupManagementType.AzureIaasVM,
                DataSourceType.VM);                

                // 2. Filter by item name
                itemModels = AzureWorkloadProviderHelper.ListProtectedItemsByItemNameCrr(
                    protectedItemsCrr,
                    itemName,
                    vaultName,
                    resourceGroupName,
                    (itemModel, protectedItemGetResponse) =>
                    {
                        AzureVmItemExtendedInfo extendedInfo = new AzureVmItemExtendedInfo();
                        var serviceClientExtendedInfo = ((AzureIaaSVMProtectedItem)protectedItemGetResponse.Properties).ExtendedInfo;
                        if (serviceClientExtendedInfo.OldestRecoveryPoint.HasValue)
                        {
                            extendedInfo.OldestRecoveryPoint = serviceClientExtendedInfo.OldestRecoveryPoint;
                        }
                        extendedInfo.PolicyState = serviceClientExtendedInfo.PolicyInconsistent.ToString();
                        extendedInfo.RecoveryPointCount =
                            (int)(serviceClientExtendedInfo.RecoveryPointCount.HasValue ?
                                serviceClientExtendedInfo.RecoveryPointCount : 0);
                        ((AzureVmItem)itemModel).ExtendedInfo = extendedInfo;
                    });                
            }
            else
            {
                protectedItems = AzureWorkloadProviderHelper.ListProtectedItemsByContainer(
                    vaultName,
                    resourceGroupName,
                    container,
                    policy,
                    ServiceClientModel.BackupManagementType.AzureIaasVM,
                    DataSourceType.VM);

                // 2. Filter by item name
                itemModels = AzureWorkloadProviderHelper.ListProtectedItemsByItemName(
                    protectedItems,
                    itemName,
                    vaultName,
                    resourceGroupName,
                    (itemModel, protectedItemGetResponse) =>
                    {
                        AzureVmItemExtendedInfo extendedInfo = new AzureVmItemExtendedInfo();
                        var serviceClientExtendedInfo = ((AzureIaaSVMProtectedItem)protectedItemGetResponse.Properties).ExtendedInfo;
                        if (serviceClientExtendedInfo.OldestRecoveryPoint.HasValue)
                        {
                            extendedInfo.OldestRecoveryPoint = serviceClientExtendedInfo.OldestRecoveryPoint;
                        }
                        extendedInfo.PolicyState = serviceClientExtendedInfo.PolicyInconsistent.ToString();
                        extendedInfo.RecoveryPointCount =
                            (int)(serviceClientExtendedInfo.RecoveryPointCount.HasValue ?
                                serviceClientExtendedInfo.RecoveryPointCount : 0);
                        ((AzureVmItem)itemModel).ExtendedInfo = extendedInfo;
                    });
            }
            
            // 3. Filter by item's Protection Status
            if (protectionStatus != 0)
            {                
                itemModels = itemModels.Where(itemModel =>
                {
                    return ((AzureVmItem)itemModel).ProtectionStatus == protectionStatus;
                }).ToList();
            }
            
            // 4. Filter by item's Protection State
            if (status != 0)
            {                
                itemModels = itemModels.Where(itemModel =>
                {
                    return ((AzureVmItem)itemModel).ProtectionState == status;
                }).ToList();
            }
            
            // 5. Filter by workload type
            if (workloadType != 0)
            {                
                itemModels = itemModels.Where(itemModel =>
                {
                    return itemModel.WorkloadType == workloadType;
                }).ToList();
            }
            
            // 6. Filter by Delete State
            if (deleteState != 0)
            {                
                itemModels = itemModels.Where(itemModel =>
                {
                    return ((AzureVmItem)itemModel).DeleteState == deleteState;
                }).ToList();
            }
            
            return itemModels;
        }

        /// <summary>
        /// Constructs the schedule policy object with default inits
        /// </summary>
        /// <returns>Default schedule policy object</returns>
        public SchedulePolicyBase GetDefaultSchedulePolicyObject()
        {
            CmdletModel.ScheduleRunType scheduleRunFrequency = (CmdletModel.ScheduleRunType)ProviderData[PolicyParams.ScheduleRunFrequency];
            CmdletModel.PSPolicyType policySubType = (CmdletModel.PSPolicyType)ProviderData[PolicyParams.PolicySubType];

            if(policySubType == CmdletModel.PSPolicyType.Enhanced)
            {
                CmdletModel.SimpleSchedulePolicyV2 defaultSchedule = new CmdletModel.SimpleSchedulePolicyV2();
                
                //Default is daily schedule at 10:30 AM local time
                defaultSchedule.ScheduleRunFrequency = scheduleRunFrequency;
                DateTime scheduleTime = AzureWorkloadProviderHelper.GenerateRandomScheduleTime();

                if (scheduleRunFrequency == CmdletModel.ScheduleRunType.Daily)
                {
                    defaultSchedule.DailySchedule = new CmdletModel.DailySchedule();
                    defaultSchedule.DailySchedule.ScheduleRunTimes = new List<DateTime>();
                    defaultSchedule.DailySchedule.ScheduleRunTimes.Add(scheduleTime);
                }
                else if (scheduleRunFrequency == CmdletModel.ScheduleRunType.Weekly)
                {
                    defaultSchedule.WeeklySchedule = new CmdletModel.WeeklySchedule();
                    defaultSchedule.WeeklySchedule.ScheduleRunTimes = new List<DateTime>();
                    defaultSchedule.WeeklySchedule.ScheduleRunTimes.Add(scheduleTime);
                    defaultSchedule.WeeklySchedule.ScheduleRunDays = new List<System.DayOfWeek>();
                    defaultSchedule.WeeklySchedule.ScheduleRunDays.Add(System.DayOfWeek.Sunday);
                }
                else if (scheduleRunFrequency == CmdletModel.ScheduleRunType.Hourly) 
                {
                    int hour = 07, minute = 30;
                    scheduleTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                        DateTime.Now.Day, hour, minute, 00, 00, DateTimeKind.Utc);
                    
                    defaultSchedule.HourlySchedule = new CmdletModel.HourlySchedule();
                    defaultSchedule.HourlySchedule.WindowStartTime = scheduleTime;
                    defaultSchedule.HourlySchedule.Interval = 4;
                    defaultSchedule.HourlySchedule.WindowDuration = 24;                    
                }

                defaultSchedule.ScheduleRunTimeZone = DateTimeKind.Utc.ToString().ToUpper();

                return defaultSchedule;
            }
            else
            {
                CmdletModel.SimpleSchedulePolicy defaultSchedule = new CmdletModel.SimpleSchedulePolicy();
                
                //Default is daily schedule at 10:30 AM local time
                defaultSchedule.ScheduleRunFrequency = scheduleRunFrequency;

                if (scheduleRunFrequency == CmdletModel.ScheduleRunType.Daily || scheduleRunFrequency == CmdletModel.ScheduleRunType.Weekly)
                {
                    DateTime scheduleTime = AzureWorkloadProviderHelper.GenerateRandomScheduleTime();
                    defaultSchedule.ScheduleRunTimes = new List<DateTime>();
                    defaultSchedule.ScheduleRunTimes.Add(scheduleTime);

                    defaultSchedule.ScheduleRunDays = new List<System.DayOfWeek>();
                    defaultSchedule.ScheduleRunDays.Add(System.DayOfWeek.Sunday);
                }

                else if (scheduleRunFrequency == CmdletModel.ScheduleRunType.Hourly)
                {
                    throw new ArgumentException(Resources.StandardHourlyScheduleNotSupported);
                }
                return defaultSchedule;
            }
        }

        /// <summary>
        /// Constructs the retention policy object with default inits
        /// </summary>
        /// <returns>Default retention policy object</returns>
        public RetentionPolicyBase GetDefaultRetentionPolicyObject()
        {
            CmdletModel.LongTermRetentionPolicy defaultRetention = new CmdletModel.LongTermRetentionPolicy();
            CmdletModel.ScheduleRunType scheduleRunFrequency = (CmdletModel.ScheduleRunType)ProviderData[PolicyParams.ScheduleRunFrequency];

            //Default time is 10:30 local time
            DateTime retentionTime = AzureWorkloadProviderHelper.GenerateRandomScheduleTime();

            //Daily Retention policy
            if(scheduleRunFrequency != CmdletModel.ScheduleRunType.Weekly)
            {
                defaultRetention.IsDailyScheduleEnabled = true;
                defaultRetention.DailySchedule = new CmdletModel.DailyRetentionSchedule();
                defaultRetention.DailySchedule.RetentionTimes = new List<DateTime>();
                defaultRetention.DailySchedule.RetentionTimes.Add(retentionTime);
                defaultRetention.DailySchedule.DurationCountInDays = 180; //TBD make it const
            }

            //Weekly Retention policy
            defaultRetention.IsWeeklyScheduleEnabled = true;
            defaultRetention.WeeklySchedule = new CmdletModel.WeeklyRetentionSchedule();
            defaultRetention.WeeklySchedule.DaysOfTheWeek = new List<System.DayOfWeek>();
            defaultRetention.WeeklySchedule.DaysOfTheWeek.Add(System.DayOfWeek.Sunday);
            defaultRetention.WeeklySchedule.DurationCountInWeeks = 104; //TBD make it const
            defaultRetention.WeeklySchedule.RetentionTimes = new List<DateTime>();
            defaultRetention.WeeklySchedule.RetentionTimes.Add(retentionTime);

            //Monthly retention policy
            defaultRetention.IsMonthlyScheduleEnabled = true;
            defaultRetention.MonthlySchedule = new CmdletModel.MonthlyRetentionSchedule();
            defaultRetention.MonthlySchedule.DurationCountInMonths = 60; //tbd: make it const
            defaultRetention.MonthlySchedule.RetentionTimes = new List<DateTime>();
            defaultRetention.MonthlySchedule.RetentionTimes.Add(retentionTime);
            defaultRetention.MonthlySchedule.RetentionScheduleFormatType =
                CmdletModel.RetentionScheduleFormat.Weekly;

            //Initialize day based schedule
            defaultRetention.MonthlySchedule.RetentionScheduleDaily = AzureWorkloadProviderHelper.GetDailyRetentionFormat();

            //Initialize Week based schedule
            defaultRetention.MonthlySchedule.RetentionScheduleWeekly = AzureWorkloadProviderHelper.GetWeeklyRetentionFormat();

            //Yearly retention policy
            defaultRetention.IsYearlyScheduleEnabled = true;
            defaultRetention.YearlySchedule = new CmdletModel.YearlyRetentionSchedule();
            defaultRetention.YearlySchedule.DurationCountInYears = 10;
            defaultRetention.YearlySchedule.RetentionTimes = new List<DateTime>();
            defaultRetention.YearlySchedule.RetentionTimes.Add(retentionTime);
            defaultRetention.YearlySchedule.RetentionScheduleFormatType =
                CmdletModel.RetentionScheduleFormat.Weekly;
            defaultRetention.YearlySchedule.MonthsOfYear = new List<Month>();
            defaultRetention.YearlySchedule.MonthsOfYear.Add(Month.January);
            defaultRetention.YearlySchedule.RetentionScheduleDaily = AzureWorkloadProviderHelper.GetDailyRetentionFormat();
            defaultRetention.YearlySchedule.RetentionScheduleWeekly = AzureWorkloadProviderHelper.GetWeeklyRetentionFormat();
            return defaultRetention;

        }
        public void RegisterContainer()
        {
            throw new NotImplementedException();
        }

        public void UndeleteContainer()
        {
            throw new NotImplementedException();
        }

        #region private
        private void ValidateProtectedItemCount(AzureVmPolicy azureVmPolicy)
        {
            if (azureVmPolicy.ProtectedItemsCount > 1000)
            {
                throw new ArgumentException(Resources.ProtectedItemsCountExceededException);
            }
        }

        private void ValidateAzureVMWorkloadType(CmdletModel.WorkloadType type)
        {
            if (type != CmdletModel.WorkloadType.AzureVM)
            {
                throw new ArgumentException(string.Format(Resources.UnExpectedWorkLoadTypeException,
                                            CmdletModel.WorkloadType.AzureVM.ToString(),
                                            type.ToString()));
            }
        }
        
        private void ValidateAzureVMWorkloadType(CmdletModel.WorkloadType itemWorkloadType,
            CmdletModel.WorkloadType policyWorkloadType)
        {
            ValidateAzureVMWorkloadType(itemWorkloadType);
            ValidateAzureVMWorkloadType(policyWorkloadType);
            if (itemWorkloadType != policyWorkloadType)
            {
                throw new ArgumentException(string.Format(Resources.UnExpectedWorkLoadTypeException,
                                            CmdletModel.WorkloadType.AzureVM.ToString(),
                                            itemWorkloadType.ToString()));
            }
        }

        private void ValidateAzureVMContainerType(CmdletModel.ContainerType type)
        {
            if (type != CmdletModel.ContainerType.AzureVM)
            {
                throw new ArgumentException(string.Format(Resources.UnExpectedContainerTypeException,
                                            CmdletModel.ContainerType.AzureVM.ToString(),
                                            type.ToString()));
            }
        }

        private void ValidateAzureVMBackupManagementType(
            CmdletModel.BackupManagementType backupManagementType)
        {
            if (backupManagementType != CmdletModel.BackupManagementType.AzureVM)
            {
                throw new ArgumentException(string.Format(Resources.UnExpectedBackupManagementTypeException,
                                            CmdletModel.BackupManagementType.AzureVM.ToString(),
                                            backupManagementType.ToString()));
            }
        }

        private void ValidateAzureVMProtectionPolicy(PolicyBase policy)
        {
            if (policy == null || policy.GetType() != typeof(AzureVmPolicy))
            {
                throw new ArgumentException(string.Format(Resources.InvalidProtectionPolicyException,
                                            typeof(AzureVmPolicy).ToString()));
            }

            ValidateAzureVMWorkloadType(policy.WorkloadType);
            // call validation
            policy.Validate();
        }

        private void ValidateAzureVMEnableProtectionRequest(string vmName, string serviceName, string rgName,
            PolicyBase policy)
        {
            if (string.IsNullOrEmpty(vmName))
            {
                throw new ArgumentException(string.Format(Resources.InvalidAzureVMName));
            }
            if (string.IsNullOrEmpty(rgName) && string.IsNullOrEmpty(serviceName))
            {
                throw new ArgumentException(
                    string.Format(Resources.BothCloudServiceNameAndResourceGroupNameShouldNotEmpty)
                    );
            }
        }

        private void ValidateAzureVMModifyProtectionRequest(ItemBase itemBase,
            PolicyBase policy)
        {
            if (itemBase == null || itemBase.GetType() != typeof(AzureVmItem))
            {
                throw new ArgumentException(string.Format(Resources.InvalidProtectionPolicyException,
                                            typeof(AzureVmItem).ToString()));
            }

            if (string.IsNullOrEmpty(((AzureVmItem)itemBase).VirtualMachineId))
            {
                throw new ArgumentException(Resources.VirtualMachineIdIsEmptyOrNull);
            }
        }

        private bool ValidateDiskExclusionParameters(string[] inclusionDiskList, string[] exclusionDiskList,
            SwitchParameter resetDiskExclusion, bool excludeAllDataDisks)
        {
            bool isDiskExclusionParamPresent = false;
            if(inclusionDiskList != null || exclusionDiskList != null || resetDiskExclusion.IsPresent || excludeAllDataDisks)
            {
                isDiskExclusionParamPresent = true;
            }

            if(inclusionDiskList != null && exclusionDiskList != null)
            {
                throw new ArgumentException(Resources.InclusionListRedundantError);
            }

            if(resetDiskExclusion.IsPresent && (inclusionDiskList != null && exclusionDiskList != null))
            {
                throw new ArgumentException(Resources.DiskExclusionParametersRedundant);
            }

            if(excludeAllDataDisks && (inclusionDiskList != null || exclusionDiskList != null || resetDiskExclusion.IsPresent))
            {
                throw new ArgumentException(Resources.DiskExclusionParametersRedundant);
            }

            return isDiskExclusionParamPresent;
        }

        private void ValidateAzureVMDisableProtectionRequest(ItemBase itemBase)
        {

            if (itemBase == null || itemBase.GetType() != typeof(AzureVmItem))
            {
                throw new ArgumentException(string.Format(Resources.InvalidProtectionPolicyException,
                                            typeof(AzureVmItem).ToString()));
            }

            if (string.IsNullOrEmpty(((AzureVmItem)itemBase).VirtualMachineId))
            {
                throw new ArgumentException(Resources.VirtualMachineIdIsEmptyOrNull);
            }

            ValidateAzureVMWorkloadType(itemBase.WorkloadType);
            ValidateAzureVMContainerType(itemBase.ContainerType);
        }

        private void ValidateInstantRPRetentionDays(AzureVmPolicy policy)
        {
            CmdletModel.ScheduleRunType scheduleRunFrequency = 0;
            CmdletModel.PSPolicyType policyType = 0;

            if (policy.SchedulePolicy.GetType() == typeof(CmdletModel.SimpleSchedulePolicy))
            {
                scheduleRunFrequency = ((CmdletModel.SimpleSchedulePolicy)policy.SchedulePolicy).ScheduleRunFrequency;
                policyType = CmdletModel.PSPolicyType.Standard;
            }
            else if (policy.SchedulePolicy.GetType() == typeof(CmdletModel.SimpleSchedulePolicyV2))
            {
                scheduleRunFrequency = ((CmdletModel.SimpleSchedulePolicyV2)policy.SchedulePolicy).ScheduleRunFrequency;
                policyType = CmdletModel.PSPolicyType.Enhanced;
            }

            if (policyType == CmdletModel.PSPolicyType.Standard)
            {
                if (scheduleRunFrequency == CmdletModel.ScheduleRunType.Weekly)
                {
                    if (policy.SnapshotRetentionInDays != 5)
                    {
                        throw new ArgumentException(string.Format(Resources.InstantRPRetentionDaysException));
                    }
                }
                else if (scheduleRunFrequency == CmdletModel.ScheduleRunType.Daily)
                {
                    if (policy.SnapshotRetentionInDays < 1 || policy.SnapshotRetentionInDays > 5)
                    {
                        throw new ArgumentException(string.Format(Resources.InstantRPRetentionDaysException));
                    }
                }
            }
            else if (policyType == CmdletModel.PSPolicyType.Enhanced)
            {
                if (scheduleRunFrequency == CmdletModel.ScheduleRunType.Weekly)
                {
                    if (policy.SnapshotRetentionInDays < 5 || policy.SnapshotRetentionInDays > 30)
                    {
                        throw new ArgumentException(Resources.SnapshotRetentionOutOfRange);
                    }
                }
                else if (scheduleRunFrequency == CmdletModel.ScheduleRunType.Daily || scheduleRunFrequency == CmdletModel.ScheduleRunType.Hourly)
                {
                    if (policy.SnapshotRetentionInDays < 1 || policy.SnapshotRetentionInDays > 30)
                    {
                        throw new ArgumentException(Resources.SnapshotRetentionOutOfRange);
                    }
                }
            }
        }

        private bool IsComputeAzureVM(string virtualMachineId)
        {
            bool isComputeAzureVM = true;
            if (virtualMachineId.IndexOf(classicComputeAzureVMVersion,
                StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                isComputeAzureVM = false;
            }
            return isComputeAzureVM;
        }

        private WorkloadProtectableItemResource GetAzureVMProtectableObject(
            string azureVMName,
            string azureVMRGName,
            bool isComputeAzureVM,
            string vaultName = null,
            string resourceGroupName = null)
        {
            //TriggerDiscovery if needed

            bool isDiscoveryNeeded = false;

            WorkloadProtectableItemResource protectableObjectResource = null;
            isDiscoveryNeeded = IsDiscoveryNeeded(
                azureVMName,
                azureVMRGName,
                isComputeAzureVM,
                out protectableObjectResource,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);

            if (isDiscoveryNeeded)
            {
                Logger.Instance.WriteDebug(string.Format(Resources.VMNotDiscovered, azureVMName));
                AzureWorkloadProviderHelper.RefreshContainer(vaultName, resourceGroupName);
                isDiscoveryNeeded = IsDiscoveryNeeded(
                    azureVMName,
                    azureVMRGName,
                    isComputeAzureVM,
                    out protectableObjectResource,
                    vaultName: vaultName,
                    resourceGroupName: resourceGroupName);

                if (isDiscoveryNeeded)
                {
                    // Container is not discovered. Throw exception
                    string vmversion = (isComputeAzureVM) ?
                        computeAzureVMVersion :
                        classicComputeAzureVMVersion;
                    string errMsg = string.Format(Resources.DiscoveryFailure,
                        azureVMName,
                        azureVMRGName,
                        vmversion);
                    Logger.Instance.WriteDebug(errMsg);
                    Logger.Instance.WriteError(
                        new ErrorRecord(new Exception(Resources.AzureVMNotFound),
                            string.Empty,
                            ErrorCategory.InvalidArgument,
                            null));
                }
            }
            if (protectableObjectResource == null)
            {
                // Container is not discovered. Throw exception
                string vmversion = (isComputeAzureVM) ?
                    computeAzureVMVersion : classicComputeAzureVMVersion;
                string errMsg = string.Format(
                    Resources.DiscoveryFailure,
                    azureVMName,
                    azureVMRGName,
                    vmversion);
                Logger.Instance.WriteDebug(errMsg);
                Logger.Instance.WriteError(
                    new ErrorRecord(new Exception(Resources.AzureVMNotFound),
                        string.Empty, ErrorCategory.InvalidArgument, null));
            }

            return protectableObjectResource;
        }

        private bool IsDiscoveryNeeded(
            string vmName,
            string rgName,
            bool isComputeAzureVM,
            out WorkloadProtectableItemResource protectableObjectResource,
            string vaultName = null,
            string resourceGroupName = null)
        {
            bool isDiscoveryNeed = true;
            protectableObjectResource = null;
            string vmVersion = string.Empty;
            vmVersion = (isComputeAzureVM) == true ? computeAzureVMVersion : classicComputeAzureVMVersion;
            string virtualMachineId = GetAzureIaasVirtualMachineId(rgName, vmVersion, vmName);

            ODataQuery<BmspoQueryObject> queryParam = new ODataQuery<BmspoQueryObject>(
                q => q.BackupManagementType
                     == ServiceClientModel.BackupManagementType.AzureIaasVM);

            var protectableItemList = ServiceClientAdapter.ListProtectableItem(
                queryParam,
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);

            Logger.Instance.WriteDebug(string.Format(Resources.ContainerCountAfterFilter,
                protectableItemList.Count()));
            if (protectableItemList.Count() == 0)
            {
                //Container is not discovered
                Logger.Instance.WriteDebug(Resources.ContainerNotDiscovered);
                isDiscoveryNeed = true;
            }
            else
            {
                foreach (var protectableItem in protectableItemList)
                {
                    IaaSVMProtectableItem iaaSVMProtectableItem =
                        (IaaSVMProtectableItem)protectableItem.Properties;

                    if (iaaSVMProtectableItem != null &&
                        string.Compare(iaaSVMProtectableItem.FriendlyName, vmName, true) == 0
                        && iaaSVMProtectableItem.VirtualMachineId.IndexOf(virtualMachineId,
                        StringComparison.InvariantCultureIgnoreCase) >= 0)
                    {
                        protectableObjectResource = protectableItem;
                        isDiscoveryNeed = false;
                        break;
                    }
                }
            }

            return isDiscoveryNeed;
        }

        private static string GetAzureIaasVirtualMachineId(
            string resourceGroup,
            string vmVersion,
            string name)
        {
            string IaasVMIdFormat = "/resourceGroups/{0}/providers/{1}/virtualMachines/{2}";
            return string.Format(IaasVMIdFormat, resourceGroup, vmVersion, name);
        }

        /// <summary>
        /// Generates ILR Response object for Windows VMs
        /// </summary>
        /// <param name="clientScriptForConnection"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private AzureVmRPMountScriptDetails GenerateILRResponseForWindowsVMs(
            ClientScriptForConnect clientScriptForConnection, out string content)
        {
            try
            {
                SystemNet.HttpWebResponse webResponse =
                    TrackingHelpers.RetryHttpWebRequest(
                        clientScriptForConnection.Url,
                        3);

                if (SystemNet.HttpStatusCode.OK == webResponse.StatusCode)
                {
                    using (Stream myResponseStream = webResponse.GetResponseStream())
                    {
                        byte[] myBuffer = new byte[4096];
                        int bytesRead;
                        MemoryStream memoryStream = new MemoryStream();
                        while ((bytesRead =
                            myResponseStream.Read(myBuffer, 0, myBuffer.Length)) > 0)
                        {
                            memoryStream.Write(myBuffer, 0, bytesRead);
                        }
                        content = Convert.ToBase64String(
                            memoryStream.ToArray());
                        string suffix = clientScriptForConnection.ScriptNameSuffix;
                        string password = this.RemovePasswordFromSuffixAndReturn(ref suffix);
                        string fileName = this.ConstructFileName(
                            suffix, clientScriptForConnection.ScriptExtension);

                        return new AzureVmRPMountScriptDetails(
                            clientScriptForConnection.OSType, fileName, password);
                    }
                }
                throw new Exception(
                    "Error in Web Request to download center for ILR script" +
                    webResponse.StatusCode);
            }
            catch (Exception e)
            {
                Logger.Instance.WriteWarning(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Generates ILR Response object for Linux VMs.
        /// </summary>
        /// <param name="clientScriptForConnection"></param>
        /// <param name="protectedItemName"></param>
        /// <param name="recoveryPointTime"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private AzureVmRPMountScriptDetails GenerateILRResponseForLinuxVMs(
            ClientScriptForConnect clientScriptForConnection,
            string protectedItemName, string recoveryPointTime, out string content)
        {
            try
            {
                content = clientScriptForConnection.ScriptContent;
                string suffix = clientScriptForConnection.ScriptNameSuffix;
                string fileName, password;
                if (suffix != null)
                {
                    this.RemovePasswordFromSuffixAndReturn(ref suffix);
                    fileName = this.ConstructFileName(
                        suffix, clientScriptForConnection.ScriptExtension);
                }
                else
                {
                    string operatingSystemName = clientScriptForConnection.OSType;
                    string vmName = protectedItemName.Split(';')[3];
                    fileName = string.Format(
                            CultureInfo.InvariantCulture,
                            "{0}_{1}_{2}" + clientScriptForConnection.ScriptExtension,
                            operatingSystemName,
                            vmName,
                            recoveryPointTime);
                }
                password = this.ReplacePasswordInScriptContentAndReturn(ref content);

                return new AzureVmRPMountScriptDetails(
                    clientScriptForConnection.OSType, fileName, password);
            }
            catch (Exception e)
            {
                Logger.Instance.WriteWarning(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Removes password from ScriptNameSuffix and returns it.
        /// </summary>
        /// <param name="suffix"></param>
        /// <returns></returns>
        private string RemovePasswordFromSuffixAndReturn(ref string suffix)
        {
            int lastIndexOfUnderScore = suffix.LastIndexOf('_');
            int passwordOffset = lastIndexOfUnderScore +
                33;
            string password = suffix.Substring(
                passwordOffset, 15);
            suffix = suffix.Remove(
                passwordOffset, 15);
            return password;
        }

        /// <summary>
        /// Constructs ILR script file name
        /// </summary>
        /// <param name="suffix"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        private string ConstructFileName(string suffix, string extension)
        {
            string format = "{0}" + extension;
            return string.Format(
                    CultureInfo.InvariantCulture,
                    format,
                    suffix);
        }

        /// <summary>
        /// Replaces password in ILR script with dummy password and returns it
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private string ReplacePasswordInScriptContentAndReturn(ref string content)
        {
            // decode to text format from Base 64 encoded format
            var contentBytes = Convert.FromBase64String(content);
            content = Encoding.UTF8.GetString(contentBytes);

            string targetPasswordString =
                "TargetPassword=\"";
            string password = content.Substring(
                content.IndexOf(
                    targetPasswordString) + targetPasswordString.Length, 15);

            string pattern = targetPasswordString + ".*\"";
            string replacement =
                targetPasswordString + "UserInput012345\"";
            Regex rgx = new Regex(pattern);
            content = rgx.Replace(content, replacement);

            // decode back to Base 64 format
            contentBytes = Encoding.UTF8.GetBytes(content);
            content = Convert.ToBase64String(contentBytes);

            return password;
        }

        private bool ShouldUseOsa(AzureVmRecoveryPoint rp, bool osaOption)
        {
            bool useOsa = false;
            if (osaOption)
            {
                if (rp.OriginalSAEnabled)
                {
                    useOsa = true;
                }
                else
                {
                    throw new Exception("This recovery point doesn’t have the capability to restore disks to their original storage account. Re-run the restore command without the UseOriginalStorageAccountForDisks parameter.");
                }
            }

            return useOsa;
        }

        public List<PointInTimeBase> GetLogChains()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}