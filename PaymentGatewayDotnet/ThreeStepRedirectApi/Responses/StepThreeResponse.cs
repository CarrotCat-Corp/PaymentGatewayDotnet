using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using PaymentGatewayDotnet.Exceptions;
using PaymentGatewayDotnet.Shared;
using PaymentGatewayDotnet.Shared.Enums;
using PaymentGatewayDotnet.Utilities;

namespace PaymentGatewayDotnet.ThreeStepRedirectApi.Responses
{
    public class StepThreeResponse
    {
        public int Result { get; private set; }
        
        public string ResultText { get; private set; }
        
        public string TransactionId { get; private set; }
        
        public string ResultCode { get; private set; }

        public string AuthorizationCode { get; private set; }

        public string AvsResult { get; private set; }

        public string CvvResult { get; private set; }

        public TransactionType ActionType { get; private set; }

        public decimal? Amount { get; private set; }

        public decimal? AmountAuthorized { get; private set; }

        public string Currency { get; private set; }

        public string IpAddress { get; private set; }

        public string Industry { get; private set; }

        public InstallmentBillingMethod BillingMethod { get; private set; }

        public string ProcessorId { get; private set; }

        public PaymentDescriptor PaymentDescriptor { get; private set; }

        public Order Order { get; private set; }

        public Ach Ach { get; private set; }

        public ThreeDSecure ThreeDSecure { get; private set; }

        public int? DupSeconds { get; private set; }

        public PartialPayment PartialPayment { get; private set; }

        public IEnumerable<MerchantDefinedField> MerchantDefinedFields { get; private set; }

        public Shipping Shipping { get; private set; }

        public Billing Billing { get; private set; }

        public DriversLicense DriversLicense { get; private set; }

        public CreditCard CreditCard { get; private set; }

        public string CustomerId { get; private set; }
        
        public string CustomerVaultId { get; private set; }
        
        public string MerchantReceiptEmail { get; private set; }


        public string ProcessorResponseMessage => ResultCodes.GetResponseCodeString(ResultCode);

        // private StepThreeResponse(
        //     int result,
        //     string resultText,
        //     string transactionId,
        //     string resultCode, string authorizationCode, string avsResult, string cvvResult, TransactionType actionType, decimal? amount, decimal? amountAuthorized, string currency, string ipAddress, string industry, InstallmentBillingMethod billingMethod, string processorId, PaymentDescriptor paymentDescriptor, Order order)
        // {
        //     Result = result;
        //     ResultText = resultText;
        //     TransactionId = transactionId;
        //     ResultCode = resultCode;
        //     AuthorizationCode = authorizationCode;
        //     AvsResult = avsResult;
        //     CvvResult = cvvResult;
        //     ActionType = actionType;
        //     Amount = amount;
        //     AmountAuthorized = amountAuthorized;
        //     Currency = currency;
        //     IpAddress = ipAddress;
        //     Industry = industry;
        //     BillingMethod = billingMethod;
        //     ProcessorId = processorId;
        //     PaymentDescriptor = paymentDescriptor;
        //     Order = order;
        // }
        
