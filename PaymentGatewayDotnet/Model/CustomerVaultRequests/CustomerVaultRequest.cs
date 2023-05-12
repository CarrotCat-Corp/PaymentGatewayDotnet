using System.Collections.Generic;
using System.Linq;
using PaymentGatewayDotnet.Model.Shared;
using PaymentGatewayDotnet.Model.StoredCredentials;

namespace PaymentGatewayDotnet.Model.CustomerVaultRequests
{
    public sealed class CustomerVaultRequest:PaymentApiRequest, IPaymentApiRequest
    {
        public CustomerVaultRequest(string securityKey) : base(securityKey)
        {
        }
        
        /// <summary>
        /// Specifies a Customer Vault id. If not set, the payment gateway will randomly generate a Customer Vault id.
        /// </summary>
        public string CustomerVaultId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public CustomerVaultAction Action { get; set; }
        
        /// <summary>
        /// Billing id to be assigned or updated. If none is provided, one will be created or the billing id with priority '1' will be updated.
        /// </summary>
        public string BillingId { get; set; }
        
        /// <summary>
        /// Specifies a payment gateway transaction id in order to associate payment information with a Subscription or Customer Vault record. Must be set with a 'recurring' or 'customer_vault' action.
        /// </summary>
        public string SourceTransactionId { get; set; }
        
        /// <summary>
        /// If set to true, credit card will be evaluated and sent based upon Automatic Card Updater settings. If set to false, credit card will not be submitted for updates when Automatic Card Updater runs.
        /// </summary>
        public bool AutomaticCardUpdaterEnabled { get; set; }
        
        /// <summary>
        /// The type of payment
        /// </summary>
        public PaymentType Payment { get; set; }
        
        /// <summary>
        /// Shipping Information
        /// </summary>
        public Shipping Shipping { get; set; }
        
        /// <summary>
        /// Payment Credentials
        /// </summary>
        public PaymentCredentials PaymentCredentials { get; set; }
        
        /// <summary>
        /// SStored Credentials
        /// </summary>
        public StoredCredentialsIndicatorParameters StoredCredentialsIndicatorParameters { get; set; }
        
        
        
        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            var list = new List<KeyValuePair<string, string>>();
            
            list.AddRange(base.ToKeyValuePairs());
            
            if (CustomerVaultId != null) list.Add(new KeyValuePair<string, string>("customer_vault_id", CustomerVaultId));
            if (Action != null) list.Add(new KeyValuePair<string, string>("customer_vault", CustomerVaultActionUtils.ToString(Action)));
            if (BillingId != null) list.Add(new KeyValuePair<string, string>("customer_vault", BillingId));
            if (SourceTransactionId != null) list.Add(new KeyValuePair<string, string>("source_transaction_id", SourceTransactionId));
            if (AutomaticCardUpdaterEnabled != null) list.Add(new KeyValuePair<string, string>("acu_enabled", AutomaticCardUpdaterEnabled.ToString().ToLower()));
            if (Payment != null) list.Add(new KeyValuePair<string, string>("payment", PaymentTypeUtils.ToString(Payment)));

            list.AddRange(Shipping.ToKeyValuePairs());
            list.AddRange(PaymentCredentials.ToKeyValuePairs());
            list.AddRange(StoredCredentialsIndicatorParameters.ToKeyValuePairs());

            return list;
        }
        
    }
}