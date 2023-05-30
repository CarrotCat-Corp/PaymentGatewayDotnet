using System;
using System.Xml.Linq;
using PaymentGatewayDotnet.Model.Shared;

namespace PaymentGatewayDotnet.Model.QueryApi
{
    public class Action
    {
        public decimal? Amount { get; set; }
        public string ActionType { get; set; }
        public DateTime? Date { get; set; }
        public bool? Success { get; set; }
        public string IpAddress { get; set; }
        public string Source { get; set; }
        public string ApiMethod { get; set; }
        public string Username { get; set; }
        public string ResponseText { get; set; }
        public string BatchId { get; set; }
        public string ProcessorBatchId { get; set; }
        public string ResponseCode { get; set; }
        public string ProcessorResponseText { get; set; }
        public string ProcessorResponseCode { get; set; }
        public decimal? RequestAmount { get; set; }
        public string DeviceLicenseNumber { get; set; }
        public string DeviceNickname { get; set; }

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