// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Extensions;

    /// <summary>Output of check resource usage API.</summary>
    public partial class ResourceUsage :
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceUsage,
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceUsageInternal
    {

        /// <summary>Backing field for <see cref="CurrentValue" /> property.</summary>
        private int? _currentValue;

        /// <summary>Actual value of usage on the specified resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)]
        public int? CurrentValue { get => this._currentValue; }

        /// <summary>Backing field for <see cref="Limit" /> property.</summary>
        private int? _limit;

        /// <summary>Quota of the specified resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)]
        public int? Limit { get => this._limit; }

        /// <summary>Internal Acessors for CurrentValue</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceUsageInternal.CurrentValue { get => this._currentValue; set { {_currentValue = value;} } }

        /// <summary>Internal Acessors for Limit</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceUsageInternal.Limit { get => this._limit; set { {_limit = value;} } }

        /// <summary>Internal Acessors for ResourceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceUsageInternal.ResourceType { get => this._resourceType; set { {_resourceType = value;} } }

        /// <summary>Internal Acessors for Unit</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceUsageInternal.Unit { get => this._unit; set { {_unit = value;} } }

        /// <summary>Backing field for <see cref="ResourceType" /> property.</summary>
        private string _resourceType;

        /// <summary>Resource type for which the usage is provided.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)]
        public string ResourceType { get => this._resourceType; }

        /// <summary>Backing field for <see cref="Unit" /> property.</summary>
        private string _unit;

        /// <summary>Unit of the usage. e.g. count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)]
        public string Unit { get => this._unit; }

        /// <summary>Creates an new <see cref="ResourceUsage" /> instance.</summary>
        public ResourceUsage()
        {

        }
    }
    /// Output of check resource usage API.
    public partial interface IResourceUsage :
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.IJsonSerializable
    {
        /// <summary>Actual value of usage on the specified resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Actual value of usage on the specified resource type.",
        SerializedName = @"currentValue",
        PossibleTypes = new [] { typeof(int) })]
        int? CurrentValue { get;  }
        /// <summary>Quota of the specified resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Quota of the specified resource type.",
        SerializedName = @"limit",
        PossibleTypes = new [] { typeof(int) })]
        int? Limit { get;  }
        /// <summary>Resource type for which the usage is provided.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Resource type for which the usage is provided.",
        SerializedName = @"resourceType",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceType { get;  }
        /// <summary>Unit of the usage. e.g. count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Unit of the usage. e.g. count.",
        SerializedName = @"unit",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Cdn.PSArgumentCompleterAttribute("count")]
        string Unit { get;  }

    }
    /// Output of check resource usage API.
    internal partial interface IResourceUsageInternal

    {
        /// <summary>Actual value of usage on the specified resource type.</summary>
        int? CurrentValue { get; set; }
        /// <summary>Quota of the specified resource type.</summary>
        int? Limit { get; set; }
        /// <summary>Resource type for which the usage is provided.</summary>
        string ResourceType { get; set; }
        /// <summary>Unit of the usage. e.g. count.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Cdn.PSArgumentCompleterAttribute("count")]
        string Unit { get; set; }

    }
}