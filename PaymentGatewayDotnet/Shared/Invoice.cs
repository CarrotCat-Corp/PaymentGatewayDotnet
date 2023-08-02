using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using PaymentGatewayDotnet.Shared.Enums;
using PaymentGatewayDotnet.Utilities;

namespace PaymentGatewayDotnet.Shared
{
    public class Invoice
    {
        public string Id { get; set; }

        /// <summary>
        /// Total amount to be invoiced. Must be greater than 0.00.
        /// </summary>
        public decimal Amount { get; set; }
        
        /// <summary>
        /// The transaction currency. Format: ISO 4217
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Total sales tax amount.
        /// </summary>
        public decimal? Tax { get; set; }

        /// <summary>
        /// When the invoice should be paid
        /// Values: 'upon_receipt'(-1), or integers from 0-999.
        /// Default: 'upon_receipt'
        /// To set value to "upon_request" set PaymentTerms to any negative integer
        /// </summary>
        public int? PaymentTerms { get; set; }

        public string OrderDescription { get; set; }

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
        public Billing Billing { get; set; }
        
        public Order Order { get; set; }

        public string Status { get; private set; }
        public decimal? PaymentsApplied { get; private set; }
        
        
        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            var list = new List<KeyValuePair<string, string>>();

            if (Id != null) list.Add(new KeyValuePair<string, string>("invoice_id", Id));
            if (Amount != null) list.Add(new KeyValuePair<string, string>("amount", Amount.ToString("F2")));
            if (Currency != null) list.Add(new KeyValuePair<string, string>("currency", Currency));
            if (Tax != null) list.Add(new KeyValuePair<string, string>("tax", Tax?.ToString("F2")));
            if (Website != null) list.Add(new KeyValuePair<string, string>("website", Website));
            if (OrderDescription != null) list.Add(new KeyValuePair<string, string>("order_description", OrderDescription));
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
                list.Add(new KeyValuePair<string, string>("payment_methods_allowed",
                    string.Join(",", PaymentMethodsAllowed.Select(pm => PaymentTypeUtils.ToShortString(pm)))));
            }

            for (int i = 0; i < Items.Count; i++)
            {
                list.AddRange(Items[i].ToKeyValuePairs(i + 1));
            }

            if (Shipping != null) list.AddRange(Shipping.ToKeyValuePairs());
            if (Billing != null) list.AddRange(Billing.ToKeyValuePairs());
            if (Order != null) list.AddRange(Order.ToKeyValuePairs());
            return list;
        }
        
        public static Invoice FromXmlElement(XElement element)
        {
            if (element is null) return null;
            var invoice = new Invoice
            {
                Id = XmlUtilities.XElementToString(element.Element("invoice_id")),
                Amount = XmlUtilities.XElementToDecimal(element.Element("amount"), "amount") ?? decimal.Zero,
                Currency = XmlUtilities.XElementToString(element.Element("currency")),
                Tax = XmlUtilities.XElementToDecimal(element.Element("tax"), "tax") ?? decimal.Zero,
                PaymentTerms = XmlUtilities.XElementToInt(element.Element("terms"), "terms"),
                Website = XmlUtilities.XElementToString(element.Element("website")),
                OrderDescription = XmlUtilities.XElementToString(element.Element("order_description")),
                CustomerId = XmlUtilities.XElementToString(element.Element("customer_id")),
                CustomerTaxId = XmlUtilities.XElementToString(element.Element("customer_tax_id")),
                Shipping = Shipping.FromXmlElement(element.Element("shipping")),
                Billing = Billing.FromXmlElement(element.Element("billing")),
                Status = XmlUtilities.XElementToString(element.Element("status")),
                PaymentsApplied = XmlUtilities.XElementToDecimal(element.Element("payments_applied"), "payments_applied") ?? decimal.Zero,
                Items = Item.FromXmlElements(element.Elements("product"))
            };
            
            return invoice;
        }
    }
}