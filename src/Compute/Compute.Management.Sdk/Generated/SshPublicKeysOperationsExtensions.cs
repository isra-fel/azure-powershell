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
    /// Extension methods for SshPublicKeysOperations.
    /// </summary>
    public static partial class SshPublicKeysOperationsExtensions
    {
            /// <summary>
            /// Lists all of the SSH public keys in the subscription. Use the nextLink
            /// property in the response to get the next page of SSH public keys.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IPage<SshPublicKeyResource> ListBySubscription(this ISshPublicKeysOperations operations)
            {
                return operations.ListBySubscriptionAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists all of the SSH public keys in the subscription. Use the nextLink
            /// property in the response to get the next page of SSH public keys.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<SshPublicKeyResource>> ListBySubscriptionAsync(this ISshPublicKeysOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListBySubscriptionWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Lists all of the SSH public keys in the specified resource group. Use the
            /// nextLink property in the response to get the next page of SSH public keys.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            public static IPage<SshPublicKeyResource> ListByResourceGroup(this ISshPublicKeysOperations operations, string resourceGroupName)
            {
                return operations.ListByResourceGroupAsync(resourceGroupName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists all of the SSH public keys in the specified resource group. Use the
            /// nextLink property in the response to get the next page of SSH public keys.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<SshPublicKeyResource>> ListByResourceGroupAsync(this ISshPublicKeysOperations operations, string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByResourceGroupWithHttpMessagesAsync(resourceGroupName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Retrieves information about an SSH public key.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='sshPublicKeyName'>
            /// The name of the SSH public key.
            /// </param>
            public static SshPublicKeyResource Get(this ISshPublicKeysOperations operations, string resourceGroupName, string sshPublicKeyName)
            {
                return operations.GetAsync(resourceGroupName, sshPublicKeyName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Retrieves information about an SSH public key.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='sshPublicKeyName'>
            /// The name of the SSH public key.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<SshPublicKeyResource> GetAsync(this ISshPublicKeysOperations operations, string resourceGroupName, string sshPublicKeyName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, sshPublicKeyName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates a new SSH public key resource.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='sshPublicKeyName'>
            /// The name of the SSH public key.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to create the SSH public key.
            /// </param>
            public static SshPublicKeyResource Create(this ISshPublicKeysOperations operations, string resourceGroupName, string sshPublicKeyName, SshPublicKeyResource parameters)
            {
                return operations.CreateAsync(resourceGroupName, sshPublicKeyName, parameters).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates a new SSH public key resource.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='sshPublicKeyName'>
            /// The name of the SSH public key.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to create the SSH public key.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<SshPublicKeyResource> CreateAsync(this ISshPublicKeysOperations operations, string resourceGroupName, string sshPublicKeyName, SshPublicKeyResource parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateWithHttpMessagesAsync(resourceGroupName, sshPublicKeyName, parameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Updates a new SSH public key resource.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='sshPublicKeyName'>
            /// The name of the SSH public key.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to update the SSH public key.
            /// </param>
            public static SshPublicKeyResource Update(this ISshPublicKeysOperations operations, string resourceGroupName, string sshPublicKeyName, SshPublicKeyUpdateResource parameters)
            {
                return operations.UpdateAsync(resourceGroupName, sshPublicKeyName, parameters).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Updates a new SSH public key resource.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='sshPublicKeyName'>
            /// The name of the SSH public key.
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to update the SSH public key.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<SshPublicKeyResource> UpdateAsync(this ISshPublicKeysOperations operations, string resourceGroupName, string sshPublicKeyName, SshPublicKeyUpdateResource parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateWithHttpMessagesAsync(resourceGroupName, sshPublicKeyName, parameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Delete an SSH public key.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='sshPublicKeyName'>
            /// The name of the SSH public key.
            /// </param>
            public static void Delete(this ISshPublicKeysOperations operations, string resourceGroupName, string sshPublicKeyName)
            {
                operations.DeleteAsync(resourceGroupName, sshPublicKeyName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Delete an SSH public key.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='sshPublicKeyName'>
            /// The name of the SSH public key.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync(this ISshPublicKeysOperations operations, string resourceGroupName, string sshPublicKeyName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.DeleteWithHttpMessagesAsync(resourceGroupName, sshPublicKeyName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Generates and returns a public/private key pair and populates the SSH
            /// public key resource with the public key. The length of the key will be 3072
            /// bits. This operation can only be performed once per SSH public key
            /// resource.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='sshPublicKeyName'>
            /// The name of the SSH public key.
            /// </param>
            /// <param name='encryptionType'>
            /// The encryption type of the SSH keys to be generated. See SshEncryptionTypes
            /// for possible set of values. If not provided, will default to RSA. Possible
            /// values include: 'RSA', 'Ed25519'
            /// </param>
            public static SshPublicKeyGenerateKeyPairResult GenerateKeyPair(this ISshPublicKeysOperations operations, string resourceGroupName, string sshPublicKeyName, string encryptionType = default(string))
            {
                return operations.GenerateKeyPairAsync(resourceGroupName, sshPublicKeyName, encryptionType).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Generates and returns a public/private key pair and populates the SSH
            /// public key resource with the public key. The length of the key will be 3072
            /// bits. This operation can only be performed once per SSH public key
            /// resource.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='sshPublicKeyName'>
            /// The name of the SSH public key.
            /// </param>
            /// <param name='encryptionType'>
            /// The encryption type of the SSH keys to be generated. See SshEncryptionTypes
            /// for possible set of values. If not provided, will default to RSA. Possible
            /// values include: 'RSA', 'Ed25519'
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<SshPublicKeyGenerateKeyPairResult> GenerateKeyPairAsync(this ISshPublicKeysOperations operations, string resourceGroupName, string sshPublicKeyName, string encryptionType = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GenerateKeyPairWithHttpMessagesAsync(resourceGroupName, sshPublicKeyName, encryptionType, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Lists all of the SSH public keys in the subscription. Use the nextLink
            /// property in the response to get the next page of SSH public keys.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<SshPublicKeyResource> ListBySubscriptionNext(this ISshPublicKeysOperations operations, string nextPageLink)
            {
                return operations.ListBySubscriptionNextAsync(nextPageLink).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists all of the SSH public keys in the subscription. Use the nextLink
            /// property in the response to get the next page of SSH public keys.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<SshPublicKeyResource>> ListBySubscriptionNextAsync(this ISshPublicKeysOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListBySubscriptionNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Lists all of the SSH public keys in the specified resource group. Use the
            /// nextLink property in the response to get the next page of SSH public keys.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<SshPublicKeyResource> ListByResourceGroupNext(this ISshPublicKeysOperations operations, string nextPageLink)
            {
                return operations.ListByResourceGroupNextAsync(nextPageLink).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists all of the SSH public keys in the specified resource group. Use the
            /// nextLink property in the response to get the next page of SSH public keys.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<SshPublicKeyResource>> ListByResourceGroupNextAsync(this ISshPublicKeysOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByResourceGroupNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
