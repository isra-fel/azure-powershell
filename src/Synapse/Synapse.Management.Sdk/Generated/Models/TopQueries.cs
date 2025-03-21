// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.Synapse.Models
{
    using System.Linq;

    /// <summary>
    /// A database query.
    /// </summary>
    public partial class TopQueries
    {
        /// <summary>
        /// Initializes a new instance of the TopQueries class.
        /// </summary>
        public TopQueries()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the TopQueries class.
        /// </summary>

        /// <param name="aggregationFunction">The function that is used to aggregate each query&#39;s metrics.
        /// Possible values include: &#39;min&#39;, &#39;max&#39;, &#39;avg&#39;, &#39;sum&#39;</param>

        /// <param name="executionType">The execution type that is used to filter the query instances that are
        /// returned.
        /// Possible values include: &#39;any&#39;, &#39;regular&#39;, &#39;irregular&#39;, &#39;aborted&#39;,
        /// &#39;exception&#39;</param>

        /// <param name="intervalType">The duration of the interval (ISO8601 duration format).
        /// </param>

        /// <param name="numberOfTopQueries">The number of requested queries.
        /// </param>

        /// <param name="observationStartTime">The start time for queries that are returned (ISO8601 format)
        /// </param>

        /// <param name="observationEndTime">The end time for queries that are returned (ISO8601 format)
        /// </param>

        /// <param name="observedMetric">The type of metric to use for ordering the top metrics.
        /// Possible values include: &#39;cpu&#39;, &#39;io&#39;, &#39;logio&#39;, &#39;duration&#39;, &#39;executionCount&#39;</param>

        /// <param name="queries">The list of queries.
        /// </param>
        public TopQueries(QueryAggregationFunction? aggregationFunction = default(QueryAggregationFunction?), QueryExecutionType? executionType = default(QueryExecutionType?), string intervalType = default(string), int? numberOfTopQueries = default(int?), System.DateTime? observationStartTime = default(System.DateTime?), System.DateTime? observationEndTime = default(System.DateTime?), QueryObservedMetricType? observedMetric = default(QueryObservedMetricType?), System.Collections.Generic.IList<QueryStatistic> queries = default(System.Collections.Generic.IList<QueryStatistic>))

        {
            this.AggregationFunction = aggregationFunction;
            this.ExecutionType = executionType;
            this.IntervalType = intervalType;
            this.NumberOfTopQueries = numberOfTopQueries;
            this.ObservationStartTime = observationStartTime;
            this.ObservationEndTime = observationEndTime;
            this.ObservedMetric = observedMetric;
            this.Queries = queries;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets the function that is used to aggregate each query&#39;s metrics. Possible values include: &#39;min&#39;, &#39;max&#39;, &#39;avg&#39;, &#39;sum&#39;
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "aggregationFunction")]
        public QueryAggregationFunction? AggregationFunction {get; private set; }

        /// <summary>
        /// Gets the execution type that is used to filter the query instances that are
        /// returned. Possible values include: &#39;any&#39;, &#39;regular&#39;, &#39;irregular&#39;, &#39;aborted&#39;, &#39;exception&#39;
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "executionType")]
        public QueryExecutionType? ExecutionType {get; private set; }

        /// <summary>
        /// Gets the duration of the interval (ISO8601 duration format).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "intervalType")]
        public string IntervalType {get; private set; }

        /// <summary>
        /// Gets the number of requested queries.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "numberOfTopQueries")]
        public int? NumberOfTopQueries {get; private set; }

        /// <summary>
        /// Gets the start time for queries that are returned (ISO8601 format)
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "observationStartTime")]
        public System.DateTime? ObservationStartTime {get; private set; }

        /// <summary>
        /// Gets the end time for queries that are returned (ISO8601 format)
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "observationEndTime")]
        public System.DateTime? ObservationEndTime {get; private set; }

        /// <summary>
        /// Gets the type of metric to use for ordering the top metrics. Possible values include: &#39;cpu&#39;, &#39;io&#39;, &#39;logio&#39;, &#39;duration&#39;, &#39;executionCount&#39;
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "observedMetric")]
        public QueryObservedMetricType? ObservedMetric {get; private set; }

        /// <summary>
        /// Gets the list of queries.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "queries")]
        public System.Collections.Generic.IList<QueryStatistic> Queries {get; private set; }
    }
}