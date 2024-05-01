using System.Collections.Generic;
using System.Linq;
using PaymentGatewayDotnet.Shared;

namespace PaymentGatewayDotnet.Abstractions
{
    public abstract class BasePaymentApiRequest : BaseApiRequest
    {
        
        /// <summary>
        /// If using Multiple MIDs, route to this processor (processor_id is obtained under Settings → Transaction Routing in the Control Panel).
        /// </summary>
        public string ProcessorId { get; set; }

        /// <summary>
        /// List of merchant defined fields.
        /// Note: Gateway supports fields with numbers inclusively between 1 and 20. 
        /// </summary>
        public IEnumerable<MerchantDefinedField> MerchantDefinedFields { get; set; }

        /// <summary>
        /// ***   NOT SUPPORTED IN THREE-STEP REDIRECT METHOD   ***
        /// <br/><br/>
        /// One-off test transactions can be processed using the below test_mode variable. This will process this singular transaction in test mode, but it will not impact anything else on the account. An example use case would be running test transactions in a developent environment while your website is actively processing real transactions from customers.
        /// <br/><br/>
        /// If set to "true" and providing one of the test credit card numbers, the single transaction will process in test mode. To see this transaction in reporting, you will need to toggle your account to test mode, but the Payment API testing can be done without doing this. 
        /// </summary>
        public bool? TestMode { get; set; }

        protected BasePaymentApiRequest(string securityKey) : base(securityKey){}


        public new IEnumerable<KeyValuePair<string, string>> ToKeyValuePairs()
        {
            var list = new List<KeyValuePair<string, string>>();
            list.AddRange(base.ToKeyValuePairs());

            if (ProcessorId != null) list.Add(new KeyValuePair<string, string>("processor_id", ProcessorId));

            if (MerchantDefinedFields is null || !MerchantDefinedFields.Any()) return list;
            
            list.AddRange(MerchantDefinedFields.Select(mdf => mdf.ToKeyValuePair()));

            return list;
        }
    }
}