// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.Network
{
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// VpnLinkConnectionsOperations operations.
    /// </summary>
    public partial interface IVpnLinkConnectionsOperations
    {
        /// <summary>
        /// Resets the VpnLink connection specified.
        /// </summary>
        /// <remarks>
        /// Resets the VpnLink connection specified.
        /// </remarks>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='gatewayName'>
        /// The name of the gateway.
        /// </param>
        /// <param name='connectionName'>
        /// The name of the vpn connection.
        /// </param>
        /// <param name='linkConnectionName'>
        /// The name of the vpn link connection.
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
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse> ResetConnectionWithHttpMessagesAsync(string resourceGroupName, string gatewayName, string connectionName, string linkConnectionName, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Lists all shared keys of VpnLink connection specified.
        /// </summary>
        /// <remarks>
        /// Lists all shared keys of VpnLink connection specified.
        /// </remarks>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='gatewayName'>
        /// The name of the gateway.
        /// </param>
        /// <param name='connectionName'>
        /// The name of the vpn connection.
        /// </param>
        /// <param name='linkConnectionName'>
        /// The name of the vpn link connection.
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
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<Microsoft.Rest.Azure.IPage<ConnectionSharedKeyResult>>> GetAllSharedKeysWithHttpMessagesAsync(string resourceGroupName, string gatewayName, string connectionName, string linkConnectionName, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Gets the shared key of VpnLink connection specified.
        /// </summary>
        /// <remarks>
        /// Gets the shared key of VpnLink connection specified.
        /// </remarks>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='gatewayName'>
        /// The name of the gateway.
        /// </param>
        /// <param name='connectionName'>
        /// The name of the vpn connection.
        /// </param>
        /// <param name='linkConnectionName'>
        /// The name of the vpn link connection.
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
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<ConnectionSharedKeyResult>> GetDefaultSharedKeyWithHttpMessagesAsync(string resourceGroupName, string gatewayName, string connectionName, string linkConnectionName, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Sets or auto generates the shared key based on the user input. If users
        /// give a shared key value, it does the set operation. If key length is given,
        /// the operation creates a random key of the pre-defined length.
        /// </summary>
        /// <remarks>
        /// Sets or auto generates the shared key based on the user input. If users
        /// give a shared key value, it does the set operation. If key length is given,
        /// the operation creates a random key of the pre-defined length.
        /// </remarks>
        /// <param name='resourceGroupName'>
        /// The resource group name of the VpnGateway.
        /// </param>
        /// <param name='gatewayName'>
        /// The name of the gateway.
        /// </param>
        /// <param name='connectionName'>
        /// The name of the connection.
        /// </param>
        /// <param name='linkConnectionName'>
        /// The name of the vpn link connection.
        /// </param>
        /// <param name='connectionSharedKeyParameters'>
        /// Parameters supplied to set or auto generate the shared key for the vpn link
        /// connection.
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
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<ConnectionSharedKeyResult>> SetOrInitDefaultSharedKeyWithHttpMessagesAsync(string resourceGroupName, string gatewayName, string connectionName, string linkConnectionName, ConnectionSharedKeyResult connectionSharedKeyParameters, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Gets the value of the shared key of VpnLink connection specified.
        /// </summary>
        /// <remarks>
        /// Gets the value of the shared key of VpnLink connection specified.
        /// </remarks>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='gatewayName'>
        /// The name of the gateway.
        /// </param>
        /// <param name='connectionName'>
        /// The name of the vpn connection.
        /// </param>
        /// <param name='linkConnectionName'>
        /// The name of the vpn link connection.
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
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<ConnectionSharedKeyResult>> ListDefaultSharedKeyWithHttpMessagesAsync(string resourceGroupName, string gatewayName, string connectionName, string linkConnectionName, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Lists IKE Security Associations for Vpn Site Link Connection in the
        /// specified resource group.
        /// </summary>
        /// <remarks>
        /// Lists IKE Security Associations for Vpn Site Link Connection in the
        /// specified resource group.
        /// </remarks>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='gatewayName'>
        /// The name of the gateway.
        /// </param>
        /// <param name='connectionName'>
        /// The name of the vpn connection.
        /// </param>
        /// <param name='linkConnectionName'>
        /// The name of the vpn link connection.
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
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<string>> GetIkeSasWithHttpMessagesAsync(string resourceGroupName, string gatewayName, string connectionName, string linkConnectionName, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Retrieves all vpn site link connections for a particular virtual wan vpn
        /// gateway vpn connection.
        /// </summary>
        /// <remarks>
        /// Retrieves all vpn site link connections for a particular virtual wan vpn
        /// gateway vpn connection.
        /// </remarks>
        /// <param name='resourceGroupName'>
        /// The resource group name of the vpn gateway.
        /// </param>
        /// <param name='gatewayName'>
        /// The name of the gateway.
        /// </param>
        /// <param name='connectionName'>
        /// The name of the vpn connection.
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
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<Microsoft.Rest.Azure.IPage<VpnSiteLinkConnection>>> ListByVpnConnectionWithHttpMessagesAsync(string resourceGroupName, string gatewayName, string connectionName, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Resets the VpnLink connection specified.
        /// </summary>
        /// <remarks>
        /// Resets the VpnLink connection specified.
        /// </remarks>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='gatewayName'>
        /// The name of the gateway.
        /// </param>
        /// <param name='connectionName'>
        /// The name of the vpn connection.
        /// </param>
        /// <param name='linkConnectionName'>
        /// The name of the vpn link connection.
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
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse> BeginResetConnectionWithHttpMessagesAsync(string resourceGroupName, string gatewayName, string connectionName, string linkConnectionName, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Sets or auto generates the shared key based on the user input. If users
        /// give a shared key value, it does the set operation. If key length is given,
        /// the operation creates a random key of the pre-defined length.
        /// </summary>
        /// <remarks>
        /// Sets or auto generates the shared key based on the user input. If users
        /// give a shared key value, it does the set operation. If key length is given,
        /// the operation creates a random key of the pre-defined length.
        /// </remarks>
        /// <param name='resourceGroupName'>
        /// The resource group name of the VpnGateway.
        /// </param>
        /// <param name='gatewayName'>
        /// The name of the gateway.
        /// </param>
        /// <param name='connectionName'>
        /// The name of the connection.
        /// </param>
        /// <param name='linkConnectionName'>
        /// The name of the vpn link connection.
        /// </param>
        /// <param name='connectionSharedKeyParameters'>
        /// Parameters supplied to set or auto generate the shared key for the vpn link
        /// connection.
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
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<ConnectionSharedKeyResult>> BeginSetOrInitDefaultSharedKeyWithHttpMessagesAsync(string resourceGroupName, string gatewayName, string connectionName, string linkConnectionName, ConnectionSharedKeyResult connectionSharedKeyParameters, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Lists IKE Security Associations for Vpn Site Link Connection in the
        /// specified resource group.
        /// </summary>
        /// <remarks>
        /// Lists IKE Security Associations for Vpn Site Link Connection in the
        /// specified resource group.
        /// </remarks>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='gatewayName'>
        /// The name of the gateway.
        /// </param>
        /// <param name='connectionName'>
        /// The name of the vpn connection.
        /// </param>
        /// <param name='linkConnectionName'>
        /// The name of the vpn link connection.
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
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<string>> BeginGetIkeSasWithHttpMessagesAsync(string resourceGroupName, string gatewayName, string connectionName, string linkConnectionName, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Lists all shared keys of VpnLink connection specified.
        /// </summary>
        /// <remarks>
        /// Lists all shared keys of VpnLink connection specified.
        /// </remarks>
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
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<Microsoft.Rest.Azure.IPage<ConnectionSharedKeyResult>>> GetAllSharedKeysNextWithHttpMessagesAsync(string nextPageLink, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Retrieves all vpn site link connections for a particular virtual wan vpn
        /// gateway vpn connection.
        /// </summary>
        /// <remarks>
        /// Retrieves all vpn site link connections for a particular virtual wan vpn
        /// gateway vpn connection.
        /// </remarks>
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
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<Microsoft.Rest.Azure.IPage<VpnSiteLinkConnection>>> ListByVpnConnectionNextWithHttpMessagesAsync(string nextPageLink, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

    }
}