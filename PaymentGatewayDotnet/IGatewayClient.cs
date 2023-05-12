using System;
using System.Threading.Tasks;
using PaymentGatewayDotnet.Model;
using PaymentGatewayDotnet.Model.FinancialRequests;
using PaymentGatewayDotnet.Model.PaymentApiResponseModel;

namespace PaymentGatewayDotnet
{
    public interface IGatewayClient
    {
        /// <summary>
        /// Implementation of Payment API (aka Direct Post) method.
        /// Used for methods that require direct post such as Collect.JS, customer vault transactions, or the Payment API itself.
        /// <br/><br/>
        /// Note: Separate PCI certification is required for merchants who store or pass credit card or banking information in unencrypted, or encrypted in in a way that can be decrypted by merchant.
        /// 
        /// <br/>
        /// </summary>
        /// <param name="request">IPaymentApiRequest Object. I.E. FinancialRequest, InvoicingRequest, RecurringRequest</param>
        /// <returns>PaymentApiResponse object </returns>
        Task<PaymentApiResponse> PaymentApiPost(IPaymentApiRequest request);
    }
}