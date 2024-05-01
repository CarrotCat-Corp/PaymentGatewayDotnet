using System.Collections.Generic;

namespace PaymentGatewayDotnet.Contracts
{
    public interface IPaymentApiRequest : IBaseApiRequest
    {
        IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs();
    }
}