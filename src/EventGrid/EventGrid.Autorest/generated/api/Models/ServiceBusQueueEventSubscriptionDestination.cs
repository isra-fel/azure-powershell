// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Runtime.Extensions;

    /// <summary>Information about the service bus destination for an event subscription.</summary>
    public partial class ServiceBusQueueEventSubscriptionDestination :
        Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IServiceBusQueueEventSubscriptionDestination,
        Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IServiceBusQueueEventSubscriptionDestinationInternal,
        Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventSubscriptionDestination"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventSubscriptionDestination __eventSubscriptionDestination = new Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.EventSubscriptionDestination();

        /// <summary>Delivery attribute details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Origin(Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IDeliveryAttributeMapping> DeliveryAttributeMapping { get => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IServiceBusQueueEventSubscriptionDestinationPropertiesInternal)Property).DeliveryAttributeMapping; set => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IServiceBusQueueEventSubscriptionDestinationPropertiesInternal)Property).DeliveryAttributeMapping = value ?? null /* arrayOf */; }

        /// <summary>Type of the endpoint for the event subscription destination.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Constant]
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Origin(Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PropertyOrigin.Inherited)]
        public string EndpointType { get => "ServiceBusQueue"; set => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventSubscriptionDestinationInternal)__eventSubscriptionDestination).EndpointType = "ServiceBusQueue"; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IServiceBusQueueEventSubscriptionDestinationProperties Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IServiceBusQueueEventSubscriptionDestinationInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ServiceBusQueueEventSubscriptionDestinationProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IServiceBusQueueEventSubscriptionDestinationProperties _property;

        /// <summary>Service Bus Properties of the event subscription destination.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Origin(Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IServiceBusQueueEventSubscriptionDestinationProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ServiceBusQueueEventSubscriptionDestinationProperties()); set => this._property = value; }

        /// <summary>
        /// The Azure Resource Id that represents the endpoint of the Service Bus destination of an event subscription.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Origin(Microsoft.Azure.PowerShell.Cmdlets.EventGrid.PropertyOrigin.Inlined)]
        public string ResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IServiceBusQueueEventSubscriptionDestinationPropertiesInternal)Property).ResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IServiceBusQueueEventSubscriptionDestinationPropertiesInternal)Property).ResourceId = value ?? null; }

        /// <summary>
        /// Creates an new <see cref="ServiceBusQueueEventSubscriptionDestination" /> instance.
        /// </summary>
        public ServiceBusQueueEventSubscriptionDestination()
        {
            this.__eventSubscriptionDestination.EndpointType = "ServiceBusQueue";
        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__eventSubscriptionDestination), __eventSubscriptionDestination);
            await eventListener.AssertObjectIsValid(nameof(__eventSubscriptionDestination), __eventSubscriptionDestination);
        }
    }
    /// Information about the service bus destination for an event subscription.
    public partial interface IServiceBusQueueEventSubscriptionDestination :
        Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventSubscriptionDestination
    {
        /// <summary>Delivery attribute details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Delivery attribute details.",
        SerializedName = @"deliveryAttributeMappings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IDeliveryAttributeMapping),typeof(Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IStaticDeliveryAttributeMapping),typeof(Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IDynamicDeliveryAttributeMapping) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IDeliveryAttributeMapping> DeliveryAttributeMapping { get; set; }
        /// <summary>
        /// The Azure Resource Id that represents the endpoint of the Service Bus destination of an event subscription.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The Azure Resource Id that represents the endpoint of the Service Bus destination of an event subscription.",
        SerializedName = @"resourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceId { get; set; }

    }
    /// Information about the service bus destination for an event subscription.
    internal partial interface IServiceBusQueueEventSubscriptionDestinationInternal :
        Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventSubscriptionDestinationInternal
    {
        /// <summary>Delivery attribute details.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IDeliveryAttributeMapping> DeliveryAttributeMapping { get; set; }
        /// <summary>Service Bus Properties of the event subscription destination.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IServiceBusQueueEventSubscriptionDestinationProperties Property { get; set; }
        /// <summary>
        /// The Azure Resource Id that represents the endpoint of the Service Bus destination of an event subscription.
        /// </summary>
        string ResourceId { get; set; }

    }
}