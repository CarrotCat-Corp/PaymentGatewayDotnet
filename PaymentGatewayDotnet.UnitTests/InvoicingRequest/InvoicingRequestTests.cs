using PaymentGatewayDotnet.Model.PaymentApi.InvoicingRequests;
using PaymentGatewayDotnet.Model.Shared;

namespace PaymentGatewayDotnet.UnitTests.InvoicingRequest;

[TestFixture]
public class InvoicingRequestTests
{
        [Test]
    public void ToKeyValuePairs_GivenObject_GeneratesValidRequest()
    {
        var request = new Model.PaymentApi.InvoicingRequests.InvoicingRequest("abc")
        {
            Order = new Order
            {
                Id = "abc",
                Items = new List<Item>() { new Item { ProductCode = "abc", } }
            },
            Billing = new Billing
            {
                Company = "abc",
                Address = new Address() { Address1 = "abc", },
                Email = "abc"
            },
            Shipping = new Shipping
            {
                FirstName = "abc",
                Address = new Address() { Address1 = "abc"}
            },
            Currency = "CAD",
            IpAddress = "999.999.999.999",
            ProcessorId = "abc",
            MerchantDefinedFields = new List<MerchantDefinedField>(){new (5, "abc"), new(20, "abc")},
            TestMode = true,
            
            
            Id = "abc",
            Type = InvoicingRequestType.AddInvoice,
            Amount = decimal.One,
            Tax = decimal.One,
            PaymentTerms = -1,
            PaymentMethodsAllowed = new List<PaymentType>(){PaymentType.Check, PaymentType.CreditCard},
            Website = "abc",
            CustomerId = "abc",
            CustomerTaxId = "abc",
            Items = new List<Item>()
            {
                new Item
                {
                    ProductCode = "abc",
                    Description = "abc",
                }
            },
        };

        var result = request.ToKeyValuePairs().ToList();

        Assert.Multiple(() =>
        {
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("security_key", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("orderid", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_product_code_1", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("company", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("address1", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("currency", "CAD")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("ipaddress", "999.999.999.999")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("processor_id", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("merchant_defined_field_5", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("merchant_defined_field_20", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("test_mode", "enabled")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_firstname", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_address1", "abc")));

            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("invoice_id", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("invoicing", "add_invoice")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("amount", "1.00")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("email", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("tax", "1.00")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("payment_terms", "upon_receipt")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("payment_methods_allowed", "ck,cc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("website", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("customer_id", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("customer_tax_id", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_product_code_1", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_description_1", "abc")));
        });
    }
}