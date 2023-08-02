using System.Xml.Linq;
using PaymentGatewayDotnet.QueryApi.Data;
using PaymentGatewayDotnet.QueryApi.Enums;

namespace PaymentGatewayDotnet.UnitTests.QueryApi;

[TestFixture]
public class TransactionTest
{

    [Test]
    public void FromXmlElement_XmlDocumentReceived_ObjectCreated()
    {
        var document = XDocument.Parse(_xml);
        var actionElement = document.Element("transaction");
        var result = Transaction.FromXmlElement(actionElement);
        Assert.Multiple(() =>
        {
            Assert.That(result.TransactionId, Is.EqualTo("2612675976"));
            Assert.That(result.Condition, Is.EqualTo(Condition.Complete));
            Assert.That(result.Shipping, Is.EqualTo(decimal.One));
        });
    }
    
        private const string _xml = @"<transaction>
        <transaction_id>2612675976</transaction_id>
        <partial_payment_id></partial_payment_id>
        <partial_payment_balance></partial_payment_balance>
        <platform_id></platform_id>
        <transaction_type>cc</transaction_type>
        <condition>complete</condition>
        <order_id>1234567890</order_id>
        <authorization_code>123456</authorization_code>
        <ponumber></ponumber>
        <order_description></order_description>
        <first_name>John</first_name>
        <last_name>Smith</last_name>
        <address_1>123 Main St</address_1>
        <address_2>Apt B</address_2>
        <company></company>
        <city>New York City</city>
        <state>NY</state>
        <postal_code>10001</postal_code>
        <country>US</country>
        <email>johnsmith@example.com</email>
        <phone>1234567890</phone>
        <fax></fax>
        <cell_phone></cell_phone>
        <customertaxid></customertaxid>
        <customerid></customerid>
        <website></website>
        <shipping_first_name></shipping_first_name>
        <shipping_last_name></shipping_last_name>
        <shipping_address_1></shipping_address_1>
        <shipping_address_2></shipping_address_2>
        <shipping_company></shipping_company>
        <shipping_city></shipping_city>
        <shipping_state></shipping_state>
        <shipping_postal_code></shipping_postal_code>
        <shipping_country></shipping_country>
        <shipping_email></shipping_email>
        <shipping_carrier></shipping_carrier>
        <tracking_number></tracking_number>
        <shipping_date></shipping_date>
        <shipping>1.00</shipping>
        <shipping_phone></shipping_phone>
        <cc_number>4xxxxxxxxxxx1111</cc_number>
        <cc_hash>f6c609e195d9d4c185dcc8ca662f0180</cc_hash>
        <cc_exp>1215</cc_exp>
        <cavv></cavv>
        <cavv_result></cavv_result>
        <xid></xid>
        <eci></eci>
        <directory_server_id></directory_server_id>
        <three_ds_version></three_ds_version>
        <avs_response>N</avs_response>
        <csc_response>M</csc_response>
        <cardholder_auth></cardholder_auth>
        <cc_start_date></cc_start_date>
        <cc_issue_number></cc_issue_number>
        <check_account></check_account>
        <check_hash></check_hash>
        <check_aba></check_aba>
        <check_name></check_name>
        <account_holder_type></account_holder_type>
        <account_type></account_type>
        <sec_code></sec_code>
        <drivers_license_number></drivers_license_number>
        <drivers_license_state></drivers_license_state>
        <drivers_license_dob></drivers_license_dob>
        <social_security_number></social_security_number>
        <processor_id>processora</processor_id>
        <tax>1.00</tax>
        <currency>USD</currency>
        <surcharge></surcharge>
        <cash_discount></cash_discount>
        <tip></tip>
        <card_balance></card_balance>
        <card_available_balance></card_available_balance>
        <entry_mode>Keyed</entry_mode>
        <cc_bin>411111</cc_bin>
        <cc_type>visa</cc_type>
        <signature_image>
            iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAIAAACQkWg2AAAAAXNSR0IArs4c6QAAAARnQU1BAA
                Cxjwv8YQUAAAAJcEhZcwAAEnQA
            ABJ0Ad5mH3gAAACGSURBVDhPlZGBEoAgCEO1//9nG83mxMrr3dkBG0hVW2vFqLX26CYbPIc7yS
                AVe8LBq5u4elyV4M0NXIoGXYqA
            w4QqMAwJCRu+Az7HSlvgHtexlFKwGrLjG/h/rESmhrhRnLCKwjiNeLYv5QsXOoNSig8IsNYaZ0
                tXJoGU9hU1k18XlZLOQHTenf7I
            cf3BwAAAABJRU5ErkJggg==
        </signature_image>
        <product>
            <sku>RS-100</sku>
            <quantity>1.0000</quantity>
            <description>Red Shirt</description>
            <amount>10.0000</amount>
        </product>
        <action>
            <amount>11.00</amount>
            <action_type>sale</action_type>
            <date>20150312215205</date>
            <success>1</success>
            <ip_address>1.1.1.1</ip_address>
            <source>virtual_terminal</source>
            <api_method></api_method>
            <username>demo</username>
            <response_text>SUCCESS</response_text>
            <batch_id>0</batch_id>
            <processor_batch_id></processor_batch_id>
            <response_code>100</response_code>
            <processor_response_text>NO MATCH</processor_response_text>
            <processor_response_code>00</processor_response_code>
            <requested_amount>11.00</requested_amount>
            <device_license_number></device_license_number>
            <device_nickname></device_nickname>
        </action>
        <action>
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
            <processor_response_text></processor_response_text>
            <processor_response_code></processor_response_code>
            <device_license_number></device_license_number>
            <device_nickname></device_nickname>
        </action>
        <action>
            <amount>11.00</amount>
            <action_type>settle</action_type>
            <date>20150313171503</date>
            <success>1</success>
            <ip_address></ip_address>
            <source>internal</source>
            <api_method></api_method>
            <username></username>
            <response_text>ACCEPTED</response_text>
            <batch_id>76158269</batch_id>
            <processor_batch_id>782</processor_batch_id>
            <response_code>100</response_code>
            <processor_response_text></processor_response_text>
            <processor_response_code>0000000000021980</processor_response_code>
            <device_license_number></device_license_number>
            <device_nickname></device_nickname>
        </action>
    </transaction>";
}