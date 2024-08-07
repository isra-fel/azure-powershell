// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.Api20221001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Peering.Runtime.Extensions;

    /// <summary>Looking glass output model</summary>
    public partial class LookingGlassOutput :
        Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.Api20221001.ILookingGlassOutput,
        Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.Api20221001.ILookingGlassOutputInternal
    {

        /// <summary>Backing field for <see cref="Command" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Peering.Support.Command? _command;

        /// <summary>Invoked command</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Peering.Origin(Microsoft.Azure.PowerShell.Cmdlets.Peering.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Peering.Support.Command? Command { get => this._command; set => this._command = value; }

        /// <summary>Backing field for <see cref="Output" /> property.</summary>
        private string _output;

        /// <summary>Output of the command</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Peering.Origin(Microsoft.Azure.PowerShell.Cmdlets.Peering.PropertyOrigin.Owned)]
        public string Output { get => this._output; set => this._output = value; }

        /// <summary>Creates an new <see cref="LookingGlassOutput" /> instance.</summary>
        public LookingGlassOutput()
        {

        }
    }
    /// Looking glass output model
    public partial interface ILookingGlassOutput :
        Microsoft.Azure.PowerShell.Cmdlets.Peering.Runtime.IJsonSerializable
    {
        /// <summary>Invoked command</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Peering.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Invoked command",
        SerializedName = @"command",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Peering.Support.Command) })]
        Microsoft.Azure.PowerShell.Cmdlets.Peering.Support.Command? Command { get; set; }
        /// <summary>Output of the command</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Peering.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Output of the command",
        SerializedName = @"output",
        PossibleTypes = new [] { typeof(string) })]
        string Output { get; set; }

    }
    /// Looking glass output model
    internal partial interface ILookingGlassOutputInternal

    {
        /// <summary>Invoked command</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Peering.Support.Command? Command { get; set; }
        /// <summary>Output of the command</summary>
        string Output { get; set; }

    }
}