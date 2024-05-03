using System.Collections.Generic;

namespace PaymentGatewayDotnet.Shared.RetailDevises
{
    public sealed class UnencryptedRetailMagneticStripeData
    {
        /// <summary>
        /// Raw Magnetic Stripe Data from track 1
        /// </summary>
        public string Track1 { get; set; }
        
        /// <summary>
        /// Raw Magnetic Stripe Data from track 2
        /// </summary>
        public string Track2 { get; set; }
        
        /// <summary>
        /// Raw Magnetic Stripe Data from track 3
        /// </summary>
        public string Track3 { get; set; }
        
        
        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            var list = new List<KeyValuePair<string, string>>();

            if (Track1 != null) list.Add(new KeyValuePair<string, string>("track_1", Track1));
            if (Track2 != null) list.Add(new KeyValuePair<string, string>("track_2", Track2));
            if (Track3 != null) list.Add(new KeyValuePair<string, string>("track_3", Track3));

            return list;
        }
    }
}