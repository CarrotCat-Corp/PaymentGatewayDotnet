using PaymentGatewayDotnet.Shared.Enums;

namespace PaymentGatewayDotnet.PaymentApi.Requests
{
    public class TransactionRequest: BaseApiRequest
    {
        /// <summary>
        /// The type of transaction to be processed
        /// 'sale', 'auth', 'credit', 'validate', or 'offline'
        /// </summary>
        public FinancialRequestType Type { get; set; }
        
        
    }
}