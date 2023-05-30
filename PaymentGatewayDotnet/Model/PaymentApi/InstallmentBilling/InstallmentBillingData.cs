using System.Collections.Generic;

namespace PaymentGatewayDotnet.Model.PaymentApi.InstallmentBilling
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
            var list = new List<KeyValuePair<string, string>>();
            
            if (Method != null) list.Add(new KeyValuePair<string, string>("billing_method", InstallmentBillingMethodUtils.ToString(Method)));
            if (Number != null) list.Add(new KeyValuePair<string, string>("billing_number", Number.ToString()));
            if (Total != null) list.Add(new KeyValuePair<string, string>("billing_total", Total.ToString("F2")));

            return list;
        }
    }
}