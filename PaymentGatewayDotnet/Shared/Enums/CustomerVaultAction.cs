namespace PaymentGatewayDotnet.Shared.Enums
{
    public enum CustomerVaultAction
    {
        Undefined,
        AddCustomer,
        UpdateCustomer,
        DeleteCustomer
    }
    
    public static class CustomerVaultActionUtils
    {
        public static CustomerVaultAction ParseString(string value)
        {
            switch (value?.ToLower())
            {
                case "add_customer": return CustomerVaultAction.AddCustomer;
                case "update_customer": return CustomerVaultAction.UpdateCustomer;
                case "delete_customer": return CustomerVaultAction.DeleteCustomer;
                default: return CustomerVaultAction.Undefined;
            }
        }
        
        public static string ToString(CustomerVaultAction? value)
        {
            switch (value)
            {
                case CustomerVaultAction.AddCustomer: return "add_customer";
                case CustomerVaultAction.UpdateCustomer: return "update_customer";
                case CustomerVaultAction.DeleteCustomer: return "delete_customer";
                default: return "";
            }
        }
    }
}