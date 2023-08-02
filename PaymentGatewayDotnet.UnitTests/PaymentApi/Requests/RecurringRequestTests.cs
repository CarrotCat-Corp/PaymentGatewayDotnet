using PaymentGatewayDotnet.PaymentApi.Data;
using PaymentGatewayDotnet.PaymentApi.Requests;
using PaymentGatewayDotnet.Shared;
using PaymentGatewayDotnet.Shared.Enums;

namespace PaymentGatewayDotnet.UnitTests.PaymentApi.Requests;

[TestFixture]
public class RecurringRequestTests
{
    [Test]
    public void ToString_PlanObjectCreated_ValidKeyValidPairs()
    {
        var data = new RecurringRequest("abc", RecurringAction.AddPlan)
        {
            CurrentPlanId = "abc",
            
            Plan = new RecurringPlan()
            {
                Amount = decimal.One,
                Payments = 0,
                Name = "abc",
                Id = "aaa",
                DayFrequency = 1,
                MonthFrequency = 1,
                DayOfMonth = 1 
            }
            
        };

        var result = data.ToKeyValuePairs().ToList();

        Assert.Multiple(() =>
        {
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("recurring", "add_plan")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("current_plan_id", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("plan_payments", "0")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("plan_amount", "1.00")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("plan_name", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("plan_id", "aaa")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("day_frequency", "1")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("month_frequency", "1")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("day_of_month", "1")));
        });
    }
    
    [Test]
    public void ToString_SubscriptionObjectCreated_ValidKeyValidPairs()
    {
        var data = new RecurringRequest("abc",RecurringAction.AddSubscription)
        {
            Action = RecurringAction.AddSubscription,
            Subscription = new RecurringSubscription
            {
                Id = "abc",
                PlanId = "abc",
                StartDate = DateTime.Parse("1550-02-01"),
                CustomerReceipt = true,
                SourceTransactionId = "abc",
                PaymentCredentials = new PaymentCredentials
                {
                    PaymentToken ="abc"
                }
            }

        };

        var result = data.ToKeyValuePairs().ToList();

        Assert.Multiple(() =>
        {
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("recurring", "add_subscription")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("subscription_id", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("plan_id", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("start_date", "15500201")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("customer_receipt", "true")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("source_transaction_id", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("payment_token", "abc")));
        });
    }
}