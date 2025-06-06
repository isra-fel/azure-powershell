// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Runtime.Extensions;

    /// <summary>Kubernetes reference</summary>
    public partial class KubernetesReference :
        Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IKubernetesReference,
        Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IKubernetesReferenceInternal
    {

        /// <summary>Backing field for <see cref="ApiGroup" /> property.</summary>
        private string _apiGroup;

        /// <summary>
        /// APIGroup is the group for the resource being referenced. If APIGroup is not specified, the specified Kind must be in the
        /// core API group. For any other third-party types, APIGroup is required.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Origin(Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.PropertyOrigin.Owned)]
        public string ApiGroup { get => this._apiGroup; set => this._apiGroup = value; }

        /// <summary>Backing field for <see cref="Kind" /> property.</summary>
        private string _kind;

        /// <summary>Kind is the type of resource being referenced</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Origin(Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.PropertyOrigin.Owned)]
        public string Kind { get => this._kind; set => this._kind = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name is the name of resource being referenced</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Origin(Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Namespace" /> property.</summary>
        private string _namespace;

        /// <summary>
        /// Namespace is the namespace of the resource being referenced. This field is required when the resource has a namespace.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Origin(Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.PropertyOrigin.Owned)]
        public string Namespace { get => this._namespace; set => this._namespace = value; }

        /// <summary>Creates an new <see cref="KubernetesReference" /> instance.</summary>
        public KubernetesReference()
        {

        }
    }
    /// Kubernetes reference
    public partial interface IKubernetesReference :
        Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Runtime.IJsonSerializable
    {
        /// <summary>
        /// APIGroup is the group for the resource being referenced. If APIGroup is not specified, the specified Kind must be in the
        /// core API group. For any other third-party types, APIGroup is required.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"APIGroup is the group for the resource being referenced. If APIGroup is not specified, the specified Kind must be in the core API group. For any other third-party types, APIGroup is required.",
        SerializedName = @"apiGroup",
        PossibleTypes = new [] { typeof(string) })]
        string ApiGroup { get; set; }
        /// <summary>Kind is the type of resource being referenced</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Kind is the type of resource being referenced",
        SerializedName = @"kind",
        PossibleTypes = new [] { typeof(string) })]
        string Kind { get; set; }
        /// <summary>Name is the name of resource being referenced</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Name is the name of resource being referenced",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>
        /// Namespace is the namespace of the resource being referenced. This field is required when the resource has a namespace.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Namespace is the namespace of the resource being referenced. This field is required when the resource has a namespace.",
        SerializedName = @"namespace",
        PossibleTypes = new [] { typeof(string) })]
        string Namespace { get; set; }

    }
    /// Kubernetes reference
    internal partial interface IKubernetesReferenceInternal

    {
        /// <summary>
        /// APIGroup is the group for the resource being referenced. If APIGroup is not specified, the specified Kind must be in the
        /// core API group. For any other third-party types, APIGroup is required.
        /// </summary>
        string ApiGroup { get; set; }
        /// <summary>Kind is the type of resource being referenced</summary>
        string Kind { get; set; }
        /// <summary>Name is the name of resource being referenced</summary>
        string Name { get; set; }
        /// <summary>
        /// Namespace is the namespace of the resource being referenced. This field is required when the resource has a namespace.
        /// </summary>
        string Namespace { get; set; }

    }
}