// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models
{
    using System.Linq;

    /// <summary>
    /// A2A provider specific settings.
    /// </summary>
    [Newtonsoft.Json.JsonObject("A2ACrossClusterMigration")]
    public partial class A2ACrossClusterMigrationReplicationDetails : ReplicationProviderSpecificSettings
    {
        /// <summary>
        /// Initializes a new instance of the A2ACrossClusterMigrationReplicationDetails class.
        /// </summary>
        public A2ACrossClusterMigrationReplicationDetails()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the A2ACrossClusterMigrationReplicationDetails class.
        /// </summary>

        /// <param name="fabricObjectId">The fabric specific object Id of the virtual machine.
        /// </param>

        /// <param name="primaryFabricLocation">Primary fabric location.
        /// </param>

        /// <param name="osType">The type of operating system.
        /// </param>

        /// <param name="vmProtectionState">The protection state for the vm.
        /// </param>

        /// <param name="vmProtectionStateDescription">The protection state description for the vm.
        /// </param>

        /// <param name="lifecycleId">An id associated with the PE that survives actions like switch protection
        /// which change the backing PE/CPE objects internally.The lifecycle id gets
        /// carried forward to have a link/continuity in being able to have an Id that
        /// denotes the &#34;same&#34; protected item even though other internal Ids/ARM Id
        /// might be changing.
        /// </param>
        public A2ACrossClusterMigrationReplicationDetails(string fabricObjectId = default(string), string primaryFabricLocation = default(string), string osType = default(string), string vmProtectionState = default(string), string vmProtectionStateDescription = default(string), string lifecycleId = default(string))

        {
            this.FabricObjectId = fabricObjectId;
            this.PrimaryFabricLocation = primaryFabricLocation;
            this.OSType = osType;
            this.VMProtectionState = vmProtectionState;
            this.VMProtectionStateDescription = vmProtectionStateDescription;
            this.LifecycleId = lifecycleId;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets the fabric specific object Id of the virtual machine.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "fabricObjectId")]
        public string FabricObjectId {get; set; }

        /// <summary>
        /// Gets or sets primary fabric location.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "primaryFabricLocation")]
        public string PrimaryFabricLocation {get; set; }

        /// <summary>
        /// Gets or sets the type of operating system.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "osType")]
        public string OSType {get; set; }

        /// <summary>
        /// Gets or sets the protection state for the vm.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "vmProtectionState")]
        public string VMProtectionState {get; set; }

        /// <summary>
        /// Gets or sets the protection state description for the vm.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "vmProtectionStateDescription")]
        public string VMProtectionStateDescription {get; set; }

        /// <summary>
        /// Gets or sets an id associated with the PE that survives actions like switch
        /// protection which change the backing PE/CPE objects internally.The lifecycle
        /// id gets carried forward to have a link/continuity in being able to have an
        /// Id that denotes the &#34;same&#34; protected item even though other internal
        /// Ids/ARM Id might be changing.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "lifecycleId")]
        public string LifecycleId {get; set; }
    }
}