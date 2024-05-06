using PaymentGatewayDotnet.Shared;

namespace PaymentGatewayDotnet.UnitTests.Shared;

[TestFixture]
public class ThreeDSecureTests
{
    [Test]
    public void ToKeyValuePairs_WithThreeDSecureData_ReturnsKeyValuePairs()
    {
        // Arrange
        var threeDSecure = new ThreeDSecure
        {
            CardholderAuth = "verified",
            Cavv = "cavv12345",
            Xid = "xid12345",
            ThreeDsVersion = "2.0.0",
            DirectoryServerId = "d12345-6789-abc",
            Eci = "12345"
        };

        // Act
        var keyValuePairs = threeDSecure.ToKeyValuePairs();

        // Assert
        Assert.IsNotNull(keyValuePairs);
        Assert.IsInstanceOf<IEnumerable<KeyValuePair<string, string>>>(keyValuePairs);
        var keyValueList = new List<KeyValuePair<string, string>>(keyValuePairs);

        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("cardholder_auth", "verified")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("cavv", "cavv12345")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("xid", "xid12345")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("three_ds_version", "2.0.0")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("directory_server_id", "d12345-6789-abc")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("eci", "12345")));
    }

    [Test]
    public void ToKeyValuePairs_WithoutThreeDSecureData_ReturnsKeyValuePairs()
    {
        // Arrange
        var threeDSecure = new ThreeDSecure();

        // Act
        var keyValuePairs = threeDSecure.ToKeyValuePairs();

        // Assert
        Assert.IsNotNull(keyValuePairs);
        Assert.IsInstanceOf<IEnumerable<KeyValuePair<string, string>>>(keyValuePairs);
        var keyValueList = new List<KeyValuePair<string, string>>(keyValuePairs);

        Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("cardholder_auth", "verified")));
        Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("cavv", "cavv12345")));
        Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("xid", "xid12345")));
        Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("three_ds_version", "2.0.0")));
        Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("directory_server_id", "d12345-6789-abc")));
        Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("eci", "12345")));
    }
}
