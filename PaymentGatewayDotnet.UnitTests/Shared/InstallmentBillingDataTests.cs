using PaymentGatewayDotnet.Shared;
using PaymentGatewayDotnet.Shared.Enums;

namespace PaymentGatewayDotnet.UnitTests.Shared;

[TestFixture]
public class InstallmentBillingDataTests
{
    [Test]
    public void ToKeyValuePairs_WithMethod_ReturnsKeyValuePairs()
    {
        // Arrange
        var installmentData = new InstallmentBillingData
        {
            Method = InstallmentBillingMethod.Recurring,
            Number = 5,
            Total = 500.00m
        };

        // Act
        var keyValuePairs = installmentData.ToKeyValuePairs()?.ToList();

        // Assert
        Assert.That(keyValuePairs, Is.Not.Null);
        Assert.That(keyValuePairs, Is.InstanceOf<IEnumerable<KeyValuePair<string, string>>>());

        Assert.Multiple(() =>
        {
            Assert.That(keyValuePairs, Does.Contain(new KeyValuePair<string, string>("billing_method", "recurring")));
            Assert.That(keyValuePairs, Does.Contain(new KeyValuePair<string, string>("billing_number", "5")));
            Assert.That(keyValuePairs, Does.Contain(new KeyValuePair<string, string>("billing_total", "500.00")));
        });
    }

    [Test]
    public void ToKeyValuePairs_WithoutMethod_ReturnsKeyValuePairs()
    {
        // Arrange
        var installmentData = new InstallmentBillingData
        {
            Number = 2,
            Total = 200.00m
        };

        // Act
        var keyValuePairs = installmentData.ToKeyValuePairs()?.ToList();

        // Assert
        Assert.That(keyValuePairs, Is.Not.Null);
        Assert.That(keyValuePairs, Is.InstanceOf<IEnumerable<KeyValuePair<string, string>>>());
        Assert.Multiple(() =>
        {
            Assert.That(keyValuePairs != null && keyValuePairs.Contains(new KeyValuePair<string, string>("billing_number", "2")), Is.True);
            Assert.That(keyValuePairs != null && keyValuePairs.Contains(new KeyValuePair<string, string>("billing_total", "200.00")), Is.True);
        });
    }
}
