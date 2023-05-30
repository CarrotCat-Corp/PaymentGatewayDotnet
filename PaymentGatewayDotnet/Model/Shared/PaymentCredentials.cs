using System.Collections.Generic;
using PaymentGatewayDotnet.Model.PaymentApi.AchData;

namespace PaymentGatewayDotnet.Model.Shared
{
    public sealed class PaymentCredentials
    {
        /// <summary>
        /// The tokenized version of the customer's card or check information. This will be generated by Collect.js and is usable only once.
        /// </summary>
        public string PaymentToken { get; set; }

        /// <summary>
        /// The encrypted token created when integration directly to the Google Pay SDK.
        /// </summary>
        public string GooglePayToken { get; set; }

        /// <summary>
        /// The encrypted Apple Pay payment data (payment.token.paymentData) from PassKit encoded as a hexadecimal string 
        /// </summary>
        public string ApplePayToken { get; set; }

        /// <summary>
        /// ACH account
        /// </summary>
        public Ach Ach { get; set; }

        /// <summary>
        /// Credit Card
        /// </summary>
        public CreditCard CreditCard { get; set; }

        public PaymentType? PaymentType { get; set; }

        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            var list = new List<KeyValuePair<string, string>>();

            if (PaymentToken != null) list.Add(new KeyValuePair<string, string>("payment_token", PaymentToken));
            if (GooglePayToken != null) list.Add(new KeyValuePair<string, string>("googlepay_payment_data", GooglePayToken));
            if (ApplePayToken != null) list.Add(new KeyValuePair<string, string>("applepay_payment_data", ApplePayToken));
            if (Ach != null) list.AddRange(Ach.ToKeyValuePairs());
            if (CreditCard != null) list.AddRange(CreditCard.ToKeyValuePairs());
            if (PaymentType != null) list.Add(new KeyValuePair<string, string>("payment", PaymentTypeUtils.ToString(PaymentType)));

            return list;
        }
    }
}