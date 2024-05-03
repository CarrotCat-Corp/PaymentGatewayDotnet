namespace PaymentGatewayDotnet.Shared
{
public static class ResultCodes
{
    public static string GetResponseCodeString(string responseCode)
    {
        switch (responseCode)
        {
            case "100":
                return "Approved";
            case "200":
                return "Declined by processor";
            case "201":
                return "Do not honor";
            case "202":
                return "Insufficient funds";
            case "203":
                return "Over limit";
            case "204":
                return "Transaction not allowed";
            case "220":
                return "Incorrect payment information";
            case "221":
                return "No such card issuer";
            case "222":
                return "No card number on file with issuer";
            case "223":
                return "Expired card";
            case "224":
                return "Invalid expiration date";
            case "225":
                return "Invalid card security code";
            case "226":
                return "Invalid PIN";
            case "240":
                return "Call issuer for further information";
            case "250":
                return "Pick up card";
            case "251":
                return "Lost card";
            case "252":
                return "Stolen card";
            case "253":
                return "Fraudulent card";
            case "260":
                return "Declined with further instructions available (See response text)";
            case "261":
                return "Declined - Stop all recurring payments";
            case "262":
                return "Declined - Stop this recurring program";
            case "263":
                return "Declined - Update cardholder data available";
            case "264":
                return "Declined - Retry in a few days";
            case "300":
                return "Transaction was rejected by gateway";
            case "301":
                return "Rate limit exceeded";
            case "400":
                return "Transaction error returned by processor";
            case "410":
                return "Invalid merchant configuration";
            case "411":
                return "Merchant account is inactive";
            case "420":
                return "Communication error";
            case "421":
                return "Communication error with issuer";
            case "430":
                return "Duplicate transaction at processor";
            case "440":
                return "Processor format error";
            case "441":
                return "Invalid transaction information";
            case "460":
                return "Processor feature not available";
            case "461":
                return "Unsupported card type";
            default:
                return "Unknown response code";
        }
    }

    public static string GetResponseCodeString(int responseCode) => GetResponseCodeString(responseCode.ToString());

    public static string GetAvsResponseString(string avsCode)
    {
        switch (avsCode?.ToLower())
        {
            case "x":
                return "Exact match, 9-character numeric ZIP";
            case "y":
            case "d":
            case "m":
                return "Exact match, 5-character numeric ZIP";
            case "2":
            case "6":
                return "Exact match, 5-character numeric ZIP, customer name";
            case "a":
            case "b":
                return "Address match only";
            case "3":
            case "7":
                return "Address, customer name match only";
            case "w":
                return "9-character numeric ZIP match only";
            case "z":
            case "p":
            case "l":
                return "5-character ZIP match only";
            case "1":
            case "5":
                return "5-character ZIP, customer name match only";
            case "n":
            case "c":
                return "No address or ZIP match only";
            case "4":
            case "8":
                return "No address or ZIP or customer name match only";
            case "u":
                return "Address unavailable";
            case "g":
            case "i":
                return "Non-U.S. issuer does not participate";
            case "r":
                return "Issuer system unavailable";
            case "e":
                return "Not a mail/phone order";
            case "s":
                return "Service not supported";
            case "0":
            case "o":
                return "AVS not available";
            default:
                return "Unknown response code";
        }
    }

    public static string GetCvvResponseString(string cvvCode)
    {
        switch (cvvCode?.ToLower())
        {
            case "m":
                return "CVV2/CVC2 match";
            case "n":
                return "CVV2/CVC2 no match";
            case "p":
                return "Not processed";
            case "s":
                return "Merchant has indicated that CVV2/CVC2 is not present on card";
            case "u":
                return "Issuer is not certified and/or has not provided Visa encryption keys";
            default:
                return "Unknown response code";
        }
    }
}
}