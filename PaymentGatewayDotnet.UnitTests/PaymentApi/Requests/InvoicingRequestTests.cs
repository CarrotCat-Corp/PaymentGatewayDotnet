// using PaymentGatewayDotnet.Shared;
// using PaymentGatewayDotnet.Shared.Enums;
//
// namespace PaymentGatewayDotnet.UnitTests.PaymentApi.InvoicingRequest;
//
// using NUnit.Framework;
// using System.Collections.Generic;
//
// [TestFixture]
// public class InvoicingRequestTests
// {
//     [Test]
//     public void ToKeyValuePairs_WithAllData_ReturnsKeyValuePairs()
//     {
//         // Arrange
//         var invoicingRequest = new InvoicingRequest("mySecurityKey", InvoicingRequestType.AddInvoice)
//         {
//             Invoice = new Invoice
//             {
//                 Number = "INV123",
//                 Amount = 100.0m,
//                 Currency = "USD"
//             }
//         };
//
//         // Act
//         var keyValuePairs = invoicingRequest.ToKeyValuePairs();
//
//         // Assert
//         Assert.IsNotNull(keyValuePairs);
//         Assert.IsInstanceOf<IEnumerable<KeyValuePair<string, string>>>(keyValuePairs);
//         var keyValueList = new List<KeyValuePair<string, string>>(keyValuePairs);
//
//         Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("invoicing", "Type1")));
//         Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("security_key", "mySecurityKey")));
//         Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("invoice_number", "INV123")));
//         Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("invoice_amount", "100.00")));
//         Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("invoice_currency", "USD")));
//     }
//
//     [Test]
//     public void ToKeyValuePairs_WithNoInvoice_ReturnsKeyValuePairs()
//     {
//         // Arrange
//         var invoicingRequest = new InvoicingRequest("mySecurityKey", InvoicingRequestType.Type2);
//
//         // Act
//         var keyValuePairs = invoicingRequest.ToKeyValuePairs();
//
//         // Assert
//         Assert.IsNotNull(keyValuePairs);
//         Assert.IsInstanceOf<IEnumerable<KeyValuePair<string, string>>>(keyValuePairs);
//         var keyValueList = new List<KeyValuePair<string, string>>(keyValuePairs);
//
//         Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("invoicing", "Type2")));
//         Assert.IsTrue(keyValueList.Contains(new KeyValuePair<string, string>("security_key", "mySecurityKey")));
//         Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("invoice_number", "INV123")));
//         Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("invoice_amount", "100.00")));
//         Assert.IsFalse(keyValueList.Contains(new KeyValuePair<string, string>("invoice_currency", "USD")));
//     }
// }
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
// [TestFixture]
// public class InvoicingRequestTestsq
// {
//     [Test]
//     public void ToKeyValuePairs_GivenObject_GeneratesValidRequest()
//     {
//         var request = new PaymentGatewayDotnet.PaymentApi.Requests.InvoicingRequest("abc", InvoicingRequestType.AddInvoice)
//         {
//             Invoice = new Invoice
//             {
//                 Id = null,
//                 Amount = 0,
//                 Tax = null,
//                 PaymentTerms = null,
//                 OrderDescription = null,
//                 PaymentMethodsAllowed = null,
//                 Website = null,
//                 CustomerId = null,
//                 CustomerTaxId = null,
//                 Items = null,
//                 Shipping = null,
//                 Billing = new Billing
//                 {
//                     Company = "abc",
//                     Address = new Address() { Address1 = "abc" },
//                     Email = "abc"
//                 }
//             },
//
//
//             Order = new Order
//             {
//                 Id = "abc",
//                 Items = new List<Item>() { new Item { ProductCode = "abc", } }
//             },
//             Billing = new Billing
//             {
//                 Company = "abc",
//                 Address = new Address() { Address1 = "abc", },
//                 Email = "abc"
//             },
//
//             Shipping = new Shipping
//             {
//                 FirstName = "abc",
//                 Address = new Address() { Address1 = "abc" }
//             },
//             Currency = "CAD",
//             IpAddress = "999.999.999.999",
//             ProcessorId = "abc",
//             MerchantDefinedFields = new List<MerchantDefinedField>() { new(5, "abc"), new(20, "abc") },
//             TestMode = true,
//             Id = "abc",
//             Type = InvoicingRequestType.AddInvoice,
//             Amount = decimal.One,
//             Tax = decimal.One,
//             PaymentTerms = -1,
//             PaymentMethodsAllowed = new List<PaymentType>() { PaymentType.Check, PaymentType.CreditCard },
//             Website = "abc",
//             CustomerId = "abc",
//             CustomerTaxId = "abc",
//             Items = new List<Item>()
//             {
//                 new Item
//                 {
//                     ProductCode = "abc",
//                     Description = "abc",
//                 }
//             },
//         };
//
//         var result = request.ToKeyValuePairs().ToList();
//
//         Assert.Multiple(() =>
//         {
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("security_key", "abc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("invoicing", "add_invoice")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("amount", "1.00")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("email", "a@b.com")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("payment_terms", "upon_receipt")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("payment_methods_allowed", "cc,ck,cs")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("processor_id", "test_processor")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("currency", "CAD")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("order_description", "order description")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("orderid", "abc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("customer_id", "abc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("customer_tax_id", "abc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("tax", "1.00")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping", "1.00")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("ponumber", "abc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("first_name", "abc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("last_name", "abc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("TEMP", "abc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("TEMP", "abc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("TEMP", "abc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("TEMP", "abc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("TEMP", "abc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("TEMP", "abc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("TEMP", "abc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("TEMP", "abc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("TEMP", "abc")));
//
//
//             
//             
//             
//             
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("orderid", "abc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_product_code_1", "abc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("company", "abc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("address1", "abc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("currency", "CAD")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("ipaddress", "999.999.999.999")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("processor_id", "abc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("merchant_defined_field_5", "abc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("merchant_defined_field_20", "abc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("test_mode", "enabled")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_firstname", "abc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_address1", "abc")));
//
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("invoice_id", "abc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("invoicing", "add_invoice")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("amount", "1.00")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("email", "abc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("tax", "1.00")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("payment_terms", "upon_receipt")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("payment_methods_allowed", "ck,cc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("website", "abc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("customer_id", "abc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("customer_tax_id", "abc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_product_code_1", "abc")));
//             Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_description_1", "abc")));
//         });
//     }
// }
//
//
//
