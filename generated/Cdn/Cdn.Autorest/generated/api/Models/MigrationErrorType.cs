// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Extensions;

    /// <summary>
    /// Error response indicates CDN service is not able to process the incoming request. The reason is provided in the error
    /// message.
    /// </summary>
    public partial class MigrationErrorType :
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IMigrationErrorType,
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IMigrationErrorTypeInternal
    {

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private string _code;

        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)]
        public string Code { get => this._code; }

        /// <summary>Backing field for <see cref="ErrorMessage" /> property.</summary>
        private string _errorMessage;

        /// <summary>Error message indicating why the operation failed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)]
        public string ErrorMessage { get => this._errorMessage; }

        /// <summary>Internal Acessors for Code</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IMigrationErrorTypeInternal.Code { get => this._code; set { {_code = value;} } }

        /// <summary>Internal Acessors for ErrorMessage</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IMigrationErrorTypeInternal.ErrorMessage { get => this._errorMessage; set { {_errorMessage = value;} } }

        /// <summary>Internal Acessors for NextStep</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IMigrationErrorTypeInternal.NextStep { get => this._nextStep; set { {_nextStep = value;} } }

        /// <summary>Internal Acessors for ResourceName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IMigrationErrorTypeInternal.ResourceName { get => this._resourceName; set { {_resourceName = value;} } }

        /// <summary>Backing field for <see cref="NextStep" /> property.</summary>
        private string _nextStep;

        /// <summary>Describes what needs to be done to fix the problem</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)]
        public string NextStep { get => this._nextStep; }

        /// <summary>Backing field for <see cref="ResourceName" /> property.</summary>
        private string _resourceName;

        /// <summary>Resource which has the problem.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)]
        public string ResourceName { get => this._resourceName; }

        /// <summary>Creates an new <see cref="MigrationErrorType" /> instance.</summary>
        public MigrationErrorType()
        {

        }
    }
    /// Error response indicates CDN service is not able to process the incoming request. The reason is provided in the error
    /// message.
    public partial interface IMigrationErrorType :
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.IJsonSerializable
    {
        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Error code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get;  }
        /// <summary>Error message indicating why the operation failed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Error message indicating why the operation failed.",
        SerializedName = @"errorMessage",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorMessage { get;  }
        /// <summary>Describes what needs to be done to fix the problem</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Describes what needs to be done to fix the problem",
        SerializedName = @"nextSteps",
        PossibleTypes = new [] { typeof(string) })]
        string NextStep { get;  }
        /// <summary>Resource which has the problem.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Resource which has the problem.",
        SerializedName = @"resourceName",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceName { get;  }

    }
    /// Error response indicates CDN service is not able to process the incoming request. The reason is provided in the error
    /// message.
    internal partial interface IMigrationErrorTypeInternal

    {
        /// <summary>Error code.</summary>
        string Code { get; set; }
        /// <summary>Error message indicating why the operation failed.</summary>
        string ErrorMessage { get; set; }
        /// <summary>Describes what needs to be done to fix the problem</summary>
        string NextStep { get; set; }
        /// <summary>Resource which has the problem.</summary>
        string ResourceName { get; set; }

    }
}