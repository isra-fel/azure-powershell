// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.Network.Models
{
    using System.Linq;

    /// <summary>
    /// Rewrite rule of an application gateway.
    /// </summary>
    public partial class ApplicationGatewayRewriteRule
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationGatewayRewriteRule class.
        /// </summary>
        public ApplicationGatewayRewriteRule()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ApplicationGatewayRewriteRule class.
        /// </summary>

        /// <param name="name">Name of the rewrite rule that is unique within an Application Gateway.
        /// </param>

        /// <param name="ruleSequence">Rule Sequence of the rewrite rule that determines the order of execution of
        /// a particular rule in a RewriteRuleSet.
        /// </param>

        /// <param name="conditions">Conditions based on which the action set execution will be evaluated.
        /// </param>

        /// <param name="actionSet">Set of actions to be done as part of the rewrite Rule.
        /// </param>
        public ApplicationGatewayRewriteRule(string name = default(string), int? ruleSequence = default(int?), System.Collections.Generic.IList<ApplicationGatewayRewriteRuleCondition> conditions = default(System.Collections.Generic.IList<ApplicationGatewayRewriteRuleCondition>), ApplicationGatewayRewriteRuleActionSet actionSet = default(ApplicationGatewayRewriteRuleActionSet))

        {
            this.Name = name;
            this.RuleSequence = ruleSequence;
            this.Conditions = conditions;
            this.ActionSet = actionSet;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets name of the rewrite rule that is unique within an Application
        /// Gateway.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name {get; set; }

        /// <summary>
        /// Gets or sets rule Sequence of the rewrite rule that determines the order of
        /// execution of a particular rule in a RewriteRuleSet.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "ruleSequence")]
        public int? RuleSequence {get; set; }

        /// <summary>
        /// Gets or sets conditions based on which the action set execution will be
        /// evaluated.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "conditions")]
        public System.Collections.Generic.IList<ApplicationGatewayRewriteRuleCondition> Conditions {get; set; }

        /// <summary>
        /// Gets or sets set of actions to be done as part of the rewrite Rule.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "actionSet")]
        public ApplicationGatewayRewriteRuleActionSet ActionSet {get; set; }
    }
}