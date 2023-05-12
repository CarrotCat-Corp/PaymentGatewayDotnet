using NUnit.Framework;
using PaymentGatewayDotnet.Model.Shared;

namespace PaymentGatewayDotnet.UnitTests.Shared;

[TestFixture]
public class MerchantDefinedFieldTests
{
    [Test]
    [TestCase(1, "abc")]
    [TestCase(20, "abc")]
    public void ToKeyValuePairs_AllFieldsAreValid_ValidListOfKeyValues(int number, string value)
    {
        var data = new MerchantDefinedField(number, value);

        var result = data.ToKeyValuePair();

        // Assert.That(result, Does.Contain(new KeyValuePair<string, string>("drivers_license_number", "1234567890123456")));
        // Assert.That(result, Does.Contain(new KeyValuePair<string, string>("drivers_license_dob", "1885-10-07")));
        // Assert.That(result, Does.Contain(new KeyValuePair<string, string>("drivers_license_state", "Ontario")));
    }
}