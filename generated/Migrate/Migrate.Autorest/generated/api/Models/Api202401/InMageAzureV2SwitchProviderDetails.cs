// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>InMageAzureV2 switch provider details.</summary>
    public partial class InMageAzureV2SwitchProviderDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202401.IInMageAzureV2SwitchProviderDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202401.IInMageAzureV2SwitchProviderDetailsInternal
    {

        /// <summary>Internal Acessors for TargetApplianceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202401.IInMageAzureV2SwitchProviderDetailsInternal.TargetApplianceId { get => this._targetApplianceId; set { {_targetApplianceId = value;} } }

        /// <summary>Internal Acessors for TargetFabricId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202401.IInMageAzureV2SwitchProviderDetailsInternal.TargetFabricId { get => this._targetFabricId; set { {_targetFabricId = value;} } }

        /// <summary>Internal Acessors for TargetResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202401.IInMageAzureV2SwitchProviderDetailsInternal.TargetResourceId { get => this._targetResourceId; set { {_targetResourceId = value;} } }

        /// <summary>Internal Acessors for TargetVaultId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202401.IInMageAzureV2SwitchProviderDetailsInternal.TargetVaultId { get => this._targetVaultId; set { {_targetVaultId = value;} } }

        /// <summary>Backing field for <see cref="TargetApplianceId" /> property.</summary>
        private string _targetApplianceId;

        /// <summary>The target appliance Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetApplianceId { get => this._targetApplianceId; }

        /// <summary>Backing field for <see cref="TargetFabricId" /> property.</summary>
        private string _targetFabricId;

        /// <summary>The target fabric Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetFabricId { get => this._targetFabricId; }

        /// <summary>Backing field for <see cref="TargetResourceId" /> property.</summary>
        private string _targetResourceId;

        /// <summary>The target resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetResourceId { get => this._targetResourceId; }

        /// <summary>Backing field for <see cref="TargetVaultId" /> property.</summary>
        private string _targetVaultId;

        /// <summary>The target vault Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetVaultId { get => this._targetVaultId; }

        /// <summary>Creates an new <see cref="InMageAzureV2SwitchProviderDetails" /> instance.</summary>
        public InMageAzureV2SwitchProviderDetails()
        {

        }
    }
    /// InMageAzureV2 switch provider details.
    public partial interface IInMageAzureV2SwitchProviderDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The target appliance Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The target appliance Id.",
        SerializedName = @"targetApplianceId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetApplianceId { get;  }
        /// <summary>The target fabric Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The target fabric Id.",
        SerializedName = @"targetFabricId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetFabricId { get;  }
        /// <summary>The target resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The target resource Id.",
        SerializedName = @"targetResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetResourceId { get;  }
        /// <summary>The target vault Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The target vault Id.",
        SerializedName = @"targetVaultId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetVaultId { get;  }

    }
    /// InMageAzureV2 switch provider details.
    internal partial interface IInMageAzureV2SwitchProviderDetailsInternal

    {
        /// <summary>The target appliance Id.</summary>
        string TargetApplianceId { get; set; }
        /// <summary>The target fabric Id.</summary>
        string TargetFabricId { get; set; }
        /// <summary>The target resource Id.</summary>
        string TargetResourceId { get; set; }
        /// <summary>The target vault Id.</summary>
        string TargetVaultId { get; set; }

    }
}