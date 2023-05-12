using System.Collections.Generic;

namespace PaymentGatewayDotnet.Model
{
    public interface IPaymentApiRequest
    {
        IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs();
    }
}