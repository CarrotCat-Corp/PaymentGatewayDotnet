using PaymentGatewayDotnet.Shared;

namespace PaymentGatewayDotnet.UnitTests.Shared;

[TestFixture]
public class DriversLicenseTests
{
    [Test]
    public void ToKeyValuePairs_ValidData_ReturnsKeyValuePairs()
    {
        // Arrange
        var license = new DriversLicense
        {
            Number = "123456789",
            DateOfBirth = "1990-05-15",
            State = "California"
        };

        // Act
        var keyValuePairs = license.ToKeyValuePairs()?.ToList();

        // Assert
        Assert.That(keyValuePairs, Is.Not.Null);
        Assert.That(keyValuePairs, Is.InstanceOf<IList<KeyValuePair<string, string>>>());

        Assert.That(keyValuePairs, Does.Contain(new KeyValuePair<string, string>("drivers_license_number", "123456789")));
        Assert.That(keyValuePairs, Does.Contain(new KeyValuePair<string, string>("drivers_license_dob", "1990-05-15")));
        Assert.That(keyValuePairs, Does.Contain(new KeyValuePair<string, string>("drivers_license_state", "California")));
    }

    [Test]
    public void ToKeyValuePairs_InvalidData_ThrowsArgumentNullException()
    {
        // Arrange
        var license = new DriversLicense();

        // Assert
        Assert.Throws<ArgumentNullException>(() => license.ToKeyValuePairs());
    }
}
