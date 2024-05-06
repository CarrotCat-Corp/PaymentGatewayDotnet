using PaymentGatewayDotnet.Shared;
using PaymentGatewayDotnet.Shared.Enums;

namespace PaymentGatewayDotnet.UnitTests.Shared;

[TestFixture]
public class PartialPaymentTests
{
    [Test]
    public void ToKeyValuePairs_WithPartialPaymentData_ReturnsKeyValuePairs()
    {
        // Arrange
        var partialPayment = new PartialPayment
        {
            Id = "123456",
            PartialPaymentType = PartialPaymentType.SettlePartial,
            CompletePartialPayment = true
        };

        // Act
        var keyValuePairs = partialPayment.ToKeyValuePairs();

        // Assert
        Assert.IsNotNull(keyValuePairs);
        Assert.IsInstanceOf<IEnumerable<KeyValuePair<string, string>>>(keyValuePairs);
        var keyValueList = new List<KeyValuePair<string, string>>(keyValuePairs);

        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("partial_payment_id", "123456")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("partial_payments", "settle_partial")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("type", "complete_partial_payment")));
    }

    [Test]
    public void ToKeyValuePairs_WithoutPartialPaymentData_ReturnsKeyValuePairs()
    {
        // Arrange
        var partialPayment = new PartialPayment();

        // Act
        var keyValuePairs = partialPayment.ToKeyValuePairs();

        // Assert
        Assert.IsNotNull(keyValuePairs);
        Assert.IsInstanceOf<IEnumerable<KeyValuePair<string, string>>>(keyValuePairs);
        var keyValueList = new List<KeyValuePair<string, string>>(keyValuePairs);

        Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("partial_payment_id", "123456")));
        Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("partial_payments", "settle_partial")));
        Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("type", "complete_partial_payment")));
    }
}