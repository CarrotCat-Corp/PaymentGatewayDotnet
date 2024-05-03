using System.Xml.Linq;
using PaymentGatewayDotnet.Abstractions;
using PaymentGatewayDotnet.Contracts;

namespace PaymentGatewayDotnet.ThreeStepRedirectApi.Requests
{
    public class StepThreeTransactionRequest : BaseStepThreeRequest, IThreeStepRequest
    {
        public StepThreeTransactionRequest(string securityKey, string tokenId) : base(securityKey, tokenId)
        {
        }

        public XDocument ToXml()
        {
            var transactionElement = new XElement(RequestName);
            foreach (var element in base.ToXmlElements())
            {
                transactionElement.Add(element);
            }

            return new XDocument(
                new XDeclaration("1.0", "UTF-8", "yes"),
                transactionElement
            );
        }
    }
}