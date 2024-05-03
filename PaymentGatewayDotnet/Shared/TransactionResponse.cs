namespace PaymentGatewayDotnet.Shared
{
    public enum TransactionResponse
    {
        Undefined,
        Approved,
        Declined,
        Error
    }


    public static class TransactionResponseUtils
    {
        public static TransactionResponse ParseInt(int? value)
        {
            switch (value)
            {
                case 1:
                    return TransactionResponse.Approved;
                case 2:
                    return TransactionResponse.Declined;
                case 3:
                    return TransactionResponse.Error;
                default:
                    return TransactionResponse.Undefined;
            }
        }
    }
}