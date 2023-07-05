using System.Collections.Generic;
using System.Xml.Linq;

namespace PaymentGatewayDotnet.Model.Shared
{
    public class Address
    {
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        //todo: implement enumerable for Province
        /// <summary>
        /// Format: CC
        /// </summary>
        public string StateProvince { get; set; }

        public string PostalZip { get; set; }

        //todo: implement enumerable for Country
        /// <summary>
        /// Country codes are as shown in ISO 3166. Format: CC
        /// </summary>
        public string Country { get; set; }


        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs(string prefix = null)
        {
            if (prefix != null && !prefix.EndsWith("_")) prefix = prefix + "_";

            var list = new List<KeyValuePair<string, string>>();

            if (Address1 != null) list.Add(new KeyValuePair<string, string>(prefix+"address1", Address1));
            if (Address2 != null) list.Add(new KeyValuePair<string, string>(prefix+"address2", Address2));
            if (City != null) list.Add(new KeyValuePair<string, string>(prefix+"city", City));
            if (StateProvince != null) list.Add(new KeyValuePair<string, string>(prefix+"state", StateProvince));
            if (PostalZip != null) list.Add(new KeyValuePair<string, string>(prefix+"zip", PostalZip));
            if (Country != null) list.Add(new KeyValuePair<string, string>(prefix+"country", Country));

            return list;
        }

        public static Address FromXmlElement(XElement element)
        {
            if (element is null) return null;
            var address = new Address
            {
                Address1 = XmlUtilities.XElementToString(element.Element("address_1")),
                Address2 = XmlUtilities.XElementToString(element.Element("address_2")),
                City = XmlUtilities.XElementToString(element.Element("city")),
                StateProvince = XmlUtilities.XElementToString(element.Element("state")),
                PostalZip = XmlUtilities.XElementToString(element.Element("postal_code")),
                Country = XmlUtilities.XElementToString(element.Element("country"))
            };
            return address;
        }
        
    }
}