using NUnit.Framework;
using PaymentGatewayDotnet.PaymentApi;
using PaymentGatewayDotnet.PaymentApi.Data;
using PaymentGatewayDotnet.Shared;

namespace PaymentGatewayDotnet.UnitTests.Shared;

[TestFixture]
public class PaymentDescriptorTests
{
    [Test]
    public void ToString_ObjectCreated_ValidKeyValidPairs()
    {
        var data = new PaymentDescriptor
        {
            Descriptor = "abc",
            Phone = "abc",
            Address = "abc",
            City = "abc",
            State = "abc",
            Postal = "abc",
            Country = "abc",
            Mcc = "abc",
            MerchantId = "abc",
            Url = "abc"
        };

        var result = data.ToKeyValuePairs().ToList();

        Assert.Multiple(() =>
        {
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("descriptor", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("descriptor_phone", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("descriptor_address", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("descriptor_city", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("descriptor_state", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("descriptor_postal", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("descriptor_country", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("descriptor_mcc", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("descriptor_merchant_id", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("descriptor_url", "abc")));
        });
    }
}