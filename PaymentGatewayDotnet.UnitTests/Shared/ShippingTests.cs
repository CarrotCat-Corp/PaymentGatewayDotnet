using PaymentGatewayDotnet.Shared;
using PaymentGatewayDotnet.Shared.Enums;

namespace PaymentGatewayDotnet.UnitTests.Shared;

[TestFixture]
public class ShippingTests
{
    [Test]
    public void ToString_ObjectCreated_ValidKeyValidPairs()
    {
        var data = new Shipping
        {
            FirstName = "a",
            LastName = "b",
            Company = "c",
            Email = "f",
            Amount = decimal.One,
            ShipFromPostalCode = "123456",
            Carrier = ShippingCarrier.Fedex,
            TrackingNumber = "123",
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

        var result = data.ToKeyValuePairs().ToList();

        Assert.Multiple(() =>
        {
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_firstname", "a")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_lastname", "b")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_company", "c")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_email", "f")));

            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping", "1.00")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("ship_from_postal", "123456")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_carrier", "fedex")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("tracking_number", "123")));

            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_address1", "a")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_address2", "b")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_city", "c")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_state", "d")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_zip", "123456")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_country", "e")));
        });
    }
}