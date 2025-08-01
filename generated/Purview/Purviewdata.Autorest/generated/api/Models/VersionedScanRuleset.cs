// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Runtime.Extensions;

    [Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.DoNotFormat]
    public partial class VersionedScanRuleset :
        Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IVersionedScanRuleset,
        Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IVersionedScanRulesetInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IProxyResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IProxyResource __proxyResource = new Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.ProxyResource();

        [Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Origin(Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IProxyResourceInternal)__proxyResource).Id; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IProxyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IProxyResourceInternal)__proxyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IProxyResourceInternal)__proxyResource).Id = value ?? null; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IProxyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IProxyResourceInternal)__proxyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IProxyResourceInternal)__proxyResource).Name = value ?? null; }

        /// <summary>Internal Acessors for Status</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IVersionedScanRulesetInternal.Status { get => this._status; set { {_status = value;} } }

        /// <summary>Internal Acessors for Version</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IVersionedScanRulesetInternal.Version { get => this._version; set { {_version = value;} } }

        [Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Origin(Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IProxyResourceInternal)__proxyResource).Name; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private string _status;

        [Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Origin(Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.PropertyOrigin.Owned)]
        public string Status { get => this._status; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        [Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Origin(Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private int? _version;

        [Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Origin(Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.PropertyOrigin.Owned)]
        public int? Version { get => this._version; }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyResource), __proxyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyResource), __proxyResource);
        }

        /// <summary>Creates an new <see cref="VersionedScanRuleset" /> instance.</summary>
        public VersionedScanRuleset()
        {

        }
    }
    public partial interface IVersionedScanRuleset :
        Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IProxyResource
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string Status { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"",
        SerializedName = @"scanRulesetType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.PSArgumentCompleterAttribute("Custom", "System")]
        string Type { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(int) })]
        int? Version { get;  }

    }
    internal partial interface IVersionedScanRulesetInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IProxyResourceInternal
    {
        [global::Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string Status { get; set; }

        [global::Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.PSArgumentCompleterAttribute("Custom", "System")]
        string Type { get; set; }

        int? Version { get; set; }

    }
}