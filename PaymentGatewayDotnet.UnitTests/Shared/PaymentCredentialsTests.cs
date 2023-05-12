using NUnit.Framework;
using PaymentGatewayDotnet.Model.AchData;
using PaymentGatewayDotnet.Model.Shared;

namespace PaymentGatewayDotnet.UnitTests.Shared;

[TestFixture]
public class PaymentCredentialsTests
{
    [Test]
    public void ToString_ObjectCreated_ValidKeyValidPairs()
    {
        var data = new PaymentCredentials
        {
            PaymentToken = "abc",
            GooglePayToken = "{abc}",
            ApplePayToken = "{abc}",
            Ach = new Ach
            {
                SecCode = StandardEntryClassCode.CCD,
                AccountType = AccountType.Checking,
                AccountHolderType = AccountHolderType.Personal,
                Account = "1234567890",
                Aba = "12345",
                Name = "Abc Defgh",
                SocialSecurityNumber = "123456789"
            }
        };

        var result = data.ToKeyValuePairs().ToList();

        Assert.Multiple(() =>
        {
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("payment_token", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("googlepay_payment_data", "{abc}")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("applepay_payment_data", "{abc}")));
            
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("checkname", "Abc Defgh")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("checkaba", "12345")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("checkaccount", "1234567890")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("sec_code", "CCD")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("account_type", "checking")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("account_holder_type", "personal")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("social_security_number", "123456789")));
        });
    }
}