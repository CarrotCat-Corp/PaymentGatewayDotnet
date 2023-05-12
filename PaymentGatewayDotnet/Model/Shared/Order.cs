using System.Collections.Generic;
using System.Linq;
using PaymentGatewayDotnet.Model.RetailDevises;

namespace PaymentGatewayDotnet.Model.Shared
{
    public sealed class Order
    {
        /// <summary>
        /// Order ID. This can be used to hold invoice ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Order description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Order template ID.
        /// </summary>
        public string TemplateId { get; set; }

        /// <summary>
        /// Original purchase order.
        /// </summary>
        public string PoNumber { get; set; }

        public decimal? TaxAmount { get; set; }
        public decimal? DiscountAmount { get; set; }

        public string SummaryCommodityCode { get; set; }
        public decimal? DutyAmount { get; set; }
        public decimal? NationalTaxAmount { get; set; }
        public decimal? VatTaxAmount { get; set; }
        public decimal? VatTaxRate { get; set; }
        public string MerchantVatRegistration { get; set; }
        public string CustomerVatRegistration { get; set; }
        public string VatInvoiceReferenceNumber { get; set; }
        public string AlternateTaxId { get; set; }
        public decimal? AlternateTaxAmount { get; set; }
        public IList<Item> Items { get; set; }


        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            var list = new List<KeyValuePair<string, string>>();

            if (Id != null) list.Add(new KeyValuePair<string, string>("orderid", Id));
            if (Description != null) list.Add(new KeyValuePair<string, string>("order_description", Description));
            if (TemplateId != null) list.Add(new KeyValuePair<string, string>("order_template", TemplateId));
            if (PoNumber != null) list.Add(new KeyValuePair<string, string>("ponumber", PoNumber));
            if (TaxAmount != null) list.Add(new KeyValuePair<string, string>("tax", TaxAmount?.ToString("F2")));
            if (DiscountAmount != null) list.Add(new KeyValuePair<string, string>("discount_amount", DiscountAmount?.ToString("F2")));
            if (SummaryCommodityCode != null) list.Add(new KeyValuePair<string, string>("summary_commodity_code", SummaryCommodityCode));
            if (DutyAmount != null) list.Add(new KeyValuePair<string, string>("duty_amount", DutyAmount?.ToString("F2")));
            if (NationalTaxAmount != null) list.Add(new KeyValuePair<string, string>("national_tax_amount", NationalTaxAmount?.ToString("F2")));
            if (VatTaxAmount != null) list.Add(new KeyValuePair<string, string>("vat_tax_amount", VatTaxAmount?.ToString("F2")));
            if (VatTaxRate != null) list.Add(new KeyValuePair<string, string>("vat_tax_rate", VatTaxRate?.ToString("F2")));
            if (MerchantVatRegistration != null) list.Add(new KeyValuePair<string, string>("merchant_vat_registration", MerchantVatRegistration));
            if (CustomerVatRegistration != null) list.Add(new KeyValuePair<string, string>("customer_vat_registration", CustomerVatRegistration));
            if (VatInvoiceReferenceNumber != null)list.Add(new KeyValuePair<string, string>("vat_invoice_reference_number", VatInvoiceReferenceNumber));
            if (AlternateTaxId != null) list.Add(new KeyValuePair<string, string>("alternate_tax_id", AlternateTaxId));
            if (AlternateTaxAmount != null) list.Add(new KeyValuePair<string, string>("alternate_tax_amount", AlternateTaxAmount?.ToString("F2")));

            if (Items is null || Items.Count <= 0) return list;

            for (var i = 0; i < Items.Count; i++)
            {
                list.AddRange(Items[i].ToKeyValuePairs(i+1));
            }

            return list;
        }
    }
}