using System.Collections.Generic;

namespace PaymentGatewayDotnet.Model.Shared
{
    /// <summary>
    /// Represents client billing information
    /// </summary>
    public sealed class Billing
    {
        /// <summary>
        /// In Customer Vault transactions, Billing id to be assigned or updated. I
        /// f none is provided, one will be created or the billing id with priority '1' will be updated.
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Cardholder's first name.
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// Cardholder's last name
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Cardholder's company
        /// </summary>
        public string Company { get; set; }
        
        /// <summary>
        /// Billing phone number
        /// </summary>
        public string Phone { get; set; }
        
        /// <summary>
        /// Billing fax number
        /// </summary>
        public string Fax { get; set; }
        
        /// <summary>
        /// Billing email address
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// Card billing address
        /// Required for Address Verification Service
        /// </summary>
        public Address Address { get; set; }
        
        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs(string prefix = null)
        {
            if (prefix != null) prefix = prefix + "_";

            var list = new List<KeyValuePair<string, string>>();

            if (Id != null) list.Add(new KeyValuePair<string, string>(prefix+"billing_id", Id));
            if (FirstName != null) list.Add(new KeyValuePair<string, string>(prefix+"first_name", FirstName));
            if (LastName != null) list.Add(new KeyValuePair<string, string>(prefix+"last_name", LastName));
            if (Company != null) list.Add(new KeyValuePair<string, string>(prefix+"company", Company));
            if (Phone != null) list.Add(new KeyValuePair<string, string>(prefix+"phone", Phone));
            if (Fax != null) list.Add(new KeyValuePair<string, string>(prefix+"fax", Fax));
            if (Email != null) list.Add(new KeyValuePair<string, string>(prefix+"email", Email));
            
            
            if (Address != null) list.AddRange(Address.ToKeyValuePairs(prefix));

            return list;
        }
    }
}