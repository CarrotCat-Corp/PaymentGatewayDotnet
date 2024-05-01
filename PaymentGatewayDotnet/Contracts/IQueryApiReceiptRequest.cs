using System.Collections.Generic;

namespace PaymentGatewayDotnet.Contracts
{
    public interface IQueryApiReceiptRequest:IBaseApiRequest
    {
        string TransactionId { get; }
        IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs();
    }
}