namespace PaymentGatewayDotnet.Model.QueryApi
{
    public enum ResultOrder
    {
        Undefined,
        Standard,
        Reverse
    }


    public static class ResultOrderUtils
    {
        public static ResultOrder ParseString(string status)
        {
            switch (status?.ToLower())
            {
                case "standard":
                    return ResultOrder.Standard;
                case "reverse":
                    return ResultOrder.Reverse;
                default:
                    return ResultOrder.Undefined;
            }
        }


        public static string ToString(ResultOrder? status)
        {
            switch (status)
            {
                case ResultOrder.Standard:
                    return "standard";
                case ResultOrder.Reverse:
                    return "reverse";
                default:
                    return "";
            }
        }
    }
}