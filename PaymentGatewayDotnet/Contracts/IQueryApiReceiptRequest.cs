namespace PaymentGatewayDotnet.Contracts
{
    public interface IQueryApiReceiptRequest:IBaseApiRequest
    {
        string TransactionId { get; }
    }
}