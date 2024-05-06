using System.Xml.Linq;
using PaymentGatewayDotnet.Shared;
using PaymentGatewayDotnet.Shared.Enums;
using PaymentGatewayDotnet.ThreeStepRedirectApi.Requests;

namespace PaymentGatewayDotnet.UnitTests.ThreeStepRedirectApi.Requests;

[TestFixture]
public class StepOneTransactionRequestTests
{
    [Test]
    public void ToXml_WithValidData_ReturnsXmlDocument()
    {
        var request = new StepOneTransactionRequest("123", "https://example.com", TransactionType.Sale)
        {
            IpAddress = "123.123.123.123",
            MerchantDefinedFields = new[] { new MerchantDefinedField(11, "22") },
            Industry = IndustryClassification.Ecommerce,
            ProcessorId = "qwerty",
            CustomerVaultId = "qwerty",
            CustomerId = "qwerty",
            MerchantReceiptEmail = "qwerty@qwerty.com",
            SignatureImage = "qwerty",
            SecCode = StandardEntryClassCode.CCD,
            Amount = 10.00m,
            Surcharge = 11.11m,
            Currency = "CAD",
            PaymentDescriptor = null,
            StoredCredentialsIndicatorParameters = null,
            AuthorizationCode = "123456",
            DuplicateSeconds = 1,
            ThreeDSecure = null,
            InstallmentBilling = null,
            PartialPayment = null,
            PaymentFacilitator = null,
            Billing = null,
            Shipping = null,
            Order = null
        };
        
        var xml = request.ToXml();
        
        Assert.IsNotNull(xml);
        Assert.IsTrue(XNode.DeepEquals(xml, XDocument.Parse(ExpectedResultString)));
    }


    private const string ExpectedResultString = @"
<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>
<sale>
    <api-key>123</api-key>
    <redirect-url>https://example.com</redirect-url>
    <mer
    <amount>10.00</amount>
    <currency>CAD</currency>
</sale>
";
}