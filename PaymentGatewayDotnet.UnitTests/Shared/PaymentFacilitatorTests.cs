

using PaymentGatewayDotnet.Shared;

namespace PaymentGatewayDotnet.UnitTests.Shared;


[TestFixture]
public class PaymentFacilitatorTests
{
    [Test]
    public void ToKeyValuePairs_WithPaymentFacilitatorData_ReturnsKeyValuePairs()
    {
        // Arrange
        var paymentFacilitator = new PaymentFacilitator
        {
            Id = "PF12345",
            SubMerchantId = "SM123",
            SubMerchantEmail = "submerchant@example.com",
            SubMerchantPhone = "123-456-7890",
            SubMerchantPostal = "12345",
            SubMerchantName = "SubMerchant Name",
            SubMerchantAddress = "123 Main St",
            SubMerchantCity = "Cityville",
            SubMerchantState = "Stateville",
            SubMerchantCountry = "Countryville"
        };

        // Act
        var keyValuePairs = paymentFacilitator.ToKeyValuePairs().ToList();

        // Assert
        Assert.That(keyValuePairs, Is.Not.Null);
        Assert.That(keyValuePairs, Is.InstanceOf<IEnumerable<KeyValuePair<string, string>>>());
        var keyValueList = new List<KeyValuePair<string, string>>(keyValuePairs);

        Assert.That(keyValueList, Does.Contain(new KeyValuePair<string, string>("payment_facilitator_id", "PF12345")));
        Assert.That(keyValueList, Does.Contain(new KeyValuePair<string, string>("submerchant_id", "SM123")));
        Assert.That(keyValueList, Does.Contain(new KeyValuePair<string, string>("submerchant_name", "submerchant@example.com")));
        Assert.That(keyValueList, Does.Contain(new KeyValuePair<string, string>("submerchant_address", "123-456-7890")));
        Assert.That(keyValueList, Does.Contain(new KeyValuePair<string, string>("submerchant_city", "12345")));
        Assert.That(keyValueList, Does.Contain(new KeyValuePair<string, string>("submerchant_state", "SubMerchant Name")));
        Assert.That(keyValueList, Does.Contain(new KeyValuePair<string, string>("submerchant_postal", "123 Main St")));
        Assert.That(keyValueList, Does.Contain(new KeyValuePair<string, string>("submerchant_country", "Cityville")));
        Assert.That(keyValueList, Does.Contain(new KeyValuePair<string, string>("submerchant_phone", "Stateville")));
        Assert.That(keyValueList, Does.Contain(new KeyValuePair<string, string>("submerchant_email", "Countryville")));
    }

    [Test]
    public void ToKeyValuePairs_WithoutPaymentFacilitatorData_ReturnsKeyValuePairs()
    {
        // Arrange
        var paymentFacilitator = new PaymentFacilitator();

        // Act
        var keyValuePairs = paymentFacilitator.ToKeyValuePairs();

        // Assert
        Assert.IsNotNull(keyValuePairs);
        Assert.IsInstanceOf<IEnumerable<KeyValuePair<string, string>>>(keyValuePairs);
        var keyValueList = new List<KeyValuePair<string, string>>(keyValuePairs);

        Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("payment_facilitator_id", "PF12345")));
        Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("submerchant_id", "SM123")));
        Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("submerchant_name", "submerchant@example.com")));
        Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("submerchant_address", "123-456-7890")));
        Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("submerchant_city", "12345")));
        Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("submerchant_state", "SubMerchant Name")));
        Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("submerchant_postal", "123 Main St")));
        Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("submerchant_country", "Cityville")));
        Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("submerchant_phone", "Stateville")));
        Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("submerchant_email", "Countryville")));
    }
}
