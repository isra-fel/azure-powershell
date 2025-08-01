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
    /// DedicatedHostsOperations operations.
    /// </summary>
    public partial interface IDedicatedHostsOperations
    {
        /// <summary>
        /// Lists all of the dedicated hosts in the specified dedicated host
        /// group. Use the nextLink property in the response to get the next
        /// page of dedicated hosts.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name='hostGroupName'>
        /// The name of the dedicated host group.
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
        Task<AzureOperationResponse<IPage<DedicatedHost>>> ListByHostGroupWithHttpMessagesAsync(string resourceGroupName, string hostGroupName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Retrieves information about a dedicated host.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name='hostGroupName'>
        /// The name of the dedicated host group.
        /// </param>
        /// <param name='hostName'>
        /// The name of the dedicated host.
        /// </param>
        /// <param name='expand'>
        /// The expand expression to apply on the operation. 'InstanceView'
        /// will retrieve the list of instance views of the dedicated host.
        /// 'UserData' is not supported for dedicated host. Possible values
        /// include: 'instanceView', 'userData', 'resiliencyView'
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
        Task<AzureOperationResponse<DedicatedHost>> GetWithHttpMessagesAsync(string resourceGroupName, string hostGroupName, string hostName, InstanceViewTypes? expand = default(InstanceViewTypes?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Create or update a dedicated host .
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name='hostGroupName'>
        /// The name of the dedicated host group.
        /// </param>
        /// <param name='hostName'>
        /// The name of the dedicated host.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Create Dedicated Host.
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
        Task<AzureOperationResponse<DedicatedHost,DedicatedHostsCreateOrUpdateHeaders>> CreateOrUpdateWithHttpMessagesAsync(string resourceGroupName, string hostGroupName, string hostName, DedicatedHost parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Update a dedicated host .
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name='hostGroupName'>
        /// The name of the dedicated host group.
        /// </param>
        /// <param name='hostName'>
        /// The name of the dedicated host.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Update Dedicated Host operation.
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
        Task<AzureOperationResponse<DedicatedHost,DedicatedHostsUpdateHeaders>> UpdateWithHttpMessagesAsync(string resourceGroupName, string hostGroupName, string hostName, DedicatedHostUpdate parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Delete a dedicated host.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name='hostGroupName'>
        /// The name of the dedicated host group.
        /// </param>
        /// <param name='hostName'>
        /// The name of the dedicated host.
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
        Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(string resourceGroupName, string hostGroupName, string hostName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists all available dedicated host sizes to which the specified
        /// dedicated host can be resized. NOTE: The dedicated host sizes
        /// provided can be used to only scale up the existing dedicated host.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name='hostGroupName'>
        /// The name of the dedicated host group.
        /// </param>
        /// <param name='hostName'>
        /// The name of the dedicated host.
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
        Task<AzureOperationResponse<IEnumerable<string>>> ListAvailableSizesWithHttpMessagesAsync(string resourceGroupName, string hostGroupName, string hostName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Redeploy the dedicated host. The operation will complete
        /// successfully once the dedicated host has migrated to a new node and
        /// is running. To determine the health of VMs deployed on the
        /// dedicated host after the redeploy check the Resource Health Center
        /// in the Azure Portal. Please refer to
        /// https://docs.microsoft.com/azure/service-health/resource-health-overview
        /// for more details.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name='hostGroupName'>
        /// The name of the dedicated host group.
        /// </param>
        /// <param name='hostName'>
        /// The name of the dedicated host.
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
        Task<AzureOperationHeaderResponse<DedicatedHostsRedeployHeaders>> RedeployWithHttpMessagesAsync(string resourceGroupName, string hostGroupName, string hostName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Restart the dedicated host. The operation will complete
        /// successfully once the dedicated host has restarted and is running.
        /// To determine the health of VMs deployed on the dedicated host after
        /// the restart check the Resource Health Center in the Azure Portal.
        /// Please refer to
        /// https://docs.microsoft.com/azure/service-health/resource-health-overview
        /// for more details.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name='hostGroupName'>
        /// The name of the dedicated host group.
        /// </param>
        /// <param name='hostName'>
        /// The name of the dedicated host.
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
        Task<AzureOperationHeaderResponse<DedicatedHostsRestartHeaders>> RestartWithHttpMessagesAsync(string resourceGroupName, string hostGroupName, string hostName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Create or update a dedicated host .
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name='hostGroupName'>
        /// The name of the dedicated host group.
        /// </param>
        /// <param name='hostName'>
        /// The name of the dedicated host.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Create Dedicated Host.
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
        Task<AzureOperationResponse<DedicatedHost,DedicatedHostsCreateOrUpdateHeaders>> BeginCreateOrUpdateWithHttpMessagesAsync(string resourceGroupName, string hostGroupName, string hostName, DedicatedHost parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Update a dedicated host .
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name='hostGroupName'>
        /// The name of the dedicated host group.
        /// </param>
        /// <param name='hostName'>
        /// The name of the dedicated host.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Update Dedicated Host operation.
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
        Task<AzureOperationResponse<DedicatedHost,DedicatedHostsUpdateHeaders>> BeginUpdateWithHttpMessagesAsync(string resourceGroupName, string hostGroupName, string hostName, DedicatedHostUpdate parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Delete a dedicated host.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name='hostGroupName'>
        /// The name of the dedicated host group.
        /// </param>
        /// <param name='hostName'>
        /// The name of the dedicated host.
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
        Task<AzureOperationResponse> BeginDeleteWithHttpMessagesAsync(string resourceGroupName, string hostGroupName, string hostName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Redeploy the dedicated host. The operation will complete
        /// successfully once the dedicated host has migrated to a new node and
        /// is running. To determine the health of VMs deployed on the
        /// dedicated host after the redeploy check the Resource Health Center
        /// in the Azure Portal. Please refer to
        /// https://docs.microsoft.com/azure/service-health/resource-health-overview
        /// for more details.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name='hostGroupName'>
        /// The name of the dedicated host group.
        /// </param>
        /// <param name='hostName'>
        /// The name of the dedicated host.
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
        Task<AzureOperationHeaderResponse<DedicatedHostsRedeployHeaders>> BeginRedeployWithHttpMessagesAsync(string resourceGroupName, string hostGroupName, string hostName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Restart the dedicated host. The operation will complete
        /// successfully once the dedicated host has restarted and is running.
        /// To determine the health of VMs deployed on the dedicated host after
        /// the restart check the Resource Health Center in the Azure Portal.
        /// Please refer to
        /// https://docs.microsoft.com/azure/service-health/resource-health-overview
        /// for more details.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name='hostGroupName'>
        /// The name of the dedicated host group.
        /// </param>
        /// <param name='hostName'>
        /// The name of the dedicated host.
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
        Task<AzureOperationHeaderResponse<DedicatedHostsRestartHeaders>> BeginRestartWithHttpMessagesAsync(string resourceGroupName, string hostGroupName, string hostName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists all of the dedicated hosts in the specified dedicated host
        /// group. Use the nextLink property in the response to get the next
        /// page of dedicated hosts.
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
        Task<AzureOperationResponse<IPage<DedicatedHost>>> ListByHostGroupNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
