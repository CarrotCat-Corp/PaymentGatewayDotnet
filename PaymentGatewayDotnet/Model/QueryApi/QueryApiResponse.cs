using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace PaymentGatewayDotnet.Model.QueryApi
{
    public class QueryApiResponse
    {
        public List<Transaction> Transactions { get; set; }
        public CustomerVault CustomerVault { get; set; }

        public List<Subscription> Subscriptions { get; set; }
    
    

        public static QueryApiResponse FromXmlString(string httpResponse)
        {
            var document = XDocument.Parse(httpResponse);
            if (document == null) throw new Exception("Response is not an XML Document");
            var responseElement = document.Element("nm_response");
            if (responseElement == null) throw new Exception("Error Response");

            var transactionElements = responseElement.Elements("transaction");
            var transactions = new List<Transaction>();
            foreach (var transactionElement in transactionElements)
            {
                var transaction = Transaction.FromXmlElement(transactionElement);
                if (transaction != null) transactions.Add(transaction);
            }

            var customerVaultElement = responseElement.Element("customer_vault");
            var customerVault = CustomerVault.FromXmlElement(customerVaultElement);
        
            var subscriptionElements = responseElement.Elements("subscription");
            var subscriptions = new List<Subscription>();
            foreach (var subscriptionElement in subscriptionElements)
            {
                var subscription = Subscription.FromXmlElement(subscriptionElement);
                if (subscription != null) subscriptions.Add(subscription);
            }
        
            return new QueryApiResponse()
            {
                Transactions = transactions,
                CustomerVault = customerVault,
                Subscriptions = subscriptions
            };
        }
    }
}