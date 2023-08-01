using System.Collections.Generic;

namespace PaymentGatewayDotnet.PaymentApi.Data
{
    public sealed class PaymentFacilitator
    {
        /// <summary>
        /// Payment Facilitator/Aggregator/ISO's ID Number
        /// Required fields for Payment Facilitator enabled transactions vary by card brand
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Sub-merchant Account ID
        /// </summary>
        public string SubMerchantId { get; set; }
        
        
        public string SubMerchantEmail { get; set; }
        
        
        public string SubMerchantPhone { get; set; }
        
        
        public string SubMerchantPostal { get; set; }
        
        
        public string SubMerchantName { get; set; }
        
        
        public string SubMerchantAddress { get; set; }
        
        
        public string SubMerchantCity { get; set; }
        
        
        public string SubMerchantState { get; set; }
        
        
        public string SubMerchantCountry { get; set; }
        
        
        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            var list = new List<KeyValuePair<string, string>>();
            if (Id != null) list.Add(new KeyValuePair<string, string>("payment_facilitator_id", Id));
            if (SubMerchantId != null) list.Add(new KeyValuePair<string, string>("submerchant_id", SubMerchantId));
            if (SubMerchantEmail != null) list.Add(new KeyValuePair<string, string>("submerchant_name", SubMerchantEmail));
            if (SubMerchantPhone != null) list.Add(new KeyValuePair<string, string>("submerchant_address", SubMerchantPhone));
            if (SubMerchantPostal != null) list.Add(new KeyValuePair<string, string>("submerchant_city", SubMerchantPostal));
            if (SubMerchantName != null) list.Add(new KeyValuePair<string, string>("submerchant_state", SubMerchantName));
            if (SubMerchantAddress != null) list.Add(new KeyValuePair<string, string>("submerchant_postal", SubMerchantAddress));
            if (SubMerchantCity != null) list.Add(new KeyValuePair<string, string>("submerchant_country", SubMerchantCity));
            if (SubMerchantState != null) list.Add(new KeyValuePair<string, string>("submerchant_phone", SubMerchantState));
            if (SubMerchantCountry != null) list.Add(new KeyValuePair<string, string>("submerchant_email", SubMerchantCountry));

            return list;
        }
    }
}