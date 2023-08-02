using System.Collections.Generic;
using PaymentGatewayDotnet.Contracts;
using PaymentGatewayDotnet.Shared;
using PaymentGatewayDotnet.Shared.Enums;

namespace PaymentGatewayDotnet.PaymentApi.Requests
{
    public class RecurringRequest : PaymentApiRequest, IPaymentApiRequest
    {
        public RecurringAction Action { get; set; }

        /// <summary>
        /// Only relevant for editing an existing plan, the value will be the 'plan_id' that will be edited in this request.
        /// </summary>
        public string CurrentPlanId { get; set; }

        public RecurringPlan Plan { get; set; }
        public RecurringSubscription Subscription { get; set; }

        public Billing Billing { get; set; }

        public RecurringRequest(string securityKey, RecurringAction action) : base(securityKey)
        {
            Action = action;
        }

        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            var list = new List<KeyValuePair<string, string>>();
            list.AddRange(base.ToKeyValuePairs());

            if (Action != null)
                list.Add(new KeyValuePair<string, string>("recurring", RecurringActionUtils.ToString(Action)));
            if (CurrentPlanId != null) list.Add(new KeyValuePair<string, string>("current_plan_id", CurrentPlanId));
            if (Billing != null) list.AddRange(Billing.ToKeyValuePairs());

            if (Plan != null) list.AddRange(Plan.ToKeyValuePairs());
            if (Subscription != null) list.AddRange(Subscription.ToKeyValuePairs());

            return list;
        }
    }
}