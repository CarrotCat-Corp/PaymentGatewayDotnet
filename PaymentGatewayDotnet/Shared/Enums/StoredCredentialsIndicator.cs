namespace PaymentGatewayDotnet.Shared.Enums
{
    /// <summary>
    /// The indicator of the stored credential.
    /// Values: 'stored' or 'used'
    /// Use 'stored' when processing the initial transaction in which you are storing a customer's payment details (customer credentials) in the Customer Vault or other third-party payment storage system.
    /// Use 'used' when processing a subsequent or follow-up transaction using the customer payment details (customer credentials) you have already stored to the Customer Vault or third-party payment storage method.
    /// </summary>
    public enum StoredCredentialsIndicator
    {
        Undefined,
        
        /// <summary>
        /// Use 'stored' when processing the initial transaction in which you are storing a customer's payment details (customer credentials) in the Customer Vault or other third-party payment storage system.
        /// </summary>
        Stored,
        
        /// <summary>
        /// Use 'used' when processing a subsequent or follow-up transaction using the customer payment details (customer credentials) you have already stored to the Customer Vault or third-party payment storage method.
        /// </summary>
        Used
    }
    
    public static class StoredCredentialsIndicatorUtils
    {
        public static StoredCredentialsIndicator ParseString(string value)
        {
            switch (value?.ToLower())
            {
                case "stored": return StoredCredentialsIndicator.Stored;
                case "used": return StoredCredentialsIndicator.Used;
                default: return StoredCredentialsIndicator.Undefined;
            }
        }
        
        public static string ToString(StoredCredentialsIndicator? value)
        {
            switch (value)
            {
                case StoredCredentialsIndicator.Stored: return "stored";
                case StoredCredentialsIndicator.Used: return "used";
                default: return "";
            }
        }
    }
}