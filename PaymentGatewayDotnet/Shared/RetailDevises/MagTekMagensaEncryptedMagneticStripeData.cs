using System.Collections.Generic;

namespace PaymentGatewayDotnet.Shared.RetailDevises
{
    public sealed class MagTekMagensaEncryptedMagneticStripeData
    {
        /// <summary>
        /// Raw MagTek Magensa Data from track 1
        /// </summary>
        public string Track1 { get; set; }

        /// <summary>
        /// Raw MagTek Magensa Data from track 2
        /// </summary>
        public string Track2 { get; set; }


        public string Ksn { get; set; }


        public string Magneprint { get; set; }


        public string MagneprintStatus { get; set; }


        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            var list = new List<KeyValuePair<string, string>>();

            if (Track1 != null) list.Add(new KeyValuePair<string, string>("magnesafe_track_1", Track1));
            if (Track2 != null) list.Add(new KeyValuePair<string, string>("magnesafe_track_2", Track2));
            if (Ksn != null) list.Add(new KeyValuePair<string, string>("magnesafe_magneprint", Ksn));
            if (Magneprint != null) list.Add(new KeyValuePair<string, string>("magnesafe_ksn", Magneprint));
            if (MagneprintStatus != null) list.Add(new KeyValuePair<string, string>("magnesafe_magneprint_status", MagneprintStatus));

            return list;
        }
    }
}