using NUnit.Framework;
using PaymentGatewayDotnet.Shared;

namespace PaymentGatewayDotnet.UnitTests.Shared;

[TestFixture]
public class BillingTests
{
    [Test]
    [TestCase(null)]
    [TestCase("shipping")]
    public void ToString_ObjectCreated_ValidKeyValidPairs(string? prefix)
    {
        var data = new Billing
        {
            FirstName = "a",
            LastName = "b",
            Company = "c",
            Phone = "d",
            Fax = "e",
            Email = "f",
            Address = new Address()
            {
                Address1 = "a",
                Address2 = "b",
                City = "c",
                StateProvince = "d",
                PostalZip = "123456",
                Country = "e"
            }
        };
        
        var result = data.ToKeyValuePairs(prefix).ToList();
        if (prefix != null) prefix = prefix + "_";
        
        Assert.Multiple(() =>
        {
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>(prefix+"first_name", "a")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>(prefix+"last_name", "b")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>(prefix+"company", "c")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>(prefix+"phone", "d")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>(prefix+"fax", "e")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>(prefix+"email", "f")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>(prefix+"address1", "a")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>(prefix+"address2", "b")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>(prefix+"city", "c")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>(prefix+"state", "d")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>(prefix+"zip", "123456")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>(prefix+"country", "e")));
        });
    }
}