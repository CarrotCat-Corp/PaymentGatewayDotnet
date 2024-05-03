using System.Collections.Generic;
using System.Xml.Linq;
using PaymentGatewayDotnet.Utilities;

namespace PaymentGatewayDotnet.Shared
{
    /// <summary>
    /// Represents client billing information
    /// </summary>
    public class Billing
    {
        /// <summary>
        /// In Customer Vault transactions, Billing id to be assigned or updated. I
        /// f none is provided, one will be created or the billing id with priority '1' will be updated.
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Cardholder's first name.
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// Cardholder's last name
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Cardholder's company
        /// </summary>
        public string Company { get; set; }
        
        /// <summary>
        /// Billing phone number
        /// </summary>
        public string Phone { get; set; }
        
        /// <summary>
        /// Billing cell phone number. (It is not explicitly specified in the gateway specs.)
        /// </summary>
        public string CellPhone { get; set; }
        
        /// <summary>
        /// Billing fax number
        /// </summary>
        public string Fax { get; set; }
        
        /// <summary>
        /// Billing email address
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// If set to true, when the customer is charged, they will be sent a transaction receipt.
        /// This will only work if billing email is entered
        /// </summary>
        public bool? CustomerReceipt { get; set; }
        
        /// <summary>
        /// Card billing address
        /// Required for Address Verification Service
        /// </summary>
        public Address Address { get; set; }
        
        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs(string prefix = null)
        {
            if (prefix != null) prefix = prefix + "_";

            var list = new List<KeyValuePair<string, string>>();

            if (Id != null) list.Add(new KeyValuePair<string, string>(prefix+"billing_id", Id));
            if (FirstName != null) list.Add(new KeyValuePair<string, string>(prefix+"first_name", FirstName));
            if (LastName != null) list.Add(new KeyValuePair<string, string>(prefix+"last_name", LastName));
            if (Company != null) list.Add(new KeyValuePair<string, string>(prefix+"company", Company));
            if (Phone != null) list.Add(new KeyValuePair<string, string>(prefix+"phone", Phone));
            if (Fax != null) list.Add(new KeyValuePair<string, string>(prefix+"fax", Fax));
            if (Email != null) list.Add(new KeyValuePair<string, string>(prefix+"email", Email));
            if (CellPhone != null) list.Add(new KeyValuePair<string, string>(prefix+"cell_phone", Email));
            
            
            if (Address != null) list.AddRange(Address.ToKeyValuePairs(prefix));

            return list;
        }


        public static Billing FromXmlElement(XElement element)
        {
            if (element is null) return null;
            var billing = new Billing
            {
                Id = XmlUtilities.XElementToString(element.Element("billing")?.Element("shipping-id")),
                
                FirstName = XmlUtilities.XElementToString(
                    element.Element("first_name") ?? element.Element("billing")?.Element("first-name")
                ),
                
                LastName = XmlUtilities.XElementToString(
                    element.Element("last_name") ?? element.Element("billing")?.Element("last-name")
                ),
                
                Company = XmlUtilities.XElementToString(
                    element.Element("company") ?? element.Element("billing")?.Element("company")
                ),
                
                Email = XmlUtilities.XElementToString(
                    element.Element("email") ?? element.Element("billing")?.Element("email")
                ),
                
                Phone = XmlUtilities.XElementToString(
                    element.Element("phone") ?? element.Element("billing")?.Element("phone")
                ),
                
                Fax = XmlUtilities.XElementToString(
                    element.Element("fax") ?? element.Element("billing")?.Element("fax")
                ),
                
                Address = Address.FromXmlElement(element.Element("billing"))
            };
            return billing;
        }
        
        public XElement ToXmlElement()
        {

            var element = new XElement("billing");

            if (Id != null) element.Add(new XElement("billing-id", Id));
            if (FirstName != null) element.Add(new XElement("first-name", FirstName));
            if (LastName != null) element.Add(new XElement("last-name", LastName));
            if (Company != null) element.Add(new XElement("company", Company));
            if (Phone != null) element.Add(new XElement("phone", Phone));
            if (Fax != null) element.Add(new XElement("fax", Fax));
            if (Email != null) element.Add(new XElement("email", Email));
            if (CellPhone != null) element.Add(new XElement("cell-phone", CellPhone));

            if (Address == null) return element;
            
            var addressElements = Address.ToXmlElements();
            foreach (var el in addressElements)
            {
                element.Add(el);
            }

            return element;
        }
    }
}