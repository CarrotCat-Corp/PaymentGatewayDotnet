using System.Collections.Generic;
using PaymentGatewayDotnet.Abstractions;
using PaymentGatewayDotnet.Contracts;
using PaymentGatewayDotnet.Shared;
using PaymentGatewayDotnet.Shared.Enums;

namespace PaymentGatewayDotnet.PaymentApi.Requests
{
    public class InvoicingRequest : BasePaymentApiRequest, IPaymentApiRequest
    {
        /// <summary>
        /// Type of invoicing request
        /// </summary>
        public InvoicingRequestType Type { get; set; }

        public Invoice Invoice { get; set; }


        public InvoicingRequest(string securityKey, InvoicingRequestType type) : base(securityKey)
        {
            Type = type;
        }


        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            var list = new List<KeyValuePair<string, string>>();

            if (Type != null)
                list.Add(new KeyValuePair<string, string>("invoicing", InvoicingRequestTypeUtils.ToString(Type)));
            list.AddRange(base.ToKeyValuePairs());
            list.AddRange(Invoice.ToKeyValuePairs());

            return list;
        }
    }
}