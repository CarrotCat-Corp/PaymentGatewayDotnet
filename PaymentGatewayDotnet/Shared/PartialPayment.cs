using System.Collections.Generic;
using System.Xml.Linq;
using PaymentGatewayDotnet.Shared.Enums;
using PaymentGatewayDotnet.Utilities;

namespace PaymentGatewayDotnet.Shared
{
    public sealed class PartialPayment
    {
        /// <summary>
        /// Unique identifier returned when making the original transaction. This should only be used for secondary transactions.
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// This variable allows the following two values to be passed to it:
        /// <br/><br/>
        /// <b>settle_partial</b>: Settles any amount of tender collected (captured partial auth's and approved partial sales) at cut off.
        /// <br/><br/>
        /// <b>payment_in_full</b>: Required that any split tendered transaction is collected in-full before settlement gets initiated.
        /// </summary>
        public PartialPaymentType? PartialPaymentType { get; set; }

        public decimal? Balance { get; set; }

        /// <summary>
        /// This variable if set to true will complete a payment_in_full transaction that has not been collected in full. This allows industries that require payment_in_full but subsequently decide to still settle the transaction even though it has not been collected in full.
        /// </summary>
        public bool CompletePartialPayment { get; set; } = false;
        
        
        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            var list = new List<KeyValuePair<string, string>>();

            if (Id != null) list.Add(new KeyValuePair<string, string>("partial_payment_id", Id));
            if (PartialPaymentType != null) list.Add(new KeyValuePair<string, string>("partial_payments", PartialPaymentTypeUtils.ToString(PartialPaymentType)));
            if (CompletePartialPayment) list.Add(new KeyValuePair<string, string>("type", "complete_partial_payment"));

            return list;
        }

        public IEnumerable<XElement> ToXmlElements()
        {
            if (Id != null) yield return new XElement("partial-payment-id", Id);
            if (PartialPaymentType != null) yield return new XElement("partial-payments", PartialPaymentTypeUtils.ToString(PartialPaymentType)); 
        }

        public static PartialPayment FromXmlElement(XElement element)
        {
            return new PartialPayment
            {
                Id = XmlUtilities.XElementToString(element.Element("partial-payment-id")),
                Balance = XmlUtilities.XElementToDecimal(element.Element("partial-payment-balance"))
            };
        }
    }
}