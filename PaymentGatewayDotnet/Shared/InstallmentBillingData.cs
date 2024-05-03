using System.Collections.Generic;
using System.Xml.Linq;
using PaymentGatewayDotnet.Shared.Enums;

namespace PaymentGatewayDotnet.Shared
{
    /// <summary>
    /// Installment billing information
    /// </summary>
    public sealed class InstallmentBillingData
    {
        /// <summary>
        /// Should be set to 'recurring' to mark payment as a recurring transaction or 'installment' to mark payment as an installment transaction.
        /// </summary>
        public InstallmentBillingMethod Method { get; set; }

        /// <summary>
        /// Specify installment billing number, on supported processors. For use when "billing_method" is set to installment.
        /// Values: 0-99
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Specify installment billing total on supported processors. For use when "billing_method" is set to installment.
        /// </summary>
        public decimal Total { get; set; }
        
        
        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            if (Method != null) yield return new KeyValuePair<string, string>("billing_method", InstallmentBillingMethodUtils.ToString(Method));
            if (Number != null) yield return new KeyValuePair<string, string>("billing_number", Number.ToString());
            if (Total != null) yield return new KeyValuePair<string, string>("billing_total", Total.ToString("F2"));
        }

        public IEnumerable<XElement> ToXmlElements()
        {
            if (Method != null) yield return new XElement("billing-method", InstallmentBillingMethodUtils.ToString(Method));
            if (Number != null) yield return new XElement("billing-number", Number.ToString());
            if (Total != null) yield return new XElement("billin-total", Total.ToString("F2"));
        }
    }
}