using System.Collections.Generic;

namespace PaymentGatewayDotnet.PaymentApi.Data.RetailDevises
{
    public sealed class IDTechM130EncryptedData
    {
        /// <summary>
        /// Raw encrypted swipe data
        /// </summary>
        public string Track1 { get; set; }
        
        /// <summary>
        /// Raw encrypted swipe data
        /// </summary>
        public string Track2 { get; set; }
        
        /// <summary>
        /// Raw encrypted swipe data
        /// </summary>
        public string Track3 { get; set; }
        
        /// <summary>
        /// Raw encrypted swipe data
        /// </summary>
        public string Ksn { get; set; }
        
        /// <summary>
        /// Raw encrypted keyed data
        /// </summary>
        public string Data { get; set; }
        
        
        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            var list = new List<KeyValuePair<string, string>>();

            if (Track1 != null) list.Add(new KeyValuePair<string, string>("encrypted_track_1", Track1));
            if (Track2 != null) list.Add(new KeyValuePair<string, string>("encrypted_track_2", Track2));
            if (Track3 != null) list.Add(new KeyValuePair<string, string>("encrypted_track_3", Track3));
            if (Ksn != null) list.Add(new KeyValuePair<string, string>("encrypted_ksn", Ksn));
            if (Data != null) list.Add(new KeyValuePair<string, string>("encrypted_data", Data));

            return list;
        }
    }
}