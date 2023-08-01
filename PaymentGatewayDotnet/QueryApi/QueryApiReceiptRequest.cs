using System.Collections.Generic;
using PaymentGatewayDotnet.Contracts;

namespace PaymentGatewayDotnet.QueryApi
{
    public class QueryApiReceiptRequest: IQueryApiReceiptRequest
    {
        public string TransactionId { get; set; }
        
        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            return new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("transaction_id", TransactionId) };

        }

    }
}