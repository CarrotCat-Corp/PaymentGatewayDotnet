namespace PaymentGatewayDotnet.Model.RetailDevises
{
    public enum IngenicoVerificationMethod
    {
        Signature,
        OfflinePin,
        OfflinePinSignature,
        None
    }
    
    public static class IngenicoVerificationMethodUtils
    {
        public static IngenicoVerificationMethod ParseString(string value)
        {
            switch (value?.ToLower())
            {
                case "signature": return IngenicoVerificationMethod.Signature;
                case "offline_pin": return IngenicoVerificationMethod.OfflinePin;
                case "offline_pin_signature": return IngenicoVerificationMethod.OfflinePinSignature;
                case "none": return IngenicoVerificationMethod.None;
                default: return IngenicoVerificationMethod.None;
            }
        }
        
        public static string ToString(IngenicoVerificationMethod? value)
        {
            switch (value)
            {
                case IngenicoVerificationMethod.Signature: return "signature";
                case IngenicoVerificationMethod.OfflinePin: return "offline_pin";
                case IngenicoVerificationMethod.OfflinePinSignature: return "offline_pin_signature";
                case IngenicoVerificationMethod.None: return "none";
                default: return "none";
            }
        }
    }
}