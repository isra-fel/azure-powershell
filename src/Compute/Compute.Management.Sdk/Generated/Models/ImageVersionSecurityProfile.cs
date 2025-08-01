// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Compute.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The security profile of a gallery image version
    /// </summary>
    public partial class ImageVersionSecurityProfile
    {
        /// <summary>
        /// Initializes a new instance of the ImageVersionSecurityProfile
        /// class.
        /// </summary>
        public ImageVersionSecurityProfile()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ImageVersionSecurityProfile
        /// class.
        /// </summary>
        /// <param name="uefiSettings">Contains UEFI settings for the image
        /// version.</param>
        public ImageVersionSecurityProfile(GalleryImageVersionUefiSettings uefiSettings = default(GalleryImageVersionUefiSettings))
        {
            UefiSettings = uefiSettings;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets contains UEFI settings for the image version.
        /// </summary>
        [JsonProperty(PropertyName = "uefiSettings")]
        public GalleryImageVersionUefiSettings UefiSettings { get; set; }

    }
}
