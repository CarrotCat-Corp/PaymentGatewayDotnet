namespace PaymentGatewayDotnet.QueryApi.Enums
{
    public enum Condition
    {
        Undefined,
        
        /// <summary>
        /// 'Auth Only' transactions that are awaiting capture.
        /// </summary>
        Pending,
        
        /// <summary>
        /// This transaction is awaiting settlement.
        /// </summary>
        PendingSettlement,
        
        /// <summary>
        /// This Three-Step Redirect API transaction has not yet been completed. The transaction condition will change to 'abandoned' if 24 hours pass with no further action.
        /// </summary>
        InProgress,
        
        /// <summary>
        /// This Three-Step Redirect API transaction has not been completed, and has timed out.
        /// </summary>
        Abandoned,
        
        /// <summary>
        /// This transaction has failed.
        /// </summary>
        Failed,
        
        /// <summary>
        /// This transaction has been voided.
        /// </summary>
        Canceled,
        
        /// <summary>
        /// This transaction has settled.
        /// </summary>
        Complete,
        
        /// <summary>
        /// An unknown error was encountered while processing this transaction.
        /// </summary>
        Unknown
    }

    public static class ConditionUtils
    {
        public static Condition ParseString(string condition)
        {
            switch (condition?.ToLower())
            {
                case "pending":
                    return Condition.Pending;
                case "pendingsettlement":
                    return Condition.PendingSettlement;
                case "in_progress":
                    return Condition.InProgress;
                case "abandoned":
                    return Condition.Abandoned;
                case "failed":
                    return Condition.Failed;
                case "canceled":
                    return Condition.Canceled;
                case "complete":
                    return Condition.Complete;
                case "unknown":
                    return Condition.Unknown;
                default:
                    return Condition.Undefined;
            }
        }


        public static string ToString(Condition? condition)
        {
            switch (condition)
            {
                case Condition.Pending:
                    return "pending";
                case Condition.PendingSettlement:
                    return "pendingsettlement";
                case Condition.InProgress:
                    return "in_progress";
                case Condition.Abandoned:
                    return "abandoned";
                case Condition.Failed:
                    return "failed";
                case Condition.Canceled:
                    return "canceled";
                case Condition.Complete:
                    return "complete";
                case Condition.Unknown:
                    return "unknown";
                default:
                    return "";
            }
        }
    }
}