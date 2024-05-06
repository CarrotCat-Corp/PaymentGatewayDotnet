using PaymentGatewayDotnet.PaymentApi.Requests;
using PaymentGatewayDotnet.QueryApi;
using PaymentGatewayDotnet.QueryApi.Enums;
using PaymentGatewayDotnet.Shared;
using PaymentGatewayDotnet.Shared.Enums;
using PaymentGatewayDotnet.ThreeStepRedirectApi.Requests;

namespace PaymentGatewayDotnet.EndToEndTests;

[TestFixture]
public class GatewayClientTests
{
    private readonly IGatewayClient _gatewayClient;
    private const string SecurityKey = TestConstants.PrivateSecurityKey;

    private const string ExistingOrderId = "33";
    private const string ExistingTransactionId = "6430237874";
    private const string RedirectUrl = "https://google.com";
    

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
    public async Task PaymentApiPost_TransactionWithAmountLessThan1AndWrongCvv_TransactionIsDeclinedAvsAndCvvNoMatch()
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
        var request = new QueryApiRequest(SecurityKey)
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
    }
    
    
    // Query API - Get Receipt
    [Test]
    public async Task QueryApiGetReceipt_RequestForReceipt_ReturnsReceiptString()
    {
        var request = new QueryApiReceiptRequest(SecurityKey, ExistingTransactionId);

        var result = await _gatewayClient.QueryApiGetReceipt(request);

        Assert.That(result, Is.Not.Null);
    }
    
    
    /// <summary>
    /// Multi-step test  to test full three-step process. 
    /// </summary>
    [Test]
    public async Task StepOnePost_ValidThreeStepRequest_ReturnsStepOneResponse()
    {

        // First Step
        var request = new StepOneTransactionRequest(SecurityKey, RedirectUrl, TransactionType.Sale);

        var stepOneResponse = await _gatewayClient.StepOnePost(request);

        Assert.That(stepOneResponse, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(stepOneResponse.Result, Is.EqualTo(1));
            Assert.That(stepOneResponse.FormUrl, Is.Not.Null);
        });
        
        // Second Step - simulating user form fill
        using var client = new HttpClient();
        
        var formContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("billing-cc-number", TestConstants.TestCardVisa02),
            new KeyValuePair<string, string>("billing-cc-exp", TestConstants.TestCardExpiration.ToString("MMyy")),
            new KeyValuePair<string, string>("billing-cc-cvv", TestConstants.Cvv)
        });

        var stepTwoResponse = await client.PostAsync(stepOneResponse.FormUrl, formContent);
        
        Assert.That(stepTwoResponse.StatusCode, Is.AtMost(300));
        
        // Step Three
        //
        //
        // var stepThreeResponse = await stepTwoResponse.Content.ReadAsStringAsync();
        // Assert.That(stepThreeResponse, Is.Not.Null);
    }

    // Step Three Post
    // [Test]
    // public async Task StepThreePost_ValidThreeStepRequest_ReturnsStepThreeResponse()
    // {
    //     var request = new StepThreeTransactionRequest(SecurityKey, )
    //     {
    //         // fill in the request properties
    //     };
    //
    //     var result = await _gatewayClient.StepThreePost(request);
    //
    //     Assert.That(result, Is.Not.Null);
    // }
    
    
}