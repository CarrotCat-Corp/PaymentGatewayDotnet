using NUnit.Framework;
using PaymentGatewayDotnet.Model.Shared;

namespace PaymentGatewayDotnet.UnitTests.Shared;

[TestFixture]
public class OrderTests
{
    [Test]
    public void ToString_ObjectCreated_ValidKeyValidPairs()
    {
        var data = new Order
        {
            Id = "abc",
            Description = "abc",
            TemplateId = "abc",
            PoNumber = "abc",
            TaxAmount = decimal.One,
            DiscountAmount = decimal.One,
            SummaryCommodityCode = "abc",
            DutyAmount = decimal.One,
            NationalTaxAmount = decimal.One,
            VatTaxAmount = decimal.One,
            VatTaxRate = decimal.One,
            MerchantVatRegistration = "abc",
            CustomerVatRegistration = "abc",
            VatInvoiceReferenceNumber = "abc",
            AlternateTaxId = "abc",
            AlternateTaxAmount = decimal.One,
            Items = new List<Item>()
            {
                new Item
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
                }
            }
        };

        var result = data.ToKeyValuePairs().ToList();

        Assert.Multiple(() =>
        {
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("orderid", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("order_description", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("order_template", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("ponumber", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("tax", "1.00")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("discount_amount", "1.00")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("summary_commodity_code", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("duty_amount", "1.00")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("national_tax_amount", "1.00")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("vat_tax_amount", "1.00")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("vat_tax_rate", "1.00")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("merchant_vat_registration", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("customer_vat_registration", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("vat_invoice_reference_number", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("alternate_tax_id", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("alternate_tax_amount", "1.00")));
            
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_product_code_1", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_description_1", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_commodity_code_1", "abc123")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_unit_of_measure_1", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_unit_cost_1", "1.00")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_quantity_1", "1.00")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_total_amount_1", "1.00")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_tax_amount_1", "1.00")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_tax_rate_1", "1.00")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_discount_amount_1", "1.00")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_discount_rate_1", "1.00")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_tax_type_1", "abc")));
            Assert.That(result, Does.Contain(new KeyValuePair<string, string>("item_alternate_tax_id_1", "1234567890")));
        });
    }
}