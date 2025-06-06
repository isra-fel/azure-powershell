// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Extensions;

    /// <summary>
    /// Represents an Azure Active Directory object. The directoryObject type is the base type for many other directory entity
    /// types.
    /// </summary>
    public partial class MicrosoftGraphApplication
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json serialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonObject container);

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

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonObject json, ref bool returnNow);

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

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphApplication.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphApplication.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphApplication FromJson(Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonObject json ? new MicrosoftGraphApplication(json, new global::System.Collections.Generic.HashSet<string>(){ @"ResourceGroupName",@"deletedDateTime",@"displayName",@"@odata.type",@"@odata.id",@"addIns",@"api",@"appId",@"applicationTemplateId",@"appRoles",@"createdDateTime",@"description",@"disabledByMicrosoftStatus",@"groupMembershipClaims",@"identifierUris",@"info",@"isDeviceOnlyAuthSupported",@"isFallbackPublicClient",@"keyCredentials",@"logo",@"notes",@"oauth2RequirePostResponse",@"optionalClaims",@"parentalControlSettings",@"passwordCredentials",@"publicClient",@"publisherDomain",@"requiredResourceAccess",@"serviceManagementReference",@"signInAudience",@"spa",@"tags",@"tokenEncryptionKeyId",@"web",@"createdOnBehalfOf",@"extensionProperties",@"federatedIdentityCredentials",@"homeRealmDiscoveryPolicies",@"owners",@"tokenIssuancePolicies",@"tokenLifetimePolicies" }) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonObject into a new instance of <see cref="MicrosoftGraphApplication" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonObject instance to deserialize from.</param>
        /// <param name="exclusions"></param>
        internal MicrosoftGraphApplication(Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonObject json, global::System.Collections.Generic.HashSet<string> exclusions = null)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.JsonSerializable.FromJson( json, ((Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.IAssociativeArray<global::System.Object>)this).AdditionalProperties, Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.JsonSerializable.DeserializeDictionary(()=>new global::System.Collections.Generic.Dictionary<global::System.String,global::System.Object>()),exclusions );
            __microsoftGraphDirectoryObject = new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphDirectoryObject(json);
            {_createdOnBehalfOf = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonObject>("createdOnBehalfOf"), out var __jsonCreatedOnBehalfOf) ? Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphDirectoryObject.FromJson(__jsonCreatedOnBehalfOf) : _createdOnBehalfOf;}
            {_addIn = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonArray>("addIns"), out var __jsonAddIns) ? If( __jsonAddIns as Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphAddIn[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphAddIn) (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphAddIn.FromJson(__u) )) ))() : null : _addIn;}
            {_appId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonString>("appId"), out var __jsonAppId) ? (string)__jsonAppId : (string)_appId;}
            {_applicationTemplateId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonString>("applicationTemplateId"), out var __jsonApplicationTemplateId) ? (string)__jsonApplicationTemplateId : (string)_applicationTemplateId;}
            {_appRole = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonArray>("appRoles"), out var __jsonAppRoles) ? If( __jsonAppRoles as Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphAppRole[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphAppRole) (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphAppRole.FromJson(__p) )) ))() : null : _appRole;}
            {_createdDateTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonString>("createdDateTime"), out var __jsonCreatedDateTime) ? global::System.DateTime.TryParse((string)__jsonCreatedDateTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonCreatedDateTimeValue) ? __jsonCreatedDateTimeValue : _createdDateTime : _createdDateTime;}
            {_description = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonString>("description"), out var __jsonDescription) ? (string)__jsonDescription : (string)_description;}
            {_disabledByMicrosoftStatus = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonString>("disabledByMicrosoftStatus"), out var __jsonDisabledByMicrosoftStatus) ? (string)__jsonDisabledByMicrosoftStatus : (string)_disabledByMicrosoftStatus;}
            {_groupMembershipClaim = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonString>("groupMembershipClaims"), out var __jsonGroupMembershipClaims) ? (string)__jsonGroupMembershipClaims : (string)_groupMembershipClaim;}
            {_identifierUri = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonArray>("identifierUris"), out var __jsonIdentifierUris) ? If( __jsonIdentifierUris as Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(string) (__k is Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonString __j ? (string)(__j.ToString()) : null)) ))() : null : _identifierUri;}
            {_isDeviceOnlyAuthSupported = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonBoolean>("isDeviceOnlyAuthSupported"), out var __jsonIsDeviceOnlyAuthSupported) ? (bool?)__jsonIsDeviceOnlyAuthSupported : _isDeviceOnlyAuthSupported;}
            {_isFallbackPublicClient = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonBoolean>("isFallbackPublicClient"), out var __jsonIsFallbackPublicClient) ? (bool?)__jsonIsFallbackPublicClient : _isFallbackPublicClient;}
            {_keyCredentials = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonArray>("keyCredentials"), out var __jsonKeyCredentials) ? If( __jsonKeyCredentials as Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonArray, out var __g) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphKeyCredential[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__g, (__f)=>(Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphKeyCredential) (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphKeyCredential.FromJson(__f) )) ))() : null : _keyCredentials;}
            {_logo = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonString>("logo"), out var __c) ?  System.Convert.FromBase64String( ((string)__c).Replace("_","/").Replace("-","+").PadRight(  ((string)__c).Length  + ((string)__c).Length * 3 % 4, '=') ) : null;}
            {_note = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonString>("notes"), out var __jsonNotes) ? (string)__jsonNotes : (string)_note;}
            {_oauth2RequirePostResponse = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonBoolean>("oauth2RequirePostResponse"), out var __jsonOauth2RequirePostResponse) ? (bool?)__jsonOauth2RequirePostResponse : _oauth2RequirePostResponse;}
            {_passwordCredentials = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonArray>("passwordCredentials"), out var __jsonPasswordCredentials) ? If( __jsonPasswordCredentials as Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonArray, out var ___z) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphPasswordCredential[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___z, (___y)=>(Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphPasswordCredential) (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphPasswordCredential.FromJson(___y) )) ))() : null : _passwordCredentials;}
            {_publisherDomain = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonString>("publisherDomain"), out var __jsonPublisherDomain) ? (string)__jsonPublisherDomain : (string)_publisherDomain;}
            {_requiredResourceAccess = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonArray>("requiredResourceAccess"), out var __jsonRequiredResourceAccess) ? If( __jsonRequiredResourceAccess as Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonArray, out var ___u) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphRequiredResourceAccess[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___u, (___t)=>(Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphRequiredResourceAccess) (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphRequiredResourceAccess.FromJson(___t) )) ))() : null : _requiredResourceAccess;}
            {_serviceManagementReference = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonString>("serviceManagementReference"), out var __jsonServiceManagementReference) ? (string)__jsonServiceManagementReference : (string)_serviceManagementReference;}
            {_signInAudience = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonString>("signInAudience"), out var __jsonSignInAudience) ? (string)__jsonSignInAudience : (string)_signInAudience;}
            {_tag = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonArray>("tags"), out var __jsonTags) ? If( __jsonTags as Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonArray, out var ___p) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___p, (___o)=>(string) (___o is Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonString ___n ? (string)(___n.ToString()) : null)) ))() : null : _tag;}
            {_tokenEncryptionKeyId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonString>("tokenEncryptionKeyId"), out var __jsonTokenEncryptionKeyId) ? (string)__jsonTokenEncryptionKeyId : (string)_tokenEncryptionKeyId;}
            {_extensionProperty = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonArray>("extensionProperties"), out var __jsonExtensionProperties) ? If( __jsonExtensionProperties as Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonArray, out var ___k) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphExtensionProperty[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___k, (___j)=>(Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphExtensionProperty) (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphExtensionProperty.FromJson(___j) )) ))() : null : _extensionProperty;}
            {_federatedIdentityCredentials = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonArray>("federatedIdentityCredentials"), out var __jsonFederatedIdentityCredentials) ? If( __jsonFederatedIdentityCredentials as Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonArray, out var ___f) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphFederatedIdentityCredential[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___f, (___e)=>(Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphFederatedIdentityCredential) (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphFederatedIdentityCredential.FromJson(___e) )) ))() : null : _federatedIdentityCredentials;}
            {_homeRealmDiscoveryPolicy = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonArray>("homeRealmDiscoveryPolicies"), out var __jsonHomeRealmDiscoveryPolicies) ? If( __jsonHomeRealmDiscoveryPolicies as Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonArray, out var ___a) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphHomeRealmDiscoveryPolicy[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___a, (____z)=>(Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphHomeRealmDiscoveryPolicy) (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphHomeRealmDiscoveryPolicy.FromJson(____z) )) ))() : null : _homeRealmDiscoveryPolicy;}
            {_owner = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonArray>("owners"), out var __jsonOwners) ? If( __jsonOwners as Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonArray, out var ____v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphDirectoryObject[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(____v, (____u)=>(Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphDirectoryObject) (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphDirectoryObject.FromJson(____u) )) ))() : null : _owner;}
            {_tokenIssuancePolicy = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonArray>("tokenIssuancePolicies"), out var __jsonTokenIssuancePolicies) ? If( __jsonTokenIssuancePolicies as Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonArray, out var ____q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphTokenIssuancePolicy[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(____q, (____p)=>(Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphTokenIssuancePolicy) (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphTokenIssuancePolicy.FromJson(____p) )) ))() : null : _tokenIssuancePolicy;}
            {_tokenLifetimePolicy = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonArray>("tokenLifetimePolicies"), out var __jsonTokenLifetimePolicies) ? If( __jsonTokenLifetimePolicies as Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonArray, out var ____l) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphTokenLifetimePolicy[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(____l, (____k)=>(Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphTokenLifetimePolicy) (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphTokenLifetimePolicy.FromJson(____k) )) ))() : null : _tokenLifetimePolicy;}
            {_api = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonObject>("api"), out var __jsonApi) ? Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphApiApplication.FromJson(__jsonApi) : _api;}
            {_info = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonObject>("info"), out var __jsonInfo) ? Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphInformationalUrl.FromJson(__jsonInfo) : _info;}
            {_optionalClaim = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonObject>("optionalClaims"), out var __jsonOptionalClaims) ? Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphOptionalClaims.FromJson(__jsonOptionalClaims) : _optionalClaim;}
            {_parentalControlSetting = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonObject>("parentalControlSettings"), out var __jsonParentalControlSettings) ? Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphParentalControlSettings.FromJson(__jsonParentalControlSettings) : _parentalControlSetting;}
            {_publicClient = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonObject>("publicClient"), out var __jsonPublicClient) ? Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphPublicClientApplication.FromJson(__jsonPublicClient) : _publicClient;}
            {_spa = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonObject>("spa"), out var __jsonSpa) ? Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphSpaApplication.FromJson(__jsonSpa) : _spa;}
            {_web = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonObject>("web"), out var __jsonWeb) ? Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.MicrosoftGraphWebApplication.FromJson(__jsonWeb) : _web;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="MicrosoftGraphApplication" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="MicrosoftGraphApplication" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.JsonSerializable.ToJson( ((Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.IAssociativeArray<global::System.Object>)this).AdditionalProperties, container);
            __microsoftGraphDirectoryObject?.ToJson(container, serializationMode);
            AddIf( null != this._createdOnBehalfOf ? (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode) this._createdOnBehalfOf.ToJson(null,serializationMode) : null, "createdOnBehalfOf" ,container.Add );
            if (null != this._addIn)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.XNodeArray();
                foreach( var __x in this._addIn )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("addIns",__w);
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != (((object)this._appId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonString(this._appId.ToString()) : null, "appId" ,container.Add );
            }
            AddIf( null != (((object)this._applicationTemplateId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonString(this._applicationTemplateId.ToString()) : null, "applicationTemplateId" ,container.Add );
            if (null != this._appRole)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.XNodeArray();
                foreach( var __s in this._appRole )
                {
                    AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                }
                container.Add("appRoles",__r);
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != this._createdDateTime ? (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonString(this._createdDateTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "createdDateTime" ,container.Add );
            }
            AddIf( null != (((object)this._description)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonString(this._description.ToString()) : null, "description" ,container.Add );
            AddIf( null != (((object)this._disabledByMicrosoftStatus)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonString(this._disabledByMicrosoftStatus.ToString()) : null, "disabledByMicrosoftStatus" ,container.Add );
            AddIf( null != (((object)this._groupMembershipClaim)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonString(this._groupMembershipClaim.ToString()) : null, "groupMembershipClaims" ,container.Add );
            if (null != this._identifierUri)
            {
                var __m = new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.XNodeArray();
                foreach( var __n in this._identifierUri )
                {
                    AddIf(null != (((object)__n)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonString(__n.ToString()) : null ,__m.Add);
                }
                container.Add("identifierUris",__m);
            }
            AddIf( null != this._isDeviceOnlyAuthSupported ? (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonBoolean((bool)this._isDeviceOnlyAuthSupported) : null, "isDeviceOnlyAuthSupported" ,container.Add );
            AddIf( null != this._isFallbackPublicClient ? (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonBoolean((bool)this._isFallbackPublicClient) : null, "isFallbackPublicClient" ,container.Add );
            if (null != this._keyCredentials)
            {
                var __h = new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.XNodeArray();
                foreach( var __i in this._keyCredentials )
                {
                    AddIf(__i?.ToJson(null, serializationMode) ,__h.Add);
                }
                container.Add("keyCredentials",__h);
            }
            AddIf( null != this._logo ? global::System.Convert.ToBase64String( this._logo).TrimEnd(new char[] {'='}).Replace('+', '-').Replace('/', '_') : null ,(v)=> container.Add( "logo",v) );
            AddIf( null != (((object)this._note)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonString(this._note.ToString()) : null, "notes" ,container.Add );
            AddIf( null != this._oauth2RequirePostResponse ? (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonBoolean((bool)this._oauth2RequirePostResponse) : null, "oauth2RequirePostResponse" ,container.Add );
            if (null != this._passwordCredentials)
            {
                var __a = new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.XNodeArray();
                foreach( var __b in this._passwordCredentials )
                {
                    AddIf(__b?.ToJson(null, serializationMode) ,__a.Add);
                }
                container.Add("passwordCredentials",__a);
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != (((object)this._publisherDomain)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonString(this._publisherDomain.ToString()) : null, "publisherDomain" ,container.Add );
            }
            if (null != this._requiredResourceAccess)
            {
                var ___v = new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.XNodeArray();
                foreach( var ___w in this._requiredResourceAccess )
                {
                    AddIf(___w?.ToJson(null, serializationMode) ,___v.Add);
                }
                container.Add("requiredResourceAccess",___v);
            }
            AddIf( null != (((object)this._serviceManagementReference)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonString(this._serviceManagementReference.ToString()) : null, "serviceManagementReference" ,container.Add );
            AddIf( null != (((object)this._signInAudience)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonString(this._signInAudience.ToString()) : null, "signInAudience" ,container.Add );
            if (null != this._tag)
            {
                var ___q = new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.XNodeArray();
                foreach( var ___r in this._tag )
                {
                    AddIf(null != (((object)___r)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonString(___r.ToString()) : null ,___q.Add);
                }
                container.Add("tags",___q);
            }
            AddIf( null != (((object)this._tokenEncryptionKeyId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonString(this._tokenEncryptionKeyId.ToString()) : null, "tokenEncryptionKeyId" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.SerializationMode.IncludeRead))
            {
                if (null != this._extensionProperty)
                {
                    var ___l = new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.XNodeArray();
                    foreach( var ___m in this._extensionProperty )
                    {
                        AddIf(___m?.ToJson(null, serializationMode) ,___l.Add);
                    }
                    container.Add("extensionProperties",___l);
                }
            }
            if (null != this._federatedIdentityCredentials)
            {
                var ___g = new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.XNodeArray();
                foreach( var ___h in this._federatedIdentityCredentials )
                {
                    AddIf(___h?.ToJson(null, serializationMode) ,___g.Add);
                }
                container.Add("federatedIdentityCredentials",___g);
            }
            if (null != this._homeRealmDiscoveryPolicy)
            {
                var ___b = new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.XNodeArray();
                foreach( var ___c in this._homeRealmDiscoveryPolicy )
                {
                    AddIf(___c?.ToJson(null, serializationMode) ,___b.Add);
                }
                container.Add("homeRealmDiscoveryPolicies",___b);
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.SerializationMode.IncludeRead))
            {
                if (null != this._owner)
                {
                    var ____w = new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.XNodeArray();
                    foreach( var ____x in this._owner )
                    {
                        AddIf(____x?.ToJson(null, serializationMode) ,____w.Add);
                    }
                    container.Add("owners",____w);
                }
            }
            if (null != this._tokenIssuancePolicy)
            {
                var ____r = new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.XNodeArray();
                foreach( var ____s in this._tokenIssuancePolicy )
                {
                    AddIf(____s?.ToJson(null, serializationMode) ,____r.Add);
                }
                container.Add("tokenIssuancePolicies",____r);
            }
            if (null != this._tokenLifetimePolicy)
            {
                var ____m = new Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.XNodeArray();
                foreach( var ____n in this._tokenLifetimePolicy )
                {
                    AddIf(____n?.ToJson(null, serializationMode) ,____m.Add);
                }
                container.Add("tokenLifetimePolicies",____m);
            }
            AddIf( null != this._api ? (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode) this._api.ToJson(null,serializationMode) : null, "api" ,container.Add );
            AddIf( null != this._info ? (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode) this._info.ToJson(null,serializationMode) : null, "info" ,container.Add );
            AddIf( null != this._optionalClaim ? (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode) this._optionalClaim.ToJson(null,serializationMode) : null, "optionalClaims" ,container.Add );
            AddIf( null != this._parentalControlSetting ? (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode) this._parentalControlSetting.ToJson(null,serializationMode) : null, "parentalControlSettings" ,container.Add );
            AddIf( null != this._publicClient ? (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode) this._publicClient.ToJson(null,serializationMode) : null, "publicClient" ,container.Add );
            AddIf( null != this._spa ? (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode) this._spa.ToJson(null,serializationMode) : null, "spa" ,container.Add );
            AddIf( null != this._web ? (Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.Json.JsonNode) this._web.ToJson(null,serializationMode) : null, "web" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}