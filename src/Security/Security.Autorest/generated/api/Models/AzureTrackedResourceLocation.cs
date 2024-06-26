// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Security.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Security.Runtime.Extensions;

    /// <summary>Describes an Azure resource with location</summary>
    public partial class AzureTrackedResourceLocation :
        Microsoft.Azure.PowerShell.Cmdlets.Security.Models.IAzureTrackedResourceLocation,
        Microsoft.Azure.PowerShell.Cmdlets.Security.Models.IAzureTrackedResourceLocationInternal
    {

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>Location where the resource is stored</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Security.Origin(Microsoft.Azure.PowerShell.Cmdlets.Security.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>Creates an new <see cref="AzureTrackedResourceLocation" /> instance.</summary>
        public AzureTrackedResourceLocation()
        {

        }
    }
    /// Describes an Azure resource with location
    public partial interface IAzureTrackedResourceLocation :
        Microsoft.Azure.PowerShell.Cmdlets.Security.Runtime.IJsonSerializable
    {
        /// <summary>Location where the resource is stored</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Security.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Location where the resource is stored",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }

    }
    /// Describes an Azure resource with location
    internal partial interface IAzureTrackedResourceLocationInternal

    {
        /// <summary>Location where the resource is stored</summary>
        string Location { get; set; }

    }
}