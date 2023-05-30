namespace PaymentGatewayDotnet.Model.Shared
{
    public enum FinancialRequestType
    {
        Undefined,
        Sale,
        Auth,
        Credit,
        Validate,
        Offline,
        Capture,
        Void,
        Refund,
        Update,
        CompletePartialPayment,
        // Return,
        // CustomerVault
    }

    public static class FinancialRequestTypeUtils
    {
        /// <summary>
        /// Parses string into FinancialRequestType Enum
        /// </summary>
        /// <param name="transactionType">String to be parsed</param>
        /// <returns>Enum value of FinancialRequestType</returns>
        public static FinancialRequestType ParseString(string transactionType)
        {
            switch (transactionType?.ToLower())
            {
                case "sale":
                    return FinancialRequestType.Sale;
                case "auth":
                    return FinancialRequestType.Auth;
                case "credit":
                    return FinancialRequestType.Credit;
                case "validate":
                    return FinancialRequestType.Validate;
                case "offline":
                    return FinancialRequestType.Offline;
                case "refund":
                    return FinancialRequestType.Refund;
                case "capture":
                    return FinancialRequestType.Capture;
                case "void":
                    return FinancialRequestType.Void;
                // case "return":
                //     return FinancialRequestType.Return;
                case "complete_partial_payment":
                    return FinancialRequestType.CompletePartialPayment;
                default:
                    return FinancialRequestType.Undefined;
            }
        }


        public static string ToString(FinancialRequestType? type)
        {
            switch (type)
            {
                case FinancialRequestType.Sale:
                    return "sale";
                case FinancialRequestType.Auth:
                    return "auth";
                case FinancialRequestType.Credit:
                    return "credit";
                case FinancialRequestType.Validate:
                    return "validate";
                case FinancialRequestType.Offline:
                    return "offline";
                case FinancialRequestType.Refund:
                    return "refund";
                case FinancialRequestType.Capture:
                    return "capture";
                case FinancialRequestType.Void:
                    return "void";
                // case FinancialRequestType.Return:
                //     return "return";
                // case FinancialRequestType.CustomerVault:
                // case null:
                // case FinancialRequestType.Undefined:
                // case FinancialRequestType.Update:
                case FinancialRequestType.CompletePartialPayment: return "complete_partial_payment";
                default:
                    return "";
            }
        }
    }
}