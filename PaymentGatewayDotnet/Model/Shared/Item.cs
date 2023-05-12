using System.Collections.Generic;

namespace PaymentGatewayDotnet.Model.Shared
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
            var list = new List<KeyValuePair<string, string>>();

            if (ProductCode!=null) list.Add(new KeyValuePair<string, string>("item_product_code_"+item, ProductCode));
            if (Description != null) list.Add(new KeyValuePair<string, string>("item_description_" + item, Description));
            if (CommodityCode!=null) list.Add(new KeyValuePair<string, string>("item_commodity_code_"+item, CommodityCode));
            if (UnitOfMeasure!=null) list.Add(new KeyValuePair<string, string>("item_unit_of_measure_"+item, UnitOfMeasure));
            if (UnitCost!=null) list.Add(new KeyValuePair<string, string>("item_unit_cost_"+item, UnitCost?.ToString("F2")));
            if (Quantity!=null) list.Add(new KeyValuePair<string, string>("item_quantity_"+item, Quantity?.ToString("F2")));
            if (TotalAmount!=null) list.Add(new KeyValuePair<string, string>("item_total_amount_"+item, TotalAmount?.ToString("F2")));
            if (TaxAmount!=null) list.Add(new KeyValuePair<string, string>("item_tax_amount_"+item, TaxAmount?.ToString("F2")));
            if (TaxRate!=null) list.Add(new KeyValuePair<string, string>("item_tax_rate_"+item, TaxRate?.ToString("F2")));
            if (DiscountAmount!=null) list.Add(new KeyValuePair<string, string>("item_discount_amount_"+item, DiscountAmount?.ToString("F2")));
            if (DiscountRate!=null) list.Add(new KeyValuePair<string, string>("item_discount_rate_"+item, DiscountRate?.ToString("F2")));
            if (TaxType!=null) list.Add(new KeyValuePair<string, string>("item_tax_type_"+item, TaxType));
            if (AlternateTaxId!=null) list.Add(new KeyValuePair<string, string>("item_alternate_tax_id_"+item, AlternateTaxId));

            return list;
        }
    }
}