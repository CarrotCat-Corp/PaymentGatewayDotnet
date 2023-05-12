using System;
using System.Collections.Generic;
using System.Linq;
using PaymentGatewayDotnet.Model.Shared;


namespace PaymentGatewayDotnet.Model
{
    public class PaymentApiRequest
    {
        /// <summary>
        /// API Security Key assigned to a merchant account.
        /// New keys can be generated from the merchant control panel in Settings > Security Keys
        /// </summary>
        public string SecurityKey { get; set; }


        public Order Order { get; set; }

        public Billing Billing { get; set; }

        /// <summary>
        /// The transaction currency. Format: ISO 4217
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// IP address of cardholder, this field is recommended.
        /// Format: xxx.xxx.xxx.xxx
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// If using Multiple MIDs, route to this processor (processor_id is obtained under Settings → Transaction Routing in the Control Panel).
        /// </summary>
        public string ProcessorId { get; set; }

        /// <summary>
        /// List of merchant defined fields.
        /// Note: Gateway supports fields with numbers inclusively between 1 and 20. 
        /// </summary>
        public List<MerchantDefinedField> MerchantDefinedFields { get; set; }


        /// <summary>
        /// One-off test transactions can be processed using the below test_mode variable. This will process this singular transaction in test mode, but it will not impact anything else on the account. An example use case would be running test transactions in a developent environment while your website is actively processing real transactions from customers.
        /// <br/><br/>
        /// If set to "true" and providing one of the test credit card numbers, the single transaction will process in test mode. To see this transaction in reporting, you will need to toggle your account to test mode, but the Payment API testing can be done without doing this. 
        /// </summary>
        public bool? TestMode { get; set; }

        public PaymentApiRequest(string securityKey)
        {
            SecurityKey = securityKey ?? throw new ArgumentNullException(nameof(securityKey));
        }

        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            var list = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("security_key", SecurityKey)
            };

            if (Currency != null) list.Add(new KeyValuePair<string, string>("currency", Currency));
            if (IpAddress != null) list.Add(new KeyValuePair<string, string>("ipaddress", IpAddress));
            if (ProcessorId != null) list.Add(new KeyValuePair<string, string>("processor_id", ProcessorId));

            if (Order != null) list.AddRange(Order.ToKeyValuePairs());
            if (Billing != null) list.AddRange(Billing.ToKeyValuePairs());
            if (Order != null) list.AddRange(Order.ToKeyValuePairs());
            if (Order != null) list.AddRange(Order.ToKeyValuePairs());

            if (TestMode == true) list.Add(new KeyValuePair<string, string>("test_mode", "enabled"));

            if (MerchantDefinedFields is null || MerchantDefinedFields.Count <= 0) return list;

            list.AddRange(MerchantDefinedFields.Select(mdf => mdf.ToKeyValuePair()));

            return list;
        }
    }
}