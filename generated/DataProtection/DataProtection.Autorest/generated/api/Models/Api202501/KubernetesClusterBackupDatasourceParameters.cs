// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Parameters for Kubernetes Cluster Backup Datasource</summary>
    public partial class KubernetesClusterBackupDatasourceParameters :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IKubernetesClusterBackupDatasourceParameters,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IKubernetesClusterBackupDatasourceParametersInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupDatasourceParameters"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupDatasourceParameters __backupDatasourceParameters = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.BackupDatasourceParameters();

        /// <summary>Backing field for <see cref="BackupHookReference" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.INamespacedNameResource[] _backupHookReference;

        /// <summary>
        /// Gets or sets the backup hook references. This property sets the hook reference to be executed during backup.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.INamespacedNameResource[] BackupHookReference { get => this._backupHookReference; set => this._backupHookReference = value; }

        /// <summary>Backing field for <see cref="ExcludedNamespace" /> property.</summary>
        private string[] _excludedNamespace;

        /// <summary>
        /// Gets or sets the exclude namespaces property. This property sets the namespaces to be excluded during backup.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string[] ExcludedNamespace { get => this._excludedNamespace; set => this._excludedNamespace = value; }

        /// <summary>Backing field for <see cref="ExcludedResourceType" /> property.</summary>
        private string[] _excludedResourceType;

        /// <summary>
        /// Gets or sets the exclude resource types property. This property sets the resource types to be excluded during backup.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string[] ExcludedResourceType { get => this._excludedResourceType; set => this._excludedResourceType = value; }

        /// <summary>Backing field for <see cref="IncludeClusterScopeResource" /> property.</summary>
        private bool _includeClusterScopeResource;

        /// <summary>
        /// Gets or sets the include cluster resources property. This property if enabled will include cluster scope resources during
        /// backup.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public bool IncludeClusterScopeResource { get => this._includeClusterScopeResource; set => this._includeClusterScopeResource = value; }

        /// <summary>Backing field for <see cref="IncludedNamespace" /> property.</summary>
        private string[] _includedNamespace;

        /// <summary>
        /// Gets or sets the include namespaces property. This property sets the namespaces to be included during backup.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string[] IncludedNamespace { get => this._includedNamespace; set => this._includedNamespace = value; }

        /// <summary>Backing field for <see cref="IncludedResourceType" /> property.</summary>
        private string[] _includedResourceType;

        /// <summary>
        /// Gets or sets the include resource types property. This property sets the resource types to be included during backup.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string[] IncludedResourceType { get => this._includedResourceType; set => this._includedResourceType = value; }

        /// <summary>Backing field for <see cref="IncludedVolumeType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.AksVolumeTypes[] _includedVolumeType;

        /// <summary>
        /// Gets or sets the include volume types property. This property sets the volume types to be included during backup.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.AksVolumeTypes[] IncludedVolumeType { get => this._includedVolumeType; set => this._includedVolumeType = value; }

        /// <summary>Backing field for <see cref="LabelSelector" /> property.</summary>
        private string[] _labelSelector;

        /// <summary>
        /// Gets or sets the LabelSelectors property. This property sets the resource with such label selectors to be included during
        /// backup.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string[] LabelSelector { get => this._labelSelector; set => this._labelSelector = value; }

        /// <summary>Type of the specific object - used for deserializing</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string ObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupDatasourceParametersInternal)__backupDatasourceParameters).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupDatasourceParametersInternal)__backupDatasourceParameters).ObjectType = value ; }

        /// <summary>Backing field for <see cref="SnapshotVolume" /> property.</summary>
        private bool _snapshotVolume;

        /// <summary>
        /// Gets or sets the volume snapshot property. This property if enabled will take volume snapshots during backup.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public bool SnapshotVolume { get => this._snapshotVolume; set => this._snapshotVolume = value; }

        /// <summary>
        /// Creates an new <see cref="KubernetesClusterBackupDatasourceParameters" /> instance.
        /// </summary>
        public KubernetesClusterBackupDatasourceParameters()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__backupDatasourceParameters), __backupDatasourceParameters);
            await eventListener.AssertObjectIsValid(nameof(__backupDatasourceParameters), __backupDatasourceParameters);
        }
    }
    /// Parameters for Kubernetes Cluster Backup Datasource
    public partial interface IKubernetesClusterBackupDatasourceParameters :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupDatasourceParameters
    {
        /// <summary>
        /// Gets or sets the backup hook references. This property sets the hook reference to be executed during backup.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the backup hook references. This property sets the hook reference to be executed during backup.",
        SerializedName = @"backupHookReferences",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.INamespacedNameResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.INamespacedNameResource[] BackupHookReference { get; set; }
        /// <summary>
        /// Gets or sets the exclude namespaces property. This property sets the namespaces to be excluded during backup.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the exclude namespaces property. This property sets the namespaces to be excluded during backup.",
        SerializedName = @"excludedNamespaces",
        PossibleTypes = new [] { typeof(string) })]
        string[] ExcludedNamespace { get; set; }
        /// <summary>
        /// Gets or sets the exclude resource types property. This property sets the resource types to be excluded during backup.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the exclude resource types property. This property sets the resource types to be excluded during backup.",
        SerializedName = @"excludedResourceTypes",
        PossibleTypes = new [] { typeof(string) })]
        string[] ExcludedResourceType { get; set; }
        /// <summary>
        /// Gets or sets the include cluster resources property. This property if enabled will include cluster scope resources during
        /// backup.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Gets or sets the include cluster resources property. This property if enabled will include cluster scope resources during backup.",
        SerializedName = @"includeClusterScopeResources",
        PossibleTypes = new [] { typeof(bool) })]
        bool IncludeClusterScopeResource { get; set; }
        /// <summary>
        /// Gets or sets the include namespaces property. This property sets the namespaces to be included during backup.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the include namespaces property. This property sets the namespaces to be included during backup.",
        SerializedName = @"includedNamespaces",
        PossibleTypes = new [] { typeof(string) })]
        string[] IncludedNamespace { get; set; }
        /// <summary>
        /// Gets or sets the include resource types property. This property sets the resource types to be included during backup.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the include resource types property. This property sets the resource types to be included during backup.",
        SerializedName = @"includedResourceTypes",
        PossibleTypes = new [] { typeof(string) })]
        string[] IncludedResourceType { get; set; }
        /// <summary>
        /// Gets or sets the include volume types property. This property sets the volume types to be included during backup.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the include volume types property. This property sets the volume types to be included during backup.",
        SerializedName = @"includedVolumeTypes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.AksVolumeTypes) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.AksVolumeTypes[] IncludedVolumeType { get; set; }
        /// <summary>
        /// Gets or sets the LabelSelectors property. This property sets the resource with such label selectors to be included during
        /// backup.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the LabelSelectors property. This property sets the resource with such label selectors to be included during backup.",
        SerializedName = @"labelSelectors",
        PossibleTypes = new [] { typeof(string) })]
        string[] LabelSelector { get; set; }
        /// <summary>
        /// Gets or sets the volume snapshot property. This property if enabled will take volume snapshots during backup.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Gets or sets the volume snapshot property. This property if enabled will take volume snapshots during backup.",
        SerializedName = @"snapshotVolumes",
        PossibleTypes = new [] { typeof(bool) })]
        bool SnapshotVolume { get; set; }

    }
    /// Parameters for Kubernetes Cluster Backup Datasource
    internal partial interface IKubernetesClusterBackupDatasourceParametersInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupDatasourceParametersInternal
    {
        /// <summary>
        /// Gets or sets the backup hook references. This property sets the hook reference to be executed during backup.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.INamespacedNameResource[] BackupHookReference { get; set; }
        /// <summary>
        /// Gets or sets the exclude namespaces property. This property sets the namespaces to be excluded during backup.
        /// </summary>
        string[] ExcludedNamespace { get; set; }
        /// <summary>
        /// Gets or sets the exclude resource types property. This property sets the resource types to be excluded during backup.
        /// </summary>
        string[] ExcludedResourceType { get; set; }
        /// <summary>
        /// Gets or sets the include cluster resources property. This property if enabled will include cluster scope resources during
        /// backup.
        /// </summary>
        bool IncludeClusterScopeResource { get; set; }
        /// <summary>
        /// Gets or sets the include namespaces property. This property sets the namespaces to be included during backup.
        /// </summary>
        string[] IncludedNamespace { get; set; }
        /// <summary>
        /// Gets or sets the include resource types property. This property sets the resource types to be included during backup.
        /// </summary>
        string[] IncludedResourceType { get; set; }
        /// <summary>
        /// Gets or sets the include volume types property. This property sets the volume types to be included during backup.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.AksVolumeTypes[] IncludedVolumeType { get; set; }
        /// <summary>
        /// Gets or sets the LabelSelectors property. This property sets the resource with such label selectors to be included during
        /// backup.
        /// </summary>
        string[] LabelSelector { get; set; }
        /// <summary>
        /// Gets or sets the volume snapshot property. This property if enabled will take volume snapshots during backup.
        /// </summary>
        bool SnapshotVolume { get; set; }

    }
}