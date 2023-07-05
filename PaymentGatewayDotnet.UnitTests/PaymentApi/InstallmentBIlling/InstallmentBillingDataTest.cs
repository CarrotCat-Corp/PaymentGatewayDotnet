using PaymentGatewayDotnet.Model.PaymentApi.InstallmentBilling;

namespace PaymentGatewayDotnet.UnitTests.PaymentApi.InstallmentBIlling;

[TestFixture]
public class InstallmentBillingDataTest
{
    [Test]
    public void ToString_ObjectCreated_ValidKeyValidPairs()
    {
        var data = new InstallmentBillingData
        {
            Method = InstallmentBillingMethod.Recurring,
            Number = 1,
            Total = 2
        };

        var result = data.ToKeyValuePairs().ToList();

        Assert.Multiple(() =>
        {
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("billing_method", "recurring")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("billing_number", "1")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("billing_total", "2.00")));
        });
    }
}