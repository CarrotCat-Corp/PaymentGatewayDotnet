using System.Collections.Generic;

namespace PaymentGatewayDotnet.Contracts
{
    public interface IQueryApiRequest : IBaseApiRequest
    {
        IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs();
    }
}