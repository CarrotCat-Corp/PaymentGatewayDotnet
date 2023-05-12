using PaymentGatewayDotnet.Model;
using PaymentGatewayDotnet.Model.StoredCredentials;

namespace PaymentGatewayDotnet.UnitTests.StoredCredentials;

[TestFixture]
public class StoredCredentialsIndicatorParametersTest
{
    [Test]
    public void ToKeyValuePairs_AllFieldsAreValid_ValidListOfKeyValues()
    {
        var storedCredentials = new StoredCredentialsIndicatorParameters()
        {
            InitiatedBy = InitiatedBy.Customer,
            InitialTransactionId = "abc",
            StoredCredentialsIndicator = StoredCredentialsIndicator.Used
        };

        var result = storedCredentials.ToKeyValuePairs().ToList();
        
        Assert.That(result, Does.Contain(new KeyValuePair<string, string>("initial_transaction_id", "abc")));
        Assert.That(result, Does.Contain(new KeyValuePair<string, string>("initiated_by", "customer")));
        Assert.That(result, Does.Contain(new KeyValuePair<string, string>("stored_credential_indicator", "used")));
    }

    [Test]
    public void ToKeyValuePairs_InitialTransactionIdWithStoredAction_ThrowInvalidStateException()
    {
        var storedCredentials = new StoredCredentialsIndicatorParameters()
        {
            InitiatedBy = InitiatedBy.Customer,
            InitialTransactionId = "abc",
            StoredCredentialsIndicator = StoredCredentialsIndicator.Stored
        };

        Assert.That(() => storedCredentials.ToKeyValuePairs(), Throws.Exception.TypeOf<InvalidStateException>());
    }
}