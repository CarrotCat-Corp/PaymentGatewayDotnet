using System;
using System.Globalization;
using System.Xml.Linq;

namespace PaymentGatewayDotnet.Utilities
{
    public static class XmlUtilities
    {
        public static decimal? XElementToDecimal(XElement element, string name = "N/A", string parent = "N/A")
        {
            if (!EnsureXElementExistsAndNotNull(element)) return null;

            var result = decimal.TryParse(element?.Value, out var resultValue);
            if (!result) throw new Exception($"Cannot parse XML Element {element?.Name} value <<{element?.Value}>> to double");
            return resultValue;
        }

        public static int? XElementToInt(XElement element, string name = "N/A", string parent = "N/A")
        {
            if (!EnsureXElementExistsAndNotNull(element)) return null;

            var result = int.TryParse(element?.Value, out var resultValue);
            if (!result) throw new Exception($"Cannot parse XML Element {element?.Name} value <<{element?.Value}>> to double");
            return resultValue;
        }

        public static DateTime? XElementToDateTime(XElement element, string pattern, string name = "N/A", string parent = "N/A")
        {
            if (!EnsureXElementExistsAndNotNull(element)) return null;

            // var result = DateTime.TryParse(element.Value, pattern, out var resultValue);
            var result = DateTime.TryParseExact(element?.Value, pattern, null, DateTimeStyles.None, out var resultValue);
            if (!result) throw new Exception($"Cannot parse XML Element {element?.Name} value <<{element?.Value}>> to DateTime");
            return resultValue;
        }

        public static string XElementToString(XElement element, string name = "N/A", string parent = "N/A")
        {
            return !EnsureXElementExists(element) ? null : element?.Value;
        }
        
        public static bool? XElementToBool(XElement element, string name = "N/A", string parent = "N/A")
        {
            return !EnsureXElementExists(element) ? null : element?.Value?.Equals("true", StringComparison.OrdinalIgnoreCase);
        }
        
        public static bool EnsureXElementExistsAndNotNull(XElement element)
        {
            return element != null && !string.IsNullOrEmpty(element.Value.Trim());
        }

        public static bool EnsureXElementExists(XElement element)
        {
            return element != null;
        }
    }
}