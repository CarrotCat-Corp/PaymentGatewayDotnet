using System.Collections.Generic;

namespace PaymentGatewayDotnet.Model.PaymentApi
{
    public interface IPaymentApiRequest
    {
        IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs();
    }
}