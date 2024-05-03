using System.Collections.Generic;
using System.Xml.Linq;
using PaymentGatewayDotnet.Exceptions;
using PaymentGatewayDotnet.Shared.Enums;

namespace PaymentGatewayDotnet.Shared
{
    /// <summary>
    /// Stored Credentials indicator fields
    /// </summary>
    public sealed class StoredCredentialsIndicatorParameters
    {
        /// <summary>
        /// Who initiated the transaction.
        /// </summary>
        public InitiatedBy? InitiatedBy { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public StoredCredentialsIndicator? StoredCredentialsIndicator { get; set; }
        
        /// <summary>
        /// Original payment gateway transaction id.
        /// </summary>
        public string InitialTransactionId { get; set; }
        
        
        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {

            if (InitialTransactionId != null && StoredCredentialsIndicator != null &&
                StoredCredentialsIndicator == Shared.Enums.StoredCredentialsIndicator.Stored)
            {
                throw new InvalidStateException(nameof(StoredCredentialsIndicator), "StoredCredentialsIndicator cannot be set to Stored if initial transaction ID is provided.");
            }
            
            var list = new List<KeyValuePair<string, string>>();
            if (InitialTransactionId != null) list.Add(new KeyValuePair<string, string>("initial_transaction_id", InitialTransactionId));
            if (InitiatedBy != null) list.Add(new KeyValuePair<string, string>("initiated_by", InitiatedByUtils.ToString(InitiatedBy)));
            if (StoredCredentialsIndicator != null) list.Add(new KeyValuePair<string, string>("stored_credential_indicator", StoredCredentialsIndicatorUtils.ToString(StoredCredentialsIndicator)));

            return list;
        }

        public IEnumerable<XElement> ToXmlElements()
        {
            if (InitiatedBy != null) yield return new XElement("initiated-by", InitiatedByUtils.ToString(InitiatedBy));
            if (InitialTransactionId != null) yield return new XElement("initial-transaction-id", InitialTransactionId);
            if (StoredCredentialsIndicator != null) yield return new XElement("stored-credential-indicator", StoredCredentialsIndicatorUtils.ToString(StoredCredentialsIndicator));
        }
    }
}