using System.Collections.Generic;
using System.Xml.Linq;
using PaymentGatewayDotnet.Exceptions;

namespace PaymentGatewayDotnet.Abstractions
{
    public class BaseStepThreeRequest : BaseApiRequest
    {
        protected const string RequestName = "complete-action";

        /// <summary>
        /// Customer payment token returned during step two.
        /// </summary>
        public string TokenId { get; private set; }

        protected BaseStepThreeRequest(string securityKey, string tokenId) : base(securityKey)
        {
            TokenId = tokenId ?? throw new InvalidArgumentException(nameof(TokenId),
                "Token ID, that is returned in step two, is required");
        }

        protected new IEnumerable<XElement> ToXmlElements()
        {
            foreach (var element in base.ToXmlElements())
            {
                yield return element;
            }

            yield return new XElement("token-id", TokenId);
        }
    }
}