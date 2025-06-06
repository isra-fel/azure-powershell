﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using WindowsAzure.Commands.Common.Attributes;

    public class PSNetworkInterfaceIPConfiguration : PSIPConfiguration
    {
        [JsonProperty(Order = 2)]
        [Ps1Xml(Target = ViewControl.Table)]
        public string PrivateIpAddressVersion { get; set; }

        [JsonProperty(Order = 2)]
        [Ps1Xml(Target = ViewControl.Table)]
        public int? PrivateIpAddressPrefixLength { get; set; }

        [JsonProperty(Order = 2)]
        public List<PSBackendAddressPool> LoadBalancerBackendAddressPools { get; set; }

        [JsonProperty(Order = 2)]
        public List<PSInboundNatRule> LoadBalancerInboundNatRules { get; set; }

        [JsonProperty(Order = 2)]
        [Ps1Xml(Target = ViewControl.Table)]
        public bool Primary { get; set; }

        [JsonProperty(Order = 2)]
        public List<PSApplicationGatewayBackendAddressPool> ApplicationGatewayBackendAddressPools { get; set; }

        [JsonProperty(Order = 2)]
        public List<PSApplicationSecurityGroup> ApplicationSecurityGroups { get; set; }

        [JsonProperty(Order = 2)]
        public List<PSVirtualNetworkTap> VirtualNetworkTaps { get; set; }

        [JsonProperty(Order = 2)]
        public PSIpConfigurationConnectivityInformation PrivateLinkConnectionProperties { get; set; }

        [JsonProperty(Order = 2)]
        [Ps1Xml(Target = ViewControl.Table)]
        public PSResourceId GatewayLoadBalancer { get; set; }

        [JsonIgnore]
        public string LoadBalancerBackendAddressPoolsText
        {
            get { return JsonConvert.SerializeObject(LoadBalancerBackendAddressPools, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string LoadBalancerInboundNatRulesText
        {
            get { return JsonConvert.SerializeObject(LoadBalancerInboundNatRules, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ApplicationGatewayBackendAddressPoolsText
        {
            get { return JsonConvert.SerializeObject(ApplicationGatewayBackendAddressPools, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ApplicationSecurityGroupsText
        {
            get { return JsonConvert.SerializeObject(ApplicationSecurityGroups, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string VirtualNetworkTapsText
        {
            get { return JsonConvert.SerializeObject(VirtualNetworkTaps, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string PrivateLinkConnectionPropertiesText
        {
            get { return JsonConvert.SerializeObject(PrivateLinkConnectionProperties, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string GatewayLoadBalancerText
        {
            get { return JsonConvert.SerializeObject(GatewayLoadBalancer, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        public bool ShouldSerializeLoadBalancerBackendAddressPools()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        public bool ShouldSerializeLoadBalancerInboundNatRules()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        public bool ShouldSerializeApplicationGatewayBackendAddressPools()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        public bool ShouldSerializeApplicationSecurityGroups()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        public bool ShouldSerializeGatewayLoadBalancer()
        {
            return !string.IsNullOrEmpty(this.Name);
        }
    }
}
