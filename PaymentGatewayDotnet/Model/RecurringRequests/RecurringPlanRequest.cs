using System.Collections.Generic;
using PaymentGatewayDotnet.Model.Shared;

namespace PaymentGatewayDotnet.Model.RecurringRequests
{
    public sealed class RecurringPlanRequest: PaymentApiRequest, IPaymentApiRequest
    {
        public RecurringAction Action { get; set; }
        
        /// <summary>
        /// Only relevant for editing an existing plan, the value will be the 'plan_id' that will be edited in this request.
        /// </summary>
        public string CurrentPlanId { get; set; }
        
        /// <summary>
        /// The plan amount to be charged each billing cycle.
        /// </summary>
        public decimal Amount { get; set; }
        
        /// <summary>
        /// The number of payments before the recurring plan is complete.
        /// Notes: '0' for until canceled
        /// </summary>
        public int Payments { get; set; }
        
        /// <summary>
        /// The display name of the plan.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// The unique plan ID that references only this recurring plan.
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// How often, in days, to charge the customer. Cannot be set with 'month_frequency' or 'day_of_month'.
        /// </summary>
        public int DayFrequency { get; set; }
        
        /// <summary>
        /// How often, in months, to charge the customer. Cannot be set with 'day_frequency'. Must be set with 'day_of_month'.
        /// Values: 1 through 24
        /// </summary>
        public int MonthFrequency { get; set; }
        
        /// <summary>
        /// The day that the customer will be charged. Cannot be set with 'day_frequency'. Must be set with 'month_frequency'.
        /// Values: 1 through 31 - for months without 29, 30, or 31 days, the charge will be on the last day
        /// </summary>
        public int DayOfMonth { get; set; }
        
        public RecurringPlanRequest(string securityKey) : base(securityKey)
        {
        }
        
        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            
            var list = new List<KeyValuePair<string, string>>();
            
            list.AddRange(base.ToKeyValuePairs());

            if (Action != null) list.Add(new KeyValuePair<string, string>("recurring", RecurringActionUtils.ToString(Action)));
            if (CurrentPlanId != null) list.Add(new KeyValuePair<string, string>("current_plan_id", CurrentPlanId));
            if (Amount != null) list.Add(new KeyValuePair<string, string>("plan_amount", Amount.ToString("F2")));
            if (Payments != null) list.Add(new KeyValuePair<string, string>("plan_payments", Payments.ToString()));
            if (Name != null) list.Add(new KeyValuePair<string, string>("plan_name", Name));
            if (Id != null) list.Add(new KeyValuePair<string, string>("plan_id", Id));
            if (DayFrequency != null) list.Add(new KeyValuePair<string, string>("day_frequency", DayFrequency.ToString()));
            if (MonthFrequency != null) list.Add(new KeyValuePair<string, string>("month_frequency", MonthFrequency.ToString()));
            if (DayOfMonth != null) list.Add(new KeyValuePair<string, string>("day_of_month", DayOfMonth.ToString()));

            return list;
        }

    }
}