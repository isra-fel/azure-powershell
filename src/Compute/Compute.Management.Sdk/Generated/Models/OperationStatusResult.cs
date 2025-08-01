// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Compute.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The current status of an async operation.
    /// </summary>
    public partial class OperationStatusResult
    {
        /// <summary>
        /// Initializes a new instance of the OperationStatusResult class.
        /// </summary>
        public OperationStatusResult()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the OperationStatusResult class.
        /// </summary>
        /// <param name="status">Operation status.</param>
        /// <param name="id">Fully qualified ID for the async
        /// operation.</param>
        /// <param name="name">Name of the async operation.</param>
        /// <param name="percentComplete">Percent of the operation that is
        /// complete.</param>
        /// <param name="startTime">The start time of the operation.</param>
        /// <param name="endTime">The end time of the operation.</param>
        /// <param name="operations">The operations list.</param>
        /// <param name="error">If present, details of the operation
        /// error.</param>
        public OperationStatusResult(string status, string id = default(string), string name = default(string), double? percentComplete = default(double?), System.DateTime? startTime = default(System.DateTime?), System.DateTime? endTime = default(System.DateTime?), IList<OperationStatusResult> operations = default(IList<OperationStatusResult>), ErrorDetail error = default(ErrorDetail))
        {
            Id = id;
            Name = name;
            Status = status;
            PercentComplete = percentComplete;
            StartTime = startTime;
            EndTime = endTime;
            Operations = operations;
            Error = error;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets fully qualified ID for the async operation.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets name of the async operation.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets operation status.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets percent of the operation that is complete.
        /// </summary>
        [JsonProperty(PropertyName = "percentComplete")]
        public double? PercentComplete { get; set; }

        /// <summary>
        /// Gets or sets the start time of the operation.
        /// </summary>
        [JsonProperty(PropertyName = "startTime")]
        public System.DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time of the operation.
        /// </summary>
        [JsonProperty(PropertyName = "endTime")]
        public System.DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets the operations list.
        /// </summary>
        [JsonProperty(PropertyName = "operations")]
        public IList<OperationStatusResult> Operations { get; set; }

        /// <summary>
        /// Gets or sets if present, details of the operation error.
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public ErrorDetail Error { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Status == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Status");
            }
            if (PercentComplete != null)
            {
                if (PercentComplete > 100)
                {
                    throw new ValidationException(ValidationRules.InclusiveMaximum, "PercentComplete", 100);
                }
                if (PercentComplete < 0)
                {
                    throw new ValidationException(ValidationRules.InclusiveMinimum, "PercentComplete", 0);
                }
            }
            if (Operations != null)
            {
                foreach (var element in Operations)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
        }
    }
}
