using PaymentGatewayDotnet.Model.PaymentApi.StoredCredentials;

namespace PaymentGatewayDotnet.UnitTests.StoredCredentials;

[TestFixture]
public class StoredCredentialsIndicatorUtilsTest
{
    [Test]
    [TestCase(StoredCredentialsIndicator.Stored, "stored")]
    [TestCase(StoredCredentialsIndicator.Used, "used")]
    [TestCase(StoredCredentialsIndicator.Undefined, "")]
    public void ToString_GivenParameter_ReturnsValidString(StoredCredentialsIndicator parameter, string result)
    {
        StringAssert.Equals(StoredCredentialsIndicatorUtils.ToString(parameter), result);
    }
}