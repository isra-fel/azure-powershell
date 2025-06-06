// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.NetApp.Models
{
    using System.Linq;

    /// <summary>
    /// NetApp account resource
    /// </summary>
    [Microsoft.Rest.Serialization.JsonTransformation]
    public partial class NetAppAccount : TrackedResource
    {
        /// <summary>
        /// Initializes a new instance of the NetAppAccount class.
        /// </summary>
        public NetAppAccount()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the NetAppAccount class.
        /// </summary>

        /// <param name="id">Fully qualified resource ID for the resource. E.g.
        /// &#34;/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}&#34;
        /// </param>

        /// <param name="name">The name of the resource
        /// </param>

        /// <param name="type">The type of the resource. E.g. &#34;Microsoft.Compute/virtualMachines&#34; or
        /// &#34;Microsoft.Storage/storageAccounts&#34;
        /// </param>

        /// <param name="systemData">Azure Resource Manager metadata containing createdBy and modifiedBy
        /// information.
        /// </param>

        /// <param name="tags">Resource tags.
        /// </param>

        /// <param name="location">The geo-location where the resource lives
        /// </param>

        /// <param name="etag">A unique read-only string that changes whenever the resource is updated.
        /// </param>

        /// <param name="identity">The identity used for the resource.
        /// </param>

        /// <param name="provisioningState">Azure lifecycle management
        /// </param>

        /// <param name="activeDirectories">Active Directories
        /// </param>

        /// <param name="encryption">Encryption settings
        /// </param>

        /// <param name="disableShowmount">Shows the status of disableShowmount for all volumes under the
        /// subscription, null equals false
        /// </param>

        /// <param name="nfsV4IdDomain">Domain for NFSv4 user ID mapping. This property will be set for all NetApp
        /// accounts in the subscription and region and only affect non ldap NFSv4
        /// volumes.
        /// </param>

        /// <param name="multiAdStatus">MultiAD Status for the account
        /// Possible values include: &#39;Disabled&#39;, &#39;Enabled&#39;</param>
        public NetAppAccount(string location, string id = default(string), string name = default(string), string type = default(string), SystemData systemData = default(SystemData), System.Collections.Generic.IDictionary<string, string> tags = default(System.Collections.Generic.IDictionary<string, string>), string etag = default(string), ManagedServiceIdentity identity = default(ManagedServiceIdentity), string provisioningState = default(string), System.Collections.Generic.IList<ActiveDirectory> activeDirectories = default(System.Collections.Generic.IList<ActiveDirectory>), AccountEncryption encryption = default(AccountEncryption), bool? disableShowmount = default(bool?), string nfsV4IdDomain = default(string), string multiAdStatus = default(string))

        : base(location, id, name, type, systemData, tags)
        {
            this.Etag = etag;
            this.Identity = identity;
            this.ProvisioningState = provisioningState;
            this.ActiveDirectories = activeDirectories;
            this.Encryption = encryption;
            this.DisableShowmount = disableShowmount;
            this.NfsV4IdDomain = nfsV4IdDomain;
            this.MultiAdStatus = multiAdStatus;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets a unique read-only string that changes whenever the resource is
        /// updated.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "etag")]
        public string Etag {get; private set; }

        /// <summary>
        /// Gets or sets the identity used for the resource.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "identity")]
        public ManagedServiceIdentity Identity {get; set; }

        /// <summary>
        /// Gets azure lifecycle management
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState {get; private set; }

        /// <summary>
        /// Gets or sets active Directories
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.activeDirectories")]
        public System.Collections.Generic.IList<ActiveDirectory> ActiveDirectories {get; set; }

        /// <summary>
        /// Gets or sets encryption settings
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.encryption")]
        public AccountEncryption Encryption {get; set; }

        /// <summary>
        /// Gets shows the status of disableShowmount for all volumes under the
        /// subscription, null equals false
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.disableShowmount")]
        public bool? DisableShowmount {get; private set; }

        /// <summary>
        /// Gets or sets domain for NFSv4 user ID mapping. This property will be set
        /// for all NetApp accounts in the subscription and region and only affect non
        /// ldap NFSv4 volumes.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.nfsV4IDDomain")]
        public string NfsV4IdDomain {get; set; }

        /// <summary>
        /// Gets multiAD Status for the account Possible values include: &#39;Disabled&#39;, &#39;Enabled&#39;
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.multiAdStatus")]
        public string MultiAdStatus {get; private set; }
        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public override void Validate()
        {
            base.Validate();

            if (this.Identity != null)
            {
                this.Identity.Validate();
            }

            if (this.ActiveDirectories != null)
            {
                foreach (var element in this.ActiveDirectories)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
            if (this.Encryption != null)
            {
                this.Encryption.Validate();
            }
            if (this.NfsV4IdDomain != null)
            {
                if (this.NfsV4IdDomain.Length > 255)
                {
                    throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.MaxLength, "NfsV4IdDomain", 255);
                }
                if (!System.Text.RegularExpressions.Regex.IsMatch(this.NfsV4IdDomain, "^[a-zA-Z0-9][a-zA-Z0-9.-]{0,253}[a-zA-Z0-9]$"))
                {
                    throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.Pattern, "NfsV4IdDomain", "^[a-zA-Z0-9][a-zA-Z0-9.-]{0,253}[a-zA-Z0-9]$");
                }
            }

        }
    }
}