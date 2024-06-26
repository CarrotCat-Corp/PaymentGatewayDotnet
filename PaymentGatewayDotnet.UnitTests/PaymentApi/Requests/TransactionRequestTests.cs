using PaymentGatewayDotnet.PaymentApi.Requests;
using PaymentGatewayDotnet.Shared;
using PaymentGatewayDotnet.Shared.Enums;
using PaymentGatewayDotnet.Shared.RetailDevises;

namespace PaymentGatewayDotnet.UnitTests.PaymentApi.Requests;

[TestFixture]
public class TransactionRequestTests
{
    [Test]
    public void ToKeyValuePairs_GivenObject_GeneratesValidRequest()
    {
        var request = new TransactionRequest("123", TransactionType.Sale)
        {
            Order = new Order
            {
                Id = "abc",
                Items = new List<Item>()
                {
                    new Item
                    {
                        ProductCode = "abc",
                    }
                }
            },
            Billing = new Billing
            {
                Company = "abc",
                Address = new Address()
                {
                    Address1 = "abc",
                },
                CustomerReceipt = true,
            },
            Currency = "CAD",
            IpAddress = "999.999.999.999",
            ProcessorId = "abc",
            MerchantDefinedFields = new List<MerchantDefinedField>() { new(5, "abc"), new(20, "abc") },
            TestMode = true,
            PaymentCredentials = new PaymentCredentials
            {
                PaymentToken = "abc",
            },
            CustomerVaultId = "abc",
            CustomerVaultAction = CustomerVaultAction.AddCustomer,
            Amount = decimal.One,
            Tip = decimal.One,
            Surcharge = decimal.One,
            CashDiscount = decimal.One,
            Kount = new Kount { TransactionSessionId = "abc" },
            PaymentDescriptor = new PaymentDescriptor { Descriptor = "abc" },
            StoredCredentialsIndicatorParameters = new StoredCredentialsIndicatorParameters
                { InitialTransactionId = "abc" },
            SignatureImage = "abc",
            PinlessDebitOverride = true,
            DuplicateSeconds = 1,
            InstallmentBilling = new InstallmentBillingData { Method = InstallmentBillingMethod.Recurring },
            AuthorizationCode = "abc",
            ThreeDSecure = new ThreeDSecure { Cavv = "abc" },
            DriversLicence = new DriversLicense()
                { Number = "abc", DateOfBirth = "2000-01-01", State = "abc" },
            PartialPayment = new PartialPayment { PartialPaymentType = PartialPaymentType.SettlePartial },
            PaymentFacilitator = new PaymentFacilitator() { Id = "abc" },
            RetailData = new CardDeviceData
            {
                UnencryptedRetailMagneticStripeData = new UnencryptedRetailMagneticStripeData { Track1 = "abc" }
            },
            Payment = PaymentType.Cash,
            Shipping = new Shipping
            {
                FirstName = "abc",
                Address = new Address() { Address1 = "abc" }
            }
        };

        var result = request.ToKeyValuePairs().ToList();


        Assert.Multiple(() =>
        {
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("security_key", "123")));
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
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("payment_token", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("amount", "1.00")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("tip", "1.00")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("surcharge", "1.00")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("cash_discount", "1.00")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("transaction_session_id", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("descriptor", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("initial_transaction_id", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("signature_image", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("pinless_debit_override", "Y")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("dup_seconds", "1")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("billing_method", "recurring")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("authorization_code", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("cavv", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("drivers_license_number", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("partial_payments", "settle_partial")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("payment_facilitator_id", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("track_1", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("payment", "cash")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("customer_receipt", "true")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_firstname", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("shipping_address1", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("customer_vault_id", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("customer_vault", "add_customer")));
        });
    }

    [Test]
    public void ToKeyValuePairs_CustomerVaultUpdate_GeneratesValidRequest()
    {
        var request = new TransactionRequest("123", TransactionType.Sale)
        {
            CustomerVaultId = "abc",
            CustomerVaultAction = CustomerVaultAction.UpdateCustomer,
        };

        var result = request.ToKeyValuePairs().ToList();


        Assert.Multiple(() =>
        {
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("customer_vault_id", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("customer_vault", "update_customer")));
        });
    }


    [Test]
    public void ToKeyValuePairs_GivenVoidObject_GeneratesValidRequest()
    {
        var request = new TransactionRequest("123", TransactionType.Void)
        {
            TestMode = true,
            PaymentCredentials = new PaymentCredentials
            {
                TransactionId = "abc",
            },
            VoidReason = VoidReasonType.Fraud,
            Payment = PaymentType.Cash,
        };

        var result = request.ToKeyValuePairs().ToList();

        Assert.Multiple(() =>
        {
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("security_key", "123")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("type", "void")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("transactionid", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("void_reason", "fraud")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("payment", "cash")));
        });
    }
}