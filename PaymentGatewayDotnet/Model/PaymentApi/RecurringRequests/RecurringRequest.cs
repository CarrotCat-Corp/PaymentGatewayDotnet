using System.Collections.Generic;
using PaymentGatewayDotnet.Model.Shared;

namespace PaymentGatewayDotnet.Model.PaymentApi.RecurringRequests
{
    public sealed class RecurringRequest: PaymentApiRequest, IPaymentApiRequest
    {
        public RecurringAction Action { get; set; }
        
        /// <summary>
        /// Only relevant for editing an existing plan, the value will be the 'plan_id' that will be edited in this request.
        /// </summary>
        public string CurrentPlanId { get; set; }
        public RecurringPlan Plan { get; set; }
        public RecurringSubscription Subscription { get; set; }
        
        public RecurringRequest(string securityKey) : base(securityKey)
        {
        }
        
        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            
            var list = new List<KeyValuePair<string, string>>();
            list.AddRange(base.ToKeyValuePairs());
            
            if (Action != null) list.Add(new KeyValuePair<string, string>("recurring", RecurringActionUtils.ToString(Action)));
            if (CurrentPlanId != null) list.Add(new KeyValuePair<string, string>("current_plan_id", CurrentPlanId));
            
            list.AddRange(Plan.ToKeyValuePairs());
            list.AddRange(Subscription.ToKeyValuePairs());

            return list;
        }
        

    }
}