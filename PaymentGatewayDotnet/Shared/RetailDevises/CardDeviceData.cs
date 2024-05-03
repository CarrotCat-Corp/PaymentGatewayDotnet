using System.Collections.Generic;

namespace PaymentGatewayDotnet.Shared.RetailDevises
{
    public sealed class CardDeviceData
    {
        public UnencryptedRetailMagneticStripeData UnencryptedRetailMagneticStripeData { get; set; }
        public MagTekMagensaEncryptedMagneticStripeData MagTekMagensaEncryptedMagneticStripeData { get; set; }
        public IDTechM130EncryptedData IDTechM130EncryptedData { get; set; }
        public IngenicoTelium2Data IngenicoTelium2Data { get; set; }
        
        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            var list = new List<KeyValuePair<string, string>>();
            
            if (UnencryptedRetailMagneticStripeData != null) list.AddRange(UnencryptedRetailMagneticStripeData.ToKeyValuePairs());
            if (MagTekMagensaEncryptedMagneticStripeData != null) list.AddRange(MagTekMagensaEncryptedMagneticStripeData.ToKeyValuePairs());
            if (IDTechM130EncryptedData != null) list.AddRange(IDTechM130EncryptedData.ToKeyValuePairs());
            if (IngenicoTelium2Data != null) list.AddRange(IngenicoTelium2Data.ToKeyValuePairs());

            return list;
        }
    }
}