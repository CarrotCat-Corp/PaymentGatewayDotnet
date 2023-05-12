using System;

namespace PaymentGatewayDotnet.Model
{
    public sealed class InvalidStateException: Exception
    {
        public string ParameterName { get;}

        public InvalidStateException(string parameterName, string message):base(message)
        {
            ParameterName = parameterName;
        }
    }
}