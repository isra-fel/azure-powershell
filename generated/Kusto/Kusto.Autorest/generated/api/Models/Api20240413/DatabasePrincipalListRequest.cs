// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>The list Kusto database principals operation request.</summary>
    public partial class DatabasePrincipalListRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.IDatabasePrincipalListRequest,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.IDatabasePrincipalListRequestInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.IDatabasePrincipal[] _value;

        /// <summary>The list of Kusto database principals.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.IDatabasePrincipal[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="DatabasePrincipalListRequest" /> instance.</summary>
        public DatabasePrincipalListRequest()
        {

        }
    }
    /// The list Kusto database principals operation request.
    public partial interface IDatabasePrincipalListRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>The list of Kusto database principals.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of Kusto database principals.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.IDatabasePrincipal) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.IDatabasePrincipal[] Value { get; set; }

    }
    /// The list Kusto database principals operation request.
    internal partial interface IDatabasePrincipalListRequestInternal

    {
        /// <summary>The list of Kusto database principals.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.IDatabasePrincipal[] Value { get; set; }

    }
}