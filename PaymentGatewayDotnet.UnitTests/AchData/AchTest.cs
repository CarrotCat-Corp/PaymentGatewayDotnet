using PaymentGatewayDotnet.Model.PaymentApi.AchData;

namespace PaymentGatewayDotnet.UnitTests.AchData;

[TestFixture]
public class AchTest
{
    [Test]
    public void ToString_ObjectCreated_ValidKeyValidPairs()
    {
        var ach = new Ach
        {
            SecCode = StandardEntryClassCode.CCD,
            AccountType = AccountType.Checking,
            AccountHolderType = AccountHolderType.Personal,
            Account = "1234567890",
            Aba = "12345",
            Name = "Abc Defgh",
            SocialSecurityNumber = "123456789"
        };

        var result = ach.ToKeyValuePairs().ToList();
        
        Assert.That(result, Does.Contain(new KeyValuePair<string, string>("checkname", "Abc Defgh")));
        Assert.That(result, Does.Contain(new KeyValuePair<string, string>("checkaba", "12345")));
        Assert.That(result, Does.Contain(new KeyValuePair<string, string>("checkaccount", "1234567890")));
        Assert.That(result, Does.Contain(new KeyValuePair<string, string>("sec_code", "CCD")));
        Assert.That(result, Does.Contain(new KeyValuePair<string, string>("account_type", "checking")));
        Assert.That(result, Does.Contain(new KeyValuePair<string, string>("account_holder_type", "personal")));
        Assert.That(result, Does.Contain(new KeyValuePair<string, string>("social_security_number", "123456789")));
    }
}