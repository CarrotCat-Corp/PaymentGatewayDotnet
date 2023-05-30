using System.Xml.Linq;
using PaymentGatewayDotnet.Model.Shared;

namespace PaymentGatewayDotnet.Model.QueryApi
{
    public class SubscriptionPlan
    {
        public string PlanId { get; set; }
        public string PlanName { get; set; }
        public decimal? PlanAmount { get; set; }
        public int? PlanPayments { get; set; }
        public int? MonthFrequency { get; set; }
        public int? DayOfMonth { get; set; }
    
    
        public static SubscriptionPlan FromXmlElement(XElement subscriptionPlanElement)
        {
            if (subscriptionPlanElement is null) return null;
 
            var subscriptionPlan = new SubscriptionPlan();
            subscriptionPlan.PlanId = XmlUtilities.XElementToString(subscriptionPlanElement.Element("plan_id"));
            subscriptionPlan.PlanName = XmlUtilities.XElementToString(subscriptionPlanElement.Element("plan_name"));
            subscriptionPlan.PlanAmount = XmlUtilities.XElementToDecimal(subscriptionPlanElement.Element("plan_amount"));
            subscriptionPlan.PlanPayments = XmlUtilities.XElementToInt(subscriptionPlanElement.Element("plan_payments"));
            subscriptionPlan.MonthFrequency = XmlUtilities.XElementToInt(subscriptionPlanElement.Element("month_frequency"));
            subscriptionPlan.DayOfMonth = XmlUtilities.XElementToInt(subscriptionPlanElement.Element("day_of_month"));

            return subscriptionPlan;
        }
    }
}