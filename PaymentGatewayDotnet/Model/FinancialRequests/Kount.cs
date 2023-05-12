using System.Collections.Generic;

namespace PaymentGatewayDotnet.Model.FinancialRequests
{
    public sealed class Kount
    {
        /// <summary>
        /// A single use session ID used by Kount to link the transaction and Data Collector information together. This ID should be generated every time a payment form is loaded by the cardholder, and be random/unpredictable (do not use sequential IDs). This ID should not be reused within a 30 day period. This can be used with Collect.js or the Payment API when using the Kount DDC with Gateway.js.
        /// Format: alphanumeric, 32 characters required
        /// </summary>
        public string TransactionSessionId { get; set; }
        
        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            var list = new List<KeyValuePair<string, string>>();
            if (TransactionSessionId != null) list.Add(new KeyValuePair<string, string>("transaction_session_id", TransactionSessionId));
            return list;
        }
    }
}