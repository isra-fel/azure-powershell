// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Support
{

    /// <summary>Allowed values are Sum, Avg, Count, Min, Max. Default is Sum</summary>
    public partial struct AggregationType :
        System.IEquatable<AggregationType>
    {
        public static Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Support.AggregationType Avg = @"Avg";

        public static Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Support.AggregationType Count = @"Count";

        public static Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Support.AggregationType Max = @"Max";

        public static Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Support.AggregationType Min = @"Min";

        public static Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Support.AggregationType Sum = @"Sum";

        /// <summary>the value for an instance of the <see cref="AggregationType" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Creates an instance of the <see cref="AggregationType"/> Enum class.</summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private AggregationType(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to AggregationType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="AggregationType" />.</param>
        internal static object CreateFrom(object value)
        {
            return new AggregationType(global::System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type AggregationType</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Support.AggregationType e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type AggregationType (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is AggregationType && Equals((AggregationType)obj);
        }

        /// <summary>Returns hashCode for enum AggregationType</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for AggregationType</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to AggregationType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="AggregationType" />.</param>

        public static implicit operator AggregationType(string value)
        {
            return new AggregationType(value);
        }

        /// <summary>Implicit operator to convert AggregationType to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="AggregationType" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Support.AggregationType e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum AggregationType</summary>
        /// <param name="e1">the value to compare against <paramref name="e2" /></param>
        /// <param name="e2">the value to compare against <paramref name="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Support.AggregationType e1, Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Support.AggregationType e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum AggregationType</summary>
        /// <param name="e1">the value to compare against <paramref name="e2" /></param>
        /// <param name="e2">the value to compare against <paramref name="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Support.AggregationType e1, Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Support.AggregationType e2)
        {
            return e2.Equals(e1);
        }
    }
}