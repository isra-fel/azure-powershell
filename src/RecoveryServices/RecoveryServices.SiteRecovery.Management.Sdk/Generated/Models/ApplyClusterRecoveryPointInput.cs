// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models
{
    using System.Linq;

    /// <summary>
    /// Input definition for apply cluster recovery point.
    /// </summary>
    public partial class ApplyClusterRecoveryPointInput
    {
        /// <summary>
        /// Initializes a new instance of the ApplyClusterRecoveryPointInput class.
        /// </summary>
        public ApplyClusterRecoveryPointInput()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ApplyClusterRecoveryPointInput class.
        /// </summary>

        /// <param name="properties">The properties to apply cluster recovery point input.
        /// </param>
        public ApplyClusterRecoveryPointInput(ApplyClusterRecoveryPointInputProperties properties)

        {
            this.Properties = properties;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets the properties to apply cluster recovery point input.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties")]
        public ApplyClusterRecoveryPointInputProperties Properties {get; set; }
        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (this.Properties == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "Properties");
            }
            if (this.Properties != null)
            {
                this.Properties.Validate();
            }
        }
    }
}