using System;

namespace PaymentGatewayDotnet.Exceptions
{
    public sealed class InvalidArgumentException: Exception
    {
        public string ParameterName { get;}

        public InvalidArgumentException(string parameterName, string message):base(message)
        {
            ParameterName = parameterName;
        }
    }
}