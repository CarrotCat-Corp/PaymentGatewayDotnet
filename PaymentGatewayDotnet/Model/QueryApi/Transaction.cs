using System.Collections.Generic;
using System.Xml.Linq;
using PaymentGatewayDotnet.Model.Shared;

namespace PaymentGatewayDotnet.Model.QueryApi
{
    public class Transaction
    {
        public string TransactionId { get; set; }
        public string PartialPaymentId { get; set; }
        public decimal? PartialPaymentBalance { get; set; }
        public string PlatformId { get; set; }
        /// <summary>
        /// Action type in gateway docs
        /// </summary>
        public PaymentType? TransactionType { get; set; } //Action Type in NMI docs
        public Condition? Condition { get; set; }
        public string OrderId { get; set; }
        public string AuthorizationCode { get; set; }
        public string PoNumber { get; set; }
        public string OrderDescription { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string CellPhone { get; set; }
        public string CustomerTaxId { get; set; }
        public string CustomerId { get; set; }
        public string Website { get; set; }

        public string ShippingFirstName { get; set; }
        public string ShippingLastName { get; set; }
        public string ShippingAddress1 { get; set; }
        public string ShippingAddress2 { get; set; }
        public string ShippingCompany { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public string ShippingPostalCode { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingEmail { get; set; }
        public string ShippingPhone { get; set; }
        public string ShippingCarrier { get; set; }
        public string TrackingNumber { get; set; }
        public string ShippingDate { get; set; }
        public decimal? Shipping { get; set; }

        public string CcNumber { get; set; }
        public string CcHash { get; set; }
        public string CcExp { get; set; }
        public string Cavv { get; set; }
        public string CavvResult { get; set; }
        public string Xid { get; set; }
        public string Eci { get; set; } // E-commerce Indicator. Examples: "01", "02", "05", or "06"
        public string DirectoryServerId { get; set; }
        public string ThreeDsVersion { get; set; }
        public string AvsResponse { get; set; }
        public string CvvResponse { get; set; }
        public string CardholderAuth { get; set; }
        public string CcStartDate { get; set; }
        public string CcIssueNumber { get; set; }

        public string CheckAccount { get; set; }
        public string CheckHash { get; set; }
        public string CheckName { get; set; }
        public string CheckAba { get; set; }
        public string AccountHolderType { get; set; }
        public string AccountType { get; set; }
        public string SecCode { get; set; }
        public string DriversLicenseNumber { get; set; }
        public string DriversLicenseState { get; set; }
        public string DriversLicenseDob { get; set; }
        public string SocialSecurityNumber { get; set; }

        public string ProcessorId { get; set; }
        public decimal? Tax { get; set; }
        public string Currency { get; set; }
        public decimal? Surcharge { get; set; }
        public decimal? CashDiscount { get; set; }
        public decimal? Tip { get; set; }
        public decimal? CardBalance { get; set; }
        public decimal? CardAvailableBalance { get; set; }
        public string EntryMode { get; set; }
        public string CcBin { get; set; }
        public string CcType { get; set; }
        public string SignatureImage { get; set; }

        public List<Item> Products { get; set; }
        public List<Action> Actions { get; set; }


        public static Transaction FromXmlElement(XElement transactionElement)
        {
            if (transactionElement is null) return null;
            
            var actions = new List<Action>();
            var actionElements = transactionElement.Elements("action");
            foreach (var actionElement in actionElements)
            {
                actions.Add(Action.FromXmlElement(actionElement));
            }
            
            var transaction = new Transaction();
            transaction.TransactionId = XmlUtilities.XElementToString(transactionElement.Element("transaction_id"));
            transaction.PartialPaymentId = XmlUtilities.XElementToString(transactionElement.Element("partial_payment_id"));
            transaction.PartialPaymentBalance = XmlUtilities.XElementToDecimal(transactionElement.Element("partial_payment_balance"));
            transaction.PlatformId = XmlUtilities.XElementToString(transactionElement.Element("platform_id"));
            transaction.TransactionType = PaymentTypeUtils.ParseString(transactionElement.Element("transaction_type")?.Value); //Action Type in NMI docs
            transaction.Condition = ConditionUtils.ParseString(transactionElement.Element("condition")?.Value);
            transaction.OrderId = XmlUtilities.XElementToString(transactionElement.Element("order_id"));
            transaction.AuthorizationCode = XmlUtilities.XElementToString(transactionElement.Element("authorization_code"));
            transaction.PoNumber = XmlUtilities.XElementToString(transactionElement.Element("ponumber"));
            transaction.OrderDescription = XmlUtilities.XElementToString(transactionElement.Element("order_description"));

            transaction.FirstName = XmlUtilities.XElementToString(transactionElement.Element("first_name"));
            transaction.LastName = XmlUtilities.XElementToString(transactionElement.Element("last_name"));
            transaction.Address1 = XmlUtilities.XElementToString(transactionElement.Element("address_1"));
            transaction.Address2 = XmlUtilities.XElementToString(transactionElement.Element("address_2"));
            transaction.Company = XmlUtilities.XElementToString(transactionElement.Element("company"));
            transaction.City = XmlUtilities.XElementToString(transactionElement.Element("city"));
            transaction.State = XmlUtilities.XElementToString(transactionElement.Element("state"));
            transaction.PostalCode = XmlUtilities.XElementToString(transactionElement.Element("postal_code"));
            transaction.Country = XmlUtilities.XElementToString(transactionElement.Element("country"));
            transaction.Email = XmlUtilities.XElementToString(transactionElement.Element("email"));
            transaction.Phone = XmlUtilities.XElementToString(transactionElement.Element("phone"));
            transaction.Fax = XmlUtilities.XElementToString(transactionElement.Element("fax"));
            transaction.CellPhone = XmlUtilities.XElementToString(transactionElement.Element("cell_phone"));
            transaction.CustomerTaxId = XmlUtilities.XElementToString(transactionElement.Element("customertaxid"));
            transaction.CustomerId = XmlUtilities.XElementToString(transactionElement.Element("customerid"));
            transaction.Website = XmlUtilities.XElementToString(transactionElement.Element("website"));

            transaction.ShippingFirstName = XmlUtilities.XElementToString(transactionElement.Element("shipping_first_name"));
            transaction.ShippingLastName = XmlUtilities.XElementToString(transactionElement.Element("shipping_last_name"));
            transaction.ShippingAddress1 = XmlUtilities.XElementToString(transactionElement.Element("shipping_address_1"));
            transaction.ShippingAddress2 = XmlUtilities.XElementToString(transactionElement.Element("shipping_address_2"));
            transaction.ShippingCompany = XmlUtilities.XElementToString(transactionElement.Element("shipping_company"));
            transaction.ShippingCity = XmlUtilities.XElementToString(transactionElement.Element("shipping_city"));
            transaction.ShippingState = XmlUtilities.XElementToString(transactionElement.Element("shipping_state"));
            transaction.ShippingPostalCode = XmlUtilities.XElementToString(transactionElement.Element("shipping_postal_code"));
            transaction.ShippingCountry = XmlUtilities.XElementToString(transactionElement.Element("shipping_country"));
            transaction.ShippingEmail = XmlUtilities.XElementToString(transactionElement.Element("shipping_email"));
            transaction.ShippingPhone = XmlUtilities.XElementToString(transactionElement.Element("shipping_phone"));
            transaction.ShippingCarrier = XmlUtilities.XElementToString(transactionElement.Element("shipping_carrier"));
            transaction.TrackingNumber = XmlUtilities.XElementToString(transactionElement.Element("tracking_number"));
            transaction.ShippingDate = XmlUtilities.XElementToString(transactionElement.Element("shipping_date"));
            transaction.Shipping = XmlUtilities.XElementToDecimal(transactionElement.Element("shipping"), "shipping");

            transaction.CcNumber = XmlUtilities.XElementToString(transactionElement.Element("cc_number"));
            transaction.CcHash = XmlUtilities.XElementToString(transactionElement.Element("cc_hash"));
            transaction.CcExp = XmlUtilities.XElementToString(transactionElement.Element("cc_exp"));
            transaction.Cavv = XmlUtilities.XElementToString(transactionElement.Element("cavv"));
            transaction.CavvResult = XmlUtilities.XElementToString(transactionElement.Element("cavv_result"));
            transaction.Xid = XmlUtilities.XElementToString(transactionElement.Element("xid"));
            transaction.Eci = XmlUtilities.XElementToString(transactionElement.Element("eci"));
            transaction.DirectoryServerId = XmlUtilities.XElementToString(transactionElement.Element("directory_server_id"));
            transaction.ThreeDsVersion = XmlUtilities.XElementToString(transactionElement.Element("three_ds_version"));
            transaction.AvsResponse = XmlUtilities.XElementToString(transactionElement.Element("avs_response"));
            transaction.CvvResponse = XmlUtilities.XElementToString(transactionElement.Element("csc_response"));
            transaction.CardholderAuth = XmlUtilities.XElementToString(transactionElement.Element("cardholder_auth"));
            transaction.CcStartDate = XmlUtilities.XElementToString(transactionElement.Element("cc_start_date"));
            transaction.CcIssueNumber = XmlUtilities.XElementToString(transactionElement.Element("cc_issue_number"));

            transaction.CheckAccount = XmlUtilities.XElementToString(transactionElement.Element("check_account"));
            transaction.CheckHash = XmlUtilities.XElementToString(transactionElement.Element("check_hash"));
            transaction.CheckName = XmlUtilities.XElementToString(transactionElement.Element("check_name"));
            transaction.CheckAba = XmlUtilities.XElementToString(transactionElement.Element("check_aba"));
            transaction.AccountHolderType = XmlUtilities.XElementToString(transactionElement.Element("account_holder_type"));
            transaction.AccountType = XmlUtilities.XElementToString(transactionElement.Element("account_type"));
            transaction.SecCode = XmlUtilities.XElementToString(transactionElement.Element("sec_code"));
            transaction.DriversLicenseNumber = XmlUtilities.XElementToString(transactionElement.Element("drivers_license_number"));
            transaction.DriversLicenseState = XmlUtilities.XElementToString(transactionElement.Element("drivers_license_state"));
            transaction.DriversLicenseDob = XmlUtilities.XElementToString(transactionElement.Element("drivers_license_dob"));
            transaction.SocialSecurityNumber = XmlUtilities.XElementToString(transactionElement.Element("social_security_number"));

            transaction.ProcessorId = XmlUtilities.XElementToString(transactionElement.Element("processor_id"));
            transaction.Tax = XmlUtilities.XElementToDecimal(transactionElement.Element("tax"), "tax");
            transaction.Currency = XmlUtilities.XElementToString(transactionElement.Element("currency"));
            transaction.Surcharge = XmlUtilities.XElementToDecimal(transactionElement.Element("surcharge"), "surcharge");
            transaction.CashDiscount = XmlUtilities.XElementToDecimal(transactionElement.Element("cash_discount"), "cash_discount");
            transaction.Tip = XmlUtilities.XElementToDecimal(transactionElement.Element("tip"), "tip");
            transaction.CardBalance = XmlUtilities.XElementToDecimal(transactionElement.Element("card_balance"), "card_balance");
            transaction.CardAvailableBalance = XmlUtilities.XElementToDecimal(transactionElement.Element("card_available_balance"), "card_available_balance");
            transaction.EntryMode = XmlUtilities.XElementToString(transactionElement.Element("entry_mode"));
            transaction.CcBin = XmlUtilities.XElementToString(transactionElement.Element("cc_bin"));
            transaction.CcType = XmlUtilities.XElementToString(transactionElement.Element("cc_type"));
            transaction.SignatureImage = XmlUtilities.XElementToString(transactionElement.Element("signature_image"));

            transaction.Actions = actions;
            transaction.Products = Item.FromXmlElements(transactionElement.Elements("product"));

            return transaction;
        }
    }
}