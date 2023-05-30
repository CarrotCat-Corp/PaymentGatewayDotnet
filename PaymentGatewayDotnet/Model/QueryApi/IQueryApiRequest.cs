using System.Collections.Generic;

namespace PaymentGatewayDotnet.Model
{
    public interface IQueryApiRequest
    {
        IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs();
    }
}