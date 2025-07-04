// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Extensions;

    /// <summary>
    /// KubernetesClusterRestartNodeParameters represents the body of the request to restart the node of a Kubernetes cluster.
    /// </summary>
    public partial class KubernetesClusterRestartNodeParameters :
        Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IKubernetesClusterRestartNodeParameters,
        Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IKubernetesClusterRestartNodeParametersInternal
    {

        /// <summary>Backing field for <see cref="NodeName" /> property.</summary>
        private string _nodeName;

        /// <summary>The name of the node to restart.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.PropertyOrigin.Owned)]
        public string NodeName { get => this._nodeName; set => this._nodeName = value; }

        /// <summary>Creates an new <see cref="KubernetesClusterRestartNodeParameters" /> instance.</summary>
        public KubernetesClusterRestartNodeParameters()
        {

        }
    }
    /// KubernetesClusterRestartNodeParameters represents the body of the request to restart the node of a Kubernetes cluster.
    public partial interface IKubernetesClusterRestartNodeParameters :
        Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.IJsonSerializable
    {
        /// <summary>The name of the node to restart.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the node to restart.",
        SerializedName = @"nodeName",
        PossibleTypes = new [] { typeof(string) })]
        string NodeName { get; set; }

    }
    /// KubernetesClusterRestartNodeParameters represents the body of the request to restart the node of a Kubernetes cluster.
    internal partial interface IKubernetesClusterRestartNodeParametersInternal

    {
        /// <summary>The name of the node to restart.</summary>
        string NodeName { get; set; }

    }
}