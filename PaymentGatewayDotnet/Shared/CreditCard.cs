using System;
using System.Collections.Generic;
using System.Xml.Linq;
using PaymentGatewayDotnet.Utilities;

namespace PaymentGatewayDotnet.Shared
{
    public sealed class CreditCard
    {
        public string Number { get; set; }
        public DateTime Expiration { get; set; }
        public string Cvv { get; set; }
        
        public string CcNumberMasked { get; set; }
        public string CcHash { get; set; }
        public string CcExp { get; set; }
        public string CcStartDate { get; set; }
        public string CcIssueNumber { get; set; }
        public string CcBin { get; set; }
        
        
        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            if (Number == null) throw new ArgumentNullException(nameof(Number));
            
            var list = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("ccnumber", Number),
                new KeyValuePair<string, string>("ccexp", Expiration.ToString("MMyyyy").Remove(2,2))
            };
            if (Cvv != null) list.Add(new KeyValuePair<string, string>("cvv", Cvv));

            return list;
        }
        
        public static CreditCard FromXmlElement(XElement element)
        {
            if (element is null) return null;
            var cc = new CreditCard();

            cc.CcNumberMasked = XmlUtilities.XElementToString(element.Element("cc_number"));
            cc.CcHash = XmlUtilities.XElementToString(element.Element("cc_hash"));
            cc.CcExp = XmlUtilities.XElementToString(element.Element("cc_exp"));
            cc.CcStartDate = XmlUtilities.XElementToString(element.Element("cc_start_date"));
            cc.CcIssueNumber = XmlUtilities.XElementToString(element.Element("cc_issue_number"));
            cc.CcBin = XmlUtilities.XElementToString(element.Element("cc_bin"));
            return cc;
        }
    }
}