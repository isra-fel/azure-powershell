// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Runtime.PowerShell;

    /// <summary>Describe the Update properties of a license profile.</summary>
    [System.ComponentModel.TypeConverter(typeof(LicenseProfileUpdatePropertiesTypeConverter))]
    public partial class LicenseProfileUpdateProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.LicenseProfileUpdateProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdateProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdateProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new LicenseProfileUpdateProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.LicenseProfileUpdateProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdateProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdateProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new LicenseProfileUpdateProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="LicenseProfileUpdateProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="LicenseProfileUpdateProperties" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdateProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.LicenseProfileUpdateProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal LicenseProfileUpdateProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("SoftwareAssurance"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).SoftwareAssurance = (Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesSoftwareAssurance) content.GetValueForProperty("SoftwareAssurance",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).SoftwareAssurance, Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.LicenseProfileUpdatePropertiesSoftwareAssuranceTypeConverter.ConvertFrom);
            }
            if (content.Contains("EsuProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).EsuProfile = (Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IEsuProfileUpdateProperties) content.GetValueForProperty("EsuProfile",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).EsuProfile, Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.EsuProfileUpdatePropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ProductProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).ProductProfile = (Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IProductProfileUpdateProperties) content.GetValueForProperty("ProductProfile",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).ProductProfile, Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ProductProfileUpdatePropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("SoftwareAssuranceCustomer"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).SoftwareAssuranceCustomer = (bool?) content.GetValueForProperty("SoftwareAssuranceCustomer",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).SoftwareAssuranceCustomer, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("EsuProfileAssignedLicense"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).EsuProfileAssignedLicense = (string) content.GetValueForProperty("EsuProfileAssignedLicense",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).EsuProfileAssignedLicense, global::System.Convert.ToString);
            }
            if (content.Contains("ProductProfileSubscriptionStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).ProductProfileSubscriptionStatus = (string) content.GetValueForProperty("ProductProfileSubscriptionStatus",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).ProductProfileSubscriptionStatus, global::System.Convert.ToString);
            }
            if (content.Contains("ProductProfileProductType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).ProductProfileProductType = (string) content.GetValueForProperty("ProductProfileProductType",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).ProductProfileProductType, global::System.Convert.ToString);
            }
            if (content.Contains("ProductProfileProductFeature"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).ProductProfileProductFeature = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IProductFeatureUpdate>) content.GetValueForProperty("ProductProfileProductFeature",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).ProductProfileProductFeature, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IProductFeatureUpdate>(__y, Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ProductFeatureUpdateTypeConverter.ConvertFrom));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.LicenseProfileUpdateProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal LicenseProfileUpdateProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("SoftwareAssurance"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).SoftwareAssurance = (Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesSoftwareAssurance) content.GetValueForProperty("SoftwareAssurance",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).SoftwareAssurance, Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.LicenseProfileUpdatePropertiesSoftwareAssuranceTypeConverter.ConvertFrom);
            }
            if (content.Contains("EsuProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).EsuProfile = (Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IEsuProfileUpdateProperties) content.GetValueForProperty("EsuProfile",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).EsuProfile, Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.EsuProfileUpdatePropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ProductProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).ProductProfile = (Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IProductProfileUpdateProperties) content.GetValueForProperty("ProductProfile",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).ProductProfile, Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ProductProfileUpdatePropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("SoftwareAssuranceCustomer"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).SoftwareAssuranceCustomer = (bool?) content.GetValueForProperty("SoftwareAssuranceCustomer",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).SoftwareAssuranceCustomer, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("EsuProfileAssignedLicense"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).EsuProfileAssignedLicense = (string) content.GetValueForProperty("EsuProfileAssignedLicense",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).EsuProfileAssignedLicense, global::System.Convert.ToString);
            }
            if (content.Contains("ProductProfileSubscriptionStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).ProductProfileSubscriptionStatus = (string) content.GetValueForProperty("ProductProfileSubscriptionStatus",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).ProductProfileSubscriptionStatus, global::System.Convert.ToString);
            }
            if (content.Contains("ProductProfileProductType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).ProductProfileProductType = (string) content.GetValueForProperty("ProductProfileProductType",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).ProductProfileProductType, global::System.Convert.ToString);
            }
            if (content.Contains("ProductProfileProductFeature"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).ProductProfileProductFeature = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IProductFeatureUpdate>) content.GetValueForProperty("ProductProfileProductFeature",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ILicenseProfileUpdatePropertiesInternal)this).ProductProfileProductFeature, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IProductFeatureUpdate>(__y, Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.ProductFeatureUpdateTypeConverter.ConvertFrom));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Runtime.SerializationMode.IncludeAll)?.ToString();

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
    /// Describe the Update properties of a license profile.
    [System.ComponentModel.TypeConverter(typeof(LicenseProfileUpdatePropertiesTypeConverter))]
    public partial interface ILicenseProfileUpdateProperties

    {

    }
}