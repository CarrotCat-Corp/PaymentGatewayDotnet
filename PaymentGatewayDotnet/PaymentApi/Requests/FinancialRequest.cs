using System.Collections.Generic;
using PaymentGatewayDotnet.Contracts;
using PaymentGatewayDotnet.PaymentApi.Data;
using PaymentGatewayDotnet.PaymentApi.Data.RetailDevises;
using PaymentGatewayDotnet.Shared;
using PaymentGatewayDotnet.Shared.Enums;

namespace PaymentGatewayDotnet.PaymentApi.Requests
{
    public class FinancialRequest : PaymentApiRequest, IPaymentApiRequest
    {
        /// <summary>
        /// The type of transaction to be processed
        /// 'sale', 'auth', 'credit', 'validate', or 'offline'
        /// </summary>
        public FinancialRequestType Type { get; set; }

        /// <summary>
        /// Payment credentials (Credit Card, ACH, Payment Token or Google and Apple Pay data)
        /// </summary>
        public PaymentCredentials PaymentCredentials { get; set; }

        public string CustomerVaultId { get; set; }

        /// <summary>
        /// Total amount to be charged. For validate, the amount must be omitted or set to 0.00.
        /// </summary>
        public decimal? Amount { get; set; }
        
        /// <summary>
        /// The transaction currency. Format: ISO 4217
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Total amount to be charged. For validate, the amount must be omitted or set to 0.00.
        /// </summary>
        public decimal? Tip { get; set; }

        /// <summary>
        /// Surcharge amount.
        /// </summary>
        public decimal? Surcharge { get; set; }

        /// <summary>
        /// How much less a customer paid due to a cash discount.
        /// Only applicable to cash and check transactions
        /// </summary>
        public decimal? CashDiscount { get; set; }

        /// <summary>
        /// Kount request data
        /// </summary>
        public Kount Kount { get; set; }

        /// <summary>
        /// Set payment descriptor on supported processors
        /// </summary>
        public PaymentDescriptor PaymentDescriptor { get; set; }

        /// <summary>
        /// Stored Credentials indicator fields
        /// </summary>
        public StoredCredentialsIndicatorParameters StoredCredentialsIndicatorParameters { get; set; }

        /// <summary>
        /// Cardholder signature image. For use with "sale" and "auth" actions only.
        /// Format: base64 encoded raw PNG image. (16kiB maximum)
        /// </summary>
        public string SignatureImage { get; set; }

        /// <summary>
        /// Set to TRUE if you have Pinless Debit Conversion enabled but want to opt out for this transaction. Feature applies to selected processors only.
        /// </summary>
        public bool? PinlessDebitOverride { get; set; }

        /// <summary>
        /// Sets the time in seconds for duplicate transaction checking on supported processors. Set to 0 to disable duplicate checking. This value should not exceed 7862400.
        /// </summary>
        public int? DuplicateSeconds { get; set; }

        /// <summary>
        /// Installment Billing information
        /// </summary>
        public InstallmentBillingData InstallmentBilling { get; set; }

        /// <summary>
        /// Specify authorization code. For use with "offline" action only.
        /// </summary>
        public string AuthorizationCode { get; set; }

        /// <summary>
        /// 3-D Secure verification data
        /// </summary>
        public ThreeDSecure ThreeDSecure { get; set; }

        /// <summary>
        /// Driver License info
        /// </summary>
        public DriversLicense DriversLicence { get; set; }

        /// <summary>
        /// Partial payments parameters
        /// </summary>
        public PartialPayment PartialPayment { get; set; }

        /// <summary>
        /// Payment Facilitator Specific Fields
        /// </summary>
        public PaymentFacilitator PaymentFacilitator { get; set; }

        /// <summary>
        /// Reatil/Cradr data from cardreader or terminal
        /// </summary>
        public CardDeviceData RetailData { get; set; }

        /// <summary>
        /// The type of payment
        /// </summary>
        public PaymentType? Payment { get; set; }

        /// <summary>
        /// If set to true, when the customer is charged, they will be sent a transaction receipt.
        /// </summary>
        public bool? CustomerReceipt { get; set; }

        public Billing Billing { get; set; }

        /// <summary>
        /// Shipping information
        /// </summary>
        public Shipping Shipping { get; set; }


        public FinancialRequest(string securityKey, FinancialRequestType type) : base(securityKey)
        {
            Type = type;
        }

        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            var list = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("type", FinancialRequestTypeUtils.ToString(Type)),
            };

            list.AddRange(base.ToKeyValuePairs());

            if (PaymentCredentials != null) list.AddRange(PaymentCredentials.ToKeyValuePairs());
            if (CustomerVaultId != null)
                list.Add(new KeyValuePair<string, string>("customer_vault_id", CustomerVaultId));
            if (Amount != null) list.Add(new KeyValuePair<string, string>("amount", Amount?.ToString("F2")));
            if (Currency != null) list.Add(new KeyValuePair<string, string>("currency", Currency));
            if (Tip != null) list.Add(new KeyValuePair<string, string>("tip", Tip?.ToString("F2")));
            if (Surcharge != null) list.Add(new KeyValuePair<string, string>("surcharge", Surcharge?.ToString("F2")));
            if (CashDiscount != null)
                list.Add(new KeyValuePair<string, string>("cash_discount", CashDiscount?.ToString("F2")));
            if (Kount != null) list.AddRange(Kount.ToKeyValuePairs());
            if (PaymentDescriptor != null) list.AddRange(PaymentDescriptor.ToKeyValuePairs());
            if (StoredCredentialsIndicatorParameters != null)
                list.AddRange(StoredCredentialsIndicatorParameters.ToKeyValuePairs());
            if (SignatureImage != null) list.Add(new KeyValuePair<string, string>("signature_image", SignatureImage));
            if (PinlessDebitOverride != null && PinlessDebitOverride == true)
                list.Add(new KeyValuePair<string, string>("pinless_debit_override", "Y"));
            if (DuplicateSeconds != null)
                list.Add(new KeyValuePair<string, string>("dup_seconds", DuplicateSeconds.ToString()));
            if (InstallmentBilling != null) list.AddRange(InstallmentBilling.ToKeyValuePairs());
            if (AuthorizationCode != null)
                list.Add(new KeyValuePair<string, string>("authorization_code", AuthorizationCode));
            if (ThreeDSecure != null) list.AddRange(ThreeDSecure.ToKeyValuePairs());
            if (DriversLicence != null) list.AddRange(DriversLicence.ToKeyValuePairs());
            if (PartialPayment != null) list.AddRange(PartialPayment.ToKeyValuePairs());
            if (PaymentFacilitator != null) list.AddRange(PaymentFacilitator.ToKeyValuePairs());
            if (RetailData != null) list.AddRange(RetailData.ToKeyValuePairs());
            if (Payment != null)
                list.Add(new KeyValuePair<string, string>("payment", PaymentTypeUtils.ToString(Payment)));
            if (Shipping != null) list.AddRange(Shipping.ToKeyValuePairs());
            if (Billing != null) list.AddRange(Billing.ToKeyValuePairs());
            if (CustomerReceipt != null)
                list.Add(new KeyValuePair<string, string>("customer_receipt", CustomerReceipt.ToString().ToLower()));

            return list;
        }
    }
}