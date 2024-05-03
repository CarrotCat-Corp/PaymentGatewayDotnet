using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PaymentGatewayDotnet.Contracts;
using PaymentGatewayDotnet.PaymentApi.Response;
using PaymentGatewayDotnet.QueryApi;
using PaymentGatewayDotnet.ThreeStepRedirectApi.Responses;

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
        
        public async Task<StepOneResponse> StepOnePost(IThreeStepRequest request)
        {
            var formContent = new StringContent(request.ToXml().ToString(), Encoding.UTF8, "application/xml");
            var response = await _httpClient.PostAsync("api/v2/three-step", formContent);
            response.EnsureSuccessStatusCode();
            return StepOneResponse.FromXmlString(await response.Content.ReadAsStringAsync());
        }

        public async Task<StepThreeResponse> StepThreePost(IThreeStepRequest request)
        {
            var formContent = new StringContent(request.ToXml().ToString(), Encoding.UTF8, "application/xml");
            var response = await _httpClient.PostAsync("api/v2/three-step", formContent);
            response.EnsureSuccessStatusCode();
            return StepThreeResponse.FromXmlString(await response.Content.ReadAsStringAsync());
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
            return QueryApiResponse.FromXmlString(await QueryApiPost(formContent));
        }

        public async Task<string> QueryApiGetReceipt(IQueryApiReceiptRequest request)
        {
            var formContent = new FormUrlEncodedContent(request.ToKeyValuePairs());
            return await QueryApiPost(formContent); 
        }
        
        private async Task<string> QueryApiPost(FormUrlEncodedContent formContent)
        {
            var response = await _httpClient.PostAsync("api/query.php", formContent);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}