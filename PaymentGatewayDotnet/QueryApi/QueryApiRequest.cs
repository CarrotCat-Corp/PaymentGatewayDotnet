using System;
using System.Collections.Generic;
using System.Linq;
using PaymentGatewayDotnet.Contracts;
using PaymentGatewayDotnet.QueryApi.Enums;
using PaymentGatewayDotnet.Shared;
using PaymentGatewayDotnet.Shared.Enums;

namespace PaymentGatewayDotnet.QueryApi
{
    public class QueryApiRequest: IQueryApiRequest
    {
        public string SecurityKey { get; set; }

        /// <summary>
        /// A combination of values listed below can be passed and should be separated by commas. For example, to retrieve all transactions pending settlement or complete, the following could be used
        /// </summary>
        public IEnumerable<Condition> Conditions { get; set; }

        /// <summary>
        /// Retrieves only transactions with the specified transaction type. Use one of the following to specify payment type:
        /// </summary>
        public PaymentType? TransactionType { get; set; }


        public IEnumerable<TransactionType> ActionTypes { get; set; }

        /// <summary>
        /// Retrieves only transactions with a particular 'transaction source'. A combination of the values can be used and should be separated by commas. For example, to retrieve all transactions with api or recurring actions, use the following
        /// </summary>
        public IEnumerable<Source> Sources { get; set; }

        /// <summary>
        /// transaction_id 	Specify a transaction ID or a comma separated list of transaction IDs to retrieve information on. Alternatively, provide a Subscription ID to retrieve processed (approved and declined) transactions associated with it.
        /// </summary>
        public IEnumerable<string> TransactionIds { get; set; }

        /// <summary>
        /// Set a specific subscription record or comma separated list of records. Using this with a transaction search will return all transactions associated with this subscription. This will return this subscription's payment/plan information when used with report_type=recurring.
        /// </summary>
        public IEnumerable<string> SubscriptionIds { get; set; }

        /// <summary>
        /// Set a specific Invoice ID. Should only be used when report_type=invoicing.
        /// </summary>
        public string InvoiceId { get; set; }

