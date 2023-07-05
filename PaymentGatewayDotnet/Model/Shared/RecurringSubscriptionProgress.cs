using System;
using System.Xml.Linq;

namespace PaymentGatewayDotnet.Model.Shared
{
    public class RecurringSubscriptionProgress
    {
        
        public DateTime? NextChargeDate { get; set; }
        public int? CompletedPayments { get; set; }
        public int? AttemptedPayments { get; set; }
        public string RemainingPayments { get; set; }
        
        
        public static RecurringSubscriptionProgress FromXmlElement(XElement element)
        {
            if (element is null) return null;
            var subscriptionProgress = new RecurringSubscriptionProgress();
            subscriptionProgress.NextChargeDate = XmlUtilities.XElementToDateTime(element.Element("next_charge_date"), "yyyy-MM-dd", "date", "action");
            subscriptionProgress.CompletedPayments = XmlUtilities.XElementToInt(element.Element("completed_payments"));
            subscriptionProgress.AttemptedPayments = XmlUtilities.XElementToInt(element.Element("attempted_payments"));
            subscriptionProgress.RemainingPayments = XmlUtilities.XElementToString(element.Element("remaining_payments"));
            return subscriptionProgress;
        }
    }
}