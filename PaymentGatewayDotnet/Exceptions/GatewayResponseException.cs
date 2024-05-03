using System;

namespace PaymentGatewayDotnet.Exceptions
{
    public class GatewayResponseException : Exception
    {
        public GatewayResponseException(string message) : base(message)
        {
        }
    }
}