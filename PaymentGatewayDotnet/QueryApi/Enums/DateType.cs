namespace PaymentGatewayDotnet.QueryApi.Enums
{
    public enum DateType
    {
        Undefined,
        Created,
        Updated
    }

    public static class DateTypeUtils
    {
        public static DateType ParseString(string value)
        {
            switch (value?.ToLower())
            {
                case "created":
                    return DateType.Created;
                case "updated":
                    return DateType.Updated;
                default:
                    return DateType.Undefined;
            }
        }


        public static string ToString(DateType? value)
        {
            switch (value)
            {
                case DateType.Created:
                    return "created";
                case DateType.Updated:
                    return "updated";
                default:
                    return "";
            }
        }
    }
}