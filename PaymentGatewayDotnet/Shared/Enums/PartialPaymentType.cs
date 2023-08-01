namespace PaymentGatewayDotnet.Shared.Enums
{
    public enum PartialPaymentType
    {
        Undefined,
        /// <summary>
        /// Settles any amount of tender collected (captured partial auth's and approved partial sales) at cut off.
        /// </summary>
        SettlePartial,
        
        /// <summary>
        /// Required that any split tendered transaction is collected in-full before settlement gets initiated
        /// </summary>
        PaymentInFull,
    }
    
    public static class PartialPaymentTypeUtils
    {
        public static PartialPaymentType ParseString(string value)
        {
            switch (value?.ToLower())
            {
                case "settle_partial": return PartialPaymentType.SettlePartial;
                case "payment_in_full": return PartialPaymentType.PaymentInFull;
                default: return PartialPaymentType.Undefined;
            }
        }
        
        public static string ToString(PartialPaymentType? value)
        {
            switch (value)
            {
                case PartialPaymentType.SettlePartial: return "settle_partial";
                case PartialPaymentType.PaymentInFull: return "payment_in_full";
                default: return "";
            }
        }
    }
}