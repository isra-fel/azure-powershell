// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.DataFactory.Models
{
    using System.Linq;

    /// <summary>
    /// HDFS linked service properties.
    /// </summary>
    public partial class HdfsLinkedServiceTypeProperties
    {
        /// <summary>
        /// Initializes a new instance of the HdfsLinkedServiceTypeProperties class.
        /// </summary>
        public HdfsLinkedServiceTypeProperties()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the HdfsLinkedServiceTypeProperties class.
        /// </summary>

        /// <param name="url">The URL of the HDFS service endpoint, e.g.
        /// http://myhostname:50070/webhdfs/v1 . Type: string (or Expression with
        /// resultType string).
        /// </param>

        /// <param name="authenticationType">Type of authentication used to connect to the HDFS. Possible values are:
        /// Anonymous and Windows. Type: string (or Expression with resultType string).
        /// </param>

        /// <param name="encryptedCredential">The encrypted credential used for authentication. Credentials are encrypted
        /// using the integration runtime credential manager. Type: string.
        /// </param>

        /// <param name="userName">User name for Windows authentication. Type: string (or Expression with
        /// resultType string).
        /// </param>

        /// <param name="password">Password for Windows authentication.
        /// </param>
        public HdfsLinkedServiceTypeProperties(object url, object authenticationType = default(object), string encryptedCredential = default(string), object userName = default(object), SecretBase password = default(SecretBase))

        {
            this.Url = url;
            this.AuthenticationType = authenticationType;
            this.EncryptedCredential = encryptedCredential;
            this.UserName = userName;
            this.Password = password;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets the URL of the HDFS service endpoint, e.g.
        /// http://myhostname:50070/webhdfs/v1 . Type: string (or Expression with
        /// resultType string).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "url")]
        public object Url {get; set; }

        /// <summary>
        /// Gets or sets type of authentication used to connect to the HDFS. Possible
        /// values are: Anonymous and Windows. Type: string (or Expression with
        /// resultType string).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "authenticationType")]
        public object AuthenticationType {get; set; }

        /// <summary>
        /// Gets or sets the encrypted credential used for authentication. Credentials
        /// are encrypted using the integration runtime credential manager. Type:
        /// string.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "encryptedCredential")]
        public string EncryptedCredential {get; set; }

        /// <summary>
        /// Gets or sets user name for Windows authentication. Type: string (or
        /// Expression with resultType string).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "userName")]
        public object UserName {get; set; }

        /// <summary>
        /// Gets or sets password for Windows authentication.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "password")]
        public SecretBase Password {get; set; }
        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (this.Url == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "Url");
            }





        }
    }
}