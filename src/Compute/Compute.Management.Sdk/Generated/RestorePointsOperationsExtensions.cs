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
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for RestorePointsOperations.
    /// </summary>
    public static partial class RestorePointsOperationsExtensions
    {
            /// <summary>
            /// The operation to get the restore point.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='restorePointCollectionName'>
            /// The name of the restore point collection.
            /// </param>
            /// <param name='restorePointName'>
            /// The name of the restore point.
            /// </param>
            /// <param name='expand'>
            /// The expand expression to apply on the operation. 'InstanceView' retrieves
            /// information about the run-time state of a restore point. Possible values
            /// include: 'instanceView'
            /// </param>
            public static RestorePoint Get(this IRestorePointsOperations operations, string resourceGroupName, string restorePointCollectionName, string restorePointName, string expand = default(string))
            {
                return operations.GetAsync(resourceGroupName, restorePointCollectionName, restorePointName, expand).GetAwaiter().GetResult();
            }

            /// <summary>
            /// The operation to get the restore point.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='restorePointCollectionName'>
            /// The name of the restore point collection.
            /// </param>
            /// <param name='restorePointName'>
            /// The name of the restore point.
            /// </param>
            /// <param name='expand'>
            /// The expand expression to apply on the operation. 'InstanceView' retrieves
            /// information about the run-time state of a restore point. Possible values
            /// include: 'instanceView'
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<RestorePoint> GetAsync(this IRestorePointsOperations operations, string resourceGroupName, string restorePointCollectionName, string restorePointName, string expand = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, restorePointCollectionName, restorePointName, expand, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// The operation to create the restore point. Updating properties of an
            /// existing restore point is not allowed
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='restorePointCollectionName'>
            /// The name of the restore point collection.
            /// </param>
            /// <param name='restorePointName'>
            /// The name of the restore point.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the Create restore point operation.
            /// </param>
            public static RestorePoint Create(this IRestorePointsOperations operations, string resourceGroupName, string restorePointCollectionName, string restorePointName, RestorePoint parameters)
            {
                return operations.CreateAsync(resourceGroupName, restorePointCollectionName, restorePointName, parameters).GetAwaiter().GetResult();
            }

            /// <summary>
            /// The operation to create the restore point. Updating properties of an
            /// existing restore point is not allowed
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='restorePointCollectionName'>
            /// The name of the restore point collection.
            /// </param>
            /// <param name='restorePointName'>
            /// The name of the restore point.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the Create restore point operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<RestorePoint> CreateAsync(this IRestorePointsOperations operations, string resourceGroupName, string restorePointCollectionName, string restorePointName, RestorePoint parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateWithHttpMessagesAsync(resourceGroupName, restorePointCollectionName, restorePointName, parameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// The operation to delete the restore point.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='restorePointCollectionName'>
            /// The name of the restore point collection.
            /// </param>
            /// <param name='restorePointName'>
            /// The name of the restore point.
            /// </param>
            public static void Delete(this IRestorePointsOperations operations, string resourceGroupName, string restorePointCollectionName, string restorePointName)
            {
                operations.DeleteAsync(resourceGroupName, restorePointCollectionName, restorePointName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// The operation to delete the restore point.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='restorePointCollectionName'>
            /// The name of the restore point collection.
            /// </param>
            /// <param name='restorePointName'>
            /// The name of the restore point.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync(this IRestorePointsOperations operations, string resourceGroupName, string restorePointCollectionName, string restorePointName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.DeleteWithHttpMessagesAsync(resourceGroupName, restorePointCollectionName, restorePointName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// The operation to create the restore point. Updating properties of an
            /// existing restore point is not allowed
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='restorePointCollectionName'>
            /// The name of the restore point collection.
            /// </param>
            /// <param name='restorePointName'>
            /// The name of the restore point.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the Create restore point operation.
            /// </param>
            public static RestorePoint BeginCreate(this IRestorePointsOperations operations, string resourceGroupName, string restorePointCollectionName, string restorePointName, RestorePoint parameters)
            {
                return operations.BeginCreateAsync(resourceGroupName, restorePointCollectionName, restorePointName, parameters).GetAwaiter().GetResult();
            }

            /// <summary>
            /// The operation to create the restore point. Updating properties of an
            /// existing restore point is not allowed
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='restorePointCollectionName'>
            /// The name of the restore point collection.
            /// </param>
            /// <param name='restorePointName'>
            /// The name of the restore point.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the Create restore point operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<RestorePoint> BeginCreateAsync(this IRestorePointsOperations operations, string resourceGroupName, string restorePointCollectionName, string restorePointName, RestorePoint parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginCreateWithHttpMessagesAsync(resourceGroupName, restorePointCollectionName, restorePointName, parameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// The operation to delete the restore point.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='restorePointCollectionName'>
            /// The name of the restore point collection.
            /// </param>
            /// <param name='restorePointName'>
            /// The name of the restore point.
            /// </param>
            public static void BeginDelete(this IRestorePointsOperations operations, string resourceGroupName, string restorePointCollectionName, string restorePointName)
            {
                operations.BeginDeleteAsync(resourceGroupName, restorePointCollectionName, restorePointName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// The operation to delete the restore point.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='restorePointCollectionName'>
            /// The name of the restore point collection.
            /// </param>
            /// <param name='restorePointName'>
            /// The name of the restore point.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task BeginDeleteAsync(this IRestorePointsOperations operations, string resourceGroupName, string restorePointCollectionName, string restorePointName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.BeginDeleteWithHttpMessagesAsync(resourceGroupName, restorePointCollectionName, restorePointName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

    }
}
