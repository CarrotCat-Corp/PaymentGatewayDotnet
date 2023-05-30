namespace PaymentGatewayDotnet.Model.PaymentApi.InstallmentBilling
{
    public enum InstallmentBillingMethod
    {
        Undefined, Recurring, Installment
    }
    
    public static class InstallmentBillingMethodUtils
    {
        public static InstallmentBillingMethod ParseString(string value)
        {
            switch (value?.ToLower())
            {
                case "recurring": return InstallmentBillingMethod.Recurring;
                case "installment": return InstallmentBillingMethod.Installment;
                default: return InstallmentBillingMethod.Undefined;
            }
        }
        
        public static string ToString(InstallmentBillingMethod? value)
        {
            switch (value)
            {
                case InstallmentBillingMethod.Recurring: return "recurring";
                case InstallmentBillingMethod.Installment: return "installment";
                default: return "";
            }
        }
    }
}