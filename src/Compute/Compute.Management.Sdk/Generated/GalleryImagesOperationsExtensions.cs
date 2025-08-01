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
    /// Extension methods for GalleryImagesOperations.
    /// </summary>
    public static partial class GalleryImagesOperationsExtensions
    {
            /// <summary>
            /// List gallery image definitions in a gallery.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='galleryName'>
            /// The name of the Shared Image Gallery.
            /// </param>
            public static IPage<GalleryImage> ListByGallery(this IGalleryImagesOperations operations, string resourceGroupName, string galleryName)
            {
                return operations.ListByGalleryAsync(resourceGroupName, galleryName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// List gallery image definitions in a gallery.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='galleryName'>
            /// The name of the Shared Image Gallery.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<GalleryImage>> ListByGalleryAsync(this IGalleryImagesOperations operations, string resourceGroupName, string galleryName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByGalleryWithHttpMessagesAsync(resourceGroupName, galleryName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Retrieves information about a gallery image definition.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='galleryName'>
            /// The name of the Shared Image Gallery.
            /// </param>
            /// <param name='galleryImageName'>
            /// The name of the gallery image definition to be retrieved.
            /// </param>
            public static GalleryImage Get(this IGalleryImagesOperations operations, string resourceGroupName, string galleryName, string galleryImageName)
            {
                return operations.GetAsync(resourceGroupName, galleryName, galleryImageName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Retrieves information about a gallery image definition.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='galleryName'>
            /// The name of the Shared Image Gallery.
            /// </param>
            /// <param name='galleryImageName'>
            /// The name of the gallery image definition to be retrieved.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<GalleryImage> GetAsync(this IGalleryImagesOperations operations, string resourceGroupName, string galleryName, string galleryImageName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, galleryName, galleryImageName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Create or update a gallery image definition.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='galleryName'>
            /// The name of the Shared Image Gallery.
            /// </param>
            /// <param name='galleryImageName'>
            /// The name of the gallery image definition to be retrieved.
            /// </param>
            /// <param name='galleryImage'>
            /// Parameters supplied to the create or update gallery image operation.
            /// </param>
            public static GalleryImage CreateOrUpdate(this IGalleryImagesOperations operations, string resourceGroupName, string galleryName, string galleryImageName, GalleryImage galleryImage)
            {
                return operations.CreateOrUpdateAsync(resourceGroupName, galleryName, galleryImageName, galleryImage).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Create or update a gallery image definition.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='galleryName'>
            /// The name of the Shared Image Gallery.
            /// </param>
            /// <param name='galleryImageName'>
            /// The name of the gallery image definition to be retrieved.
            /// </param>
            /// <param name='galleryImage'>
            /// Parameters supplied to the create or update gallery image operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<GalleryImage> CreateOrUpdateAsync(this IGalleryImagesOperations operations, string resourceGroupName, string galleryName, string galleryImageName, GalleryImage galleryImage, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, galleryName, galleryImageName, galleryImage, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Update a gallery image definition.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='galleryName'>
            /// The name of the Shared Image Gallery.
            /// </param>
            /// <param name='galleryImageName'>
            /// The name of the gallery image definition to be retrieved.
            /// </param>
            /// <param name='galleryImage'>
            /// Parameters supplied to the update gallery image operation.
            /// </param>
            public static GalleryImage Update(this IGalleryImagesOperations operations, string resourceGroupName, string galleryName, string galleryImageName, GalleryImageUpdate galleryImage)
            {
                return operations.UpdateAsync(resourceGroupName, galleryName, galleryImageName, galleryImage).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Update a gallery image definition.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='galleryName'>
            /// The name of the Shared Image Gallery.
            /// </param>
            /// <param name='galleryImageName'>
            /// The name of the gallery image definition to be retrieved.
            /// </param>
            /// <param name='galleryImage'>
            /// Parameters supplied to the update gallery image operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<GalleryImage> UpdateAsync(this IGalleryImagesOperations operations, string resourceGroupName, string galleryName, string galleryImageName, GalleryImageUpdate galleryImage, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateWithHttpMessagesAsync(resourceGroupName, galleryName, galleryImageName, galleryImage, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Delete a gallery image.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='galleryName'>
            /// The name of the Shared Image Gallery.
            /// </param>
            /// <param name='galleryImageName'>
            /// The name of the gallery image definition to be retrieved.
            /// </param>
            public static void Delete(this IGalleryImagesOperations operations, string resourceGroupName, string galleryName, string galleryImageName)
            {
                operations.DeleteAsync(resourceGroupName, galleryName, galleryImageName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Delete a gallery image.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='galleryName'>
            /// The name of the Shared Image Gallery.
            /// </param>
            /// <param name='galleryImageName'>
            /// The name of the gallery image definition to be retrieved.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync(this IGalleryImagesOperations operations, string resourceGroupName, string galleryName, string galleryImageName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.DeleteWithHttpMessagesAsync(resourceGroupName, galleryName, galleryImageName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Create or update a gallery image definition.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='galleryName'>
            /// The name of the Shared Image Gallery.
            /// </param>
            /// <param name='galleryImageName'>
            /// The name of the gallery image definition to be retrieved.
            /// </param>
            /// <param name='galleryImage'>
            /// Parameters supplied to the create or update gallery image operation.
            /// </param>
            public static GalleryImage BeginCreateOrUpdate(this IGalleryImagesOperations operations, string resourceGroupName, string galleryName, string galleryImageName, GalleryImage galleryImage)
            {
                return operations.BeginCreateOrUpdateAsync(resourceGroupName, galleryName, galleryImageName, galleryImage).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Create or update a gallery image definition.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='galleryName'>
            /// The name of the Shared Image Gallery.
            /// </param>
            /// <param name='galleryImageName'>
            /// The name of the gallery image definition to be retrieved.
            /// </param>
            /// <param name='galleryImage'>
            /// Parameters supplied to the create or update gallery image operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<GalleryImage> BeginCreateOrUpdateAsync(this IGalleryImagesOperations operations, string resourceGroupName, string galleryName, string galleryImageName, GalleryImage galleryImage, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginCreateOrUpdateWithHttpMessagesAsync(resourceGroupName, galleryName, galleryImageName, galleryImage, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Update a gallery image definition.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='galleryName'>
            /// The name of the Shared Image Gallery.
            /// </param>
            /// <param name='galleryImageName'>
            /// The name of the gallery image definition to be retrieved.
            /// </param>
            /// <param name='galleryImage'>
            /// Parameters supplied to the update gallery image operation.
            /// </param>
            public static GalleryImage BeginUpdate(this IGalleryImagesOperations operations, string resourceGroupName, string galleryName, string galleryImageName, GalleryImageUpdate galleryImage)
            {
                return operations.BeginUpdateAsync(resourceGroupName, galleryName, galleryImageName, galleryImage).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Update a gallery image definition.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='galleryName'>
            /// The name of the Shared Image Gallery.
            /// </param>
            /// <param name='galleryImageName'>
            /// The name of the gallery image definition to be retrieved.
            /// </param>
            /// <param name='galleryImage'>
            /// Parameters supplied to the update gallery image operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<GalleryImage> BeginUpdateAsync(this IGalleryImagesOperations operations, string resourceGroupName, string galleryName, string galleryImageName, GalleryImageUpdate galleryImage, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginUpdateWithHttpMessagesAsync(resourceGroupName, galleryName, galleryImageName, galleryImage, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Delete a gallery image.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='galleryName'>
            /// The name of the Shared Image Gallery.
            /// </param>
            /// <param name='galleryImageName'>
            /// The name of the gallery image definition to be retrieved.
            /// </param>
            public static void BeginDelete(this IGalleryImagesOperations operations, string resourceGroupName, string galleryName, string galleryImageName)
            {
                operations.BeginDeleteAsync(resourceGroupName, galleryName, galleryImageName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Delete a gallery image.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='galleryName'>
            /// The name of the Shared Image Gallery.
            /// </param>
            /// <param name='galleryImageName'>
            /// The name of the gallery image definition to be retrieved.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task BeginDeleteAsync(this IGalleryImagesOperations operations, string resourceGroupName, string galleryName, string galleryImageName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.BeginDeleteWithHttpMessagesAsync(resourceGroupName, galleryName, galleryImageName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// List gallery image definitions in a gallery.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<GalleryImage> ListByGalleryNext(this IGalleryImagesOperations operations, string nextPageLink)
            {
                return operations.ListByGalleryNextAsync(nextPageLink).GetAwaiter().GetResult();
            }

            /// <summary>
            /// List gallery image definitions in a gallery.
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
            public static async Task<IPage<GalleryImage>> ListByGalleryNextAsync(this IGalleryImagesOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByGalleryNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
