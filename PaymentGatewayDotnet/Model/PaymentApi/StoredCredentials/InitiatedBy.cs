namespace PaymentGatewayDotnet.Model.PaymentApi.StoredCredentials
{
    public enum InitiatedBy
    {
        Undefined,
        Customer,
        Merchant
    }
    
    public static class InitiatedByUtils
    {
        public static InitiatedBy ParseString(string value)
        {
            switch (value?.ToLower())
            {
                case "customer": return InitiatedBy.Customer;
                case "merchant": return InitiatedBy.Merchant;
                default: return InitiatedBy.Undefined;
            }
        }
        
        public static string ToString(InitiatedBy? value)
        {
            switch (value)
            {
                case InitiatedBy.Customer: return "customer";
                case InitiatedBy.Merchant: return "merchant";
                default: return "";
            }
        }
    }
}