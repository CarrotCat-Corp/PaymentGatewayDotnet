using System;
using System.Collections.Generic;

namespace PaymentGatewayDotnet.Model.Shared
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
    }
}