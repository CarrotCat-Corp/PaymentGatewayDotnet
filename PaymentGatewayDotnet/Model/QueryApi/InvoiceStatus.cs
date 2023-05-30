namespace PaymentGatewayDotnet.Model.QueryApi
{
    public enum InvoiceStatus
    {
        Undefined,
        Open,
        Paid,
        Closed,
        PastDue
    }

    public static class InvoiceStatusUtils
    {
        public static InvoiceStatus ParseString(string status)
        {
            switch (status?.ToLower())
            {
                case "open":
                    return InvoiceStatus.Open;
                case "paid":
                    return InvoiceStatus.Paid;
                case "closed":
                    return InvoiceStatus.Closed;
                case "past_due":
                    return InvoiceStatus.PastDue;
                default:
                    return InvoiceStatus.Undefined;
            }
        }


        public static string ToString(InvoiceStatus? status)
        {
            switch (status)
            {
                case InvoiceStatus.Open:
                    return "open";
                case InvoiceStatus.Paid:
                    return "paid";
                case InvoiceStatus.Closed:
                    return "closed";
                case InvoiceStatus.PastDue:
                    return "past_due";
                default:
                    return "";
            }
        }
    }
}