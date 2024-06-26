// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Runtime.Extensions;

    /// <summary>The status of an Azure resource at the time the operation was called.</summary>
    public partial class Status :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IStatus,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IStatusInternal
    {

        /// <summary>Backing field for <see cref="DisplayStatus" /> property.</summary>
        private string _displayStatus;

        /// <summary>The short label for the status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.PropertyOrigin.Owned)]
        public string DisplayStatus { get => this._displayStatus; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>The detailed message for the status, including alerts and error messages.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.PropertyOrigin.Owned)]
        public string Message { get => this._message; }

        /// <summary>Internal Acessors for DisplayStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IStatusInternal.DisplayStatus { get => this._displayStatus; set { {_displayStatus = value;} } }

        /// <summary>Internal Acessors for Message</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IStatusInternal.Message { get => this._message; set { {_message = value;} } }

        /// <summary>Internal Acessors for Timestamp</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IStatusInternal.Timestamp { get => this._timestamp; set { {_timestamp = value;} } }

        /// <summary>Backing field for <see cref="Timestamp" /> property.</summary>
        private global::System.DateTime? _timestamp;

        /// <summary>The timestamp when the status was changed to the current value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.PropertyOrigin.Owned)]
        public global::System.DateTime? Timestamp { get => this._timestamp; }

        /// <summary>Creates an new <see cref="Status" /> instance.</summary>
        public Status()
        {

        }
    }
    /// The status of an Azure resource at the time the operation was called.
    public partial interface IStatus :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Runtime.IJsonSerializable
    {
        /// <summary>The short label for the status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The short label for the status.",
        SerializedName = @"displayStatus",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayStatus { get;  }
        /// <summary>The detailed message for the status, including alerts and error messages.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The detailed message for the status, including alerts and error messages.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get;  }
        /// <summary>The timestamp when the status was changed to the current value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The timestamp when the status was changed to the current value.",
        SerializedName = @"timestamp",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? Timestamp { get;  }

    }
    /// The status of an Azure resource at the time the operation was called.
    internal partial interface IStatusInternal

    {
        /// <summary>The short label for the status.</summary>
        string DisplayStatus { get; set; }
        /// <summary>The detailed message for the status, including alerts and error messages.</summary>
        string Message { get; set; }
        /// <summary>The timestamp when the status was changed to the current value.</summary>
        global::System.DateTime? Timestamp { get; set; }

    }
}