// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The list of user identities associated with the container group.</summary>
    public partial class ContainerGroupIdentityUserAssignedIdentities :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.IContainerGroupIdentityUserAssignedIdentities,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.IContainerGroupIdentityUserAssignedIdentitiesInternal
    {

        /// <summary>
        /// Creates an new <see cref="ContainerGroupIdentityUserAssignedIdentities" /> instance.
        /// </summary>
        public ContainerGroupIdentityUserAssignedIdentities()
        {

        }
    }
    /// The list of user identities associated with the container group.
    public partial interface IContainerGroupIdentityUserAssignedIdentities :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.IUserAssignedIdentities>
    {

    }
    /// The list of user identities associated with the container group.
    internal partial interface IContainerGroupIdentityUserAssignedIdentitiesInternal

    {

    }
}