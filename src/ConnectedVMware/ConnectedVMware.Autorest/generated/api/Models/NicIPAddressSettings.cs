// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.Extensions;

    /// <summary>IP address information for a virtual network adapter reported by the fabric.</summary>
    public partial class NicIPAddressSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.INicIPAddressSettings,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.INicIPAddressSettingsInternal
    {

        /// <summary>Backing field for <see cref="AllocationMethod" /> property.</summary>
        private string _allocationMethod;

        /// <summary>Gets the ip address allocation method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PropertyOrigin.Owned)]
        public string AllocationMethod { get => this._allocationMethod; }

        /// <summary>Backing field for <see cref="IPAddress" /> property.</summary>
        private string _iPAddress;

        /// <summary>Gets the ip address for the nic.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PropertyOrigin.Owned)]
        public string IPAddress { get => this._iPAddress; }

        /// <summary>Internal Acessors for AllocationMethod</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.INicIPAddressSettingsInternal.AllocationMethod { get => this._allocationMethod; set { {_allocationMethod = value;} } }

        /// <summary>Internal Acessors for IPAddress</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.INicIPAddressSettingsInternal.IPAddress { get => this._iPAddress; set { {_iPAddress = value;} } }

        /// <summary>Internal Acessors for SubnetMask</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.INicIPAddressSettingsInternal.SubnetMask { get => this._subnetMask; set { {_subnetMask = value;} } }

        /// <summary>Backing field for <see cref="SubnetMask" /> property.</summary>
        private string _subnetMask;

        /// <summary>Gets the mask.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PropertyOrigin.Owned)]
        public string SubnetMask { get => this._subnetMask; }

        /// <summary>Creates an new <see cref="NicIPAddressSettings" /> instance.</summary>
        public NicIPAddressSettings()
        {

        }
    }
    /// IP address information for a virtual network adapter reported by the fabric.
    public partial interface INicIPAddressSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.IJsonSerializable
    {
        /// <summary>Gets the ip address allocation method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Gets the ip address allocation method.",
        SerializedName = @"allocationMethod",
        PossibleTypes = new [] { typeof(string) })]
        string AllocationMethod { get;  }
        /// <summary>Gets the ip address for the nic.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Gets the ip address for the nic.",
        SerializedName = @"ipAddress",
        PossibleTypes = new [] { typeof(string) })]
        string IPAddress { get;  }
        /// <summary>Gets the mask.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Gets the mask.",
        SerializedName = @"subnetMask",
        PossibleTypes = new [] { typeof(string) })]
        string SubnetMask { get;  }

    }
    /// IP address information for a virtual network adapter reported by the fabric.
    internal partial interface INicIPAddressSettingsInternal

    {
        /// <summary>Gets the ip address allocation method.</summary>
        string AllocationMethod { get; set; }
        /// <summary>Gets the ip address for the nic.</summary>
        string IPAddress { get; set; }
        /// <summary>Gets the mask.</summary>
        string SubnetMask { get; set; }

    }
}