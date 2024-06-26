// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Runtime.Extensions;

    /// <summary>
    /// The Active Directory Object that will be used for authenticating the token of a container registry.
    /// </summary>
    public partial class ActiveDirectoryObject :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IActiveDirectoryObject,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IActiveDirectoryObjectInternal
    {

        /// <summary>Backing field for <see cref="ObjectId" /> property.</summary>
        private string _objectId;

        /// <summary>
        /// The user/group/application object ID for Active Directory Object that will be used for authenticating the token of a container
        /// registry.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.PropertyOrigin.Owned)]
        public string ObjectId { get => this._objectId; set => this._objectId = value; }

        /// <summary>Backing field for <see cref="TenantId" /> property.</summary>
        private string _tenantId;

        /// <summary>
        /// The tenant ID of user/group/application object Active Directory Object that will be used for authenticating the token
        /// of a container registry.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.PropertyOrigin.Owned)]
        public string TenantId { get => this._tenantId; set => this._tenantId = value; }

        /// <summary>Creates an new <see cref="ActiveDirectoryObject" /> instance.</summary>
        public ActiveDirectoryObject()
        {

        }
    }
    /// The Active Directory Object that will be used for authenticating the token of a container registry.
    public partial interface IActiveDirectoryObject :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The user/group/application object ID for Active Directory Object that will be used for authenticating the token of a container
        /// registry.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The user/group/application object ID for Active Directory Object that will be used for authenticating the token of a container registry.",
        SerializedName = @"objectId",
        PossibleTypes = new [] { typeof(string) })]
        string ObjectId { get; set; }
        /// <summary>
        /// The tenant ID of user/group/application object Active Directory Object that will be used for authenticating the token
        /// of a container registry.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The tenant ID of user/group/application object Active Directory Object that will be used for authenticating the token of a container registry.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string TenantId { get; set; }

    }
    /// The Active Directory Object that will be used for authenticating the token of a container registry.
    internal partial interface IActiveDirectoryObjectInternal

    {
        /// <summary>
        /// The user/group/application object ID for Active Directory Object that will be used for authenticating the token of a container
        /// registry.
        /// </summary>
        string ObjectId { get; set; }
        /// <summary>
        /// The tenant ID of user/group/application object Active Directory Object that will be used for authenticating the token
        /// of a container registry.
        /// </summary>
        string TenantId { get; set; }

    }
}