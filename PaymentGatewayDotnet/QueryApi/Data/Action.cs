using System;
using System.Xml.Linq;
using PaymentGatewayDotnet.Shared;
using PaymentGatewayDotnet.Utilities;

namespace PaymentGatewayDotnet.QueryApi.Data
{
    public class Action
    {
        public decimal? Amount { get; private set; }
        public string ActionType { get; private set; }
        public DateTime? Date { get; private set; }
        public bool? Success { get; private set; }
        public string IpAddress { get; private set; }
        public string Source { get; private set; }
        public string ApiMethod { get; private set; }
        public string Username { get; private set; }
        public string ResponseText { get; private set; }
        public string BatchId { get; private set; }
        public string ProcessorBatchId { get; private set; }
        public string ResponseCode { get; private set; }
        public string ProcessorResponseText { get; private set; }
        public string ProcessorResponseCode { get; private set; }
        public decimal? RequestAmount { get; private set; }
        public string DeviceLicenseNumber { get; private set; }
        public string DeviceNickname { get; private set; }

        public static Action FromXmlElement(XElement actionElement)
        {
            return new Action()
            {
                Amount = XmlUtilities.XElementToDecimal(actionElement.Element("amount"), "amount"),
                ActionType = XmlUtilities.XElementToString(actionElement.Element("action_type")),
                Date = XmlUtilities.XElementToDateTime(actionElement.Element("date"), "yyyyMMddHHmmss", "date", "action"),
                Success = actionElement.Element("success")?.Value.Equals("1"),
                IpAddress = XmlUtilities.XElementToString(actionElement.Element("ip_address")),
                Source = XmlUtilities.XElementToString(actionElement.Element("source")),
                ApiMethod = XmlUtilities.XElementToString(actionElement.Element("api_method")),
                Username = XmlUtilities.XElementToString(actionElement.Element("username")),
                ResponseText = XmlUtilities.XElementToString(actionElement.Element("response_text")),
                BatchId = XmlUtilities.XElementToString(actionElement.Element("batch_id")),
                ProcessorBatchId = XmlUtilities.XElementToString(actionElement.Element("processor_batch_id")),
                ResponseCode = XmlUtilities.XElementToString(actionElement.Element("response_code")),
                ProcessorResponseText = XmlUtilities.XElementToString(actionElement.Element("processor_response_text")),
                ProcessorResponseCode = XmlUtilities.XElementToString(actionElement.Element("processor_response_code")),
                RequestAmount = XmlUtilities.XElementToDecimal(actionElement.Element("requested_amount"), "requested_amount"),
                DeviceLicenseNumber = XmlUtilities.XElementToString(actionElement.Element("device_license_number")),
                DeviceNickname = XmlUtilities.XElementToString(actionElement.Element("device_nickname")),
            };
        }
    }
}