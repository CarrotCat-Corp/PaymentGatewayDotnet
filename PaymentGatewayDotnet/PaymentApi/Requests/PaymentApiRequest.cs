using System;
using System.Collections.Generic;
using System.Linq;
using PaymentGatewayDotnet.Shared;

namespace PaymentGatewayDotnet.PaymentApi.Requests
{
    public class PaymentApiRequest : BaseApiRequest
    {
        
        /// <summary>
        /// If using Multiple MIDs, route to this processor (processor_id is obtained under Settings → Transaction Routing in the Control Panel).
        /// </summary>
        public string ProcessorId { get; set; }

        /// <summary>
        /// List of merchant defined fields.
        /// Note: Gateway supports fields with numbers inclusively between 1 and 20. 
        /// </summary>
        public List<MerchantDefinedField> MerchantDefinedFields { get; set; }



        public PaymentApiRequest(string securityKey) : base(securityKey){}


        public IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            var list = new List<KeyValuePair<string, string>>();
            list.AddRange(base.ToKeyValuePairs());

            if (ProcessorId != null) list.Add(new KeyValuePair<string, string>("processor_id", ProcessorId));

            if (MerchantDefinedFields is null || MerchantDefinedFields.Count <= 0) return list;
            list.AddRange(MerchantDefinedFields.Select(mdf => mdf.ToKeyValuePair()));

            return list;
        }
    }
}