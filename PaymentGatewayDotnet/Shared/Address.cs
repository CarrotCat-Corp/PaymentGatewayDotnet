using System.Collections.Generic;
using System.Xml.Linq;
using PaymentGatewayDotnet.Utilities;

namespace PaymentGatewayDotnet.Shared
{
    public class Address
    {
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        /// <summary>
        /// Format: CC
        /// </summary>
        public string StateProvince { get; set; }

        public string PostalZip { get; set; }

        /// <summary>
        /// Country codes are as shown in ISO 3166. Format: CC
        /// </summary>
        public string Country { get; set; }


        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs(string prefix = null)
        {
            if (prefix != null && !prefix.EndsWith("_")) prefix = prefix + "_";

            if (Address1 != null) yield return new KeyValuePair<string, string>(prefix + "address1", Address1);
            if (Address2 != null) yield return new KeyValuePair<string, string>(prefix + "address2", Address2);
            if (City != null) yield return new KeyValuePair<string, string>(prefix + "city", City);
            if (StateProvince != null) yield return new KeyValuePair<string, string>(prefix + "state", StateProvince);
            if (PostalZip != null) yield return new KeyValuePair<string, string>(prefix + "zip", PostalZip);
            if (Country != null) yield return new KeyValuePair<string, string>(prefix + "country", Country);
        }

        public static Address FromXmlElement(XElement element)
        {
            if (element is null) return null;
            var address = new Address
            {
                Address1 = XmlUtilities.XElementToString(element.Element("address_1") ?? element.Element("address1")),
                Address2 = XmlUtilities.XElementToString(element.Element("address_2") ?? element.Element("address2")),
                City = XmlUtilities.XElementToString(element.Element("city") ?? element.Element("city")),
                StateProvince = XmlUtilities.XElementToString(element.Element("state") ?? element.Element("state")),
                PostalZip = XmlUtilities.XElementToString(element.Element("postal_code") ?? element.Element("postal")),
                Country = XmlUtilities.XElementToString(element.Element("country") ?? element.Element("company"))
            };
            return address;
        }

        public IEnumerable<XElement> ToXmlElements()
        {
            if (Address1 != null) yield return new XElement("address1", Address1);
            if (Address2 != null) yield return new XElement("address2", Address2);
            if (City != null) yield return new XElement("city", City);
            if (StateProvince != null) yield return new XElement("state", StateProvince);
            if (PostalZip != null) yield return new XElement("postal", PostalZip);
            if (Country != null) yield return new XElement("country", Country);
        }
    }
}