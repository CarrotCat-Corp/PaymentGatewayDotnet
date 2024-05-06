using PaymentGatewayDotnet.Shared;
using PaymentGatewayDotnet.Shared.Enums;

namespace PaymentGatewayDotnet.UnitTests.Shared;

[TestFixture]
public class AchTests
{
    [Test]
    public void ToKeyValuePairs_ValidData_ReturnsKeyValuePairs()
    {
        // Arrange
        var ach = new Ach
        {
            Name = "John Doe",
            Aba = "123456789",
            Account = "987654321",
            SecCode = StandardEntryClassCode.CCD,
            AccountType = AccountType.Checking,
            AccountHolderType = AccountHolderType.Personal,
            SocialSecurityNumber = "123-45-6789"
        };

        // Act
        var keyValuePairs = ach.ToKeyValuePairs();

        // Assert
        Assert.IsNotNull(keyValuePairs);
        Assert.IsInstanceOf<IEnumerable<KeyValuePair<string, string>>>(keyValuePairs);
        var keyValueList = new List<KeyValuePair<string, string>>(keyValuePairs);

        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("checkname", "John Doe")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("checkaba", "123456789")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("checkaccount", "987654321")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("sec_code", "CCD")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("account_type", "checking")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("account_holder_type", "personal")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("social_security_number", "123-45-6789")));
    }

    [Test]
    public void ToKeyValuePairs_InvalidData_ThrowsArgumentNullException()
    {
        // Arrange
        var ach = new Ach();

        // Assert
        Assert.Throws<ArgumentNullException>(() => ach.ToKeyValuePairs());
    }
}