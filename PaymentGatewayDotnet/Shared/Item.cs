using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using PaymentGatewayDotnet.Utilities;

namespace PaymentGatewayDotnet.Shared
{
    public sealed class Item
    {
        /// <summary>
        /// Merchant defined description code of the item being purchased.
        /// </summary>
        public string ProductCode { get; set; }
        
        /// <summary>
        /// Description of the item(s) being supplied.
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// International description code of the individual good or service being supplied. The acquirer or processor will provide a list of current codes.
        /// </summary>
        public string CommodityCode { get; set; }
        
        /// <summary>
        /// Code for units of measurement as used in international trade.
        /// Default: 'EACH'
        /// </summary>
        public string UnitOfMeasure { get; set; }
        
        /// <summary>
        /// Unit cost of item purchased, may contain up to 4 decimal places.
        /// </summary>
        public decimal? UnitCost { get; set; }
        
        /// <summary>
        /// Quantity of the item(s) being purchased.
        /// Default: '1'
        /// </summary>
        public decimal? Quantity { get; set; }
        
        /// <summary>
        /// Purchase amount associated with the item. Defaults to: 'item_unit_cost_#' x 'item_quantity_#' rounded to the nearest penny. 
        /// </summary>
        public decimal? TotalAmount { get; set; }
        
        /// <summary>
        /// Amount of sales tax on specific item. Amount should not be included in 'total_amount_#'.
        /// Default: '0.00'
        /// </summary>
        public decimal? TaxAmount { get; set; }
        
        /// <summary>
        /// Percentage representing the value-added tax applied.
        /// Default: '0.00'
        /// </summary>
        public decimal? TaxRate { get; set; }
        
        /// <summary>
        /// Discount amount which can have been applied by the merchant on the sale of the specific item. Amount should not be included in 'total_amount_#'.
        /// </summary>
        public decimal? DiscountAmount { get; set; }
        
        /// <summary>
        /// Discount rate for the line item. 1% = 1.00.
        /// </summary>
        public decimal? DiscountRate { get; set; }
        
        /// <summary>
        /// Type of value-added taxes that are being used.
        /// </summary>
        public string TaxType { get; set; }
        
        /// <summary>
        /// Tax identification number of the merchant that reported the alternate tax amount.
        /// </summary>
        public string AlternateTaxId { get; set; }
        
        
        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs(int itemNumber)
        {
            var item = itemNumber.ToString();

            if (ProductCode!=null) yield return new KeyValuePair<string, string>("item_product_code_"+item, ProductCode);
            if (Description != null) yield return new KeyValuePair<string, string>("item_description_" + item, Description);
            if (CommodityCode!=null) yield return new KeyValuePair<string, string>("item_commodity_code_"+item, CommodityCode);
            if (UnitOfMeasure!=null) yield return new KeyValuePair<string, string>("item_unit_of_measure_"+item, UnitOfMeasure);
            if (UnitCost!=null) yield return new KeyValuePair<string, string>("item_unit_cost_"+item, UnitCost?.ToString("F2"));
            if (Quantity!=null) yield return new KeyValuePair<string, string>("item_quantity_"+item, Quantity?.ToString("F2"));
            if (TotalAmount!=null) yield return new KeyValuePair<string, string>("item_total_amount_"+item, TotalAmount?.ToString("F2"));
            if (TaxAmount!=null) yield return new KeyValuePair<string, string>("item_tax_amount_"+item, TaxAmount?.ToString("F2"));
            if (TaxRate!=null) yield return new KeyValuePair<string, string>("item_tax_rate_"+item, TaxRate?.ToString("F2"));
            if (DiscountAmount!=null) yield return new KeyValuePair<string, string>("item_discount_amount_"+item, DiscountAmount?.ToString("F2"));
            if (DiscountRate!=null) yield return new KeyValuePair<string, string>("item_discount_rate_"+item, DiscountRate?.ToString("F2"));
            if (TaxType!=null) yield return new KeyValuePair<string, string>("item_tax_type_"+item, TaxType);
            if (AlternateTaxId!=null) yield return new KeyValuePair<string, string>("item_alternate_tax_id_"+item, AlternateTaxId);
        }
        
        public static IEnumerable<Item> FromXmlElements(IEnumerable<XElement> productElements) => productElements.Select(FromXmlElement);
        

        public static Item FromXmlElement(XElement element)
        {
            return new Item
            {
                ProductCode = XmlUtilities.XElementToString(element.Element("product-code")),
                Description = XmlUtilities.XElementToString(element.Element("description")),
                CommodityCode = XmlUtilities.XElementToString(element.Element("commodity-code")),
                UnitOfMeasure = XmlUtilities.XElementToString(element.Element("unit-of-measure")),
                UnitCost = XmlUtilities.XElementToDecimal(element.Element("unit-cost")), 
                Quantity = XmlUtilities.XElementToDecimal(element.Element("quantity")), 
                TotalAmount = XmlUtilities.XElementToDecimal(element.Element("total-amount")),
                TaxAmount = XmlUtilities.XElementToDecimal(element.Element("tax-amount")), 
                TaxRate = XmlUtilities.XElementToDecimal(element.Element("tax-rate")), 
                DiscountAmount = XmlUtilities.XElementToDecimal(element.Element("discount-amount")), 
                DiscountRate = XmlUtilities.XElementToDecimal(element.Element("discount-rate")),
                TaxType = XmlUtilities.XElementToString(element.Element("tax-type")),
                AlternateTaxId = XmlUtilities.XElementToString(element.Element("alternate-tax-id")),
            };
        }
        
        public XElement ToXmlElement()
        {
            var element = new XElement("product");
            if (ProductCode != null) element.Add(new XElement("product-code", ProductCode));
            if (Description != null) element.Add(new XElement("description", Description));
            if (CommodityCode != null) element.Add(new XElement("commodity-code", CommodityCode));
            if (UnitOfMeasure != null) element.Add(new XElement("unit-of-measure", UnitOfMeasure));
            if (UnitCost != null) element.Add(new XElement("unit-cost", UnitCost?.ToString("F2")));
            if (Quantity != null) element.Add(new XElement("quantity", Quantity?.ToString("F2")));
            if (TotalAmount != null) element.Add(new XElement("total-amount", TotalAmount?.ToString("F2")));
            if (TaxAmount != null) element.Add(new XElement("tax-amount", TaxAmount?.ToString("F2")));
            if (TaxRate != null) element.Add(new XElement("tax-rate", TaxRate?.ToString("F2")));
            if (DiscountAmount != null) element.Add(new XElement("discount-amount", DiscountAmount?.ToString("F2")));
            if (DiscountRate != null) element.Add(new XElement("discount-rate", DiscountRate?.ToString("F2")));
            if (TaxType != null) element.Add(new XElement("tax-type", TaxType));
            if (AlternateTaxId != null) element.Add(new XElement("alternate-tax-id", AlternateTaxId));

            return element;
        }
    }
}