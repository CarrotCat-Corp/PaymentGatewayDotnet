using System.Web;

namespace PaymentGatewayDotnet.PaymentApi.Response
{
    public sealed class PaymentApiResponse
    {
        /// <summary>
        /// 1 = Transaction Approved
        /// 2 = Transaction Declined
        /// 3 = Error in transaction data or system error 
        /// </summary>
        public byte? RawResponse { get; } //

        /// <summary>
        /// Textual Response
        /// </summary>
        public string ResponseText { get; }

        /// <summary>
        /// Transaction authorization code.
        /// </summary>
        public string AuthCode { get; }

        /// <summary>
        /// Payment gateway transaction id.
        /// </summary>
        public string TransactionId { get; }

        /// <summary>
        /// AVS rawResponse code (See AVS RawResponse Codes). https://empyrean.transactiongateway.com/merchants/resources/integration/integration_portal.php#dp_appendix_1
        /// </summary>
        public string RawAvsResponse { get; }

        /// <summary>
        /// CVV rawResponse code (See See CVV RawResponse Codes). https://empyrean.transactiongateway.com/merchants/resources/integration/integration_portal.php#dp_appendix_2
        /// </summary>
        public string RawCvvResponse { get; }

        /// <summary>
        /// The original order id passed in the transaction request.
        /// </summary>
        public string OrderId { get; }

        public string Type { get; }

        /// <summary>
        /// Numeric mapping of processor responses (See See Result Code Table).  https://empyrean.transactiongateway.com/merchants/resources/integration/integration_portal.php#transaction_response_variables
        /// </summary>
        public string ResponseCode { get; }

        /// <summary>
        /// This will optionally come back when any chip card data is provided on the authorization. This data needs to be sent back to the SDK after an authorization.
        /// </summary>
        public string EmvAuthResponseData { get; }

        public string ProcessorId { get; }

        /// <summary>
        /// The original customer_vault_id passed in the transaction request or the resulting customer_vault_id created on an approved transaction.
        /// <br/>
        /// Note: Only returned when the "Customer Vault" service is active. 
        /// </summary>
        public string CustomerVaultId { get; }

        /// <summary>
        /// The Kount "Omniscore" indicating the level of risk on a given transaction. The higher the score, the lower the risk.
        /// <br/>
        /// Note: Only returned when the "Kount" service is active. 
        /// </summary>
        public string KountScore { get; }
        
        public TransactionResponse TransactionResponse => TransactionResponseUtils.ParseByte(RawResponse);
        public string ResponseMessage => ResultCodes.GetResponseCodeString(ResponseCode);
        public string AvsResponse => ResultCodes.GetAvsResponseString(RawAvsResponse);
        public string CvvResponse => ResultCodes.GetCvvResponseString(RawCvvResponse);

        public PaymentApiResponse(
            byte? rawResponse = null,
            string responseText = null,
            string authCode = null,
            string transactionId = null,
            string avsResponse = null,
            string cvvResponse = null,
            string orderId = null,
            string type = null,
            string responseCode = null,
            string emvAuthResponseData = null,
            string processorId = null,
            string customerVaultId = null,
            string kountScore = null
        )
        {
            RawResponse = rawResponse;
            ResponseText = responseText;
            AuthCode = authCode;
            TransactionId = transactionId;
            RawAvsResponse = avsResponse;
            RawCvvResponse = cvvResponse;
            OrderId = orderId;
            Type = type;
            ResponseCode = responseCode;
            EmvAuthResponseData = emvAuthResponseData;
            ProcessorId = processorId;
            CustomerVaultId = customerVaultId;
            KountScore = kountScore;
        }

        public static PaymentApiResponse FromQueryString(string data)
        {
            var query = HttpUtility.ParseQueryString(data);
            return new PaymentApiResponse(
                rawResponse: byte.Parse(query["response"] ?? "0"),
                responseText: query["responsetext"],
                authCode: query["authcode"],
                transactionId: query["transactionid"],
                avsResponse: query["avsresponse"],
                cvvResponse: query["cvvresponse"],
                orderId: query["orderid"],
                type: query["type"],
                responseCode: query["response_code"],
                emvAuthResponseData: query["emv_auth_response_data"],
                processorId: query["processor_id"],
                customerVaultId: query["customer_vault_id"],
                kountScore: query["kount_score"]
            );
        }

    }
}