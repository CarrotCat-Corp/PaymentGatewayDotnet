using System.Collections.Generic;
using System.Xml.Linq;
using PaymentGatewayDotnet.Shared.Enums;
using PaymentGatewayDotnet.Utilities;

namespace PaymentGatewayDotnet.Shared
{
    public sealed class Shipping
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public decimal? Amount { get; set; }
        public string ShipFromPostalCode { get; set; }
        public ShippingCarrier? Carrier { get; set; }
        public string TrackingNumber { get; set; }
        
        /// <summary>
        /// Shipping phone number
        /// </summary>
        public string Phone { get; set; }
        
        /// <summary>
        /// Shipping fax number
        /// </summary>
        public string Fax { get; set; }
        
        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            var list = new List<KeyValuePair<string, string>>();
            
            if (Id != null) list.Add(new KeyValuePair<string, string>("shipping_id", Id));
            if (FirstName != null) list.Add(new KeyValuePair<string, string>("shipping_firstname", FirstName));
            if (LastName != null) list.Add(new KeyValuePair<string, string>("shipping_lastname", LastName));
            if (Company != null) list.Add(new KeyValuePair<string, string>("shipping_company", Company));
            if (Email != null) list.Add(new KeyValuePair<string, string>("shipping_email", Email));
            if (Amount != null) list.Add(new KeyValuePair<string, string>("shipping", Amount?.ToString("F2")));
            if (ShipFromPostalCode != null) list.Add(new KeyValuePair<string, string>("ship_from_postal", ShipFromPostalCode));
            if (Carrier != null) list.Add(new KeyValuePair<string, string>("shipping_carrier", ShippingCarrierUtils.ToString(Carrier)));
            if (TrackingNumber != null) list.Add(new KeyValuePair<string, string>("tracking_number", TrackingNumber));
            if (Phone != null) list.Add(new KeyValuePair<string, string>("shipping_phone", Phone));
            if (Fax != null) list.Add(new KeyValuePair<string, string>("shipping_fax", Fax));
            
            if (Address != null) list.AddRange(Address.ToKeyValuePairs("shipping"));
            
            return list;
        }
        
        public static Shipping FromXmlElement(XElement element)
        {
            if (element is null) return null;
            var billing = new Shipping
            {
                Id = XmlUtilities.XElementToString(element.Element("shipping")?.Element("shipping-id")),
                
                FirstName = XmlUtilities.XElementToString(
                    element.Element("first_name") ?? element.Element("shipping")?.Element("first-name")
                    ),
                
                LastName = XmlUtilities.XElementToString(
                    element.Element("last_name") ?? element.Element("shipping")?.Element("last-name")
                    ),
                
                Company = XmlUtilities.XElementToString(
                    element.Element("company") ?? element.Element("shipping")?.Element("company")
                    ),
                
                Email = XmlUtilities.XElementToString(
                    element.Element("email") ?? element.Element("shipping")?.Element("email")
                    ),
                
                Phone = XmlUtilities.XElementToString(
                    element.Element("phone") ?? element.Element("shipping")?.Element("phone")
                    ),
                
                Fax = XmlUtilities.XElementToString(
                    element.Element("fax") ?? element.Element("shipping")?.Element("fax")
                    ),
                
                Amount = XmlUtilities.XElementToDecimal(
                    element.Element("amount") ?? element.Element("shipping-amount")
                    ),
                
                ShipFromPostalCode = XmlUtilities.XElementToString(element.Element("ship-from-postal")),
                
                TrackingNumber = XmlUtilities.XElementToString(
                    element.Element("tracking") ?? element.Element("tracking-number")
                    ),
                
                Address = Address.FromXmlElement(element.Element("shipping"))

            };
            return billing;
        }
        
        public IEnumerable<XElement> ToXmlElements()
        {
            yield return ToShippingXmlElement();
            if (Amount != null) yield return new XElement("shipping-amount", Amount?.ToString("F2"));
            if (ShipFromPostalCode != null) yield return new XElement("ship-from-postal", ShipFromPostalCode);
            if (Carrier != null) yield return new XElement("shipping-carrier", ShippingCarrierUtils.ToString(Carrier));
            if (TrackingNumber != null) yield return new XElement("tracking-number", TrackingNumber);
        }
        
        private XElement ToShippingXmlElement()
        {

            var element = new XElement("shipping");

            if (Id != null) element.Add(new XElement("shipping-id", Id));
            if (FirstName != null) element.Add(new XElement("first-name", FirstName));
            if (LastName != null) element.Add(new XElement("last-name", LastName));
            if (Company != null) element.Add(new XElement("company", Company));
            if (Phone != null) element.Add(new XElement("phone", Phone));
            if (Fax != null) element.Add(new XElement("fax", Fax));
            if (Email != null) element.Add(new XElement("email", Email));

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