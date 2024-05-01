using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using PaymentGatewayDotnet.Contracts;
using PaymentGatewayDotnet.Shared;

namespace PaymentGatewayDotnet.Abstractions
{
    public abstract class BaseStepOneRequest : BaseApiRequest
    {
        // 3-8, 11-19, 22-31, 34-37

        /// <summary>
        /// A URL on your web server that the gateway will redirect your customer to after sensitive data collection.
        /// </summary>
        protected string RedirectUrl { get; private set; }

        /// <summary>
        /// List of merchant defined fields.
        /// Note: Gateway supports fields with numbers inclusively between 1 and 20. 
        /// </summary>
        public IEnumerable<MerchantDefinedField> MerchantDefinedFields { get; set; }

        protected BaseStepOneRequest(string securityKey, string redirectUrl) : base(securityKey)
        {
            RedirectUrl = redirectUrl ?? throw new ArgumentNullException(nameof(redirectUrl));
        }

        protected new IEnumerable<XElement> ToXmlElements()
        {
            var elements = new List<XElement>();
            elements.AddRange(base.ToXmlElements());

            elements.Add(new XElement("redirect_url", RedirectUrl));

            elements.AddRange(
                MerchantDefinedFields.Select(
                    merchantDefinedField => new XElement(
                        $"merchant_defined_field_{merchantDefinedField.Number}",
                        merchantDefinedField.Value)
                    )
            );

            return elements;
        }
    }
}