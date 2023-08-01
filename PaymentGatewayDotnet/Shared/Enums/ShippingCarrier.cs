namespace PaymentGatewayDotnet.Shared.Enums
{
    public enum ShippingCarrier
    {
        Undefined, Ups, Fedex, Dhl, Usps
    }
    
    public static class ShippingCarrierUtils
    {
        public static ShippingCarrier ParseString(string value)
        {
            switch (value?.ToLower())
            {
                case "ups": return ShippingCarrier.Ups;
                case "fedex": return ShippingCarrier.Fedex;
                case "dhl": return ShippingCarrier.Dhl;
                case "usps": return ShippingCarrier.Usps;
                default: return ShippingCarrier.Undefined;
            }
        }
        
        public static string ToString(ShippingCarrier? value)
        {
            switch (value)
            {
                case ShippingCarrier.Ups: return "ups";
                case ShippingCarrier.Fedex: return "fedex";
                case ShippingCarrier.Dhl: return "dhl";
                case ShippingCarrier.Usps: return "usps";
                default: return "";
            }
        }
    }
}