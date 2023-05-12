using PaymentGatewayDotnet.Model.Shared;

namespace PaymentGatewayDotnet.UnitTests.Shared;

[TestFixture]
public class CreditCardTests
{
    [Test]
    public void ToKeyValuePairs_AllFieldsAreValid_ValidListOfKeyValues()
    {
        var creditCard = new CreditCard()
        {
            Number = "4111111111111111",
            Expiration = new DateTime(2029, 12, 1),
            Cvv = "999"
        };

        var result = creditCard.ToKeyValuePairs().ToList();

        Assert.That(result, Does.Contain(new KeyValuePair<string, string>("ccnumber", "4111111111111111")));
        Assert.That(result, Does.Contain(new KeyValuePair<string, string>("ccexp", "1229")));
        Assert.That(result, Does.Contain(new KeyValuePair<string, string>("cvv", "999")));
    }

    // [Test]
    // public void ToKeyValuePairs_InitialTransactionIdWithStoredAction_ThrowInvalidStateException()
    // {
    //     var storedCredentials = new StoredCredentialsIndicatorParameters()
    //     {
    //         InitiatedBy = InitiatedBy.Customer,
    //         IniInitialTransactionId = "abc",
    //         StoredCredentialsIndicator = StoredCredentialsIndicator.Stored
    //     };
    //
    //     Assert.That(() => storedCredentials.ToKeyValuePairs(), Throws.Exception.TypeOf<InvalidStateException>());
    // }

}