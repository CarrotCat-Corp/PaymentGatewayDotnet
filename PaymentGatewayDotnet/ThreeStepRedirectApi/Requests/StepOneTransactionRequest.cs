using System.Xml.Linq;
using PaymentGatewayDotnet.Abstractions;
using PaymentGatewayDotnet.Contracts;
using PaymentGatewayDotnet.Shared;
using PaymentGatewayDotnet.Shared.Enums;

namespace PaymentGatewayDotnet.ThreeStepRedirectApi.Requests
{
    public class StepOneTransactionRequest : BaseStepOneRequest, IThreeStepRequest
    {
        /// <summary>
        /// The type of transaction to be processed
        /// 'sale', 'auth', 'credit', 'validate', or 'offline'
        /// </summary>
        public TransactionType Type { get; private set; }

        /// <summary>
        /// Specify industry classification of transaction.
        /// Values: 'ecommerce', 'moto', or 'retail'
        /// </summary>
        public IndustryClassification? Industry { get; set; }

        /// <summary>
        /// If using multiple processors, route to specified processor. Obtained under Settings->Transaction Routing in the merchant control panel.
        /// </summary>
        public string ProcessorId { get; set; }

        /// <summary>
        /// Load customer details from an existing Customer Vault record. If set, no payment information is required during step two.
        /// </summary>
        public string CustomerVaultId { get; set; }

        /// <summary>
        /// Customer identification.
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Send merchant receipt to email
        /// </summary>
        public string MerchantReceiptEmail { get; set; }

        /// <summary>
        /// Cardholder signature image. For use with "sale" and "auth" actions only.
        /// Format: base64 encoded raw PNG image. (16kiB maximum)
        /// </summary>
        public string SignatureImage { get; set; }

        /// <summary>
        /// The Standard Entry Class code of the ACH transaction.
        /// </summary>
        public StandardEntryClassCode? SecCode { get; set; }

        /// <summary>
        /// Total amount to be charged. For validate, the amount must be omitted or set to 0.00.
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Surcharge amount.
        /// </summary>
        public decimal? Surcharge { get; set; }

        /// <summary>
        /// The transaction currency. Format: ISO 4217
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Set payment descriptor on supported processors
        /// </summary>
        public PaymentDescriptor PaymentDescriptor { get; set; }

        /// <summary>
        /// Stored Credentials indicator fields
        /// </summary>
        public StoredCredentialsIndicatorParameters StoredCredentialsIndicatorParameters { get; set; }

        /// <summary>
        /// Specify authorization code. For use with "offline" action only.
        /// </summary>
        public string AuthorizationCode { get; set; }

        /// <summary>
        /// Sets the time in seconds for duplicate transaction checking on supported processors. Set to 0 to disable duplicate checking. This value should not exceed 7862400.
        /// </summary>
        public int? DuplicateSeconds { get; set; }

        /// <summary>
        /// 3-D Secure verification data
        /// </summary>
        public ThreeDSecure ThreeDSecure { get; set; }

        /// <summary>
        /// Installment Billing information
        /// </summary>
        public InstallmentBillingData InstallmentBilling { get; set; }

        /// <summary>
        /// Partial payments parameters
        /// </summary>
        public PartialPayment PartialPayment { get; set; }

        /// <summary>
        /// Payment Facilitator Specific Fields
        /// </summary>
        public PaymentFacilitator PaymentFacilitator { get; set; }


        public Billing Billing { get; set; }

        /// <summary>
        /// Shipping information
        /// </summary>
        public Shipping Shipping { get; set; }

        public Order Order { get; set; }


        public StepOneTransactionRequest(string securityKey, string redirectUrl, TransactionType type) : base(
            securityKey, redirectUrl)
        {
            Type = type;
        }

        public XDocument ToXml()
        {
            // Creating XML document with mandatory parameters
            var xml = new XDocument(
                new XDeclaration("1.0", "UTF-8", "yes")
            );

            var transactionElement = new XElement(TransactionTypeUtils.ToString(Type));
            var baseElements = ToXmlElements();
            foreach (var element in baseElements)
            {
                transactionElement.Add(element);
            }

            if (Industry != null) transactionElement.Add(new XElement("industry", IndustryClassificationUtils.ToString(Industry)));
            if (!string.IsNullOrEmpty(ProcessorId)) transactionElement.Add(new XElement("processor-id", ProcessorId));
            if (!string.IsNullOrEmpty(CustomerVaultId)) transactionElement.Add(new XElement("customer-vault-id", CustomerVaultId));
            if (!string.IsNullOrEmpty(CustomerId)) transactionElement.Add(new XElement("customer-id", CustomerId));
            if (!string.IsNullOrEmpty(MerchantReceiptEmail)) transactionElement.Add(new XElement("merchant-receipt-email", MerchantReceiptEmail));
            if (!string.IsNullOrEmpty(SignatureImage)) transactionElement.Add(new XElement("signature-image", SignatureImage));
            if (SecCode != null) transactionElement.Add(new XElement("sec-code", StandardEntryClassCodeUtils.ToString(SecCode)));
            if (Amount != null) transactionElement.Add(new XElement("amount", Amount?.ToString("F2")));
            if (Surcharge != null) transactionElement.Add(new XElement("surcharge-amount", Surcharge?.ToString("F2")));
            if (!string.IsNullOrEmpty(Currency)) transactionElement.Add(new XElement("currency", Currency));
            if (PaymentDescriptor != null)
            {
                foreach (var element in PaymentDescriptor.ToXmlElements())
                {
                    transactionElement.Add(element);
                }
            }
            if (StoredCredentialsIndicatorParameters != null)
            {
                foreach (var element in StoredCredentialsIndicatorParameters.ToXmlElements())
                {
                    transactionElement.Add(element);
                }
            }
            if (!string.IsNullOrEmpty(AuthorizationCode)) transactionElement.Add(new XElement("authorization-code", AuthorizationCode));
            if (DuplicateSeconds != null) transactionElement.Add(new XElement("duplicate-seconds", DuplicateSeconds.ToString()));
            if (ThreeDSecure != null)
            {
                var threeDSecureElements = ThreeDSecure.ToXmlElements();
                foreach (var element in threeDSecureElements)
                {
                    transactionElement.Add(element);
                }
            }
            if (InstallmentBilling != null)
            {
                foreach (var element in InstallmentBilling.ToXmlElements())
                {
                    transactionElement.Add(element);
                }
            }
            if (PartialPayment != null)
            {
                foreach (var element in PartialPayment.ToXmlElements())
                {
                    transactionElement.Add(element);
                }
            }
            if (PaymentFacilitator != null)
            {
                foreach (var element in PaymentFacilitator.ToXmlElements())
                {
                    transactionElement.Add(element);
                }
            }
            if (Shipping != null)
            {
                foreach (var element in Shipping.ToXmlElements())
                {
                    transactionElement.Add(element);
                }
            }
            if (Billing != null) transactionElement.Add(Billing.ToXmlElement());
            
            if (Order != null)
            {
                foreach (var element in Order.ToXmlElements())
                {
                    transactionElement.Add(element);
                }
            }

            xml.Add(transactionElement);

            return xml;
        }
    }
}