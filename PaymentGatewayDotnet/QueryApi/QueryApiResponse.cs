using System;
using System.Collections.Generic;
using System.Xml.Linq;
using PaymentGatewayDotnet.QueryApi.Data;
using PaymentGatewayDotnet.Shared;
using PaymentGatewayDotnet.Utilities;

namespace PaymentGatewayDotnet.QueryApi
{
    public sealed class QueryApiResponse
    {
        public List<Transaction> Transactions { get; private set; }
        public CustomerVault CustomerVault { get; private set; }
        public List<RecurringSubscription> Subscriptions { get; private set; }
        public InvoiceReport InvoiceReport { get; private set; }
        public List<RecurringPlan> SubscriptionPlans { get; private set; }

        public string Receipt { get; private set; }
        public bool? TestModeEnabled { get; private set; }
    
    

        public static QueryApiResponse FromXmlString(string httpResponse)
        {
            var document = XDocument.Parse(httpResponse);
            if (document == null) throw new Exception("Response is not an XML Document");
            var responseElement = document.Element("nm_response");
            if (responseElement == null) throw new Exception("Error Response");

            
            // transaction
            var transactionElements = responseElement.Elements("transaction");
            var transactions = new List<Transaction>();
            foreach (var transactionElement in transactionElements)
            {
                var transaction = Transaction.FromXmlElement(transactionElement);
                if (transaction != null) transactions.Add(transaction);
            }

            
            // customer_vault
            var customerVaultElement = responseElement.Element("customer_vault");
            var customerVault = CustomerVault.FromXmlElement(customerVaultElement);
        
            
            // subscription
            var subscriptionElements = responseElement.Elements("subscription");
            var subscriptions = new List<RecurringSubscription>();
            foreach (var subscriptionElement in subscriptionElements)
            {
                var subscription = RecurringSubscription.FromXmlElement(subscriptionElement);
                if (subscription != null) subscriptions.Add(subscription);
            }


            // plan
            var planElements = responseElement.Elements("plan");
            var recurringPlans = new List<RecurringPlan>();
            foreach (var element in planElements)
            {
                var plan = RecurringPlan.FromXmlElement(element);
                if (plan != null) recurringPlans.Add(plan);
            }
            
           
            // invoice_report
            var invoiceReportElement = responseElement.Element("invoice_report");
            var invoiceReport = InvoiceReport.FromXmlElement(invoiceReportElement);
            
            
            
            
            // test_mode_enable
            var testModeEnabled = XmlUtilities.XElementToBool(responseElement.Element("test_mode_enabled"));
            
            return new QueryApiResponse()
            {
                Transactions = transactions,
                CustomerVault = customerVault,
                Subscriptions = subscriptions,
                TestModeEnabled = testModeEnabled,
                SubscriptionPlans = recurringPlans,
                InvoiceReport = invoiceReport
            };
        }
    }
}