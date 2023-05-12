using PaymentGatewayDotnet.Model.Shared;

namespace PaymentGatewayDotnet.UnitTests.Shared;

[TestFixture]
public class AddressTests
{
    [Test]
    [TestCase(null)]
    [TestCase("shipping")]
    public void ToString_ObjectCreated_ValidKeyValidPairs(string? prefix)
    {
        var data = new Address()
        {
            Address1 = "a",
            Address2 = "b",
            City = "c",
            StateProvince = "d",
            PostalZip = "123456",
            Country = "e"
        };

        var result = data.ToKeyValuePairs(prefix).ToList();

        if (prefix != null) prefix = prefix + "_";
        
        Assert.Multiple(() =>
        {
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>(prefix+"address1", "a")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>(prefix+"address2", "b")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>(prefix+"city", "c")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>(prefix+"state", "d")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>(prefix+"zip", "123456")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>(prefix+"country", "e")));
        });
    }
}