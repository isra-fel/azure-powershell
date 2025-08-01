// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Extensions;

    /// <summary>
    /// KubernetesClusterFeaturePatchParameters represents the body of the request to patch the Kubernetes cluster feature.
    /// </summary>
    public partial class KubernetesClusterFeaturePatchParameters :
        Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IKubernetesClusterFeaturePatchParameters,
        Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IKubernetesClusterFeaturePatchParametersInternal
    {

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IKubernetesClusterFeaturePatchProperties Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IKubernetesClusterFeaturePatchParametersInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.KubernetesClusterFeaturePatchProperties()); set { {_property = value;} } }

        /// <summary>The configured options for the feature.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IStringKeyValuePair[] Option { get => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IKubernetesClusterFeaturePatchPropertiesInternal)Property).Option; set => ((Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IKubernetesClusterFeaturePatchPropertiesInternal)Property).Option = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IKubernetesClusterFeaturePatchProperties _property;

        /// <summary>The list of the resource properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IKubernetesClusterFeaturePatchProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.KubernetesClusterFeaturePatchProperties()); set => this._property = value; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IKubernetesClusterFeaturePatchParametersTags _tag;

        /// <summary>The Azure resource tags that will replace the existing ones.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IKubernetesClusterFeaturePatchParametersTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.KubernetesClusterFeaturePatchParametersTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="KubernetesClusterFeaturePatchParameters" /> instance.</summary>
        public KubernetesClusterFeaturePatchParameters()
        {

        }
    }
    /// KubernetesClusterFeaturePatchParameters represents the body of the request to patch the Kubernetes cluster feature.
    public partial interface IKubernetesClusterFeaturePatchParameters :
        Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.IJsonSerializable
    {
        /// <summary>The configured options for the feature.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The configured options for the feature.",
        SerializedName = @"options",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IStringKeyValuePair) })]
        Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IStringKeyValuePair[] Option { get; set; }
        /// <summary>The Azure resource tags that will replace the existing ones.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Azure resource tags that will replace the existing ones.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IKubernetesClusterFeaturePatchParametersTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IKubernetesClusterFeaturePatchParametersTags Tag { get; set; }

    }
    /// KubernetesClusterFeaturePatchParameters represents the body of the request to patch the Kubernetes cluster feature.
    internal partial interface IKubernetesClusterFeaturePatchParametersInternal

    {
        /// <summary>The configured options for the feature.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IStringKeyValuePair[] Option { get; set; }
        /// <summary>The list of the resource properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IKubernetesClusterFeaturePatchProperties Property { get; set; }
        /// <summary>The Azure resource tags that will replace the existing ones.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IKubernetesClusterFeaturePatchParametersTags Tag { get; set; }

    }
}