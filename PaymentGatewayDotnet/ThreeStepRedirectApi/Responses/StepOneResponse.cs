using System;
using System.Xml.Linq;
using PaymentGatewayDotnet.Shared;
using PaymentGatewayDotnet.Utilities;

namespace PaymentGatewayDotnet.ThreeStepRedirectApi.Responses
{
    public class StepOneResponse
    {
        public int Result { get; private set; }
        public string ResultText { get; private set; }
        public string TransactionId { get; private set; }
        public string ResultCode { get; private set; }
        public string FormUrl { get; private set; }
        
        public string ProcessorResponseMessage => ResultCodes.GetResponseCodeString(ResultCode);

        private StepOneResponse(
            int result,
            string resultText,
            string transactionId,
            string resultCode,
            string formUrl
        )
        {
            Result = result;
            ResultText = resultText;
            TransactionId = transactionId;
            ResultCode = resultCode;
            FormUrl = formUrl;
        }

        public static StepOneResponse FromXmlString(string httpResponse)
        {
            var document = XDocument.Parse(httpResponse);
            if (document == null) throw new Exception("Response is not an XML Document");

            var responseElement = document.Element("response");
            if (responseElement == null) throw new Exception("Error Response");

            return new StepOneResponse(
                XmlUtilities.XElementToInt(responseElement.Element("result")) ?? 3,
                XmlUtilities.XElementToString(responseElement.Element("result-text")),
                XmlUtilities.XElementToString(responseElement.Element("transaction-id")),
                XmlUtilities.XElementToString(responseElement.Element("result-code")),
                XmlUtilities.XElementToString(responseElement.Element("form-url"))
            );
        }
    }
}