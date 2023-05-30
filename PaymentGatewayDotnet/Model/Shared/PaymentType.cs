namespace PaymentGatewayDotnet.Model.Shared
{
    public enum PaymentType
    {
        Undefined,
        CreditCard,
        Check,
        Cash
    }

    public static class PaymentTypeUtils
    {
        public static PaymentType ParseString(string value)
        {
            switch (value?.ToLower())
            {
                case "creditcard": return PaymentType.CreditCard;
                case "check": return PaymentType.Check;
                case "cash": return PaymentType.Cash;
                case "cc": return PaymentType.CreditCard;
                case "ck": return PaymentType.Check;
                case "cs": return PaymentType.Cash;
                default: return PaymentType.Undefined;
            }
        }
        
        public static string ToString(PaymentType? value)
        {
            switch (value)
            {
                case PaymentType.CreditCard: return "creditcard";
                case PaymentType.Check: return "check";
                case PaymentType.Cash: return "cash";
                default: return "";
            }
        }
        
        public static string ToShortString(PaymentType? value)
        {
            switch (value)
            {
                case PaymentType.CreditCard: return "cc";
                case PaymentType.Check: return "ck";
                case PaymentType.Cash: return "cs";
                default: return "";
            }
        }
    }
}