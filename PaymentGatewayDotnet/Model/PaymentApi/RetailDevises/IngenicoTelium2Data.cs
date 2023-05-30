using System.Collections.Generic;

namespace PaymentGatewayDotnet.Model.PaymentApi.RetailDevises
{
    public sealed class IngenicoTelium2Data
    {
        /// <summary>
        /// The type of transaction data to be processed.
        /// </summary>
        public IngenicoTelium2EntryMode EntryMode { get; set; }
        
        /// <summary>
        /// EMV Data for the transaction as received from the EMV Chip Card SDK.
        /// </summary>
        public string EmvAuthRequestData { get; set; }
        
        /// <summary>
        /// The EMV - capable card reader. Default is "ingenico_rba".
        /// </summary>
        public string EmvDevice { get; set; } = "ingenico_rba";
        
        /// <summary>
        /// Method used to verify the EMV transaction.
        /// </summary>
        public IngenicoVerificationMethod VerificationMethod { get; set; }
        
        /// <summary>
        /// Raw encrypted data
        /// </summary>
        public string EncryptedKsn { get; set; }
        
        /// <summary>
        /// Raw encrypted data from track 1
        /// </summary>
        public string EncryptedTrack1 { get; set; }
        
        /// <summary>
        /// Raw encrypted data from track 2
        /// </summary>
        public string EncryptedTrack2 { get; set; }
        
        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            var list = new List<KeyValuePair<string, string>>();

            if (EntryMode != null) list.Add(new KeyValuePair<string, string>("entry_mode", IngenicoTelium2EntryModeUtils.ToString(EntryMode)));
            if (EmvAuthRequestData != null) list.Add(new KeyValuePair<string, string>("emv_auth_request_data", EmvAuthRequestData));
            if (EmvDevice != null) list.Add(new KeyValuePair<string, string>("emv_device", EmvDevice));
            if (VerificationMethod != null) list.Add(new KeyValuePair<string, string>("verification_method", IngenicoVerificationMethodUtils.ToString(VerificationMethod)));
            if (EncryptedKsn != null) list.Add(new KeyValuePair<string, string>("encrypted_ksn", EncryptedKsn));
            if (EncryptedTrack1 != null) list.Add(new KeyValuePair<string, string>("encrypted_track_1", EncryptedTrack1));
            if (EncryptedTrack2 != null) list.Add(new KeyValuePair<string, string>("encrypted_track_2", EncryptedTrack2));

            return list;
        }
    }
}