namespace PaymentGatewayDotnet.Shared.Enums
{
    public enum TransactionType
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
        public static TransactionType ParseString(string transactionType)
        {
            switch (transactionType?.ToLower())
            {
                case "sale":
                    return TransactionType.Sale;
                case "auth":
                    return TransactionType.Auth;
                case "credit":
                    return TransactionType.Credit;
                case "validate":
                    return TransactionType.Validate;
                case "offline":
                    return TransactionType.Offline;
                case "refund":
                    return TransactionType.Refund;
                case "capture":
                    return TransactionType.Capture;
                case "void":
                    return TransactionType.Void;
                // case "return":
                //     return FinancialRequestType.Return;
                case "complete_partial_payment":
                    return TransactionType.CompletePartialPayment;
                default:
                    return TransactionType.Undefined;
            }
        }


        public static string ToString(TransactionType? type)
        {
            switch (type)
            {
                case TransactionType.Sale:
                    return "sale";
                case TransactionType.Auth:
                    return "auth";
                case TransactionType.Credit:
                    return "credit";
                case TransactionType.Validate:
                    return "validate";
                case TransactionType.Offline:
                    return "offline";
                case TransactionType.Refund:
                    return "refund";
                case TransactionType.Capture:
                    return "capture";
                case TransactionType.Void:
                    return "void";
                // case FinancialRequestType.Return:
                //     return "return";
                // case FinancialRequestType.CustomerVault:
                // case null:
                // case FinancialRequestType.Undefined:
                // case FinancialRequestType.Update:
                case TransactionType.CompletePartialPayment: return "complete_partial_payment";
                default:
                    return "";
            }
        }
    }
}