namespace PaymentGatewayDotnet.Shared.Enums
{
    /// <summary>
    /// Reason the EMV transaction is being voided.
    /// </summary>
    public enum VoidReasonType
    {
        Undefined,
        Fraud,
        UserCancel,
        IccCancel,
        IccCardRemoved,
        IccNoConfirmation,
        PosTimeout
    }
    
    public static class VoidReasonTypeUtils
    {
        public static VoidReasonType ParseString(string value)
        {
            switch (value?.ToLower())
            {
                case "fraud": return VoidReasonType.Fraud;
                case "user_cancel": return VoidReasonType.UserCancel;
                case "icc_rejected": return VoidReasonType.IccCancel;
                case "icc_card_removed": return VoidReasonType.IccCardRemoved;
                case "icc_no_confirmation": return VoidReasonType.IccNoConfirmation;
                case "pos_timeout": return VoidReasonType.PosTimeout;
                default: return VoidReasonType.Undefined;
            }
        }
        
        public static string ToString(VoidReasonType? value)
        {
            switch (value)
            {
                case VoidReasonType.Fraud: return "fraud";
                case VoidReasonType.UserCancel: return "user_cancel";
                case VoidReasonType.IccCancel: return "icc_rejected";
                case VoidReasonType.IccCardRemoved: return "icc_card_removed";
                case VoidReasonType.IccNoConfirmation: return "icc_no_confirmation";
                case VoidReasonType.PosTimeout: return "pos_timeout";
                default: return "";
            }
        }
    }
    
}