        public string PartialPaymentId { get; set; }
        public string OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string OrderDescription { get; set; }
        public string DriversLicenseNumber { get; set; }
        public string DriversLicenseDob { get; set; }
        public string DriversLicenseState { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Retrieves only transactions with the specified credit card number. You can use either the full number or the last 4 digits of the credit card number.
        /// </summary>
        public string CcNumber { get; set; }

        public IEnumerable<MerchantDefinedField> MerchantDefinedFields { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ReportType? ReportType { get; set; }

        /// <summary>
        /// Retrieves only transactions processed using the specified mobile device. The device IDs for this parameter are available in the License Manager.
        /// <br/>
        /// Use 'any_mobile' to retrieve all mobile transactions.
        /// <br/>
        /// A combination of the values can be used and should be separated by commas.
        /// <br/>
        /// Can not be used with 'mobile_device_nickname'.
        /// <br/>
        /// Example 1: mobile_device_license=D91AC56A-4242-3131-2323-2AE4AA6DB6EB
        /// Example 2: mobile_device_license=any_mobile 
        /// </summary>
        public string MobileDeviceLicence { get; set; }

        /// <summary>
        /// Retrieves only transactions processed using mobile devices with the specified nickname. The nicknames for this parameter are available in the License Manager. Can not be used with 'mobile_device_license' Example (URL encoded): mobile_device_nickname=Jim's%20iPhone
        /// </summary>
        public string MobileDeviceNickname { get; set; }

        /// <summary>
        /// Set a specific Customer Vault record. Should only be used when report_type=customer_vault.
        /// </summary>
        public string CustomerVaultId { get; set; }

        /// <summary>
        /// Allows Customer Vault information to be returned based on the 'created' or 'updated' date. If you would like to query the Customer Vault to view when customer information was created or updated, you must set the report_type variable with the customer_vault value.
        /// If you omit the report_type variable, the system will ignore the date_search variable.
        /// <br/>
        /// Example:
        /// <br/>
        /// report_type=customer_vault&date_search=created,updated&start_date=20170101000000&end_date=20201231232359
        /// </summary>
        public IEnumerable<DateType> DateSearch { get; set; }

        public ushort? ResultLimit { get; set; }
        public ushort? PageNumber { get; set; }
        public ResultOrder? ResultOrder { get; set; }
        public IEnumerable<InvoiceStatus> InvoiceStatuses { get; set; }

        
        public QueryApiRequest(string securityKey)
        {
            SecurityKey = securityKey;
        }
        

        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            var list = new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("security_key", SecurityKey) };

            if (Conditions != null && Conditions.Any()) list.Add(new KeyValuePair<string, string>("condition", string.Join(",",Conditions.Select(a=>ConditionUtils.ToString(a)))));
            if (TransactionType != null) list.Add(new KeyValuePair<string, string>("transaction_type", PaymentTypeUtils.ToShortString(TransactionType)));
            if (ActionTypes != null && ActionTypes.Any()) list.Add(new KeyValuePair<string, string>("action_type", string.Join(",",ActionTypes.Select(a=>TransactionTypeUtils.ToString(a)))));
            if (Sources != null && Sources.Any()) list.Add(new KeyValuePair<string, string>("source", string.Join(",",Sources.Select(a=>SourceUtils.ToString(a)))));
            if (TransactionIds != null && TransactionIds.Any()) list.Add(new KeyValuePair<string, string>("transaction_id", string.Join(",",TransactionIds)));
            if (SubscriptionIds != null && SubscriptionIds.Any()) list.Add(new KeyValuePair<string, string>("subscription_id", string.Join(",",SubscriptionIds)));
            if (InvoiceId != null) list.Add(new KeyValuePair<string, string>("invoice_id", InvoiceId));
            if (PartialPaymentId != null) list.Add(new KeyValuePair<string, string>("partial_payment_id", PartialPaymentId));
            if (OrderId != null) list.Add(new KeyValuePair<string, string>("order_id", OrderId));
            if (FirstName != null) list.Add(new KeyValuePair<string, string>("first_name", FirstName));
            if (LastName != null) list.Add(new KeyValuePair<string, string>("last_name", LastName));
            if (Address1 != null) list.Add(new KeyValuePair<string, string>("address1", Address1));
            if (City != null) list.Add(new KeyValuePair<string, string>("city", City));
            if (State != null) list.Add(new KeyValuePair<string, string>("state", State));
            if (Zip != null) list.Add(new KeyValuePair<string, string>("zip", Zip));
            if (Phone != null) list.Add(new KeyValuePair<string, string>("phone", Phone));
            if (Fax != null) list.Add(new KeyValuePair<string, string>("fax", Fax));
            if (OrderDescription != null) list.Add(new KeyValuePair<string, string>("order_description", OrderDescription));
            if (DriversLicenseNumber != null) list.Add(new KeyValuePair<string, string>("drivers_license_number", DriversLicenseNumber));
            if (DriversLicenseDob != null) list.Add(new KeyValuePair<string, string>("drivers_license_dob", DriversLicenseDob));
            if (DriversLicenseState != null) list.Add(new KeyValuePair<string, string>("drivers_license_state", DriversLicenseState));
            if (Email != null) list.Add(new KeyValuePair<string, string>("email", Email));
            if (CcNumber != null) list.Add(new KeyValuePair<string, string>("cc_number", CcNumber));
            if (StartDate != null) list.Add(new KeyValuePair<string, string>("start_date", StartDate?.ToString("yyyyMMddHHmmss")));
            if (EndDate != null) list.Add(new KeyValuePair<string, string>("end_date", EndDate?.ToString("yyyyMMddHHmmss")));
            if (ReportType != null ) list.Add(new KeyValuePair<string, string>("report_type", ReportTypeUtils.ToString(ReportType)));
            if (MobileDeviceLicence != null) list.Add(new KeyValuePair<string, string>("mobile_device_license", MobileDeviceLicence));
            if (MobileDeviceNickname != null) list.Add(new KeyValuePair<string, string>("mobile_device_nickname", MobileDeviceNickname));
            if (CustomerVaultId != null) list.Add(new KeyValuePair<string, string>("customer_vault_id", CustomerVaultId));
            if (DateSearch != null && DateSearch.Any()) list.Add(new KeyValuePair<string, string>("date_search", string.Join(",",DateSearch.Select(a=>DateTypeUtils.ToString(a)))));
            if (ResultLimit != null) list.Add(new KeyValuePair<string, string>("result_limit", ResultLimit.ToString()));
            if (PageNumber != null) list.Add(new KeyValuePair<string, string>("page_number", PageNumber.ToString()));
            if (ResultOrder != null ) list.Add(new KeyValuePair<string, string>("result_order", ResultOrderUtils.ToString(ResultOrder)));
            if (InvoiceStatuses != null && InvoiceStatuses.Any()) list.Add(new KeyValuePair<string, string>("invoice_status", string.Join(",",InvoiceStatuses.Select(a=>InvoiceStatusUtils.ToString(a)))));
            if (MerchantDefinedFields != null && MerchantDefinedFields.Any())
            {
                list.AddRange(MerchantDefinedFields.Select(item =>
                    new KeyValuePair<string, string>("merchant_defined_field_" + item.Number, item.Value)));
            }

            return list;
        }
    }
}