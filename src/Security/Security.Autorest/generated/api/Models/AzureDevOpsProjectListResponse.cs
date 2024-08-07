// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Security.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Security.Runtime.Extensions;

    /// <summary>List of RP resources which supports pagination.</summary>
    public partial class AzureDevOpsProjectListResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Security.Models.IAzureDevOpsProjectListResponse,
        Microsoft.Azure.PowerShell.Cmdlets.Security.Models.IAzureDevOpsProjectListResponseInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>Gets or sets next link to scroll over the results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Security.Origin(Microsoft.Azure.PowerShell.Cmdlets.Security.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Security.Models.IAzureDevOpsProject> _value;

        /// <summary>Gets or sets list of resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Security.Origin(Microsoft.Azure.PowerShell.Cmdlets.Security.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Security.Models.IAzureDevOpsProject> Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="AzureDevOpsProjectListResponse" /> instance.</summary>
        public AzureDevOpsProjectListResponse()
        {

        }
    }
    /// List of RP resources which supports pagination.
    public partial interface IAzureDevOpsProjectListResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Security.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets next link to scroll over the results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Security.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Gets or sets next link to scroll over the results.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>Gets or sets list of resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Security.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Gets or sets list of resources.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Security.Models.IAzureDevOpsProject) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Security.Models.IAzureDevOpsProject> Value { get; set; }

    }
    /// List of RP resources which supports pagination.
    internal partial interface IAzureDevOpsProjectListResponseInternal

    {
        /// <summary>Gets or sets next link to scroll over the results.</summary>
        string NextLink { get; set; }
        /// <summary>Gets or sets list of resources.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Security.Models.IAzureDevOpsProject> Value { get; set; }

    }
}