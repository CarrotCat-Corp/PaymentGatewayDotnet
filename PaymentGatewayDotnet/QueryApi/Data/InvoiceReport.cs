using System.Collections.Generic;
using System.Xml.Linq;
using PaymentGatewayDotnet.Shared;

namespace PaymentGatewayDotnet.QueryApi.Data
{
    public class InvoiceReport
    {
        public List<Invoice> Invoices { get; private set; }
        
        public static InvoiceReport FromXmlElement(XElement customerVaultElement)
        {
            if (customerVaultElement is null) return null;

            var invoices = new List<Invoice>();
            var invoicesElements = customerVaultElement.Elements("invoice");
            foreach (var invoicesElement in invoicesElements)
            {
                invoices.Add(Invoice.FromXmlElement(invoicesElement));
            }
        
            return new InvoiceReport(){Invoices = invoices};
        }
    }
}