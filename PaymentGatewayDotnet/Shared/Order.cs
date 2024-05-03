using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using PaymentGatewayDotnet.Utilities;

namespace PaymentGatewayDotnet.Shared
{
    public sealed class Order
    {
        /// <summary>
        /// Order ID. This can be used to hold invoice ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Purchase order date. Defaults to the date of the transaction.
        /// </summary>
        public DateTime? OrderDate { get; set; }

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
        public IEnumerable<Item> Items { get; set; }


        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            var list = new List<KeyValuePair<string, string>>();

            if (Id != null) list.Add(new KeyValuePair<string, string>("orderid", Id));
            if (Description != null) list.Add(new KeyValuePair<string, string>("order_description", Description));
            if (TemplateId != null) list.Add(new KeyValuePair<string, string>("order_template", TemplateId));
            if (PoNumber != null) list.Add(new KeyValuePair<string, string>("ponumber", PoNumber));
            if (TaxAmount != null) list.Add(new KeyValuePair<string, string>("tax", TaxAmount?.ToString("F2")));
            if (DiscountAmount != null)
                list.Add(new KeyValuePair<string, string>("discount_amount", DiscountAmount?.ToString("F2")));
            if (SummaryCommodityCode != null)
                list.Add(new KeyValuePair<string, string>("summary_commodity_code", SummaryCommodityCode));
            if (DutyAmount != null)
                list.Add(new KeyValuePair<string, string>("duty_amount", DutyAmount?.ToString("F2")));
            if (NationalTaxAmount != null)
                list.Add(new KeyValuePair<string, string>("national_tax_amount", NationalTaxAmount?.ToString("F2")));
            if (VatTaxAmount != null)
                list.Add(new KeyValuePair<string, string>("vat_tax_amount", VatTaxAmount?.ToString("F2")));
            if (VatTaxRate != null)
                list.Add(new KeyValuePair<string, string>("vat_tax_rate", VatTaxRate?.ToString("F2")));
            if (MerchantVatRegistration != null)
                list.Add(new KeyValuePair<string, string>("merchant_vat_registration", MerchantVatRegistration));
            if (CustomerVatRegistration != null)
                list.Add(new KeyValuePair<string, string>("customer_vat_registration", CustomerVatRegistration));
            if (VatInvoiceReferenceNumber != null)
                list.Add(new KeyValuePair<string, string>("vat_invoice_reference_number", VatInvoiceReferenceNumber));
            if (AlternateTaxId != null) list.Add(new KeyValuePair<string, string>("alternate_tax_id", AlternateTaxId));
            if (AlternateTaxAmount != null)
                list.Add(new KeyValuePair<string, string>("alternate_tax_amount", AlternateTaxAmount?.ToString("F2")));
            
            if (Items?.Any() == true)
            {
                var i = 0; // starting with 0
                foreach (var item in Items)
                {
                    i++; // adding one before action, so the start index would be 1
                    list.AddRange(item.ToKeyValuePairs(i));
                }
            }
            return list;
        }

        public IEnumerable<XElement> ToXmlElements()
        {
            if (Id != null)
                yield return new XElement("order-id", Id);

            if (OrderDate != null) 
                yield return new XElement("order-date", OrderDate?.ToString("YYMMdd"));
            
            if (Description != null) 
                yield return new XElement("order-description", Description);
            
            if (TemplateId != null) 
                yield return new XElement("order-template", TemplateId);
            
            if (PoNumber != null) 
                yield return new XElement("po-number", PoNumber);
            
            if (TaxAmount != null) 
                yield return new XElement("tax-amount", TaxAmount?.ToString("F2"));
            
            if (DiscountAmount != null)
                yield return new XElement("discount-amount", DiscountAmount?.ToString("F2"));
            
            if (SummaryCommodityCode != null)
                yield return new XElement("summary-commodity-code", SummaryCommodityCode);
            
            if (DutyAmount != null) 
                yield return new XElement("duty-amount", DutyAmount?.ToString("F2"));
            
            if (NationalTaxAmount != null)
                yield return new XElement("national-tax-amount", NationalTaxAmount?.ToString("F2"));
            
            if (VatTaxAmount != null) 
                yield return new XElement("vat-tax-amount", VatTaxAmount?.ToString("F2"));
            
            if (VatTaxRate != null) 
                yield return new XElement("vat-tax-rate", VatTaxRate?.ToString("F2"));
            
            if (MerchantVatRegistration != null)
                yield return new XElement("merchant-vat-registration", MerchantVatRegistration);
            
            if (CustomerVatRegistration != null)
                yield return new XElement("customer-vat-registration", CustomerVatRegistration);
            
            if (VatInvoiceReferenceNumber != null)
                yield return new XElement("vat-invoice-reference-number", VatInvoiceReferenceNumber);
            
            if (AlternateTaxId != null) 
                yield return new XElement("alternate-tax-id", AlternateTaxId);
            
            if (AlternateTaxAmount != null)
                yield return new XElement("alternate-tax-amount", AlternateTaxAmount?.ToString("F2"));

            if (Items != null)
            {
                foreach (var item in Items)
                {
                    yield return item.ToXmlElement();
                }
            }
        }


        public static Order FromXmlElement(XElement element)
        {
            if (element == null) return null;
            var order = new Order
            {
                Id = XmlUtilities.XElementToString(element.Element("order-id")),
                
                OrderDate = XmlUtilities.XElementToDateTime(element.Element("order-date"),"YYMMdd"),
                
                Description = XmlUtilities.XElementToString(element.Element("order-description")),
                
                TemplateId = XmlUtilities.XElementToString(element.Element("order-template")),
                
                PoNumber = XmlUtilities.XElementToString(element.Element("po-number")),
                
                TaxAmount = XmlUtilities.XElementToDecimal(element.Element("tax-amount")),
                
                DiscountAmount = XmlUtilities.XElementToDecimal(element.Element("discount-amount")),
                
                SummaryCommodityCode = XmlUtilities.XElementToString(element.Element("summary-commodity-code")),
                
                DutyAmount = XmlUtilities.XElementToDecimal(element.Element("duty-amount")),
                
                NationalTaxAmount = XmlUtilities.XElementToDecimal(element.Element("national-tax-amount")),
                
                VatTaxAmount = XmlUtilities.XElementToDecimal(element.Element("vat-tax-amount")),
                
                VatTaxRate = XmlUtilities.XElementToDecimal(element.Element("vat-tax-rate")),
                
                MerchantVatRegistration = XmlUtilities.XElementToString(element.Element("merchant-vat-registration")),
                
                CustomerVatRegistration = XmlUtilities.XElementToString(element.Element("customer-vat-registration")),
                
                VatInvoiceReferenceNumber = XmlUtilities.XElementToString(element.Element("vat-invoice-reference-number")),
                
                AlternateTaxId = XmlUtilities.XElementToString(element.Element("alternate-tax-id")),
                
                AlternateTaxAmount = XmlUtilities.XElementToDecimal(element.Element("alternate-tax-amount")),
                
                Items = element.Elements("product").Select(Item.FromXmlElement)
            };
            
            return order;
        }
    }
}