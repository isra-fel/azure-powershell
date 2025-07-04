// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace ADT.Models
{
    using static ADT.Runtime.Extensions;

    /// <summary>The action to be executed.</summary>
    public partial class Action :
        ADT.Models.IAction,
        ADT.Models.IActionInternal
    {

        /// <summary>Backing field for <see cref="Justification" /> property.</summary>
        private string _justification;

        /// <summary>Business justification for the action</summary>
        [ADT.Origin(ADT.PropertyOrigin.Owned)]
        public string Justification { get => this._justification; set => this._justification = value; }

        /// <summary>Backing field for <see cref="Target" /> property.</summary>
        private System.Collections.Generic.List<string> _target;

        /// <summary>Targets for the action</summary>
        [ADT.Origin(ADT.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> Target { get => this._target; set => this._target = value; }

        /// <summary>Backing field for <see cref="TargetType" /> property.</summary>
        private string _targetType;

        /// <summary>Type of target to execute the action on</summary>
        [ADT.Origin(ADT.PropertyOrigin.Owned)]
        public string TargetType { get => this._targetType; set => this._targetType = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Type of action to be executed</summary>
        [ADT.Origin(ADT.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="Action" /> instance.</summary>
        public Action()
        {

        }
    }
    /// The action to be executed.
    public partial interface IAction :
        ADT.Runtime.IJsonSerializable
    {
        /// <summary>Business justification for the action</summary>
        [ADT.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Business justification for the action",
        SerializedName = @"justification",
        PossibleTypes = new [] { typeof(string) })]
        string Justification { get; set; }
        /// <summary>Targets for the action</summary>
        [ADT.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Targets for the action",
        SerializedName = @"targets",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> Target { get; set; }
        /// <summary>Type of target to execute the action on</summary>
        [ADT.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Type of target to execute the action on",
        SerializedName = @"targetType",
        PossibleTypes = new [] { typeof(string) })]
        [global::ADT.PSArgumentCompleterAttribute("Pipeline", "Connection", "FlowType")]
        string TargetType { get; set; }
        /// <summary>Type of action to be executed</summary>
        [ADT.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Type of action to be executed",
        SerializedName = @"actionType",
        PossibleTypes = new [] { typeof(string) })]
        [global::ADT.PSArgumentCompleterAttribute("AllowUpdates", "ForceDisable")]
        string Type { get; set; }

    }
    /// The action to be executed.
    internal partial interface IActionInternal

    {
        /// <summary>Business justification for the action</summary>
        string Justification { get; set; }
        /// <summary>Targets for the action</summary>
        System.Collections.Generic.List<string> Target { get; set; }
        /// <summary>Type of target to execute the action on</summary>
        [global::ADT.PSArgumentCompleterAttribute("Pipeline", "Connection", "FlowType")]
        string TargetType { get; set; }
        /// <summary>Type of action to be executed</summary>
        [global::ADT.PSArgumentCompleterAttribute("AllowUpdates", "ForceDisable")]
        string Type { get; set; }

    }
}