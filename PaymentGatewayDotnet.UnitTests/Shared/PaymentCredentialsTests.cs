using PaymentGatewayDotnet.Shared;
using PaymentGatewayDotnet.Shared.Enums;

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
    
        [Test]
    public void ToKeyValuePairs_WithPaymentToken_ReturnsKeyValuePairs()
    {
        // Arrange
        var paymentCredentials = new PaymentCredentials
        {
            PaymentToken = "token12345",
            PaymentType = PaymentType.CreditCard
        };

        // Act
        var keyValuePairs = paymentCredentials.ToKeyValuePairs();

        // Assert
        Assert.IsNotNull(keyValuePairs);
        Assert.IsInstanceOf<IEnumerable<KeyValuePair<string, string>>>(keyValuePairs);
        var keyValueList = new List<KeyValuePair<string, string>>(keyValuePairs);

        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("payment_token", "token12345")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("payment", "creditcard")));
    }

    [Test]
    public void ToKeyValuePairs_WithGooglePayToken_ReturnsKeyValuePairs()
    {
        // Arrange
        var paymentCredentials = new PaymentCredentials
        {
            GooglePayToken = "googlepaytoken12345",
            PaymentType = PaymentType.CreditCard
        };

        // Act
        var keyValuePairs = paymentCredentials.ToKeyValuePairs();

        // Assert
        Assert.IsNotNull(keyValuePairs);
        Assert.IsInstanceOf<IEnumerable<KeyValuePair<string, string>>>(keyValuePairs);
        var keyValueList = new List<KeyValuePair<string, string>>(keyValuePairs);

        Assert.IsTrue(
            keyValueList.Contains(new KeyValuePair<string, string>("googlepay_payment_data", "googlepaytoken12345")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("payment", "creditcard")));
    }

    [Test]
    public void ToKeyValuePairs_WithApplePayToken_ReturnsKeyValuePairs()
    {
        // Arrange
        var paymentCredentials = new PaymentCredentials
        {
            ApplePayToken = "applepaytoken12345",
            PaymentType = PaymentType.CreditCard
        };

        // Act
        var keyValuePairs = paymentCredentials.ToKeyValuePairs();

        // Assert
        Assert.IsNotNull(keyValuePairs);
        Assert.IsInstanceOf<IEnumerable<KeyValuePair<string, string>>>(keyValuePairs);
        var keyValueList = new List<KeyValuePair<string, string>>(keyValuePairs);

        Assert.IsTrue(
            keyValueList.Contains(new KeyValuePair<string, string>("applepay_payment_data", "applepaytoken12345")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("payment", "creditcard")));
    }

    [Test]
    public void ToKeyValuePairs_WithAch_ReturnsKeyValuePairs()
    {
        // Arrange
        var ach = new Ach
        {
            Name = "John Doe",
            Aba = "123456789",
            Account = "987654321",
            SecCode = StandardEntryClassCode.CCD
        };

        var paymentCredentials = new PaymentCredentials
        {
            Ach = ach,
            PaymentType = PaymentType.Check
        };

        // Act
        var keyValuePairs = paymentCredentials.ToKeyValuePairs();

        // Assert
        Assert.IsNotNull(keyValuePairs);
        Assert.IsInstanceOf<IEnumerable<KeyValuePair<string, string>>>(keyValuePairs);
        var keyValueList = new List<KeyValuePair<string, string>>(keyValuePairs);

        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("payment", "check")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("checkname", "John Doe")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("checkaba", "123456789")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("checkaccount", "987654321")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("sec_code", "CCD")));
    }

    [Test]
    public void ToKeyValuePairs_WithCreditCard_ReturnsKeyValuePairs()
    {
        // Arrange
        var creditCard = new CreditCard()
        {
            Number = "4111111111111111",
            Expiration = new DateTime(2029, 12, 1),
            Cvv = "999"
        };

        var paymentCredentials = new PaymentCredentials
        {
            CreditCard = creditCard,
            PaymentType = PaymentType.CreditCard
        };

        // Act
        var keyValuePairs = paymentCredentials.ToKeyValuePairs();

        // Assert
        Assert.IsNotNull(keyValuePairs);
        Assert.IsInstanceOf<IEnumerable<KeyValuePair<string, string>>>(keyValuePairs);
        var keyValueList = new List<KeyValuePair<string, string>>(keyValuePairs);

        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("payment", "creditcard")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("ccnumber", "4111111111111111")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("ccexp", "1229")));
        Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("cvv", "999")));
    }

    [Test]
    public void ToKeyValuePairs_WithoutPaymentData_ReturnsKeyValuePairs()
    {
        // Arrange
        var paymentCredentials = new PaymentCredentials();

        // Act
        var keyValuePairs = paymentCredentials.ToKeyValuePairs();

        // Assert
        Assert.IsNotNull(keyValuePairs);
        Assert.IsInstanceOf<IEnumerable<KeyValuePair<string, string>>>(keyValuePairs);
        var keyValueList = new List<KeyValuePair<string, string>>(keyValuePairs);

        Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("payment_token", "token12345")));
        Assert.IsFalse(
            keyValueList.Contains(new KeyValuePair<string, string>("googlepay_payment_data", "googlepaytoken12345")));
        Assert.IsFalse(
            keyValueList.Contains(new KeyValuePair<string, string>("applepay_payment_data", "applepaytoken12345")));
        Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("checkname", "John Doe")));
        Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("checkaba", "123456789")));
        Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("checkaccount", "987654321")));
        Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("sec_code", "CCD")));
        Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("payment", "creditcard")));
        Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("ccnumber", "4111111111111111")));
        Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("ccexp", "1229")));
        Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("cvv", "999")));
    }
}