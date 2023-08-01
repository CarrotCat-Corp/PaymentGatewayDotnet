namespace PaymentGatewayDotnet.Shared.Enums
{
    public enum InvoicingRequestType
    {
        Undefined,
        AddInvoice,
        UpdateInvoice,
        SendInvoice,
        CloseInvoice
    }
    
    public static class InvoicingRequestTypeUtils
    {
        public static InvoicingRequestType ParseString(string value)
        {
            switch (value?.ToLower())
            {
                case "add_invoice": return InvoicingRequestType.AddInvoice;
                case "update_invoice": return InvoicingRequestType.UpdateInvoice;
                case "send_invoice": return InvoicingRequestType.SendInvoice;
                case "close_invoice": return InvoicingRequestType.CloseInvoice;
                default: return InvoicingRequestType.Undefined;
            }
        }
        
        public static string ToString(InvoicingRequestType? value)
        {
            switch (value)
            {
                case InvoicingRequestType.AddInvoice: return "add_invoice";
                case InvoicingRequestType.UpdateInvoice: return "update_invoice";
                case InvoicingRequestType.SendInvoice: return "send_invoice";
                case InvoicingRequestType.CloseInvoice: return "close_invoice";
                default: return "";
            }
        }
    }
}