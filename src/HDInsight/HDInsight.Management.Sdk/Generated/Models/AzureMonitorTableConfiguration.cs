// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.HDInsight.Models
{
    using System.Linq;

    /// <summary>
    /// The table configuration for the Log Analytics integration.
    /// </summary>
    public partial class AzureMonitorTableConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the AzureMonitorTableConfiguration class.
        /// </summary>
        public AzureMonitorTableConfiguration()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the AzureMonitorTableConfiguration class.
        /// </summary>

        /// <param name="name">The name.
        /// </param>
        public AzureMonitorTableConfiguration(string name = default(string))

        {
            this.Name = name;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name {get; set; }
    }
}