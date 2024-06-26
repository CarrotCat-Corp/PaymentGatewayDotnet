using PaymentGatewayDotnet.PaymentApi.Requests;
using PaymentGatewayDotnet.Shared;
using PaymentGatewayDotnet.Shared.Enums;

namespace PaymentGatewayDotnet.EndToEndTests;

public class GatewayClassTests
{
    private string _securityKey = string.Empty;

    [SetUp]
    public void Setup()
    {
        _securityKey = TestConstants.PrivateSecurityKey;
    }


// Approved transaction with verified AVS and CVV
    [Test]
    public async Task PaymentApiPost_TransactionWithValidCardCvvAndAvs_TransactionIsApprovedCvvAvsValidated()
    {
        var request = new TransactionRequest(_securityKey, TransactionType.Sale)
        {
            PaymentCredentials = new PaymentCredentials()
            {
                CreditCard = new CreditCard()
                {
                    Number = TestConstants.TestCardVisa01,
                    Expiration = TestConstants.TestCardExpiration,
                    Cvv = TestConstants.Cvv
                }
            },
            Amount = 1.01m,
            Billing = new Billing() { Address = new Address() { Address1 = TestConstants.AvsAddress1,  PostalZip = TestConstants.AvsZip } },
        };

        var result = await Gateway.PaymentApiPost(request);
        Assert.Multiple(() =>
        {
            Assert.That(result.RawResponse, Is.EqualTo(byte.Parse("1")));
            Assert.That(result.ResponseText, Is.EqualTo("SUCCESS"));
            Assert.That(result.RawAvsResponse, Is.EqualTo("Y"));
            Assert.That(result.RawCvvResponse, Is.EqualTo("M"));
        });
    }


// Declined transaction with failed AVS and CVV
    [Test]
    public async Task PaymentApiPost_TransactionWithAmountLessThan1_TransactionIsDeclinedAvsAndCvvNoMatch()
    { 
        var request = new TransactionRequest(_securityKey, TransactionType.Sale)
        {
            PaymentCredentials = new PaymentCredentials()
            {
                CreditCard = new CreditCard()
                {
                    Number = TestConstants.TestCardVisa01,
                    Expiration = TestConstants.TestCardExpiration,
                    Cvv = "111"
                }
            },
            Amount = 0.50m,
            Billing = new Billing() { Address = new Address() { Address1 = "abc", PostalZip = "12345" } },
        };

        var result = await Gateway.PaymentApiPost(request);
        Assert.Multiple(() =>
        {
            Assert.That(result.RawResponse, Is.EqualTo(byte.Parse("2")));
            Assert.That(result.ResponseText, Is.EqualTo("DECLINE"));
            Assert.That(result.RawAvsResponse, Is.EqualTo("N"));
            Assert.That(result.RawCvvResponse, Is.EqualTo("N"));
        });
    }
    
}