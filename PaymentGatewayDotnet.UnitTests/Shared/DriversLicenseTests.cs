using NUnit.Framework;
using PaymentGatewayDotnet.Model.Shared;

namespace PaymentGatewayDotnet.UnitTests.Shared;

[TestFixture]
public class DriversLicenseTests
{
    [Test]
    public void ToKeyValuePairs_AllFieldsAreValid_ValidListOfKeyValues()
    {
        var data = new DriversLicense()
        {
            Number = "1234567890123456",
            DateOfBirth = new DateTime(1885, 10, 7),
            State = "Ontario"
        };

        var result = data.ToKeyValuePairs().ToList();

        Assert.That(result, Does.Contain(new KeyValuePair<string, string>("drivers_license_number", "1234567890123456")));
        Assert.That(result, Does.Contain(new KeyValuePair<string, string>("drivers_license_dob", "1885-10-07")));
        Assert.That(result, Does.Contain(new KeyValuePair<string, string>("drivers_license_state", "Ontario")));
    }

}