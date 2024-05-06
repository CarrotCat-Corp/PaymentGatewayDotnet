using PaymentGatewayDotnet.Exceptions;
using PaymentGatewayDotnet.Shared;
using PaymentGatewayDotnet.Shared.Enums;

namespace PaymentGatewayDotnet.UnitTests.Shared;


[TestFixture]
public class StoredCredentialsIndicatorParametersTests
{
    [Test]
    public void ToKeyValuePairs_WithInitialTransactionIdAndStoredCredentialsStored_ThrowsInvalidStateException()
    {
        // Arrange
        var storedCredentialsIndicatorParams = new StoredCredentialsIndicatorParameters
        {
            InitialTransactionId = "transaction123",
            StoredCredentialsIndicator = StoredCredentialsIndicator.Stored
        };

        // Act & Assert
        Assert.Throws<InvalidStateException>(() => storedCredentialsIndicatorParams.ToKeyValuePairs());
    }

    [Test]
    public void ToKeyValuePairs_WithStoredCredentialsNotStored_ReturnsKeyValuePairs()
    {
        // Arrange
        var storedCredentialsIndicatorParams = new StoredCredentialsIndicatorParameters
        {
            InitialTransactionId = "transaction123",
            InitiatedBy = InitiatedBy.Customer,
            StoredCredentialsIndicator = StoredCredentialsIndicator.Used
        };

        // Act
        var keyValuePairs = storedCredentialsIndicatorParams.ToKeyValuePairs();

        // Assert
        var valuePairs = keyValuePairs.ToList();
        Assert.That(valuePairs, Is.Not.Null);
        Assert.That(valuePairs, Is.InstanceOf<IEnumerable<KeyValuePair<string, string>>>());
        var keyValueList = new List<KeyValuePair<string, string>>(valuePairs);

        Assert.That(keyValueList, Does.Contain(new KeyValuePair<string, string>("initial_transaction_id", "transaction123")));
        Assert.That(keyValueList, Does.Contain(new KeyValuePair<string, string>("initiated_by", "customer")));
        Assert.That(keyValueList, Does.Contain(new KeyValuePair<string, string>("stored_credential_indicator", "used")));
    }

    [Test]
    public void ToKeyValuePairs_WithoutStoredCredentials_ReturnsKeyValuePairs()
    {
        // Arrange
        var storedCredentialsIndicatorParams = new StoredCredentialsIndicatorParameters
        {
            InitiatedBy = InitiatedBy.Merchant,
            InitialTransactionId = null
        };

        // Act
        var keyValuePairs = storedCredentialsIndicatorParams.ToKeyValuePairs();

        // Assert
        var valuePairs = keyValuePairs as KeyValuePair<string, string>[] ?? keyValuePairs.ToArray();
        Assert.That(valuePairs, Is.Not.Null);
        Assert.That(valuePairs, Is.InstanceOf<IEnumerable<KeyValuePair<string, string>>>());
        var keyValueList = new List<KeyValuePair<string, string>>(valuePairs);

        Assert.That(keyValueList, Does.Not.Contain(new KeyValuePair<string, string>("initial_transaction_id", "transaction123")));
        Assert.That(keyValueList, Does.Contain(new KeyValuePair<string, string>("initiated_by", "merchant")));
        Assert.That(keyValueList, Does.Not.Contain(new KeyValuePair<string, string>("stored_credential_indicator", "used")));
    }
}
