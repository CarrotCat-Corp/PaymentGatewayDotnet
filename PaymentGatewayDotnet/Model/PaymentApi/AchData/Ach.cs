using System;
using System.Collections.Generic;

namespace PaymentGatewayDotnet.Model.PaymentApi.AchData
{
    public sealed class Ach
    {
        /// <summary>
        /// The Standard Entry Class code of the ACH transaction.
        /// </summary>
        public StandardEntryClassCode? SecCode { get; set; }
        
        /// <summary>
        /// The ACH account entity of the customer.
        /// </summary>
        public AccountType? AccountType { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public AccountHolderType? AccountHolderType { get; set; }
        
        /// <summary>
        /// The customer's bank account number.
        /// </summary>
        public string Account { get; set; }
        
        /// <summary>
        /// The customer's bank routing number.
        /// </summary>
        public string Aba { get; set; }
        
        /// <summary>
        /// The name on the customer's ACH account.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Customer's social security number, checked against bad check writers database if check verification is enabled.
        /// </summary>
        public string SocialSecurityNumber { get; set; }
        
        
        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            if (Name == null) throw new ArgumentNullException(nameof(Name));
            if (Aba == null) throw new ArgumentNullException(nameof(Aba));
            if (Account == null) throw new ArgumentNullException(nameof(Account));
            
            var list = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("checkname", Name),
                new KeyValuePair<string, string>("checkaba", Aba),
                new KeyValuePair<string, string>("checkaccount", Account),
            };

            if (SecCode != null) list.Add(new KeyValuePair<string, string>("sec_code", StandardEntryClassCodeUtils.ToString(SecCode)));
            if (AccountType != null) list.Add(new KeyValuePair<string, string>("account_type", AccountTypeUtils.ToString(AccountType)));
            if (AccountHolderType != null) list.Add(new KeyValuePair<string, string>("account_holder_type", AccountHolderTypeUtils.ToString(AccountHolderType)));
            if (SocialSecurityNumber != null) list.Add(new KeyValuePair<string, string>("social_security_number", SocialSecurityNumber));

            return list;
        }
    }
}