using NUnit.Framework;
using PaymentGatewayDotnet.Model.PartialPayments;

namespace PaymentGatewayDotnet.UnitTests.PartialPayments;

[TestFixture]
public class PartialPaymentTests
{
    [Test]
    public void ToString_ObjectCreated_ValidKeyValidPairs()
    {
        var data = new PartialPayment
        {
            Id = "123",
            PartialPaymentType = PartialPaymentType.SettlePartial,
            CompletePartialPayment = true
        };

        var result = data.ToKeyValuePairs().ToList();

        Assert.Multiple(() =>
        {
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("partial_payment_id", "123")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("partial_payments", "settle_partial")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("type", "complete_partial_payment")));
        });
    }
}