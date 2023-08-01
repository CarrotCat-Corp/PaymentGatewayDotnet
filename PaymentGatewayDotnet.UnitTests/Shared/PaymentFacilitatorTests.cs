using NUnit.Framework;
using PaymentGatewayDotnet.PaymentApi.Data;
using PaymentGatewayDotnet.Shared;

namespace PaymentGatewayDotnet.UnitTests.Shared;

[TestFixture]
public class PaymentFacilitatorTests
{
    [Test]
    public void ToString_ObjectCreated_ValidKeyValidPairs()
    {
        var data = new PaymentFacilitator
        {
            Id = "abc",
            SubMerchantId = "abc",
            SubMerchantEmail = "abc",
            SubMerchantPhone = "abc",
            SubMerchantPostal = "abc",
            SubMerchantName = "abc",
            SubMerchantAddress = "abc",
            SubMerchantCity = "abc",
            SubMerchantState = "abc",
            SubMerchantCountry = "abc"
        };

        var result = data.ToKeyValuePairs().ToList();

        Assert.Multiple(() =>
        {
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("payment_facilitator_id", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("submerchant_id", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("submerchant_name", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("submerchant_address", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("submerchant_city", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("submerchant_state", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("submerchant_postal", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("submerchant_country", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("submerchant_phone", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("submerchant_email", "abc")));
        });
    }
}