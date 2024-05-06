using PaymentGatewayDotnet.PaymentApi.Requests;
using PaymentGatewayDotnet.QueryApi;
using PaymentGatewayDotnet.QueryApi.Enums;
using PaymentGatewayDotnet.Shared;
using PaymentGatewayDotnet.Shared.Enums;

namespace PaymentGatewayDotnet.EndToEndTests;

[TestFixture]
public class GatewayClientTests
{
    private readonly IGatewayClient _gatewayClient;
    private const string SecurityKey = TestConstants.PrivateSecurityKey;

    private const string ExistingOrderId = "33";

    public GatewayClientTests()
    {
        _gatewayClient = new GatewayClient(new Uri("https://secure.nmi.com"));
    }

    [Test]
    public async Task PaymentApiPost_TransactionWithValidCardCvvAndAvs_TransactionIsApprovedCvvAvsValidated()
    {
        var request = new TransactionRequest(SecurityKey, TransactionType.Sale)
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
            Billing = new Billing()
                { Address = new Address() { Address1 = TestConstants.AvsAddress1, PostalZip = TestConstants.AvsZip } },
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
        var request = new TransactionRequest(SecurityKey, TransactionType.Sale)
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


    // Query API
    [Test]
    public async Task QueryApi_RequestForTransactionsWithSpecificOrder()
    {
        var request = new QueryApiRequest("5w3R996A7aKd57Cx7vWaauQUBQr2kdMW")
        {
            // Conditions = null,
            // TransactionType = null,
            // ActionTypes = null,
            // Sources = null,
            // TransactionIds = null,
            // SubscriptionIds = null,
            // InvoiceId = "1047",
            // PartialPaymentId = null,
            OrderId = ExistingOrderId,
            // FirstName = null,
            // LastName = null,
            // Address1 = null,
            // City = null,
            // State = null,
            // Zip = null,
            // Phone = null,
            // Fax = null,
            // OrderDescription = null,
            // DriversLicenseNumber = null,
            // DriversLicenseDob = null,
            // DriversLicenseState = null,
            // Email = null,
            // CcNumber = null,
            // MerchantDefinedFields = null,
            // StartDate = null,
            // EndDate = null,
            // ReportType = ,
            // MobileDeviceLicence = null,
            // MobileDeviceNickname = null,
            // CustomerVaultId = null,
            // DateSearch = null,
            // ResultLimit = null,
            // PageNumber = null,
            ResultOrder = ResultOrder.Reverse,
            // InvoiceStatuses = null
        };

        var result = await _gatewayClient.QueryApiPost(request);

        Assert.Multiple(() =>
        {
            Assert.That(result.Transactions, Has.Count.EqualTo(1));
            Assert.That(result.Transactions[0].OrderId, Is.EqualTo(ExistingOrderId));
        });

        // Assert.Multiple(() =>
        // {
        //     Assert.That(result.Transactions.Count, Is.EqualTo(1));
        //     Assert.That(result.Transactions.Count, Is.EqualTo(0));
        //     Assert.That(result.Transactions.Count, Is.AtLeast(1));
        //     Assert.That(result.Transactions.Count, Is.AtMost(1));
        // });
    }
}