namespace PaymentGatewayDotnet.PaymentApi.Data.RetailDevises
{
    public enum IngenicoTelium2EntryMode
    {
        Undefined,
        EmvIcc,
        Swiped,
        SwipedEmvFallback,
        NfcMsd,
        Keyed
    }    
    
    
    public static class IngenicoTelium2EntryModeUtils
    {
        public static IngenicoTelium2EntryMode ParseString(string value)
        {
            switch (value?.ToLower())
            {
                case "emv_icc": return IngenicoTelium2EntryMode.EmvIcc;
                case "swiped": return IngenicoTelium2EntryMode.Swiped;
                case "swiped_emv_fallback": return IngenicoTelium2EntryMode.SwipedEmvFallback;
                case "nfc_msd": return IngenicoTelium2EntryMode.NfcMsd;
                case "keyed": return IngenicoTelium2EntryMode.Keyed;
                default: return IngenicoTelium2EntryMode.Undefined;
            }
        }
        
        public static string ToString(IngenicoTelium2EntryMode? value)
        {
            switch (value)
            {
                case IngenicoTelium2EntryMode.EmvIcc: return "emv_icc";
                case IngenicoTelium2EntryMode.Swiped: return "swiped";
                case IngenicoTelium2EntryMode.SwipedEmvFallback: return "swiped_emv_fallback";
                case IngenicoTelium2EntryMode.NfcMsd: return "nfc_msd";
                case IngenicoTelium2EntryMode.Keyed: return "keyed";
                default: return "";
            }
        }
    }
    
    
}