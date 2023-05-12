using System;
using System.Collections.Generic;

namespace PaymentGatewayDotnet.Model.Shared
{
    public sealed class CreditCard
    {
        public string Number { get; set; }
        public DateTime Expiration { get; set; }
        public string Cvv { get; set; }
        
        
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
    }
}