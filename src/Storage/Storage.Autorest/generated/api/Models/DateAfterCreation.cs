// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Storage.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Extensions;

    /// <summary>Object to define snapshot and version action conditions.</summary>
    public partial class DateAfterCreation :
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IDateAfterCreation,
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IDateAfterCreationInternal
    {

        /// <summary>Backing field for <see cref="DaysAfterCreationGreaterThan" /> property.</summary>
        private float _daysAfterCreationGreaterThan;

        /// <summary>Value indicating the age in days after creation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Owned)]
        public float DaysAfterCreationGreaterThan { get => this._daysAfterCreationGreaterThan; set => this._daysAfterCreationGreaterThan = value; }

        /// <summary>Backing field for <see cref="DaysAfterLastTierChangeGreaterThan" /> property.</summary>
        private float? _daysAfterLastTierChangeGreaterThan;

        /// <summary>
        /// Value indicating the age in days after last blob tier change time. This property is only applicable for tierToArchive
        /// actions and requires daysAfterCreationGreaterThan to be set for snapshots and blob version based actions. The blob will
        /// be archived if both the conditions are satisfied.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Owned)]
        public float? DaysAfterLastTierChangeGreaterThan { get => this._daysAfterLastTierChangeGreaterThan; set => this._daysAfterLastTierChangeGreaterThan = value; }

        /// <summary>Creates an new <see cref="DateAfterCreation" /> instance.</summary>
        public DateAfterCreation()
        {

        }
    }
    /// Object to define snapshot and version action conditions.
    public partial interface IDateAfterCreation :
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.IJsonSerializable
    {
        /// <summary>Value indicating the age in days after creation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Value indicating the age in days after creation",
        SerializedName = @"daysAfterCreationGreaterThan",
        PossibleTypes = new [] { typeof(float) })]
        float DaysAfterCreationGreaterThan { get; set; }
        /// <summary>
        /// Value indicating the age in days after last blob tier change time. This property is only applicable for tierToArchive
        /// actions and requires daysAfterCreationGreaterThan to be set for snapshots and blob version based actions. The blob will
        /// be archived if both the conditions are satisfied.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Value indicating the age in days after last blob tier change time. This property is only applicable for tierToArchive actions and requires daysAfterCreationGreaterThan to be set for snapshots and blob version based actions. The blob will be archived if both the conditions are satisfied.",
        SerializedName = @"daysAfterLastTierChangeGreaterThan",
        PossibleTypes = new [] { typeof(float) })]
        float? DaysAfterLastTierChangeGreaterThan { get; set; }

    }
    /// Object to define snapshot and version action conditions.
    internal partial interface IDateAfterCreationInternal

    {
        /// <summary>Value indicating the age in days after creation</summary>
        float DaysAfterCreationGreaterThan { get; set; }
        /// <summary>
        /// Value indicating the age in days after last blob tier change time. This property is only applicable for tierToArchive
        /// actions and requires daysAfterCreationGreaterThan to be set for snapshots and blob version based actions. The blob will
        /// be archived if both the conditions are satisfied.
        /// </summary>
        float? DaysAfterLastTierChangeGreaterThan { get; set; }

    }
}