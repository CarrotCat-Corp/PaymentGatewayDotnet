namespace PaymentGatewayDotnet.EndToEndTests;

public class TestConstants
{
    public const string PrivateSecurityKey = "6457Thfj624V5r7WUwc5v6a68Zsd6YEm";
    public const string PaymentApiUrl = "https://secure.networkmerchants.com/api/transact.php";
    
    public const string TestCardVisa01 = "4111111111111111";
    public const string TestCardVisa02 = "4000000000000002";
    public const string TestCardMastercard = "5431111111111111";
    public const string TestCardDiscover = "6011601160116611";
    public const string TestCardAmex = "341111111111111";
    public const string TestCardDiners = "30205252489926";
    public const string TestCardJcb = "3541963594572595";
    public const string TestCardMaestro = "6799990100000000019";
    public static readonly DateTime TestCardExpiration = new DateTime(2025, 10, 1);

    public const string TestAchAccount = "123123123";
    public const string TestAchRouting = "123123123";
    
    public const string AvsAddress1 = "888";
    public const string AvsZip = "77777";
    public const string Cvv = "999";
}