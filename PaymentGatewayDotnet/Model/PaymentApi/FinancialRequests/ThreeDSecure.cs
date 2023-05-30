using System.Collections.Generic;

namespace PaymentGatewayDotnet.Model.PaymentApi.FinancialRequests
{
    
    /// <summary>
    /// 3-D Secure verification data
    /// </summary>
    public sealed class ThreeDSecure
    {
        /// <summary>
        /// Set 3D Secure condition. Value used to determine E-commerce indicator (ECI).
        /// Values: 'verified' or 'attempted'
        /// </summary>
        public string CardholderAuth { get; set; }
        
        /// <summary>
        /// Cardholder authentication verification value.
        /// Format: base64 encoded
        /// </summary>
        public string Cavv { get; set; }
        
        /// <summary>
        /// Cardholder authentication transaction id.
        /// Format: base64 encoded
        /// </summary>
        public string Xid { get; set; }
        
        /// <summary>
        /// 3DSecure version.
        /// Examples: "2.0.0" or "2.2.0"
        /// </summary>
        public string ThreeDsVersion { get; set; }
        
        /// <summary>
        /// Directory Server Transaction ID. May be provided as part of 3DSecure 2.0 authentication.
        /// Format: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
        /// </summary>
        public string DirectoryServerId { get; set; }

        /// <summary>
        /// A number that indicates the result of the attempt to authenticate the cardholder. Values are dependent on the card brand. 
        /// </summary>
        public string Esi { get; set; }
        
        
        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            var list = new List<KeyValuePair<string, string>>();
            
            if (CardholderAuth != null) list.Add(new KeyValuePair<string, string>("cardholder_auth", CardholderAuth));
            if (Cavv != null) list.Add(new KeyValuePair<string, string>("cavv", Cavv));
            if (Xid != null) list.Add(new KeyValuePair<string, string>("xid", Xid));
            if (ThreeDsVersion != null) list.Add(new KeyValuePair<string, string>("three_ds_version", ThreeDsVersion));
            if (DirectoryServerId != null) list.Add(new KeyValuePair<string, string>("directory_server_id", DirectoryServerId));
            if (Esi != null) list.Add(new KeyValuePair<string, string>("eci", Esi));

            return list;
        }
    }
}