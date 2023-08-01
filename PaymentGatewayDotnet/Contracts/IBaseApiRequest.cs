using System.Collections.Generic;

namespace PaymentGatewayDotnet.Contracts
{
    public interface IBaseApiRequest
    {
        IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs();
    }
}