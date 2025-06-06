// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Helper.Network.Models
{
    using System.Linq;

    /// <summary>
    /// NetworkSecurityGroup resource.
    /// </summary>
    [Microsoft.Rest.Serialization.JsonTransformation]
    public partial class NetworkSecurityGroup : Resource
    {
        /// <summary>
        /// Initializes a new instance of the NetworkSecurityGroup class.
        /// </summary>
        public NetworkSecurityGroup()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the NetworkSecurityGroup class.
        /// </summary>

        /// <param name="id">Resource ID.
        /// </param>

        /// <param name="name">Resource name.
        /// </param>

        /// <param name="type">Resource type.
        /// </param>

        /// <param name="location">Resource location.
        /// </param>

        /// <param name="tags">Resource tags.
        /// </param>

        /// <param name="etag">A unique read-only string that changes whenever the resource is updated.
        /// </param>

        /// <param name="provisioningState">The provisioning state of the network security group resource.
        /// Possible values include: &#39;Succeeded&#39;, &#39;Updating&#39;, &#39;Deleting&#39;, &#39;Failed&#39;</param>

        /// <param name="securityRules">A collection of security rules of the network security group.
        /// </param>

        /// <param name="defaultSecurityRules">The default security rules of network security group.
        /// </param>

        /// <param name="networkInterfaces">A collection of references to network interfaces.
        /// </param>

        /// <param name="subnets">A collection of references to subnets.
        /// </param>

        /// <param name="flowLogs">A collection of references to flow log resources.
        /// </param>

        /// <param name="resourceGuid">The resource GUID property of the network security group resource.
        /// </param>
        public NetworkSecurityGroup(string id = default(string), string name = default(string), string type = default(string), string location = default(string), System.Collections.Generic.IDictionary<string, string> tags = default(System.Collections.Generic.IDictionary<string, string>), string etag = default(string), string provisioningState = default(string), System.Collections.Generic.IList<SecurityRule> securityRules = default(System.Collections.Generic.IList<SecurityRule>), System.Collections.Generic.IList<SecurityRule> defaultSecurityRules = default(System.Collections.Generic.IList<SecurityRule>), System.Collections.Generic.IList<NetworkInterface> networkInterfaces = default(System.Collections.Generic.IList<NetworkInterface>), System.Collections.Generic.IList<Subnet> subnets = default(System.Collections.Generic.IList<Subnet>), System.Collections.Generic.IList<FlowLog> flowLogs = default(System.Collections.Generic.IList<FlowLog>), string resourceGuid = default(string))

        : base(id, name, type, location, tags)
        {
            this.Etag = etag;
            this.ProvisioningState = provisioningState;
            this.SecurityRules = securityRules;
            this.DefaultSecurityRules = defaultSecurityRules;
            this.NetworkInterfaces = networkInterfaces;
            this.Subnets = subnets;
            this.FlowLogs = flowLogs;
            this.ResourceGuid = resourceGuid;
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
        /// Gets the provisioning state of the network security group resource. Possible values include: &#39;Succeeded&#39;, &#39;Updating&#39;, &#39;Deleting&#39;, &#39;Failed&#39;
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState {get; private set; }

        /// <summary>
        /// Gets or sets a collection of security rules of the network security group.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.securityRules")]
        public System.Collections.Generic.IList<SecurityRule> SecurityRules {get; set; }

        /// <summary>
        /// Gets the default security rules of network security group.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.defaultSecurityRules")]
        public System.Collections.Generic.IList<SecurityRule> DefaultSecurityRules {get; private set; }

        /// <summary>
        /// Gets a collection of references to network interfaces.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.networkInterfaces")]
        public System.Collections.Generic.IList<NetworkInterface> NetworkInterfaces {get; private set; }

        /// <summary>
        /// Gets a collection of references to subnets.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.subnets")]
        public System.Collections.Generic.IList<Subnet> Subnets {get; private set; }

        /// <summary>
        /// Gets a collection of references to flow log resources.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.flowLogs")]
        public System.Collections.Generic.IList<FlowLog> FlowLogs {get; private set; }

        /// <summary>
        /// Gets the resource GUID property of the network security group resource.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.resourceGuid")]
        public string ResourceGuid {get; private set; }
    }
}