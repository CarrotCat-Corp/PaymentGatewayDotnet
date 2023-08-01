using System.Threading.Tasks;
using PaymentGatewayDotnet.Contracts;
using PaymentGatewayDotnet.PaymentApi.Response;
using PaymentGatewayDotnet.QueryApi;

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
        
        /// <summary>
        /// Implementation of Query API's receipt request.
        ///
        /// <br/>
        /// Refer to gateway documentation for more information
        /// </summary>
        /// <param name="request">IQueryApiReceiptRequest Object. I.E. QueryApiReceiptRequest</param>
        /// <returns>String representation of HTML receipt</returns>
        Task<string> QueryApiGetReceipt(IQueryApiReceiptRequest request);
    }
}