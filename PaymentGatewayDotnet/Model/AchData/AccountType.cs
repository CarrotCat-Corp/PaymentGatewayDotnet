namespace PaymentGatewayDotnet.Model.AchData
{
    public enum AccountType
    {
        Undefined,
        Checking,
        Savings
    }
    
    public static class AccountTypeUtils
    {
        public static AccountType ParseString(string value)
        {
            switch (value?.ToLower())
            {
                case "checking": return AccountType.Checking;
                case "savings": return AccountType.Savings;
                default: return AccountType.Undefined;
            }
        }
        
        public static string ToString(AccountType? value)
        {
            switch (value)
            {
                case AccountType.Checking: return "checking";
                case AccountType.Savings: return "savings";
                default: return "";
            }
        }
    }
}