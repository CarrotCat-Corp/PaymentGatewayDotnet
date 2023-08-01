using System;

namespace PaymentGatewayDotnet.Exceptions
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