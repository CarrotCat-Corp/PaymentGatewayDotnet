using System.Collections.Generic;
using System.Xml.Linq;

namespace PaymentGatewayDotnet.Model.QueryApi
{
    public class CustomerVault
    {
        public List<Customer> Customers { get; set; }

        public static CustomerVault FromXmlElement(XElement customerVaultElement)
        {
            if (customerVaultElement is null) return null;

            var customers = new List<Customer>();
            var customerElements = customerVaultElement.Elements("customer");
            foreach (var customerElement in customerElements)
            {
                customers.Add(Customer.FromXmlElement(customerElement));
            }
        
            return new CustomerVault(){Customers = customers};
        }
    }
}