namespace PaymentGatewayDotnet.Shared.Enums
{
    public enum AccountHolderType
    {
        Undefined,
        Business,
        Personal
    }
    
    public static class AccountHolderTypeUtils
    {
        public static AccountHolderType ParseString(string value)
        {
            switch (value?.ToLower())
            {
                case "business": return AccountHolderType.Business;
                case "personal": return AccountHolderType.Personal;
                default: return AccountHolderType.Undefined;
            }
        }
        
        public static string ToString(AccountHolderType? value)
        {
            switch (value)
            {
                case AccountHolderType.Business: return "business";
                case AccountHolderType.Personal: return "personal";
                default: return "";
            }
        }
    }
}