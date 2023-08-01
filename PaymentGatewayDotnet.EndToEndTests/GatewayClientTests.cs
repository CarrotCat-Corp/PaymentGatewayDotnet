using PaymentGatewayDotnet.PaymentApi.Data;
using PaymentGatewayDotnet.PaymentApi.Requests;
using PaymentGatewayDotnet.Shared;
using PaymentGatewayDotnet.Shared.Enums;

namespace PaymentGatewayDotnet.EndToEndTests;

[TestFixture]
public class GatewayClientTests
{
    private readonly IGatewayClient _gatewayClient;
    private const string SecurityKey = TestConstants.PrivateSecurityKey;

    public GatewayClientTests()
    {
        _gatewayClient = new GatewayClient(new Uri("https://secure.nmi.com"));
    }

    [Test]
    public async Task PaymentApiPost_TransactionWithValidCardCvvAndAvs_TransactionIsApprovedCvvAvsValidated()
    {
        var request = new FinancialRequest(SecurityKey, FinancialRequestType.Sale)
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
            Amount = new decimal(1.01),
            Billing = new Billing() { Address = new Address() { Address1 = TestConstants.AvsAddress1, PostalZip = TestConstants.AvsZip } },
        };

        var result = await _gatewayClient.PaymentApiPost(request);
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
        var request = new FinancialRequest(SecurityKey, FinancialRequestType.Sale)
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
            Amount = new decimal(0.50),
            Billing = new Billing() { Address = new Address() { Address1 = "abc", PostalZip = "12345" } },
        };

        var result = await _gatewayClient.PaymentApiPost(request);
        Assert.Multiple(() =>
        {
            Assert.That(result.RawResponse, Is.EqualTo(byte.Parse("2")));
            Assert.That(result.ResponseText, Is.EqualTo("DECLINE"));
            Assert.That(result.RawAvsResponse, Is.EqualTo("N"));
            Assert.That(result.RawCvvResponse, Is.EqualTo("N"));
        });
    }
}