// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.ServiceFabric.Models
{
    using System.Linq;

    public partial class ApplicationTypeVersionsCleanupPolicy
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationTypeVersionsCleanupPolicy class.
        /// </summary>
        public ApplicationTypeVersionsCleanupPolicy()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ApplicationTypeVersionsCleanupPolicy class.
        /// </summary>

        /// <param name="maxUnusedVersionsToKeep">Number of unused versions per application type to keep.
        /// </param>
        public ApplicationTypeVersionsCleanupPolicy(long maxUnusedVersionsToKeep)

        {
            this.MaxUnusedVersionsToKeep = maxUnusedVersionsToKeep;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets number of unused versions per application type to keep.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "maxUnusedVersionsToKeep")]
        public long MaxUnusedVersionsToKeep {get; set; }
        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (this.MaxUnusedVersionsToKeep < 0)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.InclusiveMinimum, "MaxUnusedVersionsToKeep", 0);
            }
        }
    }
}