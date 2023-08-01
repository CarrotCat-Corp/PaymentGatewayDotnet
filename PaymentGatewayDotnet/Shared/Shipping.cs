using System.Collections.Generic;
using System.Xml.Linq;
using PaymentGatewayDotnet.Shared.Enums;
using PaymentGatewayDotnet.Utilities;

namespace PaymentGatewayDotnet.Shared
{
    public sealed class Shipping
    {
        /// <summary>
        /// In Customer Vault transactions, Billing id to be assigned or updated. I
        /// f none is provided, one will be created or the billing id with priority '1' will be updated.
        /// </summary>
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
                FirstName = XmlUtilities.XElementToString(element.Element("first_name")),
                LastName = XmlUtilities.XElementToString(element.Element("last_name")),
                Company = XmlUtilities.XElementToString(element.Element("company")),
                Email = XmlUtilities.XElementToString(element.Element("email")),
                Phone = XmlUtilities.XElementToString(element.Element("phone")),
                Fax = XmlUtilities.XElementToString(element.Element("fax")),
                Amount = XmlUtilities.XElementToDecimal(element.Element("amount")),
                // ShipFromPostalCode = XmlUtilities.XElementToString(element.Element("fax")),
                TrackingNumber = XmlUtilities.XElementToString(element.Element("tracking")),
                // Address = Address.FromXmlElement(element)

            };
            return billing;
        }
    }
}   