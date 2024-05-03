using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace PaymentGatewayDotnet.Abstractions
{
    public abstract class BaseApiRequest
    {
        /// <summary>
        /// API Security Key assigned to a merchant account.
        /// New keys can be generated from the merchant control panel in Settings > Security Keys
        /// </summary>
        protected string SecurityKey { get; private set; }
        
        /// <summary>
        /// IP address of cardholder, this field is recommended.
        /// Format: xxx.xxx.xxx.xxx
        /// </summary>
        public string IpAddress { get; set; }


        protected BaseApiRequest(string securityKey)
        {
            SecurityKey = securityKey ?? throw new ArgumentNullException(nameof(securityKey));
        }

        protected IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            var list = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("security_key", SecurityKey)
            };
            if (IpAddress != null) list.Add(new KeyValuePair<string, string>("ipaddress", IpAddress));

            return list;
        }

        protected IEnumerable<XElement> ToXmlElements()
        {
            yield return new XElement("api-key", SecurityKey);
            if (!string.IsNullOrEmpty(IpAddress)) yield return new XElement("ip-address", IpAddress);
        }
    }
}