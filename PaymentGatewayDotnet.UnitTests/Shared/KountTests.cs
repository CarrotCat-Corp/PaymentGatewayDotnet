using PaymentGatewayDotnet.Shared;

namespace PaymentGatewayDotnet.UnitTests.Shared;

[TestFixture]
public class KountTests
{
    [Test]
    public void ToKeyValuePairs_WithTransactionSessionId_ReturnsKeyValuePair()
    {
        // Arrange
        var kountData = new Kount
        {
            TransactionSessionId = "A1B2C3D4E5F6G7H8I9J0K1L2M3N4O5P"
        };

        // Act
        var keyValuePairs = kountData.ToKeyValuePairs();

        // Assert
        Assert.IsNotNull(keyValuePairs);
        Assert.IsInstanceOf<IEnumerable<KeyValuePair<string, string>>>(keyValuePairs);
        var keyValueList = new List<KeyValuePair<string, string>>(keyValuePairs);

        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("transaction_session_id", "A1B2C3D4E5F6G7H8I9J0K1L2M3N4O5P")));
    }

    [Test]
    public void ToKeyValuePairs_WithoutTransactionSessionId_ReturnsEmptyList()
    {
        // Arrange
        var kountData = new Kount();

        // Act
        var keyValuePairs = kountData.ToKeyValuePairs();

        // Assert
        Assert.IsNotNull(keyValuePairs);
        Assert.IsEmpty(keyValuePairs);
    }
}