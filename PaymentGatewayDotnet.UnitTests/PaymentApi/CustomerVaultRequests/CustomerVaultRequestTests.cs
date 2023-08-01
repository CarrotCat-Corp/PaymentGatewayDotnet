using PaymentGatewayDotnet.PaymentApi.Data;
using PaymentGatewayDotnet.PaymentApi.Requests;
using PaymentGatewayDotnet.Shared;
using PaymentGatewayDotnet.Shared.Enums;

namespace PaymentGatewayDotnet.UnitTests.PaymentApi.CustomerVaultRequests;

[TestFixture]
public class CustomerVaultRequestTests
{
        [Test]
        public void ToString_ObjectCreated_ValidKeyValidPairs()
    {
        var data = new CustomerVaultRequest("123abc")
        {
            Order = new Order(){Id = "abc", Description = "abc"},
            Billing = new Billing()
            {
                Id = "abc",
                FirstName = "abc",
                LastName = "abc",
                Company = "abc",
                Phone = "abc",
                Fax = "abc",
                Email = "abc",
                Address = new Address()
                {
                    Address1 = "abc",
                    Address2 = "abc",
                    City = "abc",
                    StateProvince = "abc",
                    PostalZip = "abc",
                    Country = "abc"
                }
            },
            Currency = "CAD",
            IpAddress = "999.999.999.999",
            ProcessorId = "abc",
            MerchantDefinedFields = new List<MerchantDefinedField>(){new (1, "abc")},
            Action = CustomerVaultAction.AddCustomer,
            BillingId = "abc",
            SourceTransactionId = "abc",
            AutomaticCardUpdaterEnabled = true,
            Payment = PaymentType.CreditCard,
            Shipping = new Shipping()
            {
                Id = "abc",
                FirstName = "abc",
                LastName = "abc",
                Company = "abc",
                Email = "abc",
                Amount = decimal.One,
                ShipFromPostalCode = "abc",
                Carrier = ShippingCarrier.Fedex,
                TrackingNumber = "abc",
                Phone = "abc",
                Fax = "abc",
                Address = new Address()
                {
                    Address1 = "abc",
                    Address2 = "abc",
                    City = "abc",
                    StateProvince = "abc",
                    PostalZip = "abc",
                    Country = "abc"
                }
            },
            PaymentCredentials = new PaymentCredentials()
            {
                CreditCard = new CreditCard(){Number = "1234567890123456", Expiration = new DateTime(1887, 8, 12)}
            },
            StoredCredentialsIndicatorParameters = new StoredCredentialsIndicatorParameters
            {
                InitialTransactionId = "123"
            }
        };
        
        var result = data.ToKeyValuePairs().ToList();

        Assert.Multiple(() =>
        {
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("customer_vault", "add_customer")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("billing_id", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("security_key", "123abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("ccnumber", "1234567890123456")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("ccexp", "0887")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("currency", "CAD")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("payment", "creditcard")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("orderid", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("order_description", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("first_name", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("last_name", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("address1", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("city", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("state", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("zip", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("country", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("phone", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("email", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("company", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("address2", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("fax", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_id", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_firstname", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_lastname", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_company", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_address1", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_address2", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_city", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_state", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_zip", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_country", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_phone", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_fax", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_email", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("source_transaction_id", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("acu_enabled", "true")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("merchant_defined_field_1", "abc")));

        });
    }
}