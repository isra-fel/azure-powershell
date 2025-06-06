// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Support
{

    /// <summary>
    /// Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).
    /// </summary>
    public partial struct ManagedServiceIdentityType :
        System.IEquatable<ManagedServiceIdentityType>
    {
        public static Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Support.ManagedServiceIdentityType None = @"None";

        public static Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Support.ManagedServiceIdentityType SystemAssigned = @"SystemAssigned";

        public static Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Support.ManagedServiceIdentityType SystemAssignedUserAssigned = @"SystemAssigned,UserAssigned";

        public static Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Support.ManagedServiceIdentityType UserAssigned = @"UserAssigned";

        /// <summary>
        /// the value for an instance of the <see cref="ManagedServiceIdentityType" /> Enum.
        /// </summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to ManagedServiceIdentityType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ManagedServiceIdentityType" />.</param>
        internal static object CreateFrom(object value)
        {
            return new ManagedServiceIdentityType(global::System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ManagedServiceIdentityType</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Support.ManagedServiceIdentityType e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type ManagedServiceIdentityType (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ManagedServiceIdentityType && Equals((ManagedServiceIdentityType)obj);
        }

        /// <summary>Returns hashCode for enum ManagedServiceIdentityType</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="ManagedServiceIdentityType"/> Enum class.</summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ManagedServiceIdentityType(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for ManagedServiceIdentityType</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ManagedServiceIdentityType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ManagedServiceIdentityType" />.</param>

        public static implicit operator ManagedServiceIdentityType(string value)
        {
            return new ManagedServiceIdentityType(value);
        }

        /// <summary>Implicit operator to convert ManagedServiceIdentityType to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ManagedServiceIdentityType" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Support.ManagedServiceIdentityType e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ManagedServiceIdentityType</summary>
        /// <param name="e1">the value to compare against <paramref name="e2" /></param>
        /// <param name="e2">the value to compare against <paramref name="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Support.ManagedServiceIdentityType e1, Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Support.ManagedServiceIdentityType e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ManagedServiceIdentityType</summary>
        /// <param name="e1">the value to compare against <paramref name="e2" /></param>
        /// <param name="e2">the value to compare against <paramref name="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Support.ManagedServiceIdentityType e1, Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Support.ManagedServiceIdentityType e2)
        {
            return e2.Equals(e1);
        }
    }
}