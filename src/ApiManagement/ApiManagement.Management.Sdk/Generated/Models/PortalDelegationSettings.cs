// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.ApiManagement.Models
{
    using System.Linq;

    /// <summary>
    /// Delegation settings for a developer portal.
    /// </summary>
    [Microsoft.Rest.Serialization.JsonTransformation]
    public partial class PortalDelegationSettings : Resource
    {
        /// <summary>
        /// Initializes a new instance of the PortalDelegationSettings class.
        /// </summary>
        public PortalDelegationSettings()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PortalDelegationSettings class.
        /// </summary>

        /// <param name="id">Fully qualified resource ID for the resource. Ex -
        /// /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </param>

        /// <param name="name">The name of the resource
        /// </param>

        /// <param name="type">The type of the resource. E.g. &#34;Microsoft.Compute/virtualMachines&#34; or
        /// &#34;Microsoft.Storage/storageAccounts&#34;
        /// </param>

        /// <param name="url">A delegation Url.
        /// </param>

        /// <param name="validationKey">A base64-encoded validation key to validate, that a request is coming from
        /// Azure API Management.
        /// </param>

        /// <param name="subscriptions">Subscriptions delegation settings.
        /// </param>

        /// <param name="userRegistration">User registration delegation settings.
        /// </param>
        public PortalDelegationSettings(string id = default(string), string name = default(string), string type = default(string), string url = default(string), string validationKey = default(string), SubscriptionsDelegationSettingsProperties subscriptions = default(SubscriptionsDelegationSettingsProperties), RegistrationDelegationSettingsProperties userRegistration = default(RegistrationDelegationSettingsProperties))

        : base(id, name, type)
        {
            this.Url = url;
            this.ValidationKey = validationKey;
            this.Subscriptions = subscriptions;
            this.UserRegistration = userRegistration;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets a delegation Url.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.url")]
        public string Url {get; set; }

        /// <summary>
        /// Gets or sets a base64-encoded validation key to validate, that a request is
        /// coming from Azure API Management.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.validationKey")]
        public string ValidationKey {get; set; }

        /// <summary>
        /// Gets or sets subscriptions delegation settings.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.subscriptions")]
        public SubscriptionsDelegationSettingsProperties Subscriptions {get; set; }

        /// <summary>
        /// Gets or sets user registration delegation settings.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.userRegistration")]
        public RegistrationDelegationSettingsProperties UserRegistration {get; set; }
    }
}