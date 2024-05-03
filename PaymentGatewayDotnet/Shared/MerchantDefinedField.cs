using System;
using System.Collections.Generic;
using System.Xml.Linq;
using PaymentGatewayDotnet.Utilities;

namespace PaymentGatewayDotnet.Shared
{
    public sealed class MerchantDefinedField
    {
        public int Number { get; set; }
        public string Value { get; set; }

        public MerchantDefinedField(int number, string value)
        {
            if (number > 20 || number < 1) throw new ArgumentException("Number must be between 1 and 20 inclusively", nameof(Number));
            Number = number;
            Value = value;
        }

        public KeyValuePair<string, string> ToKeyValuePair() => new KeyValuePair<string, string>("merchant_defined_field_" + Number, Value);
        
        public static MerchantDefinedField FromXmlElement(XElement merchantDefinedFieldElement)
        {
            var idAttribute = merchantDefinedFieldElement?.Attribute("id");
            if (idAttribute is null || !int.TryParse(idAttribute.Value, out var idAttributeValue)) return null;

            return new MerchantDefinedField(idAttributeValue, XmlUtilities.XElementToString(merchantDefinedFieldElement));
        }
        
        public static MerchantDefinedField FromXmlElement(XElement merchantDefinedFieldElement, int id)
        {
            var value = XmlUtilities.XElementToString(merchantDefinedFieldElement);
            if (value == null) return null;
            return new MerchantDefinedField(id, value);
        }

        public static IEnumerable<MerchantDefinedField> ParseXmlElement(XElement element)
        {
            for (var i = 0; i < 20; i++)
            {
                if (element.Element("merchant-defined-field-" + i) != null)
                {
                    yield return FromXmlElement(element.Element("merchant-defined-field-" + i), i);
                }
            }
        }
    }
}