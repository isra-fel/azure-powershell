// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Oracle.Runtime.Extensions;

    /// <summary>GiVersion resource model</summary>
    public partial class GiVersionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IGiVersionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IGiVersionPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private string _version;

        /// <summary>A valid Oracle Grid Infrastructure (GI) software version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Oracle.Origin(Microsoft.Azure.PowerShell.Cmdlets.Oracle.PropertyOrigin.Owned)]
        public string Version { get => this._version; set => this._version = value; }

        /// <summary>Creates an new <see cref="GiVersionProperties" /> instance.</summary>
        public GiVersionProperties()
        {

        }
    }
    /// GiVersion resource model
    public partial interface IGiVersionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Oracle.Runtime.IJsonSerializable
    {
        /// <summary>A valid Oracle Grid Infrastructure (GI) software version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Oracle.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"A valid Oracle Grid Infrastructure (GI) software version.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string Version { get; set; }

    }
    /// GiVersion resource model
    internal partial interface IGiVersionPropertiesInternal

    {
        /// <summary>A valid Oracle Grid Infrastructure (GI) software version.</summary>
        string Version { get; set; }

    }
}