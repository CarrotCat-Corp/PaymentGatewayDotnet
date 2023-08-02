using PaymentGatewayDotnet.PaymentApi.Response;

namespace PaymentGatewayDotnet.UnitTests.PaymentApi.Response;


[TestFixture]
public class PaymentApiResponseTests
{
    [Test]
    public void FromQueryString_WithValidData_ReturnsPaymentApiResponse()
    {
        // Arrange
        const string queryString = "response=1&responsetext=Transaction Approved&authcode=123456&transactionid=TRAN123&avsresponse=Y&cvvresponse=M&orderid=ORDER456&type=Sale&response_code=100&emv_auth_response_data=EMVDATA123&processor_id=PRO123&customer_vault_id=CUST456&kount_score=90";

        // Act
        var paymentApiResponse = PaymentApiResponse.FromQueryString(queryString);

        // Assert
        Assert.That(paymentApiResponse, Is.Not.Null);
        Assert.That(paymentApiResponse, Is.InstanceOf<PaymentApiResponse>());
        Assert.Multiple(() =>
        {
            Assert.That(paymentApiResponse.RawResponse, Is.EqualTo(1));
            Assert.That(paymentApiResponse.ResponseText, Is.EqualTo("Transaction Approved"));
            Assert.That(paymentApiResponse.AuthCode, Is.EqualTo("123456"));
            Assert.That(paymentApiResponse.TransactionId, Is.EqualTo("TRAN123"));
            Assert.That(paymentApiResponse.RawAvsResponse, Is.EqualTo("Y"));
            Assert.That(paymentApiResponse.RawCvvResponse, Is.EqualTo("M"));
            Assert.That(paymentApiResponse.OrderId, Is.EqualTo("ORDER456"));
            Assert.That(paymentApiResponse.Type, Is.EqualTo("Sale"));
            Assert.That(paymentApiResponse.ResponseCode, Is.EqualTo("100"));
            Assert.That(paymentApiResponse.EmvAuthResponseData, Is.EqualTo("EMVDATA123"));
            Assert.That(paymentApiResponse.ProcessorId, Is.EqualTo("PRO123"));
            Assert.That(paymentApiResponse.CustomerVaultId, Is.EqualTo("CUST456"));
            Assert.That(paymentApiResponse.KountScore, Is.EqualTo("90"));
        });
    }

    // [Test]
    // public void FromQueryString_WithInvalidData_ReturnsDefaultPaymentApiResponse()
    // {
    //     // Arrange
    //     const string queryString = "response=invalid&responsetext=&authcode=&transactionid=&avsresponse=&cvvresponse=&orderid=&type=&response_code=&emv_auth_response_data=&processor_id=&customer_vault_id=&kount_score=";
    //
    //     // Act
    //     var paymentApiResponse = PaymentApiResponse.FromQueryString(queryString);
    //
    //     // Assert
    //     Assert.That(paymentApiResponse, Is.Not.Null);
    //     Assert.That(paymentApiResponse, Is.InstanceOf<PaymentApiResponse>());
    //     Assert.Multiple(() =>
    //     {
    //         Assert.That(paymentApiResponse.RawResponse, Is.EqualTo(null));
    //         Assert.That(paymentApiResponse.ResponseText, Is.EqualTo(null));
    //         Assert.That(paymentApiResponse.AuthCode, Is.EqualTo(null));
    //         Assert.That(paymentApiResponse.TransactionId, Is.EqualTo(null));
    //         Assert.That(paymentApiResponse.RawAvsResponse, Is.EqualTo(null));
    //         Assert.That(paymentApiResponse.RawCvvResponse, Is.EqualTo(null));
    //         Assert.That(paymentApiResponse.OrderId, Is.EqualTo(null));
    //         Assert.That(paymentApiResponse.Type, Is.EqualTo(null));
    //         Assert.That(paymentApiResponse.ResponseCode, Is.EqualTo(null));
    //         Assert.That(paymentApiResponse.EmvAuthResponseData, Is.EqualTo(null));
    //         Assert.That(paymentApiResponse.ProcessorId, Is.EqualTo(null));
    //         Assert.That(paymentApiResponse.CustomerVaultId, Is.EqualTo(null));
    //         Assert.That(paymentApiResponse.KountScore, Is.EqualTo(null));
    //     });
    // }
}
