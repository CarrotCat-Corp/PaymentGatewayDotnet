namespace PaymentGatewayDotnet.Shared.Enums
{
    public enum IndustryClassification
    {
        Undefined,
        Ecommerce,
        Retail,
        Moto
    }
    
    public static class IndustryClassificationUtils
    {
        public static IndustryClassification ParseString(string value)
        {
            switch (value?.ToLower())
            {
                case "ecommerce": return IndustryClassification.Ecommerce;
                case "retail": return IndustryClassification.Retail;
                case "moto": return IndustryClassification.Moto;
                default: return IndustryClassification.Undefined;
            }
        }
        
        public static string ToString(IndustryClassification? value)
        {
            switch (value)
            {
                case IndustryClassification.Ecommerce: return "ecommerce";
                case IndustryClassification.Retail: return "retail";
                case IndustryClassification.Moto: return "moto";
                default: return "";
            }
        }
    }
}