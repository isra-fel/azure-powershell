// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Runtime.Extensions;

    public partial class Label :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Models.ILabel,
        Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Models.ILabelInternal
    {

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Models.ILabelInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        [Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Creates an new <see cref="Label" /> instance.</summary>
        public Label()
        {

        }
    }
    public partial interface ILabel :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfigurationdata.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }

    }
    internal partial interface ILabelInternal

    {
        string Name { get; set; }

    }
}