using System;
using System.Collections.Generic;
using PaymentGatewayDotnet.Model.Shared;

namespace PaymentGatewayDotnet.Model.PaymentApi.RecurringRequests
{
    public sealed class RecurringSubscriptionRequest
    {
        /// <summary>
        /// The subscription ID that will be updated.
        /// </summary>
        public string Id { get; set; }
        
        public RecurringAction Action { get; set; }
        
        /// <summary>
        /// The plan ID of the plan that the subscription will be associated with.
        /// </summary>
        public string PlanId { get; set; }
        
        /// <summary>
        /// The first day that the customer will be charged.
        /// Note: only date will be taken, time will be ignored
        /// </summary>
        public DateTime StartDate { get; set; }
        
        /// <summary>
        /// If set to true, when the customer is charged, they will be sent a transaction receipt.
        /// </summary>
        public bool CustomerReceipt { get; set; }
        
        /// <summary>
        /// Specifies a payment gateway transaction id in order to associate payment information with a Subscription or Customer Vault record. Must be set with a 'recurring' or 'customer_vault' action.
        /// </summary>
        public string SourceTransactionId { get; set; }
        
        /// <summary>
        /// Payment Credentials
        /// </summary>
        public PaymentCredentials PaymentCredentials { get; set; }
        
        
        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            var list = new List<KeyValuePair<string, string>>();

            if (Id != null) list.Add(new KeyValuePair<string, string>("subscription_id", Id));
            if (Action != null) list.Add(new KeyValuePair<string, string>("recurring", RecurringActionUtils.ToString(Action)));
            if (PlanId != null) list.Add(new KeyValuePair<string, string>("plan_id", PlanId));
            if (StartDate != null) list.Add(new KeyValuePair<string, string>("start_date", StartDate.ToString("yyyyMMdd")));
            if (CustomerReceipt != null) list.Add(new KeyValuePair<string, string>("customer_receipt", CustomerReceipt.ToString()));
            if (SourceTransactionId != null) list.Add(new KeyValuePair<string, string>("customer_receipt", SourceTransactionId));
            
            if (PaymentCredentials != null) list.AddRange(PaymentCredentials.ToKeyValuePairs());

            return list;
        }
    }
}