        private StepThreeResponse(
            int result,
            string resultText,
            string transactionId,
            string resultCode, 
            string authorizationCode, 
            string avsResult, 
            string cvvResult, 
            TransactionType actionType, 
            decimal? amount, 
            decimal? amountAuthorized, 
            string currency, 
            string ipAddress, 
            string industry, 
            InstallmentBillingMethod billingMethod, 
            string processorId, 
            PaymentDescriptor paymentDescriptor, 
            Order order,
            Ach ach,
            ThreeDSecure threeDSecure,
            int? dupSeconds,
            PartialPayment partialPayment,
            IEnumerable<MerchantDefinedField> merchantDefinedFields,
            Shipping shipping,
            Billing billing,
            DriversLicense driversLicense,
            CreditCard creditCard,
            string customerId,
            string customerVaultId,
            string merchantReceiptEmail
        )
        {
            Result = result;
            ResultText = resultText;
            TransactionId = transactionId;
            ResultCode = resultCode;
            AuthorizationCode = authorizationCode;
            AvsResult = avsResult;
            CvvResult = cvvResult;
            ActionType = actionType;
            Amount = amount;
            AmountAuthorized = amountAuthorized;
            Currency = currency;
            IpAddress = ipAddress;
            Industry = industry;
            BillingMethod = billingMethod;
            ProcessorId = processorId;
            PaymentDescriptor = paymentDescriptor;
            Order = order;
            Ach = ach;
            ThreeDSecure = threeDSecure;
            DupSeconds = dupSeconds;
            PartialPayment = partialPayment;
            MerchantDefinedFields = merchantDefinedFields;
            Shipping = shipping;
            Billing = billing;
            DriversLicense = driversLicense;
            CreditCard = creditCard;
            CustomerId = customerId;
            CustomerVaultId = customerVaultId;
            MerchantReceiptEmail = merchantReceiptEmail;
        }

        public static StepThreeResponse FromXmlString(string httpResponse)
        {
            var document = XDocument.Parse(httpResponse);
            if (document == null) throw new GatewayResponseException("Response is not an XML Document");

            var responseElement = document.Element("response");
            if (responseElement == null) throw new GatewayResponseException("Error Response");

            return new StepThreeResponse(
                result: XmlUtilities.XElementToInt(responseElement.Element("result")) ??
                        throw new GatewayResponseException("Invalid value for transaction result"),

                resultText: XmlUtilities.XElementToString(responseElement.Element("result-text")),

                transactionId: XmlUtilities.XElementToString(responseElement.Element("transaction-id")),

                resultCode: XmlUtilities.XElementToString(responseElement.Element("result-code")),

                authorizationCode: XmlUtilities.XElementToString(responseElement.Element("authorization-code")),

                avsResult: XmlUtilities.XElementToString(responseElement.Element("avs-result")),

                cvvResult: XmlUtilities.XElementToString(responseElement.Element("cvv-result")),

                actionType: TransactionTypeUtils.ParseString(
                    XmlUtilities.XElementToString(responseElement.Element("action-type"))
                ),

                amount: XmlUtilities.XElementToDecimal(responseElement.Element("amount")),

                amountAuthorized: XmlUtilities.XElementToDecimal(responseElement.Element("amount-authorized")),

                currency: XmlUtilities.XElementToString(responseElement.Element("currency")),

                ipAddress: XmlUtilities.XElementToString(responseElement.Element("ip-address")),

                industry: XmlUtilities.XElementToString(responseElement.Element("industry")),

                billingMethod: InstallmentBillingMethodUtils.ParseString(
                    XmlUtilities.XElementToString(responseElement.Element("billing-method"))
                ),

                processorId: XmlUtilities.XElementToString(responseElement.Element("processor-id")),

                paymentDescriptor: PaymentDescriptor.FromXmlElement(responseElement),

                order: Order.FromXmlElement(responseElement),

                ach: Ach.FromXmlElement(responseElement),

                threeDSecure: ThreeDSecure.FromXmlElement(responseElement),

                dupSeconds: XmlUtilities.XElementToInt(responseElement.Element("dup-seconds")),

                partialPayment: PartialPayment.FromXmlElement(responseElement),

                merchantDefinedFields: MerchantDefinedField.ParseXmlElement(responseElement),

                shipping: Shipping.FromXmlElement(responseElement),

                billing: Billing.FromXmlElement(responseElement.Element("billing")),

                driversLicense: DriversLicense.FromXmlElement(responseElement),

                creditCard: CreditCard.FromXmlElement(responseElement.Element("billing")),

                customerId: XmlUtilities.XElementToString(responseElement.Element("customer-id")),

                customerVaultId: XmlUtilities.XElementToString(responseElement.Element("customer-vault-id")),

                merchantReceiptEmail: XmlUtilities.XElementToString(responseElement.Element("merchant-receipt-email"))
                );
        }
    }
}