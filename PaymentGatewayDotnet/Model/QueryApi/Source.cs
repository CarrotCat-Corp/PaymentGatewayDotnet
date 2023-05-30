namespace PaymentGatewayDotnet.Model.QueryApi
{
    public enum Source
    {
        Undefined,
        Api,
        BatchUpload,
        Mobile,
        QuickClick,
        QuickBooks,
        Recurring,
        Swipe,
        VirtualTerminal,
        Internal
    }


    public static class SourceUtils
    {
        public static Source ParseString(string source)
        {
            switch (source?.ToLower())
            {
                case "api":
                    return Source.Api;
                case "batch_upload":
                    return Source.BatchUpload;
                case "mobile":
                    return Source.Mobile;
                case "quickclick":
                    return Source.QuickClick;
                case "quickbooks":
                    return Source.QuickBooks;
                case "recurring":
                    return Source.Recurring;
                case "swipe":
                    return Source.Swipe;
                case "virtual_terminal":
                    return Source.VirtualTerminal;
                case "internal":
                    return Source.Internal;
                default:
                    return Source.Undefined;
            }
        }


        public static string ToString(Source? source)
        {
            switch (source)
            {
                case Source.Api:
                    return "api";
                case Source.BatchUpload:
                    return "batch_upload";
                case Source.Mobile:
                    return "mobile";
                case Source.QuickClick:
                    return "quickclick";
                case Source.QuickBooks:
                    return "quickbooks";
                case Source.Recurring:
                    return "recurring";
                case Source.Swipe:
                    return "swipe";
                case Source.VirtualTerminal:
                    return "virtual_terminal";
                case Source.Internal:
                    return "internal";
                default:
                    return "";
            }
        }
    }
}