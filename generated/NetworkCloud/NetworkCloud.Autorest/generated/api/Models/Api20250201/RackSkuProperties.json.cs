// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Extensions;

    /// <summary>
    /// RackSkuProperties represents the properties of compute-related hardware for a rack. This supports both aggregator and
    /// compute racks.
    /// </summary>
    public partial class RackSkuProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json serialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name= "returnNow" />
        /// output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IRackSkuProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IRackSkuProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IRackSkuProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonObject json ? new RackSkuProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonObject into a new instance of <see cref="RackSkuProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal RackSkuProperties(Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_computeMachine = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonArray>("computeMachines"), out var __jsonComputeMachines) ? If( __jsonComputeMachines as Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IMachineSkuSlot[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IMachineSkuSlot) (Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.MachineSkuSlot.FromJson(__u) )) ))() : null : ComputeMachine;}
            {_controllerMachine = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonArray>("controllerMachines"), out var __jsonControllerMachines) ? If( __jsonControllerMachines as Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IMachineSkuSlot[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IMachineSkuSlot) (Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.MachineSkuSlot.FromJson(__p) )) ))() : null : ControllerMachine;}
            {_description = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonString>("description"), out var __jsonDescription) ? (string)__jsonDescription : (string)Description;}
            {_maxClusterSlot = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonNumber>("maxClusterSlots"), out var __jsonMaxClusterSlots) ? (long?)__jsonMaxClusterSlots : MaxClusterSlot;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_rackType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonString>("rackType"), out var __jsonRackType) ? (string)__jsonRackType : (string)RackType;}
            {_storageAppliance = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonArray>("storageAppliances"), out var __jsonStorageAppliances) ? If( __jsonStorageAppliances as Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IStorageApplianceSkuSlot[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.IStorageApplianceSkuSlot) (Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20250201.StorageApplianceSkuSlot.FromJson(__k) )) ))() : null : StorageAppliance;}
            {_supportedRackSkuId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonArray>("supportedRackSkuIds"), out var __jsonSupportedRackSkuIds) ? If( __jsonSupportedRackSkuIds as Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonArray, out var __g) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__g, (__f)=>(string) (__f is Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonString __e ? (string)(__e.ToString()) : null)) ))() : null : SupportedRackSkuId;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="RackSkuProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="RackSkuProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._computeMachine)
                {
                    var __w = new Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.XNodeArray();
                    foreach( var __x in this._computeMachine )
                    {
                        AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                    }
                    container.Add("computeMachines",__w);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._controllerMachine)
                {
                    var __r = new Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.XNodeArray();
                    foreach( var __s in this._controllerMachine )
                    {
                        AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                    }
                    container.Add("controllerMachines",__r);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._description)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonString(this._description.ToString()) : null, "description" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._maxClusterSlot ? (Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonNumber((long)this._maxClusterSlot) : null, "maxClusterSlots" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._rackType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonString(this._rackType.ToString()) : null, "rackType" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._storageAppliance)
                {
                    var __m = new Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.XNodeArray();
                    foreach( var __n in this._storageAppliance )
                    {
                        AddIf(__n?.ToJson(null, serializationMode) ,__m.Add);
                    }
                    container.Add("storageAppliances",__m);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._supportedRackSkuId)
                {
                    var __h = new Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.XNodeArray();
                    foreach( var __i in this._supportedRackSkuId )
                    {
                        AddIf(null != (((object)__i)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Runtime.Json.JsonString(__i.ToString()) : null ,__h.Add);
                    }
                    container.Add("supportedRackSkuIds",__h);
                }
            }
            AfterToJson(ref container);
            return container;
        }
    }
}