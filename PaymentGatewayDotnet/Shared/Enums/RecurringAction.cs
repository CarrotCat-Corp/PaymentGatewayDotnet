namespace PaymentGatewayDotnet.Shared.Enums
{
    public enum RecurringAction
    {
        Undefined,
        /// <summary>
        /// Add a recurring plan that subscriptions can be added to in the future.
        /// </summary>
        AddPlan,
        
        /// <summary>
        /// Edit an existing recurring plan.
        /// </summary>
        EditPlan,
        
        /// <summary>
        /// Associate payment information with a recurring plan.
        /// </summary>
        AddSubscription,
        
        /// <summary>
        /// Add a custom recurring subscription that is NOT associated with an existing plan
        /// </summary>
        AddCustomSubscription,
        
        /// <summary>
        /// Update the subscription's billing information.
        /// </summary>
        UpdateSubscription,
        
        /// <summary>
        /// Delete the subscription. Customer will no longer be charged.
        /// </summary>
        DeleteSubscription
    }
    
    public static class RecurringActionUtils
    {
        public static RecurringAction ParseString(string value)
        {
            switch (value?.ToLower())
            {
                case "add_plan": return RecurringAction.AddPlan;
                case "edit_plan": return RecurringAction.EditPlan;
                case "add_subscription": return RecurringAction.AddSubscription;
                case "add_custom_subscription": return RecurringAction.AddCustomSubscription;
                case "update_subscription": return RecurringAction.UpdateSubscription;
                case "delete_subscription": return RecurringAction.DeleteSubscription;
                default: return RecurringAction.Undefined;
            }
        }
        
        public static string ToString(RecurringAction? value)
        {
            switch (value)
            {
                case RecurringAction.AddPlan: return "add_plan";
                case RecurringAction.EditPlan: return "edit_plan";
                case RecurringAction.AddSubscription: return "add_subscription";
                case RecurringAction.AddCustomSubscription: return "add_subscription";
                case RecurringAction.UpdateSubscription: return "update_subscription";
                case RecurringAction.DeleteSubscription: return "delete_subscription";
                default: return "";
            }
        }
    }
}