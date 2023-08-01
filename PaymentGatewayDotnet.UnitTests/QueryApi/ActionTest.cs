using System.Xml.Linq;
using NUnit.Framework;
using Action = PaymentGatewayDotnet.QueryApi.Data.Action;

namespace PaymentGatewayDotnet.UnitTests.QueryApi;

[TestFixture]
public class ActionTest
{
    private const string _xml = @"<action>
        <amount>11.00</amount>
    <action_type>level3</action_type>
    <date>20150312215205</date>
    <success>1</success>
    <ip_address>1.1.1.1</ip_address>
    <source>virtual_terminal</source>
    <api_method></api_method>
    <username>demo</username>
    <response_text></response_text>
    <batch_id>0</batch_id>
    <processor_batch_id></processor_batch_id>
    <response_code>100</response_code>
    <processor_response_text>NO MATCH</processor_response_text>
    <processor_response_code>00</processor_response_code>
    <requested_amount>11.00</requested_amount>
    <device_license_number></device_license_number>
    <device_nickname></device_nickname>
    </action>";

    [Test]
    public void FromXmlElement_XmlDocumentReceived_ObjectCreated()
    {
        var document = XDocument.Parse(_xml);
        var actionElement = document.Element("action");
        var result = Action.FromXmlElement(actionElement);
        Assert.Multiple(() =>
        {
            Assert.That(result.Amount, Is.EqualTo(decimal.Parse("11")));
            Assert.That(result.ActionType, Is.EqualTo("level3"));
            Assert.That(result.Success, Is.EqualTo(true));
            Assert.That(result.RequestAmount, Is.EqualTo(decimal.Parse("11")));
            Assert.That(result.Date, Is.EqualTo(DateTime.Parse("2015-03-12T21:52:05")));
        });
    }
}