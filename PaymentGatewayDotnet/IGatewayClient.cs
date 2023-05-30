using System;
using System.Threading.Tasks;
using PaymentGatewayDotnet.Model;
using PaymentGatewayDotnet.Model.PaymentApi;
using PaymentGatewayDotnet.Model.PaymentApi.PaymentApiResponseModel;
using PaymentGatewayDotnet.Model.QueryApi;

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

        /// <summary>
        /// Implementation of Query API.
        ///
        /// <br/>
        /// Refer to gateway documentation for more information
        /// </summary>
        /// <param name="request">IQueryApiRequest Object. I.E. QueryApiRequest</param>
        /// <returns>QueryApiResponse object </returns>
        Task<QueryApiResponse> QueryApiPost(IQueryApiRequest request);
    }
}