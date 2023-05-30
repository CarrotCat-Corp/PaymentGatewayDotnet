namespace PaymentGatewayDotnet.Model.PaymentApi.AchData
{
    public enum StandardEntryClassCode
    {
        Undefined,
        PPD,
        WEB,
        TEL,
        CCD
    }
    
    public static class StandardEntryClassCodeUtils
    {
        public static StandardEntryClassCode ParseString(string value)
        {
            switch (value?.ToLower())
            {
                case "PPD": return StandardEntryClassCode.PPD;
                case "WEB": return StandardEntryClassCode.WEB;
                case "TEL": return StandardEntryClassCode.TEL;
                case "CCD": return StandardEntryClassCode.CCD;
                default: return StandardEntryClassCode.Undefined;
            }
        }
        
        public static string ToString(StandardEntryClassCode? value)
        {
            switch (value)
            {
                case StandardEntryClassCode.PPD: return "PPD";
                case StandardEntryClassCode.WEB: return "WEB";
                case StandardEntryClassCode.TEL: return "TEL";
                case StandardEntryClassCode.CCD: return "CCD";
                default: return "";
            }
        }
    }
}