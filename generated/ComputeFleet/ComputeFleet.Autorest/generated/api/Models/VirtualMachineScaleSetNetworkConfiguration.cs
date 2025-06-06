// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Extensions;

    /// <summary>Describes a virtual machine scale set network profile's network configurations.</summary>
    public partial class VirtualMachineScaleSetNetworkConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationInternal
    {

        /// <summary>
        /// Specifies whether the Auxiliary mode is enabled for the Network Interface
        /// resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string AuxiliaryMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationPropertiesInternal)Property).AuxiliaryMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationPropertiesInternal)Property).AuxiliaryMode = value ?? null; }

        /// <summary>
        /// Specifies whether the Auxiliary sku is enabled for the Network Interface
        /// resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string AuxiliarySku { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationPropertiesInternal)Property).AuxiliarySku; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationPropertiesInternal)Property).AuxiliarySku = value ?? null; }

        /// <summary>Specify what happens to the network interface when the VM is deleted</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string DeleteOption { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationPropertiesInternal)Property).DeleteOption; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationPropertiesInternal)Property).DeleteOption = value ?? null; }

        /// <summary>Specifies whether the network interface is disabled for tcp state tracking.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public bool? DisableTcpStateTracking { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationPropertiesInternal)Property).DisableTcpStateTracking; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationPropertiesInternal)Property).DisableTcpStateTracking = value ?? default(bool); }

        /// <summary>List of DNS servers IP addresses</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> DnsSettingDnsServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationPropertiesInternal)Property).DnsSettingDnsServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationPropertiesInternal)Property).DnsSettingDnsServer = value ?? null /* arrayOf */; }

        /// <summary>Specifies whether the network interface is accelerated networking-enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public bool? EnableAcceleratedNetworking { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationPropertiesInternal)Property).EnableAcceleratedNetworking; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationPropertiesInternal)Property).EnableAcceleratedNetworking = value ?? default(bool); }

        /// <summary>Specifies whether the network interface is FPGA networking-enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public bool? EnableFpga { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationPropertiesInternal)Property).EnableFpga; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationPropertiesInternal)Property).EnableFpga = value ?? default(bool); }

        /// <summary>Whether IP forwarding enabled on this NIC.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public bool? EnableIPForwarding { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationPropertiesInternal)Property).EnableIPForwarding; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationPropertiesInternal)Property).EnableIPForwarding = value ?? default(bool); }

        /// <summary>Specifies the IP configurations of the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetIPConfiguration> IPConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationPropertiesInternal)Property).IPConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationPropertiesInternal)Property).IPConfiguration = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for DnsSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationDnsSettings Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationInternal.DnsSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationPropertiesInternal)Property).DnsSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationPropertiesInternal)Property).DnsSetting = value; }

        /// <summary>Internal Acessors for NetworkSecurityGroup</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISubResource Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationInternal.NetworkSecurityGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationPropertiesInternal)Property).NetworkSecurityGroup; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationPropertiesInternal)Property).NetworkSecurityGroup = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationProperties Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetNetworkConfigurationProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The network configuration name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public string NetworkSecurityGroupId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationPropertiesInternal)Property).NetworkSecurityGroupId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationPropertiesInternal)Property).NetworkSecurityGroupId = value ?? null; }

        /// <summary>
        /// Specifies the primary network interface in case the virtual machine has more
        /// than 1 network interface.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Inlined)]
        public bool? Primary { get => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationPropertiesInternal)Property).Primary; set => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationPropertiesInternal)Property).Primary = value ?? default(bool); }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationProperties _property;

        /// <summary>Describes a virtual machine scale set network profile's IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Origin(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetNetworkConfigurationProperties()); set => this._property = value; }

        /// <summary>
        /// Creates an new <see cref="VirtualMachineScaleSetNetworkConfiguration" /> instance.
        /// </summary>
        public VirtualMachineScaleSetNetworkConfiguration()
        {

        }
    }
    /// Describes a virtual machine scale set network profile's network configurations.
    public partial interface IVirtualMachineScaleSetNetworkConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Specifies whether the Auxiliary mode is enabled for the Network Interface
        /// resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies whether the Auxiliary mode is enabled for the Network Interface
        resource.",
        SerializedName = @"auxiliaryMode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("None", "AcceleratedConnections", "Floating")]
        string AuxiliaryMode { get; set; }
        /// <summary>
        /// Specifies whether the Auxiliary sku is enabled for the Network Interface
        /// resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies whether the Auxiliary sku is enabled for the Network Interface
        resource.",
        SerializedName = @"auxiliarySku",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("None", "A1", "A2", "A4", "A8")]
        string AuxiliarySku { get; set; }
        /// <summary>Specify what happens to the network interface when the VM is deleted</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specify what happens to the network interface when the VM is deleted",
        SerializedName = @"deleteOption",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("Delete", "Detach")]
        string DeleteOption { get; set; }
        /// <summary>Specifies whether the network interface is disabled for tcp state tracking.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies whether the network interface is disabled for tcp state tracking.",
        SerializedName = @"disableTcpStateTracking",
        PossibleTypes = new [] { typeof(bool) })]
        bool? DisableTcpStateTracking { get; set; }
        /// <summary>List of DNS servers IP addresses</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"List of DNS servers IP addresses",
        SerializedName = @"dnsServers",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> DnsSettingDnsServer { get; set; }
        /// <summary>Specifies whether the network interface is accelerated networking-enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies whether the network interface is accelerated networking-enabled.",
        SerializedName = @"enableAcceleratedNetworking",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableAcceleratedNetworking { get; set; }
        /// <summary>Specifies whether the network interface is FPGA networking-enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies whether the network interface is FPGA networking-enabled.",
        SerializedName = @"enableFpga",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableFpga { get; set; }
        /// <summary>Whether IP forwarding enabled on this NIC.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Whether IP forwarding enabled on this NIC.",
        SerializedName = @"enableIPForwarding",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableIPForwarding { get; set; }
        /// <summary>Specifies the IP configurations of the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies the IP configurations of the network interface.",
        SerializedName = @"ipConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetIPConfiguration) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetIPConfiguration> IPConfiguration { get; set; }
        /// <summary>The network configuration name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The network configuration name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Resource Id",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkSecurityGroupId { get; set; }
        /// <summary>
        /// Specifies the primary network interface in case the virtual machine has more
        /// than 1 network interface.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies the primary network interface in case the virtual machine has more
        than 1 network interface.",
        SerializedName = @"primary",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Primary { get; set; }

    }
    /// Describes a virtual machine scale set network profile's network configurations.
    internal partial interface IVirtualMachineScaleSetNetworkConfigurationInternal

    {
        /// <summary>
        /// Specifies whether the Auxiliary mode is enabled for the Network Interface
        /// resource.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("None", "AcceleratedConnections", "Floating")]
        string AuxiliaryMode { get; set; }
        /// <summary>
        /// Specifies whether the Auxiliary sku is enabled for the Network Interface
        /// resource.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("None", "A1", "A2", "A4", "A8")]
        string AuxiliarySku { get; set; }
        /// <summary>Specify what happens to the network interface when the VM is deleted</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("Delete", "Detach")]
        string DeleteOption { get; set; }
        /// <summary>Specifies whether the network interface is disabled for tcp state tracking.</summary>
        bool? DisableTcpStateTracking { get; set; }
        /// <summary>The dns settings to be applied on the network interfaces.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationDnsSettings DnsSetting { get; set; }
        /// <summary>List of DNS servers IP addresses</summary>
        System.Collections.Generic.List<string> DnsSettingDnsServer { get; set; }
        /// <summary>Specifies whether the network interface is accelerated networking-enabled.</summary>
        bool? EnableAcceleratedNetworking { get; set; }
        /// <summary>Specifies whether the network interface is FPGA networking-enabled.</summary>
        bool? EnableFpga { get; set; }
        /// <summary>Whether IP forwarding enabled on this NIC.</summary>
        bool? EnableIPForwarding { get; set; }
        /// <summary>Specifies the IP configurations of the network interface.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetIPConfiguration> IPConfiguration { get; set; }
        /// <summary>The network configuration name.</summary>
        string Name { get; set; }
        /// <summary>The network security group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ISubResource NetworkSecurityGroup { get; set; }
        /// <summary>Resource Id</summary>
        string NetworkSecurityGroupId { get; set; }
        /// <summary>
        /// Specifies the primary network interface in case the virtual machine has more
        /// than 1 network interface.
        /// </summary>
        bool? Primary { get; set; }
        /// <summary>Describes a virtual machine scale set network profile's IP configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVirtualMachineScaleSetNetworkConfigurationProperties Property { get; set; }

    }
}