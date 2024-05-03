using System.Collections.Generic;
using System.Xml.Linq;
using PaymentGatewayDotnet.Utilities;

namespace PaymentGatewayDotnet.Shared
{
    /// <summary>
    /// Payment Descriptor Data
    /// Only works for supported processors. See Gateway service matrix
    /// </summary>
    public sealed class PaymentDescriptor
    {
        /// <summary>
        /// Set payment descriptor on supported processors.
        /// </summary>
        public string Descriptor { get; set; }
        
        /// <summary>
        /// Set payment descriptor phone on supported processors.
        /// </summary>
        public string Phone { get; set; }
        
        /// <summary>
        /// Set payment descriptor address on supported processors.
        /// </summary>
        public string Address { get; set; }
        
        /// <summary>
        /// Set payment descriptor city on supported processors.
        /// </summary>
        public string City { get; set; }
        
        /// <summary>
        /// Set payment descriptor state on supported processors.
        /// </summary>
        public string State { get; set; }
        
        /// <summary>
        /// Set payment descriptor postal code on supported processors.
        /// </summary>
        public string Postal { get; set; }
        
        /// <summary>
        /// Set payment descriptor country on supported processors.
        /// </summary>
        public string Country { get; set; }
        
        /// <summary>
        /// Set payment descriptor mcc on supported processors.
        /// </summary>
        public string Mcc { get; set; }
        
        /// <summary>
        /// Set payment descriptor merchant id on supported processors.
        /// </summary>
        public string MerchantId { get; set; }
        
        /// <summary>
        /// Set payment descriptor url on supported processors.
        /// </summary>
        public string Url { get; set; }
        
        
        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            var list = new List<KeyValuePair<string, string>>();
            if (Descriptor != null) list.Add(new KeyValuePair<string, string>("descriptor", Descriptor));
            if (Phone != null) list.Add(new KeyValuePair<string, string>("descriptor_phone", Phone));
            if (Address != null) list.Add(new KeyValuePair<string, string>("descriptor_address", Address));
            if (City != null) list.Add(new KeyValuePair<string, string>("descriptor_city", City));
            if (State != null) list.Add(new KeyValuePair<string, string>("descriptor_state", State));
            if (Postal != null) list.Add(new KeyValuePair<string, string>("descriptor_postal", Postal));
            if (Country != null) list.Add(new KeyValuePair<string, string>("descriptor_country", Country));
            if (Mcc != null) list.Add(new KeyValuePair<string, string>("descriptor_mcc", Mcc));
            if (MerchantId != null) list.Add(new KeyValuePair<string, string>("descriptor_merchant_id", MerchantId));
            if (Url != null) list.Add(new KeyValuePair<string, string>("descriptor_url", Url));

            return list;
        }

        public IEnumerable<XElement> ToXmlElements()
        {
            if (Descriptor != null) yield return new XElement("descriptor", Descriptor);
            if (Phone != null) yield return new XElement("descriptor-phone", Phone);
            if (Address != null) yield return new XElement("descriptor-address", Address);
            if (City != null) yield return new XElement("descriptor-city", City);
            if (State != null) yield return new XElement("descriptor-state", State);
            if (Postal != null) yield return new XElement("descriptor-postal", Postal);
            if (Country != null) yield return new XElement("descriptor-country", Country);
            if (Mcc != null) yield return new XElement("descriptor-mcc", Mcc);
            if (MerchantId != null) yield return new XElement("descriptor-merchant_id", MerchantId);
            if (Url != null) yield return new XElement("descriptor-url", Url);
        }

        public static PaymentDescriptor FromXmlElement(XElement document)
        {
            if (document == null) return null;
            var paymentDescriptor = new PaymentDescriptor
            {
                Descriptor = XmlUtilities.XElementToString(document.Element("descriptor")),
                Phone = XmlUtilities.XElementToString(document.Element("descriptor-phone")),
                Address = XmlUtilities.XElementToString(document.Element("descriptor-address")),
                City = XmlUtilities.XElementToString(document.Element("descriptor-city")),
                State = XmlUtilities.XElementToString(document.Element("descriptor-state")),
                Postal = XmlUtilities.XElementToString(document.Element("descriptor-postal")),
                Country = XmlUtilities.XElementToString(document.Element("descriptor-country")),
                Mcc = XmlUtilities.XElementToString(document.Element("descriptor-mcc")),
                MerchantId = XmlUtilities.XElementToString(document.Element("descriptor-merchant_id")),
                Url = XmlUtilities.XElementToString(document.Element("descriptor-url"))
            };
            return paymentDescriptor;
        }
    }
}