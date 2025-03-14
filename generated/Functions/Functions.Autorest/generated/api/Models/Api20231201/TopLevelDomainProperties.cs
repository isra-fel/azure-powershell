// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>TopLevelDomain resource specific properties</summary>
    public partial class TopLevelDomainProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.ITopLevelDomainProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20231201.ITopLevelDomainPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Privacy" /> property.</summary>
        private bool? _privacy;

        /// <summary>
        /// If <code>true</code>, then the top level domain supports domain privacy; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? Privacy { get => this._privacy; set => this._privacy = value; }

        /// <summary>Creates an new <see cref="TopLevelDomainProperties" /> instance.</summary>
        public TopLevelDomainProperties()
        {

        }
    }
    /// TopLevelDomain resource specific properties
    public partial interface ITopLevelDomainProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// If <code>true</code>, then the top level domain supports domain privacy; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If <code>true</code>, then the top level domain supports domain privacy; otherwise, <code>false</code>.",
        SerializedName = @"privacy",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Privacy { get; set; }

    }
    /// TopLevelDomain resource specific properties
    internal partial interface ITopLevelDomainPropertiesInternal

    {
        /// <summary>
        /// If <code>true</code>, then the top level domain supports domain privacy; otherwise, <code>false</code>.
        /// </summary>
        bool? Privacy { get; set; }

    }
}