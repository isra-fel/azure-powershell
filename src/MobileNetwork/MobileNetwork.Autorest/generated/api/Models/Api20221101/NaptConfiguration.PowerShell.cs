// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101
{
    using Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Runtime.PowerShell;

    /// <summary>
    /// The network address and port translation settings to use for the attached data network.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(NaptConfigurationTypeConverter))]
    public partial class NaptConfiguration
    {

        /// <summary>
        /// <c>AfterDeserializeDictionary</c> will be called after the deserialization has finished, allowing customization of the
        /// object before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>

        partial void AfterDeserializeDictionary(global::System.Collections.IDictionary content);

        /// <summary>
        /// <c>AfterDeserializePSObject</c> will be called after the deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>

        partial void AfterDeserializePSObject(global::System.Management.Automation.PSObject content);

        /// <summary>
        /// <c>BeforeDeserializeDictionary</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// <c>OverrideToString</c> will be called if it is implemented. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="stringResult">/// instance serialized to a string, normally it is a Json</param>
        /// <param name="returnNow">/// set returnNow to true if you provide a customized OverrideToString function</param>

        partial void OverrideToString(ref string stringResult, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.NaptConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfiguration" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfiguration DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new NaptConfiguration(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.NaptConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfiguration" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfiguration DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new NaptConfiguration(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="NaptConfiguration" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="NaptConfiguration" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfiguration FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.NaptConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal NaptConfiguration(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("PortRange"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PortRange = (Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.IPortRange) content.GetValueForProperty("PortRange",((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PortRange, Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.PortRangeTypeConverter.ConvertFrom);
            }
            if (content.Contains("PortReuseHoldTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PortReuseHoldTime = (Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.IPortReuseHoldTimes) content.GetValueForProperty("PortReuseHoldTime",((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PortReuseHoldTime, Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.PortReuseHoldTimesTypeConverter.ConvertFrom);
            }
            if (content.Contains("PinholeTimeout"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PinholeTimeout = (Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.IPinholeTimeouts) content.GetValueForProperty("PinholeTimeout",((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PinholeTimeout, Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.PinholeTimeoutsTypeConverter.ConvertFrom);
            }
            if (content.Contains("Enabled"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).Enabled = (Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Support.NaptEnabled?) content.GetValueForProperty("Enabled",((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).Enabled, Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Support.NaptEnabled.CreateFrom);
            }
            if (content.Contains("PinholeLimit"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PinholeLimit = (int?) content.GetValueForProperty("PinholeLimit",((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PinholeLimit, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("PortRangeMinPort"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PortRangeMinPort = (int?) content.GetValueForProperty("PortRangeMinPort",((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PortRangeMinPort, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("PortRangeMaxPort"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PortRangeMaxPort = (int?) content.GetValueForProperty("PortRangeMaxPort",((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PortRangeMaxPort, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("PinholeTimeoutTcp"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PinholeTimeoutTcp = (int?) content.GetValueForProperty("PinholeTimeoutTcp",((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PinholeTimeoutTcp, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("PinholeTimeoutUdp"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PinholeTimeoutUdp = (int?) content.GetValueForProperty("PinholeTimeoutUdp",((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PinholeTimeoutUdp, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("PinholeTimeoutIcmp"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PinholeTimeoutIcmp = (int?) content.GetValueForProperty("PinholeTimeoutIcmp",((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PinholeTimeoutIcmp, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("PortReuseHoldTimeTcp"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PortReuseHoldTimeTcp = (int?) content.GetValueForProperty("PortReuseHoldTimeTcp",((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PortReuseHoldTimeTcp, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("PortReuseHoldTimeUdp"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PortReuseHoldTimeUdp = (int?) content.GetValueForProperty("PortReuseHoldTimeUdp",((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PortReuseHoldTimeUdp, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.NaptConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal NaptConfiguration(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("PortRange"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PortRange = (Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.IPortRange) content.GetValueForProperty("PortRange",((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PortRange, Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.PortRangeTypeConverter.ConvertFrom);
            }
            if (content.Contains("PortReuseHoldTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PortReuseHoldTime = (Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.IPortReuseHoldTimes) content.GetValueForProperty("PortReuseHoldTime",((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PortReuseHoldTime, Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.PortReuseHoldTimesTypeConverter.ConvertFrom);
            }
            if (content.Contains("PinholeTimeout"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PinholeTimeout = (Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.IPinholeTimeouts) content.GetValueForProperty("PinholeTimeout",((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PinholeTimeout, Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.PinholeTimeoutsTypeConverter.ConvertFrom);
            }
            if (content.Contains("Enabled"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).Enabled = (Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Support.NaptEnabled?) content.GetValueForProperty("Enabled",((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).Enabled, Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Support.NaptEnabled.CreateFrom);
            }
            if (content.Contains("PinholeLimit"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PinholeLimit = (int?) content.GetValueForProperty("PinholeLimit",((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PinholeLimit, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("PortRangeMinPort"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PortRangeMinPort = (int?) content.GetValueForProperty("PortRangeMinPort",((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PortRangeMinPort, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("PortRangeMaxPort"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PortRangeMaxPort = (int?) content.GetValueForProperty("PortRangeMaxPort",((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PortRangeMaxPort, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("PinholeTimeoutTcp"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PinholeTimeoutTcp = (int?) content.GetValueForProperty("PinholeTimeoutTcp",((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PinholeTimeoutTcp, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("PinholeTimeoutUdp"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PinholeTimeoutUdp = (int?) content.GetValueForProperty("PinholeTimeoutUdp",((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PinholeTimeoutUdp, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("PinholeTimeoutIcmp"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PinholeTimeoutIcmp = (int?) content.GetValueForProperty("PinholeTimeoutIcmp",((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PinholeTimeoutIcmp, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("PortReuseHoldTimeTcp"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PortReuseHoldTimeTcp = (int?) content.GetValueForProperty("PortReuseHoldTimeTcp",((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PortReuseHoldTimeTcp, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("PortReuseHoldTimeUdp"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PortReuseHoldTimeUdp = (int?) content.GetValueForProperty("PortReuseHoldTimeUdp",((Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.INaptConfigurationInternal)this).PortReuseHoldTimeUdp, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Runtime.SerializationMode.IncludeAll)?.ToString();

        public override string ToString()
        {
            var returnNow = false;
            var result = global::System.String.Empty;
            OverrideToString(ref result, ref returnNow);
            if (returnNow)
            {
                return result;
            }
            return ToJsonString();
        }
    }
    /// The network address and port translation settings to use for the attached data network.
    [System.ComponentModel.TypeConverter(typeof(NaptConfigurationTypeConverter))]
    public partial interface INaptConfiguration

    {

    }
}