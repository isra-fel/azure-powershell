// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Ssh.Helpers.HybridCompute.Models
{
    using System.Linq;

    /// <summary>
    /// Specifies the patch settings.
    /// </summary>
    public partial class PatchSettings
    {
        /// <summary>
        /// Initializes a new instance of the PatchSettings class.
        /// </summary>
        public PatchSettings()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PatchSettings class.
        /// </summary>

        /// <param name="assessmentMode">Specifies the assessment mode.
        /// Possible values include: &#39;ImageDefault&#39;, &#39;AutomaticByPlatform&#39;</param>

        /// <param name="patchMode">Specifies the patch mode.
        /// Possible values include: &#39;ImageDefault&#39;, &#39;AutomaticByPlatform&#39;,
        /// &#39;AutomaticByOS&#39;, &#39;Manual&#39;</param>
        public PatchSettings(string assessmentMode = default(string), string patchMode = default(string))

        {
            this.AssessmentMode = assessmentMode;
            this.PatchMode = patchMode;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets specifies the assessment mode. Possible values include: &#39;ImageDefault&#39;, &#39;AutomaticByPlatform&#39;
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "assessmentMode")]
        public string AssessmentMode {get; set; }

        /// <summary>
        /// Gets or sets specifies the patch mode. Possible values include: &#39;ImageDefault&#39;, &#39;AutomaticByPlatform&#39;, &#39;AutomaticByOS&#39;, &#39;Manual&#39;
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "patchMode")]
        public string PatchMode {get; set; }
    }
}