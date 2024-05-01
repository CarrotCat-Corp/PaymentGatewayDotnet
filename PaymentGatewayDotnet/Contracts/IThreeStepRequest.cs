using System.Xml.Linq;

namespace PaymentGatewayDotnet.Contracts
{
    internal interface IThreeStepRequest
    {
        XDocument ToXml();
    }
}