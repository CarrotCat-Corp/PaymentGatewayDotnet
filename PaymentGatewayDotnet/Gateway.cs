using System;
using System.Net.Http;
using System.Threading.Tasks;
using PaymentGatewayDotnet.Model;
using PaymentGatewayDotnet.Model.CustomerVaultRequests;
using PaymentGatewayDotnet.Model.FinancialRequests;
using PaymentGatewayDotnet.Model.PaymentApiResponseModel;

namespace PaymentGatewayDotnet
{
    public sealed class Gateway
    {
        /// <summary>
        /// WARNING!!! <br/>
        /// This static implementation is not as performant as the same method from IGatewayClient implementation. You should use IGatewayClient methods whenever is possible. Using static implementation may lead to socket exhaustion problem.
        /// <br/><br/>
        ///
        /// Implementation of Payment API (aka Direct Post) method.
        /// Used for methods that require direct post such as Collect.JS, customer vault transactions, or the Payment API itself.
        /// <br/><br/>
        /// Note: Separate PCI certification is required for merchants who store or pass credit card or banking information in unencrypted, or encrypted in in a way that can be decrypted by merchant.
        /// 
        /// <br/>
        /// </summary>
        /// <param name="request">DirectPostRequest Object</param>
        /// <param name="uri">Host Uri, if null or omitted, default Uri for "https://secure.nmi.com/api/transact.php" will be used</param>
        /// <returns>DirectPostResponse object </returns>
        public static async Task<PaymentApiResponse> PaymentApiPost(IPaymentApiRequest request, Uri uri = null)
        {
            if (uri == null) uri = new Uri("https://secure.nmi.com/api/transact.php");
            
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = uri;
                var formContent = new FormUrlEncodedContent(request.ToKeyValuePairs());
                var response = await httpClient.PostAsync("", formContent);
                response.EnsureSuccessStatusCode();
                return PaymentApiResponse.FromQueryString(await response.Content.ReadAsStringAsync());
            }
        }
    }
}