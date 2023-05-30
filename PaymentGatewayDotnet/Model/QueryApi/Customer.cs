using System;
using System.Collections.Generic;
using System.Xml.Linq;
using PaymentGatewayDotnet.Model.Shared;

namespace PaymentGatewayDotnet.Model.QueryApi
{
public class Customer
{
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
    public string ShippingCarrier { get; set; }
    public string TrackingNumber { get; set; }
    public string ShippingDate { get; set; }
    public decimal? Shipping { get; set; }
    public string CcNumber { get; set; }
    public string CcHash { get; set; }
    public string CcExp { get; set; }
    public string CcStartDate { get; set; }
    public string CcIssueNumber { get; set; }
    public string CheckAccount { get; set; }
    public string CheckHash { get; set; }
    public string CheckAba { get; set; }
    public string CheckName { get; set; }
    public string AccountHolderType { get; set; }
    public string AccountType { get; set; }
    public string SecCode { get; set; }
    public string ProcessorId { get; set; }
    public string CcBin { get; set; }
    public string CcType { get; set; }
    public DateTime? Created { get; set; }
    public DateTime? Updated { get; set; }
    public string AccountUpdated { get; set; }
    public string CustomerVaultId { get; set; }
    
    public List<MerchantDefinedField> MerchantDefinedFields { get; set; }

    public static Customer FromXmlElement(XElement customerElement)
    {
        var merchantDefinedFieldElements = customerElement.Elements("merchant_defined_field");
        var merchantDefinedFields = new List<MerchantDefinedField>();
        foreach (var element in merchantDefinedFieldElements)
        {
            var merchantDefinedField = MerchantDefinedField.FromXmlElement(element);
            if (merchantDefinedField != null) merchantDefinedFields.Add(MerchantDefinedField.FromXmlElement(element));
        }

        return new Customer
        {
            FirstName = XmlUtilities.XElementToString(customerElement.Element("first_name")),
            LastName = XmlUtilities.XElementToString(customerElement.Element("last_name")),
            Address1 = XmlUtilities.XElementToString(customerElement.Element("address_1")),
            Address2 = XmlUtilities.XElementToString(customerElement.Element("address_2")),
            Company = XmlUtilities.XElementToString(customerElement.Element("company")),
            City = XmlUtilities.XElementToString(customerElement.Element("city")),
            State = XmlUtilities.XElementToString(customerElement.Element("state")),
            PostalCode = XmlUtilities.XElementToString(customerElement.Element("postal_code")),
            Country = XmlUtilities.XElementToString(customerElement.Element("country")),
            Email = XmlUtilities.XElementToString(customerElement.Element("email")),
            Phone = XmlUtilities.XElementToString(customerElement.Element("phone")),
            Fax = XmlUtilities.XElementToString(customerElement.Element("fax")),
            CellPhone = XmlUtilities.XElementToString(customerElement.Element("cell_phone")),
            CustomerTaxId = XmlUtilities.XElementToString(customerElement.Element("customertaxid")),
            Website = XmlUtilities.XElementToString(customerElement.Element("website")),
            ShippingFirstName = XmlUtilities.XElementToString(customerElement.Element("shipping_first_name")),
            ShippingLastName = XmlUtilities.XElementToString(customerElement.Element("shipping_last_name")),
            ShippingAddress1 = XmlUtilities.XElementToString(customerElement.Element("shipping_address_1")),
            ShippingAddress2 = XmlUtilities.XElementToString(customerElement.Element("shipping_address_2")),
            ShippingCompany = XmlUtilities.XElementToString(customerElement.Element("shipping_company")),
            ShippingCity = XmlUtilities.XElementToString(customerElement.Element("shipping_city")),
            ShippingState = XmlUtilities.XElementToString(customerElement.Element("shipping_state")),
            ShippingPostalCode = XmlUtilities.XElementToString(customerElement.Element("shipping_postal_code")),
            ShippingCountry = XmlUtilities.XElementToString(customerElement.Element("shipping_country")),
            ShippingEmail = XmlUtilities.XElementToString(customerElement.Element("shipping_email")),
            ShippingCarrier = XmlUtilities.XElementToString(customerElement.Element("shipping_carrier")),
            TrackingNumber = XmlUtilities.XElementToString(customerElement.Element("tracking_number")),
            ShippingDate = XmlUtilities.XElementToString(customerElement.Element("shipping_date")),
            Shipping = XmlUtilities.XElementToDecimal(customerElement.Element("shipping"), "shipping"),
            CcNumber = XmlUtilities.XElementToString(customerElement.Element("cc_number")),
            CcHash = XmlUtilities.XElementToString(customerElement.Element("cc_hash")),
            CcExp = XmlUtilities.XElementToString(customerElement.Element("cc_exp")),
            CcStartDate = XmlUtilities.XElementToString(customerElement.Element("cc_start_date")),
            CcIssueNumber = XmlUtilities.XElementToString(customerElement.Element("cc_issue_number")),
            CheckAccount = XmlUtilities.XElementToString(customerElement.Element("check_account")),
            CheckHash = XmlUtilities.XElementToString(customerElement.Element("check_hash")),
            CheckAba = XmlUtilities.XElementToString(customerElement.Element("check_aba")),
            CheckName = XmlUtilities.XElementToString(customerElement.Element("check_name")),
            AccountHolderType = XmlUtilities.XElementToString(customerElement.Element("account_holder_type")),
            AccountType = XmlUtilities.XElementToString(customerElement.Element("account_type")),
            SecCode = XmlUtilities.XElementToString(customerElement.Element("sec_code")),
            ProcessorId = XmlUtilities.XElementToString(customerElement.Element("processor_id")),
            CcBin = XmlUtilities.XElementToString(customerElement.Element("cc_bin")),
            CcType = XmlUtilities.XElementToString(customerElement.Element("cc_type")),
            Created = XmlUtilities.XElementToDateTime(customerElement.Element("created"),"yyyyMMddHHmmss", "date", "action"),
            Updated = XmlUtilities.XElementToDateTime(customerElement.Element("updated"),"yyyyMMddHHmmss", "date", "action"),
            AccountUpdated = XmlUtilities.XElementToString(customerElement.Element("account_updated")),
            CustomerVaultId = XmlUtilities.XElementToString(customerElement.Element("customer_vault_id")),
            MerchantDefinedFields = merchantDefinedFields
        };
    }
}

}