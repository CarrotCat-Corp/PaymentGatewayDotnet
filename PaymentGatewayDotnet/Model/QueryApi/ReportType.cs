namespace PaymentGatewayDotnet.Model.QueryApi
{
public enum ReportType
{
    Undefined,
    
    /// <summary>
    /// Will return an html receipt for a specified transaction id.
    /// </summary>
    Receipt,
    
    
    /// <summary>
    /// Set the Query API to return Customer Vault data.
    /// <br/>
    /// Allows Customer Vault information or a html receipt to be returned. If you would like to query the Customer Vault to view what customer information is stored in the Customer Vault, you must set the customer_vault variable. If you omit the customer_vault_id, the system will return all customers that are stored in the vault. If you include a customer_vault_id, it will return the customer record associated with that ID.
    /// <br/><br/>
    /// <![CDATA[Example: report_type=customer_vault&customer_vault _id=123456789]]>
    /// </summary>
    CustomerVault,
    
    
    /// <summary>
    /// Set the Query API to return subscription data.
    /// </summary>
    Recurring,
    
    
    /// <summary>
    /// Set the Query API to return plan data.
    /// </summary>
    RecurringPlans,
    
    
    /// <summary>
    /// Set the Query API to return invoicing data.
    /// </summary>
    Invoicing,
    
    
    /// <summary>
    /// Will return Processor details a user has permissions for. Specify a "user" by querying with that security key.
    /// </summary>
    GatewayProcessors,
    
    
    /// <summary>
    /// Will return Customer Vault data that has been updated using the Account Updater service.
    /// </summary>
    AccountUpdater,
    
    
    /// <summary>
    /// Will return whether the account has test mode active or inactive.
    /// </summary>
    TestModeStatus
}


public static class ReportTypeUtils
{
    public static ReportType ParseString(string type)
    {
        switch (type?.ToLower())
        {
            case "receipt":
                return ReportType.Receipt;
            case "customer_vault":
                return ReportType.CustomerVault;
            case "recurring":
                return ReportType.Recurring;
            case "recurring_plans":
                return ReportType.RecurringPlans;
            case "invoicing":
                return ReportType.Invoicing;
            case "gateway_processors":
                return ReportType.GatewayProcessors;
            case "account_updater":
                return ReportType.AccountUpdater;
            case "test_mode_status":
                return ReportType.TestModeStatus;
            default:
                return ReportType.Undefined;
        }
    }


    public static string ToString(ReportType? type)
    {
        switch (type)
        {
            case ReportType.Receipt:
                return "receipt";
            case ReportType.CustomerVault:
                return "customer_vault";
            case ReportType.Recurring:
                return "recurring";
            case ReportType.RecurringPlans:
                return "recurring_plans";
            case ReportType.Invoicing:
                return "invoicing";
            case ReportType.GatewayProcessors:
                return "gateway_processors";
            case ReportType.AccountUpdater:
                return "account_updater";
            case ReportType.TestModeStatus:
                return "test_mode_status";
            default:
                return "";
        }
    }
}
}