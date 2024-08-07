// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Runtime.Extensions;

    /// <summary>Represents a list of cluster pool upgrade history.</summary>
    public partial class ClusterPoolUpgradeHistoryListResult :
        Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterPoolUpgradeHistoryListResult,
        Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterPoolUpgradeHistoryListResultInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterPoolUpgradeHistoryListResultInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The link (url) to the next page of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Origin(Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterPoolUpgradeHistory> _value;

        /// <summary>The list of cluster pool upgrade history.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Origin(Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterPoolUpgradeHistory> Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ClusterPoolUpgradeHistoryListResult" /> instance.</summary>
        public ClusterPoolUpgradeHistoryListResult()
        {

        }
    }
    /// Represents a list of cluster pool upgrade history.
    public partial interface IClusterPoolUpgradeHistoryListResult :
        Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Runtime.IJsonSerializable
    {
        /// <summary>The link (url) to the next page of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The link (url) to the next page of results.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>The list of cluster pool upgrade history.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The list of cluster pool upgrade history.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterPoolUpgradeHistory) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterPoolUpgradeHistory> Value { get; set; }

    }
    /// Represents a list of cluster pool upgrade history.
    internal partial interface IClusterPoolUpgradeHistoryListResultInternal

    {
        /// <summary>The link (url) to the next page of results.</summary>
        string NextLink { get; set; }
        /// <summary>The list of cluster pool upgrade history.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterPoolUpgradeHistory> Value { get; set; }

    }
}