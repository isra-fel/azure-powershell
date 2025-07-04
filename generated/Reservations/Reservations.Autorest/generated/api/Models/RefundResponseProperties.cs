// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Extensions;

    /// <summary>The refund properties of reservation</summary>
    public partial class RefundResponseProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundResponseProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundResponsePropertiesInternal
    {

        /// <summary>Backing field for <see cref="BillingInformation" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundBillingInformation _billingInformation;

        /// <summary>billing information</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundBillingInformation BillingInformation { get => (this._billingInformation = this._billingInformation ?? new Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.RefundBillingInformation()); set => this._billingInformation = value; }

        /// <summary>Pricing information containing the amount and the currency code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice BillingInformationBillingCurrencyProratedAmount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundBillingInformationInternal)BillingInformation).BillingCurrencyProratedAmount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundBillingInformationInternal)BillingInformation).BillingCurrencyProratedAmount = value ?? null /* model class */; }

        /// <summary>Pricing information containing the amount and the currency code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice BillingInformationBillingCurrencyRemainingCommitmentAmount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundBillingInformationInternal)BillingInformation).BillingCurrencyRemainingCommitmentAmount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundBillingInformationInternal)BillingInformation).BillingCurrencyRemainingCommitmentAmount = value ?? null /* model class */; }

        /// <summary>Pricing information containing the amount and the currency code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice BillingInformationBillingCurrencyTotalPaidAmount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundBillingInformationInternal)BillingInformation).BillingCurrencyTotalPaidAmount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundBillingInformationInternal)BillingInformation).BillingCurrencyTotalPaidAmount = value ?? null /* model class */; }

        /// <summary>Represent the billing plans.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Inlined)]
        public string BillingInformationBillingPlan { get => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundBillingInformationInternal)BillingInformation).BillingPlan; set => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundBillingInformationInternal)BillingInformation).BillingPlan = value ?? null; }

        /// <summary>The number of completed transactions in this reservation's payment</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Inlined)]
        public int? BillingInformationCompletedTransaction { get => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundBillingInformationInternal)BillingInformation).CompletedTransaction; set => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundBillingInformationInternal)BillingInformation).CompletedTransaction = value ?? default(int); }

        /// <summary>The number of total transactions in this reservation's payment</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Inlined)]
        public int? BillingInformationTotalTransaction { get => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundBillingInformationInternal)BillingInformation).TotalTransaction; set => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundBillingInformationInternal)BillingInformation).TotalTransaction = value ?? default(int); }

        /// <summary>Backing field for <see cref="BillingRefundAmount" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice _billingRefundAmount;

        /// <summary>Pricing information containing the amount and the currency code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice BillingRefundAmount { get => (this._billingRefundAmount = this._billingRefundAmount ?? new Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Price()); set => this._billingRefundAmount = value; }

        /// <summary>Pricing information containing the amount and the currency code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice ConsumedRefundsTotal { get => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundPolicyResultInternal)PolicyResult).ConsumedRefundsTotal; set => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundPolicyResultInternal)PolicyResult).ConsumedRefundsTotal = value ?? null /* model class */; }

        /// <summary>Pricing information containing the amount and the currency code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice MaxRefundLimit { get => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundPolicyResultInternal)PolicyResult).MaxRefundLimit; set => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundPolicyResultInternal)PolicyResult).MaxRefundLimit = value ?? null /* model class */; }

        /// <summary>Internal Acessors for BillingInformation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundBillingInformation Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundResponsePropertiesInternal.BillingInformation { get => (this._billingInformation = this._billingInformation ?? new Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.RefundBillingInformation()); set { {_billingInformation = value;} } }

        /// <summary>Internal Acessors for PolicyResult</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundPolicyResult Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundResponsePropertiesInternal.PolicyResult { get => (this._policyResult = this._policyResult ?? new Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.RefundPolicyResult()); set { {_policyResult = value;} } }

        /// <summary>Internal Acessors for PolicyResultProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundPolicyResultProperty Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundResponsePropertiesInternal.PolicyResultProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundPolicyResultInternal)PolicyResult).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundPolicyResultInternal)PolicyResult).Property = value ?? null /* model class */; }

        /// <summary>Refund Policy errors</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundPolicyError> PolicyError { get => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundPolicyResultInternal)PolicyResult).PolicyError; set => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundPolicyResultInternal)PolicyResult).PolicyError = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="PolicyResult" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundPolicyResult _policyResult;

        /// <summary>Refund policy result</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundPolicyResult PolicyResult { get => (this._policyResult = this._policyResult ?? new Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.RefundPolicyResult()); set => this._policyResult = value; }

        /// <summary>Backing field for <see cref="PricingRefundAmount" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice _pricingRefundAmount;

        /// <summary>Pricing information containing the amount and the currency code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice PricingRefundAmount { get => (this._pricingRefundAmount = this._pricingRefundAmount ?? new Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Price()); set => this._pricingRefundAmount = value; }

        /// <summary>Backing field for <see cref="Quantity" /> property.</summary>
        private int? _quantity;

        /// <summary>Quantity to be returned</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        public int? Quantity { get => this._quantity; set => this._quantity = value; }

        /// <summary>Backing field for <see cref="SessionId" /> property.</summary>
        private string _sessionId;

        /// <summary>Refund session identifier</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        public string SessionId { get => this._sessionId; set => this._sessionId = value; }

        /// <summary>Creates an new <see cref="RefundResponseProperties" /> instance.</summary>
        public RefundResponseProperties()
        {

        }
    }
    /// The refund properties of reservation
    public partial interface IRefundResponseProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.IJsonSerializable
    {
        /// <summary>Pricing information containing the amount and the currency code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Pricing information containing the amount and the currency code",
        SerializedName = @"billingCurrencyProratedAmount",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice) })]
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice BillingInformationBillingCurrencyProratedAmount { get; set; }
        /// <summary>Pricing information containing the amount and the currency code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Pricing information containing the amount and the currency code",
        SerializedName = @"billingCurrencyRemainingCommitmentAmount",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice) })]
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice BillingInformationBillingCurrencyRemainingCommitmentAmount { get; set; }
        /// <summary>Pricing information containing the amount and the currency code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Pricing information containing the amount and the currency code",
        SerializedName = @"billingCurrencyTotalPaidAmount",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice) })]
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice BillingInformationBillingCurrencyTotalPaidAmount { get; set; }
        /// <summary>Represent the billing plans.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Represent the billing plans.",
        SerializedName = @"billingPlan",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Reservations.PSArgumentCompleterAttribute("Upfront", "Monthly")]
        string BillingInformationBillingPlan { get; set; }
        /// <summary>The number of completed transactions in this reservation's payment</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The number of completed transactions in this reservation's payment",
        SerializedName = @"completedTransactions",
        PossibleTypes = new [] { typeof(int) })]
        int? BillingInformationCompletedTransaction { get; set; }
        /// <summary>The number of total transactions in this reservation's payment</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The number of total transactions in this reservation's payment",
        SerializedName = @"totalTransactions",
        PossibleTypes = new [] { typeof(int) })]
        int? BillingInformationTotalTransaction { get; set; }
        /// <summary>Pricing information containing the amount and the currency code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Pricing information containing the amount and the currency code",
        SerializedName = @"billingRefundAmount",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice) })]
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice BillingRefundAmount { get; set; }
        /// <summary>Pricing information containing the amount and the currency code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Pricing information containing the amount and the currency code",
        SerializedName = @"consumedRefundsTotal",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice) })]
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice ConsumedRefundsTotal { get; set; }
        /// <summary>Pricing information containing the amount and the currency code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Pricing information containing the amount and the currency code",
        SerializedName = @"maxRefundLimit",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice) })]
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice MaxRefundLimit { get; set; }
        /// <summary>Refund Policy errors</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Refund Policy errors",
        SerializedName = @"policyErrors",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundPolicyError) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundPolicyError> PolicyError { get; set; }
        /// <summary>Pricing information containing the amount and the currency code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Pricing information containing the amount and the currency code",
        SerializedName = @"pricingRefundAmount",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice) })]
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice PricingRefundAmount { get; set; }
        /// <summary>Quantity to be returned</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Quantity to be returned",
        SerializedName = @"quantity",
        PossibleTypes = new [] { typeof(int) })]
        int? Quantity { get; set; }
        /// <summary>Refund session identifier</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Refund session identifier",
        SerializedName = @"sessionId",
        PossibleTypes = new [] { typeof(string) })]
        string SessionId { get; set; }

    }
    /// The refund properties of reservation
    internal partial interface IRefundResponsePropertiesInternal

    {
        /// <summary>billing information</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundBillingInformation BillingInformation { get; set; }
        /// <summary>Pricing information containing the amount and the currency code</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice BillingInformationBillingCurrencyProratedAmount { get; set; }
        /// <summary>Pricing information containing the amount and the currency code</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice BillingInformationBillingCurrencyRemainingCommitmentAmount { get; set; }
        /// <summary>Pricing information containing the amount and the currency code</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice BillingInformationBillingCurrencyTotalPaidAmount { get; set; }
        /// <summary>Represent the billing plans.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Reservations.PSArgumentCompleterAttribute("Upfront", "Monthly")]
        string BillingInformationBillingPlan { get; set; }
        /// <summary>The number of completed transactions in this reservation's payment</summary>
        int? BillingInformationCompletedTransaction { get; set; }
        /// <summary>The number of total transactions in this reservation's payment</summary>
        int? BillingInformationTotalTransaction { get; set; }
        /// <summary>Pricing information containing the amount and the currency code</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice BillingRefundAmount { get; set; }
        /// <summary>Pricing information containing the amount and the currency code</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice ConsumedRefundsTotal { get; set; }
        /// <summary>Pricing information containing the amount and the currency code</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice MaxRefundLimit { get; set; }
        /// <summary>Refund Policy errors</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundPolicyError> PolicyError { get; set; }
        /// <summary>Refund policy result</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundPolicyResult PolicyResult { get; set; }
        /// <summary>Refund policy result property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IRefundPolicyResultProperty PolicyResultProperty { get; set; }
        /// <summary>Pricing information containing the amount and the currency code</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.IPrice PricingRefundAmount { get; set; }
        /// <summary>Quantity to be returned</summary>
        int? Quantity { get; set; }
        /// <summary>Refund session identifier</summary>
        string SessionId { get; set; }

    }
}