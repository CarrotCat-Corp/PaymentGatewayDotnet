using System;
using System.Collections.Generic;
using System.Xml.Linq;
using PaymentGatewayDotnet.Shared.Enums;
using PaymentGatewayDotnet.Utilities;

namespace PaymentGatewayDotnet.Shared
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

            if (SecCode != null)
                list.Add(new KeyValuePair<string, string>("sec_code", StandardEntryClassCodeUtils.ToString(SecCode)));
            if (AccountType != null)
                list.Add(new KeyValuePair<string, string>("account_type", AccountTypeUtils.ToString(AccountType)));
            if (AccountHolderType != null)
                list.Add(new KeyValuePair<string, string>("account_holder_type",
                    AccountHolderTypeUtils.ToString(AccountHolderType)));
            if (SocialSecurityNumber != null)
                list.Add(new KeyValuePair<string, string>("social_security_number", SocialSecurityNumber));

            return list;
        }

        public static Ach FromXmlElement(XElement element)
        {
            if (element == null) return null;
            var ach = new Ach();

            ach.SecCode =
                StandardEntryClassCodeUtils.ParseString(XmlUtilities.XElementToString(
                    element.Element("sec_code") ?? element.Element("sec-code")
                ));

            ach.AccountType =
                AccountTypeUtils.ParseString(
                    XmlUtilities.XElementToString(
                        element.Element("account_type") ?? element.Element("billing")?.Element("account-type")
                    ));


            ach.AccountHolderType =
                AccountHolderTypeUtils.ParseString(
                    XmlUtilities.XElementToString(
                        element.Element("account_holder_type") ?? element.Element("billing")?.Element("entity-type")
                    ));

            ach.Account = XmlUtilities.XElementToString(
                element.Element("check_account") ?? element.Element("billing")?.Element("account-number")
                );

            ach.Aba = XmlUtilities.XElementToString(
                element.Element("check_aba") ?? element.Element("billing")?.Element("routing-number")
                );
            
            ach.Name = XmlUtilities.XElementToString(
                element.Element("check_name") ?? element.Element("billing")?.Element("account-name")
                );
            
            ach.SocialSecurityNumber = XmlUtilities.XElementToString(
                element.Element("social_security_number") ?? element.Element("billing")?.Element("social-security-number")
                );

            return ach;
        }
    }
}