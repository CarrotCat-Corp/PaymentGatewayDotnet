// using NUnit.Framework;
// using PaymentGatewayDotnet.Shared;
//
// namespace PaymentGatewayDotnet.UnitTests.Shared;
//
// [TestFixture]
// public class MerchantDefinedFieldTests
// {
//     [Test]
//     [TestCase(1, "abc")]
//     [TestCase(20, "abc")]
//     public void ToKeyValuePairs_AllFieldsAreValid_ValidListOfKeyValues(int number, string value)
//     {
//         var data = new MerchantDefinedField(number, value);
//
//         var result = data.ToKeyValuePair();
//
//         Assert.That(result, Is.(new KeyValuePair<string, string>($"merchant_defined_field_{number}", value)));
//     }
// }