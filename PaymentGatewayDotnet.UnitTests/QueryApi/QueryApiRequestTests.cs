using PaymentGatewayDotnet.QueryApi;
using PaymentGatewayDotnet.QueryApi.Enums;
using PaymentGatewayDotnet.Shared;
using PaymentGatewayDotnet.Shared.Enums;

namespace PaymentGatewayDotnet.UnitTests.QueryApi;

[TestFixture]
public class QueryApiRequestTests
{
    [Test]
    public void ToKeyValuePairs_WithValidData_ReturnsKeyValuePairList()
    {
        // Arrange
        const string securityKey = "SECURITYKEY123";
        var queryApiRequest = new QueryApiRequest(securityKey)
        {
            Conditions = new List<Condition> { Condition.PendingSettlement, Condition.Complete },
            TransactionType = PaymentType.CreditCard,
            ActionTypes = new List<TransactionType> { TransactionType.Sale, TransactionType.Auth },
            Sources = new List<Source> { Source.Api, Source.Recurring },
            TransactionIds = new List<string> { "TRAN001", "TRAN002" },
            SubscriptionIds = new List<string> { "SUBS001", "SUBS002" },
            InvoiceId = "INV001",
            PartialPaymentId = "PARTIAL001",
            OrderId = "ORDER001",
            FirstName = "John",
            LastName = "Doe",
            Address1 = "123 Main St",
            City = "New York",
            State = "NY",
            Zip = "10001",
            Phone = "555-123-4567",
            Fax = "555-987-6543",
            OrderDescription = "Test Order",
            DriversLicenseNumber = "DL123456",
            DriversLicenseDob = "19800101",
            DriversLicenseState = "NY",
            Email = "john.doe@example.com",
            CcNumber = "4111111111111111",
            MerchantDefinedFields = new List<MerchantDefinedField>
            {
                new ( 1, "Value1" ),
                new ( 2, "Value2" )
            },
            StartDate = new DateTime(2023, 7, 1, 0, 0, 0),
            EndDate = new DateTime(2023, 7, 31, 23, 59, 59),
            ReportType = ReportType.CustomerVault,
            MobileDeviceLicence = "D91AC56A-4242-3131-2323-2AE4AA6DB6EB,any_mobile",
            MobileDeviceNickname = "Jim's iPhone",
            CustomerVaultId = "CUST001",
            DateSearch = new List<DateType> { DateType.Created, DateType.Updated },
            ResultLimit = 10,
            PageNumber = 1,
            ResultOrder = ResultOrder.Reverse,
            InvoiceStatuses = new List<InvoiceStatus> { InvoiceStatus.Paid, InvoiceStatus.Closed }
        };

        // Act
        var valuePairList = queryApiRequest.ToKeyValuePairs()?.ToList();

        // Assert
        
        Assert.That(valuePairList, Is.Not.Null);
        Assert.That(valuePairList, Is.InstanceOf<List<KeyValuePair<string, string>>>());
        Assert.Multiple(() =>
        {
            Assert.That(valuePairList.Count(), Is.EqualTo(37));

            Assert.That(valuePairList.Any(kvp => kvp.Key == "security_key" && kvp.Value == securityKey), Is.True);
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "condition", Value: "pendingsettlement,complete" }), Is.True);
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "transaction_type", Value: "cc" }), Is.True);
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "action_type", Value: "sale,auth" }), Is.True);
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "source", Value: "api,recurring" }), Is.True);
            
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "transaction_id", Value: "TRAN001,TRAN002" }), Is.True);
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "subscription_id", Value: "SUBS001,SUBS002" }), Is.True);
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "invoice_id", Value: "INV001" }), Is.True);
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "partial_payment_id", Value: "PARTIAL001" }), Is.True);
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "order_id", Value: "ORDER001" }), Is.True);
            
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "first_name", Value: "John" }), Is.True);
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "last_name", Value: "Doe" }), Is.True);
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "address1", Value: "123 Main St" }), Is.True);
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "city", Value: "New York" }), Is.True);
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "state", Value: "NY" }), Is.True);
            
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "zip", Value: "10001" }), Is.True);
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "phone", Value: "555-123-4567" }), Is.True);
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "fax", Value: "555-987-6543" }), Is.True);
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "order_description", Value: "Test Order" }), Is.True);
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "drivers_license_number", Value: "DL123456" }), Is.True);
            
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "drivers_license_dob", Value: "19800101" }), Is.True);
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "drivers_license_state", Value: "NY" }), Is.True);
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "email", Value: "john.doe@example.com" }), Is.True);
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "cc_number", Value: "4111111111111111" }), Is.True);
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "merchant_defined_field_1", Value: "Value1" }), Is.True);
            
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "merchant_defined_field_2", Value: "Value2" }), Is.True);
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "start_date", Value: "20230701000000" }), Is.True);
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "end_date", Value: "20230731235959" }), Is.True);
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "report_type", Value: "customer_vault" }), Is.True);
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "mobile_device_license", Value: "D91AC56A-4242-3131-2323-2AE4AA6DB6EB,any_mobile" }), Is.True);
            
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "mobile_device_nickname", Value: "Jim's iPhone" }), Is.True);
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "customer_vault_id", Value: "CUST001" }), Is.True);
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "date_search", Value: "created,updated" }), Is.True);
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "result_limit", Value: "10" }), Is.True);
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "page_number", Value: "1" }), Is.True);
            
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "result_order", Value: "reverse" }), Is.True);
            Assert.That(valuePairList.Any(kvp => kvp is { Key: "invoice_status", Value: "paid,closed" }), Is.True);
        });
    }

    [Test]
    public void ToKeyValuePairs_WithNullValues_ReturnsKeyValuePairListWithoutNulls()
    {
        // Arrange
        var securityKey = "SECURITYKEY456";
        var queryApiRequest = new QueryApiRequest(securityKey)
        {

        };

        // Act
        var keyValuePairList = queryApiRequest.ToKeyValuePairs()?.ToList();

        // Assert
        Assert.That(keyValuePairList, Is.Not.Null);
        Assert.That(keyValuePairList, Is.InstanceOf<List<KeyValuePair<string, string>>>());
        Assert.That(keyValuePairList.Count(), Is.EqualTo(1));

        Assert.That(keyValuePairList.Any(kvp => kvp.Key == "security_key" && kvp.Value == securityKey), Is.True);
    }
}
