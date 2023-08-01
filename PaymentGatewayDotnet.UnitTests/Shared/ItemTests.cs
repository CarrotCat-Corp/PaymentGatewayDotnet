using NUnit.Framework;
using PaymentGatewayDotnet.Shared;

namespace PaymentGatewayDotnet.UnitTests.Shared;

[TestFixture]
public class ItemTests
{
    [Test]
    [TestCase(1)]
    [TestCase(21)]
    public void ToKeyValuePairs_AllFieldsAreValid_ValidListOfKeyValues(int itemNumber)
    {
        var data = new Item
        {
            ProductCode = "abc",
            Description = "abc",
            CommodityCode = "abc123",
            UnitOfMeasure = "abc",
            UnitCost = decimal.One,
            Quantity = decimal.One,
            TotalAmount = decimal.One,
            TaxAmount = decimal.One,
            TaxRate = decimal.One,
            DiscountAmount = decimal.One,
            DiscountRate = decimal.One,
            TaxType = "abc",
            AlternateTaxId = "1234567890",
        };

        var result = data.ToKeyValuePairs(itemNumber).ToList();

        Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_product_code_"+itemNumber, "abc")));
        Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_description_"+itemNumber, "abc")));
        Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_commodity_code_"+itemNumber, "abc123")));
        Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_unit_of_measure_"+itemNumber, "abc")));
        Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_unit_cost_"+itemNumber, "1.00")));
        Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_quantity_"+itemNumber, "1.00")));
        Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_total_amount_"+itemNumber, "1.00")));
        Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_tax_amount_"+itemNumber, "1.00")));
        Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_tax_rate_"+itemNumber, "1.00")));
        Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_discount_amount_"+itemNumber, "1.00")));
        Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_discount_rate_"+itemNumber, "1.00")));
        Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_tax_type_"+itemNumber, "abc")));
        Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_alternate_tax_id_"+itemNumber, "1234567890")));
    }
}