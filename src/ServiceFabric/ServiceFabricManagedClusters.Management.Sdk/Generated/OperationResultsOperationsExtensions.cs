// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.Management.ServiceFabricManagedClusters
{
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// Extension methods for OperationResultsOperations
    /// </summary>
    public static partial class OperationResultsOperationsExtensions
    {
        /// <summary>
        /// Get long running operation result.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='location'>
        /// The location for the cluster code versions. This is different from cluster location.
        /// </param>
        /// <param name='operationId'>
        /// operation identifier.
        /// </param>
        public static void Get(this IOperationResultsOperations operations, string location, string operationId)
        {
                ((IOperationResultsOperations)operations).GetAsync(location, operationId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get long running operation result.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='location'>
        /// The location for the cluster code versions. This is different from cluster location.
        /// </param>
        /// <param name='operationId'>
        /// operation identifier.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task GetAsync(this IOperationResultsOperations operations, string location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            (await operations.GetWithHttpMessagesAsync(location, operationId, null, cancellationToken).ConfigureAwait(false)).Dispose();
        }
    }
}
