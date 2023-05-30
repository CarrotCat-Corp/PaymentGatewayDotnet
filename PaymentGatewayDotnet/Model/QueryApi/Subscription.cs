using System;
using System.Collections.Generic;
using System.Xml.Linq;
using PaymentGatewayDotnet.Model.Shared;

namespace PaymentGatewayDotnet.Model.QueryApi
{
    public class Subscription
    {
        public string SubscriptionId { get; set; }
        public SubscriptionPlan Plan { get; set; }
        public DateTime? NextChargeDate { get; set; }
        public int? CompletedPayments { get; set; }
        public int? AttemptedPayments { get; set; }
        public string RemainingPayments { get; set; }
        public string PoNumber { get; set; }
        public string OrderId { get; set; }
        public string OrderDescription { get; set; }
        public decimal? Shipping { get; set; }
        public decimal? Tax { get; set; }
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
        public string CcNumber { get; set; }
        public string CcHash { get; set; }
        public string CcExp { get; set; }
        public string CcStartDate { get; set; }
        public string CcIssueNumber { get; set; }
        public string CcBin { get; set; }
        public string ProcessorId { get; set; }

        public List<MerchantDefinedField> MerchantDefinedFields { get; set; }

        public static Subscription FromXmlElement(XElement subscriptionElement)
        {
            if (subscriptionElement is null) return null;

            var subscription = new Subscription();
            subscription.SubscriptionId = XmlUtilities.XElementToString(subscriptionElement.Element("subscription_id"));
            subscription.Plan = SubscriptionPlan.FromXmlElement(subscriptionElement.Element("plan"));
            subscription.NextChargeDate =
                XmlUtilities.XElementToDateTime(subscriptionElement.Element("next_charge_date"), "yyyy-MM-dd", "date", "action");
            subscription.CompletedPayments = XmlUtilities.XElementToInt(subscriptionElement.Element("completed_payments"));
            subscription.AttemptedPayments = XmlUtilities.XElementToInt(subscriptionElement.Element("attempted_payments"));
            subscription.RemainingPayments = XmlUtilities.XElementToString(subscriptionElement.Element("remaining_payments"));

            subscription.PoNumber = XmlUtilities.XElementToString(subscriptionElement.Element("ponumber"));
            subscription.OrderId = XmlUtilities.XElementToString(subscriptionElement.Element("orderid"));
            subscription.OrderDescription = XmlUtilities.XElementToString(subscriptionElement.Element("order_description"));
            subscription.Shipping = XmlUtilities.XElementToDecimal(subscriptionElement.Element("shipping"), "shipping");
            subscription.Tax = XmlUtilities.XElementToDecimal(subscriptionElement.Element("tax"), "tax");

            subscription.FirstName = XmlUtilities.XElementToString(subscriptionElement.Element("first_name"));
            subscription.LastName = XmlUtilities.XElementToString(subscriptionElement.Element("last_name"));
            subscription.Address1 = XmlUtilities.XElementToString(subscriptionElement.Element("address_1"));
            subscription.Address2 = XmlUtilities.XElementToString(subscriptionElement.Element("address_2"));
            subscription.Company = XmlUtilities.XElementToString(subscriptionElement.Element("company"));
            subscription.City = XmlUtilities.XElementToString(subscriptionElement.Element("city"));
            subscription.State = XmlUtilities.XElementToString(subscriptionElement.Element("state"));
            subscription.PostalCode = XmlUtilities.XElementToString(subscriptionElement.Element("postal_code"));
            subscription.Country = XmlUtilities.XElementToString(subscriptionElement.Element("country"));
            subscription.Email = XmlUtilities.XElementToString(subscriptionElement.Element("email"));
            subscription.Phone = XmlUtilities.XElementToString(subscriptionElement.Element("phone"));
            subscription.Fax = XmlUtilities.XElementToString(subscriptionElement.Element("fax"));
            subscription.CellPhone = XmlUtilities.XElementToString(subscriptionElement.Element("cell_phone"));
            subscription.CustomerTaxId = XmlUtilities.XElementToString(subscriptionElement.Element("customertaxid"));
            subscription.Website = XmlUtilities.XElementToString(subscriptionElement.Element("website"));

            subscription.CcNumber = XmlUtilities.XElementToString(subscriptionElement.Element("cc_number"));
            subscription.CcHash = XmlUtilities.XElementToString(subscriptionElement.Element("cc_hash"));
            subscription.CcExp = XmlUtilities.XElementToString(subscriptionElement.Element("cc_exp"));
            subscription.CcStartDate = XmlUtilities.XElementToString(subscriptionElement.Element("cc_start_date"));
            subscription.CcIssueNumber = XmlUtilities.XElementToString(subscriptionElement.Element("cc_issue_number"));
            subscription.CcBin = XmlUtilities.XElementToString(subscriptionElement.Element("cc_bin"));

            subscription.ProcessorId = XmlUtilities.XElementToString(subscriptionElement.Element("processor_id"));

            var merchantDefinedFieldElements = subscriptionElement.Elements("merchant_defined_field");
            var merchantDefinedFields = new List<MerchantDefinedField>();
            foreach (var element in merchantDefinedFieldElements)
            {
                var merchantDefinedField = MerchantDefinedField.FromXmlElement(element);
                if (merchantDefinedField != null) merchantDefinedFields.Add(MerchantDefinedField.FromXmlElement(element));
            }

            subscription.MerchantDefinedFields = merchantDefinedFields;
            return subscription;
        }
    }
}