// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Compute
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// DiskRestorePointOperations operations.
    /// </summary>
    public partial interface IDiskRestorePointOperations
    {
        /// <summary>
        /// Lists diskRestorePoints under a vmRestorePoint.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name='restorePointCollectionName'>
        /// The name of the restore point collection that the disk restore
        /// point belongs.
        /// </param>
        /// <param name='vmRestorePointName'>
        /// The name of the vm restore point that the disk disk restore point
        /// belongs.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<IPage<DiskRestorePoint>>> ListByRestorePointWithHttpMessagesAsync(string resourceGroupName, string restorePointCollectionName, string vmRestorePointName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get disk restorePoint resource
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name='restorePointCollectionName'>
        /// The name of the restore point collection that the disk restore
        /// point belongs.
        /// </param>
        /// <param name='vmRestorePointName'>
        /// The name of the vm restore point that the disk disk restore point
        /// belongs.
        /// </param>
        /// <param name='diskRestorePointName'>
        /// The name of the DiskRestorePoint
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<DiskRestorePoint>> GetWithHttpMessagesAsync(string resourceGroupName, string restorePointCollectionName, string vmRestorePointName, string diskRestorePointName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Grants access to a diskRestorePoint.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name='restorePointCollectionName'>
        /// The name of the restore point collection that the disk restore
        /// point belongs.
        /// </param>
        /// <param name='vmRestorePointName'>
        /// The name of the vm restore point that the disk disk restore point
        /// belongs.
        /// </param>
        /// <param name='diskRestorePointName'>
        /// The name of the DiskRestorePoint
        /// </param>
        /// <param name='grantAccessData'>
        /// Access data object supplied in the body of the get disk access
        /// operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<AccessUri>> GrantAccessWithHttpMessagesAsync(string resourceGroupName, string restorePointCollectionName, string vmRestorePointName, string diskRestorePointName, GrantAccessData grantAccessData, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Revokes access to a diskRestorePoint.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name='restorePointCollectionName'>
        /// The name of the restore point collection that the disk restore
        /// point belongs.
        /// </param>
        /// <param name='vmRestorePointName'>
        /// The name of the vm restore point that the disk disk restore point
        /// belongs.
        /// </param>
        /// <param name='diskRestorePointName'>
        /// The name of the DiskRestorePoint
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse> RevokeAccessWithHttpMessagesAsync(string resourceGroupName, string restorePointCollectionName, string vmRestorePointName, string diskRestorePointName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Grants access to a diskRestorePoint.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name='restorePointCollectionName'>
        /// The name of the restore point collection that the disk restore
        /// point belongs.
        /// </param>
        /// <param name='vmRestorePointName'>
        /// The name of the vm restore point that the disk disk restore point
        /// belongs.
        /// </param>
        /// <param name='diskRestorePointName'>
        /// The name of the DiskRestorePoint
        /// </param>
        /// <param name='grantAccessData'>
        /// Access data object supplied in the body of the get disk access
        /// operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<AccessUri>> BeginGrantAccessWithHttpMessagesAsync(string resourceGroupName, string restorePointCollectionName, string vmRestorePointName, string diskRestorePointName, GrantAccessData grantAccessData, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Revokes access to a diskRestorePoint.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name='restorePointCollectionName'>
        /// The name of the restore point collection that the disk restore
        /// point belongs.
        /// </param>
        /// <param name='vmRestorePointName'>
        /// The name of the vm restore point that the disk disk restore point
        /// belongs.
        /// </param>
        /// <param name='diskRestorePointName'>
        /// The name of the DiskRestorePoint
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse> BeginRevokeAccessWithHttpMessagesAsync(string resourceGroupName, string restorePointCollectionName, string vmRestorePointName, string diskRestorePointName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists diskRestorePoints under a vmRestorePoint.
        /// </summary>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<IPage<DiskRestorePoint>>> ListByRestorePointNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
