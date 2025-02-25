// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Runtime.PowerShell;

    /// <summary>The Defender for Storage resource.</summary>
    [System.ComponentModel.TypeConverter(typeof(DefenderForStorageSettingTypeConverter))]
    public partial class DefenderForStorageSetting
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.DefenderForStorageSetting"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DefenderForStorageSetting(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.DefenderForStorageSettingPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IResourceInternal)this).Id, global::System.Convert.ToString);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IResourceInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("Type"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IResourceInternal)this).Type, global::System.Convert.ToString);
            }
            if (content.Contains("MalwareScanning"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).MalwareScanning = (Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IMalwareScanningProperties) content.GetValueForProperty("MalwareScanning",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).MalwareScanning, Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.MalwareScanningPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("SensitiveDataDiscovery"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).SensitiveDataDiscovery = (Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.ISensitiveDataDiscoveryProperties) content.GetValueForProperty("SensitiveDataDiscovery",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).SensitiveDataDiscovery, Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.SensitiveDataDiscoveryPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("IsEnabled"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).IsEnabled = (bool?) content.GetValueForProperty("IsEnabled",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).IsEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("OverrideSubscriptionLevelSetting"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).OverrideSubscriptionLevelSetting = (bool?) content.GetValueForProperty("OverrideSubscriptionLevelSetting",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).OverrideSubscriptionLevelSetting, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("MalwareScanningOperationStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).MalwareScanningOperationStatus = (Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IOperationStatus) content.GetValueForProperty("MalwareScanningOperationStatus",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).MalwareScanningOperationStatus, Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.OperationStatusTypeConverter.ConvertFrom);
            }
            if (content.Contains("SensitiveDataDiscoveryOperationStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).SensitiveDataDiscoveryOperationStatus = (Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IOperationStatus) content.GetValueForProperty("SensitiveDataDiscoveryOperationStatus",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).SensitiveDataDiscoveryOperationStatus, Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.OperationStatusTypeConverter.ConvertFrom);
            }
            if (content.Contains("MalwareScanningOnUpload"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).MalwareScanningOnUpload = (Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IOnUploadProperties) content.GetValueForProperty("MalwareScanningOnUpload",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).MalwareScanningOnUpload, Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.OnUploadPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("MalwareScanningScanResultsEventGridTopicResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).MalwareScanningScanResultsEventGridTopicResourceId = (string) content.GetValueForProperty("MalwareScanningScanResultsEventGridTopicResourceId",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).MalwareScanningScanResultsEventGridTopicResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("MalwareScanningOperationStatusCode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).MalwareScanningOperationStatusCode = (string) content.GetValueForProperty("MalwareScanningOperationStatusCode",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).MalwareScanningOperationStatusCode, global::System.Convert.ToString);
            }
            if (content.Contains("MalwareScanningOperationStatusMessage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).MalwareScanningOperationStatusMessage = (string) content.GetValueForProperty("MalwareScanningOperationStatusMessage",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).MalwareScanningOperationStatusMessage, global::System.Convert.ToString);
            }
            if (content.Contains("SensitiveDataDiscoveryIsEnabled"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).SensitiveDataDiscoveryIsEnabled = (bool?) content.GetValueForProperty("SensitiveDataDiscoveryIsEnabled",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).SensitiveDataDiscoveryIsEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("SensitiveDataDiscoveryOperationStatusCode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).SensitiveDataDiscoveryOperationStatusCode = (string) content.GetValueForProperty("SensitiveDataDiscoveryOperationStatusCode",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).SensitiveDataDiscoveryOperationStatusCode, global::System.Convert.ToString);
            }
            if (content.Contains("SensitiveDataDiscoveryOperationStatusMessage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).SensitiveDataDiscoveryOperationStatusMessage = (string) content.GetValueForProperty("SensitiveDataDiscoveryOperationStatusMessage",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).SensitiveDataDiscoveryOperationStatusMessage, global::System.Convert.ToString);
            }
            if (content.Contains("OnUploadIsEnabled"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).OnUploadIsEnabled = (bool?) content.GetValueForProperty("OnUploadIsEnabled",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).OnUploadIsEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("OnUploadCapGbPerMonth"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).OnUploadCapGbPerMonth = (int?) content.GetValueForProperty("OnUploadCapGbPerMonth",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).OnUploadCapGbPerMonth, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.DefenderForStorageSetting"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DefenderForStorageSetting(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.DefenderForStorageSettingPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IResourceInternal)this).Id, global::System.Convert.ToString);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IResourceInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("Type"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IResourceInternal)this).Type, global::System.Convert.ToString);
            }
            if (content.Contains("MalwareScanning"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).MalwareScanning = (Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IMalwareScanningProperties) content.GetValueForProperty("MalwareScanning",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).MalwareScanning, Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.MalwareScanningPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("SensitiveDataDiscovery"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).SensitiveDataDiscovery = (Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.ISensitiveDataDiscoveryProperties) content.GetValueForProperty("SensitiveDataDiscovery",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).SensitiveDataDiscovery, Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.SensitiveDataDiscoveryPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("IsEnabled"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).IsEnabled = (bool?) content.GetValueForProperty("IsEnabled",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).IsEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("OverrideSubscriptionLevelSetting"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).OverrideSubscriptionLevelSetting = (bool?) content.GetValueForProperty("OverrideSubscriptionLevelSetting",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).OverrideSubscriptionLevelSetting, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("MalwareScanningOperationStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).MalwareScanningOperationStatus = (Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IOperationStatus) content.GetValueForProperty("MalwareScanningOperationStatus",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).MalwareScanningOperationStatus, Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.OperationStatusTypeConverter.ConvertFrom);
            }
            if (content.Contains("SensitiveDataDiscoveryOperationStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).SensitiveDataDiscoveryOperationStatus = (Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IOperationStatus) content.GetValueForProperty("SensitiveDataDiscoveryOperationStatus",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).SensitiveDataDiscoveryOperationStatus, Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.OperationStatusTypeConverter.ConvertFrom);
            }
            if (content.Contains("MalwareScanningOnUpload"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).MalwareScanningOnUpload = (Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IOnUploadProperties) content.GetValueForProperty("MalwareScanningOnUpload",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).MalwareScanningOnUpload, Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.OnUploadPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("MalwareScanningScanResultsEventGridTopicResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).MalwareScanningScanResultsEventGridTopicResourceId = (string) content.GetValueForProperty("MalwareScanningScanResultsEventGridTopicResourceId",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).MalwareScanningScanResultsEventGridTopicResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("MalwareScanningOperationStatusCode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).MalwareScanningOperationStatusCode = (string) content.GetValueForProperty("MalwareScanningOperationStatusCode",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).MalwareScanningOperationStatusCode, global::System.Convert.ToString);
            }
            if (content.Contains("MalwareScanningOperationStatusMessage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).MalwareScanningOperationStatusMessage = (string) content.GetValueForProperty("MalwareScanningOperationStatusMessage",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).MalwareScanningOperationStatusMessage, global::System.Convert.ToString);
            }
            if (content.Contains("SensitiveDataDiscoveryIsEnabled"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).SensitiveDataDiscoveryIsEnabled = (bool?) content.GetValueForProperty("SensitiveDataDiscoveryIsEnabled",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).SensitiveDataDiscoveryIsEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("SensitiveDataDiscoveryOperationStatusCode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).SensitiveDataDiscoveryOperationStatusCode = (string) content.GetValueForProperty("SensitiveDataDiscoveryOperationStatusCode",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).SensitiveDataDiscoveryOperationStatusCode, global::System.Convert.ToString);
            }
            if (content.Contains("SensitiveDataDiscoveryOperationStatusMessage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).SensitiveDataDiscoveryOperationStatusMessage = (string) content.GetValueForProperty("SensitiveDataDiscoveryOperationStatusMessage",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).SensitiveDataDiscoveryOperationStatusMessage, global::System.Convert.ToString);
            }
            if (content.Contains("OnUploadIsEnabled"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).OnUploadIsEnabled = (bool?) content.GetValueForProperty("OnUploadIsEnabled",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).OnUploadIsEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("OnUploadCapGbPerMonth"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).OnUploadCapGbPerMonth = (int?) content.GetValueForProperty("OnUploadCapGbPerMonth",((Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSettingInternal)this).OnUploadCapGbPerMonth, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.DefenderForStorageSetting"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSetting" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSetting DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DefenderForStorageSetting(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.DefenderForStorageSetting"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSetting" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSetting DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DefenderForStorageSetting(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DefenderForStorageSetting" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="DefenderForStorageSetting" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSetting FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Runtime.SerializationMode.IncludeAll)?.ToString();

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
    /// The Defender for Storage resource.
    [System.ComponentModel.TypeConverter(typeof(DefenderForStorageSettingTypeConverter))]
    public partial interface IDefenderForStorageSetting

    {

    }
}