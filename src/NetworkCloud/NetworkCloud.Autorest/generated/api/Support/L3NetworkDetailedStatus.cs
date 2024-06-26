// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support
{

    /// <summary>The more detailed status of the L3 network.</summary>
    public partial struct L3NetworkDetailedStatus :
        System.IEquatable<L3NetworkDetailedStatus>
    {
        public static Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.L3NetworkDetailedStatus Available = @"Available";

        public static Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.L3NetworkDetailedStatus Error = @"Error";

        public static Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.L3NetworkDetailedStatus Provisioning = @"Provisioning";

        /// <summary>the value for an instance of the <see cref="L3NetworkDetailedStatus" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to L3NetworkDetailedStatus</summary>
        /// <param name="value">the value to convert to an instance of <see cref="L3NetworkDetailedStatus" />.</param>
        internal static object CreateFrom(object value)
        {
            return new L3NetworkDetailedStatus(global::System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type L3NetworkDetailedStatus</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.L3NetworkDetailedStatus e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type L3NetworkDetailedStatus (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is L3NetworkDetailedStatus && Equals((L3NetworkDetailedStatus)obj);
        }

        /// <summary>Returns hashCode for enum L3NetworkDetailedStatus</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="L3NetworkDetailedStatus"/> Enum class.</summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private L3NetworkDetailedStatus(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for L3NetworkDetailedStatus</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to L3NetworkDetailedStatus</summary>
        /// <param name="value">the value to convert to an instance of <see cref="L3NetworkDetailedStatus" />.</param>

        public static implicit operator L3NetworkDetailedStatus(string value)
        {
            return new L3NetworkDetailedStatus(value);
        }

        /// <summary>Implicit operator to convert L3NetworkDetailedStatus to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="L3NetworkDetailedStatus" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.L3NetworkDetailedStatus e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum L3NetworkDetailedStatus</summary>
        /// <param name="e1">the value to compare against <paramref name="e2" /></param>
        /// <param name="e2">the value to compare against <paramref name="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.L3NetworkDetailedStatus e1, Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.L3NetworkDetailedStatus e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum L3NetworkDetailedStatus</summary>
        /// <param name="e1">the value to compare against <paramref name="e2" /></param>
        /// <param name="e2">the value to compare against <paramref name="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.L3NetworkDetailedStatus e1, Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.L3NetworkDetailedStatus e2)
        {
            return e2.Equals(e1);
        }
    }
}