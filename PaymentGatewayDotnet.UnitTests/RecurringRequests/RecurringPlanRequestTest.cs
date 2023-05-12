

using PaymentGatewayDotnet.Model.RecurringRequests;

namespace PaymentGatewayDotnet.UnitTests.RecurringRequests;

[TestFixture]
public class RecurringPlanRequestTest
{
    [Test]
    public void ToString_ObjectCreated_ValidKeyValidPairs()
    {
        var data = new RecurringPlanRequest("abc")
        {
            Action = RecurringAction.AddPlan,
            CurrentPlanId = "abc",
            Amount = decimal.One,
            Payments = 0,
            Name = "abc",
            Id = "aaa",
            DayFrequency = 1,
            MonthFrequency = 1,
            DayOfMonth = 1
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
}