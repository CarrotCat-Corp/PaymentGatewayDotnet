using System;
using System.Collections.Generic;
using System.Linq;
using PaymentGatewayDotnet.Model.Shared;

namespace PaymentGatewayDotnet.Model.InvoicingRequests
{
    public sealed class InvoicingRequest : PaymentApiRequest, IPaymentApiRequest
    {
        public string Id { get; set; }

        /// <summary>
        /// Type of invoicing request
        /// </summary>
        public InvoicingRequestType Type { get; set; }

        /// <summary>
        /// Total amount to be invoiced. Must be greater than 0.00.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Total sales tax amount.
        /// </summary>
        public decimal Tax { get; set; }

        /// <summary>
        /// When the invoice should be paid
        /// Values: 'upon_receipt'(-1), or integers from 0-999.
        /// Default: 'upon_receipt'
        /// To set value to "upon_request" set PaymentTerms to any negative integer
        /// </summary>
        public int? PaymentTerms { get; set; }

        /// <summary>
        /// What payment methods a customer may use when paying invoice.
        /// Defaults to all available payment methods available in your merchant account
        /// </summary>
        public IList<PaymentType> PaymentMethodsAllowed { get; set; }

        /// <summary>
        /// Customer website.
        /// </summary>
        public string Website { get; set; }

        /// <summary>
        /// Customer ID.
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Customer Tax ID.
        /// </summary>
        public string CustomerTaxId { get; set; }

        /// <summary>
        /// Invoice Items
        /// </summary>
        public List<Item> Items { get; set; }

        /// <summary>
        /// Shipping info
        /// </summary>
        public Shipping Shipping { get; set; }


        public InvoicingRequest(string securityKey) : base(securityKey)
        {
        }


        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            var list = new List<KeyValuePair<string, string>>();

            list.AddRange(base.ToKeyValuePairs());

            if (Id != null) list.Add(new KeyValuePair<string, string>("invoice_id", Id));
            if (Type != null) list.Add(new KeyValuePair<string, string>("invoicing", InvoicingRequestTypeUtils.ToString(Type)));
            if (Amount != null) list.Add(new KeyValuePair<string, string>("amount", Amount.ToString("F2")));
            if (Tax != null) list.Add(new KeyValuePair<string, string>("tax", Tax.ToString("F2")));
            if (Website != null) list.Add(new KeyValuePair<string, string>("website", Website));
            if (CustomerId != null) list.Add(new KeyValuePair<string, string>("customer_id", CustomerId));
            if (CustomerTaxId != null) list.Add(new KeyValuePair<string, string>("customer_tax_id", CustomerTaxId));

            if (PaymentTerms != null)
            {
                list.Add(PaymentTerms == -1
                    ? new KeyValuePair<string, string>("payment_terms", "upon_receipt")
                    : new KeyValuePair<string, string>("payment_terms", PaymentTerms.ToString()));
            }

            if (PaymentMethodsAllowed != null && PaymentMethodsAllowed.Count > 0)
            {
                list.Add(new KeyValuePair<string, string>("payment_methods_allowed", string.Join(",", PaymentMethodsAllowed.Select(pm=> PaymentTypeUtils.ToShortString(pm)))));
            }

            for (int i = 0; i < Items.Count; i++)
            {
                list.AddRange(Items[i].ToKeyValuePairs(i + 1));
            }

            if (Shipping != null) list.AddRange(Shipping.ToKeyValuePairs());

            return list;
        }
    }
}