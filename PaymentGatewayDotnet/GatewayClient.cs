using System;
using System.Net.Http;
using System.Threading.Tasks;
using PaymentGatewayDotnet.Model;
using PaymentGatewayDotnet.Model.PaymentApi;
using PaymentGatewayDotnet.Model.PaymentApi.PaymentApiResponseModel;
using PaymentGatewayDotnet.Model.QueryApi;

namespace PaymentGatewayDotnet
{
    public sealed class GatewayClient : IGatewayClient
    {
        private readonly HttpClient _httpClient;

        public GatewayClient(Uri baseUri = null)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.BaseAddress = baseUri??new Uri("https://secure.networkmerchants.com");
        }

        public async Task<PaymentApiResponse> PaymentApiPost(IPaymentApiRequest request)
        {
            var formContent = new FormUrlEncodedContent(request.ToKeyValuePairs());
            var response = await _httpClient.PostAsync("api/transact.php", formContent);
            response.EnsureSuccessStatusCode();
            return PaymentApiResponse.FromQueryString(await response.Content.ReadAsStringAsync());
        }
        
        public async Task<QueryApiResponse> QueryApiPost(IQueryApiRequest request)
        {
            var formContent = new FormUrlEncodedContent(request.ToKeyValuePairs());
            var response = await _httpClient.PostAsync("api/query.php", formContent);
            response.EnsureSuccessStatusCode();
            return QueryApiResponse.FromXmlString(await response.Content.ReadAsStringAsync());
        }
        
    }
}