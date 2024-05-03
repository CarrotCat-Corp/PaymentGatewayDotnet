using System.Xml.Linq;

namespace PaymentGatewayDotnet.Contracts
{
    public interface IThreeStepRequest
    {
        XDocument ToXml();
    }
}