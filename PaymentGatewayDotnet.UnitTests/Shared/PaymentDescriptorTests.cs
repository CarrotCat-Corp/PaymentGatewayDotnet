using PaymentGatewayDotnet.Shared;

namespace PaymentGatewayDotnet.UnitTests.Shared;

[TestFixture]
public class PaymentDescriptorTests
{
    [Test]
    public void ToString_ObjectCreated_ValidKeyValidPairs()
    {
        var data = new PaymentDescriptor
        {
            Descriptor = "abc",
            Phone = "abc",
            Address = "abc",
            City = "abc",
            State = "abc",
            Postal = "abc",
            Country = "abc",
            Mcc = "abc",
            MerchantId = "abc",
            Url = "abc"
        };

        var result = data.ToKeyValuePairs().ToList();

        Assert.Multiple(() =>
        {
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("descriptor", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("descriptor_phone", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("descriptor_address", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("descriptor_city", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("descriptor_state", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("descriptor_postal", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("descriptor_country", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("descriptor_mcc", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("descriptor_merchant_id", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("descriptor_url", "abc")));
        });
    }
    
     [Test]
    public void ToKeyValuePairs_WithAllData_ReturnsKeyValuePairs()
    {
        // Arrange
        var paymentDescriptor = new PaymentDescriptor
        {
            Descriptor = "Company XYZ",
            Phone = "+123456789",
            Address = "123 Main St",
            City = "New York",
            State = "NY",
            Postal = "10001",
            Country = "USA",
            Mcc = "1234",
            MerchantId = "MERCHANT123",
            Url = "https://www.example.com"
        };

        // Act
        var keyValuePairs = paymentDescriptor.ToKeyValuePairs();

        // Assert
        Assert.IsNotNull(keyValuePairs);
        Assert.IsInstanceOf<IEnumerable<KeyValuePair<string, string>>>(keyValuePairs);
        var keyValueList = new List<KeyValuePair<string, string>>(keyValuePairs);

        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("descriptor", "Company XYZ")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("descriptor_phone", "+123456789")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("descriptor_address", "123 Main St")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("descriptor_city", "New York")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("descriptor_state", "NY")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("descriptor_postal", "10001")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("descriptor_country", "USA")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("descriptor_mcc", "1234")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("descriptor_merchant_id", "MERCHANT123")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("descriptor_url", "https://www.example.com")));
    }

    [Test]
    public void ToKeyValuePairs_WithNoData_ReturnsEmptyKeyValuePairs()
    {
        // Arrange
        var paymentDescriptor = new PaymentDescriptor();

        // Act
        var keyValuePairs = paymentDescriptor.ToKeyValuePairs();

        // Assert
        Assert.IsNotNull(keyValuePairs);
        Assert.IsEmpty(keyValuePairs);
    }
}