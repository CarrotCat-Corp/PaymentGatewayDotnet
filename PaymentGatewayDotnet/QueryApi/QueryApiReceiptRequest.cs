using System.Collections.Generic;
using PaymentGatewayDotnet.Contracts;

namespace PaymentGatewayDotnet.QueryApi
{
    public class QueryApiReceiptRequest: IQueryApiReceiptRequest
    {
        public string SecurityKey { get; private set; }
        
        public string TransactionId { get; private set; }

        public QueryApiReceiptRequest(string securityKey, string transactionId)
        {
            TransactionId = transactionId;
            SecurityKey = securityKey;
        }

        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            return new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("transaction_id", TransactionId) };

        }

    }
}