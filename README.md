# PaymentGatewayDotnet

#### v0.1.0-beta

---

Please review LICENSE.md before using this library. 

## What is PaymentGatewayDotnet?
PaymentGatewayDotnet is a library that provides comprehensive and convenient way to assemble and make transactions with `*.transactiongateway.com` type of gateways.
The advantage of this library is that it brakes down gateway requests into logical and digestible chunks making it easier to build the requests. 
This library has both static and service implementations of gateway client and can be used both as stand-alone and via dependency injection.

## Compatibility?
PaymentGatewayDotnet is .NET Standard 2.0 library. You can check .NET Standard 2.0 compatibility with your version of .NET on [this](https://learn.microsoft.com/en-us/dotnet/standard/net-standard?tabs=net-standard-2-0) page 

## How do I get Started?
First, of course, you need to download PaymentGatewayDotnet NuGet package and add dependency to your project.

Next steps depend on implementation that you will choose: static, or service.

### Static
_**WARNING!!! If your app will be making a lot of gateway requests, using static implementation can lead to socket exhaustion problem that will either slow down, freeze, or crash your application.**_

I strongly advise against using this method. 

To make the request simply pass your `FinancialRequest`, `CustomerVaultRequest`, `InvoicingRequest`, or `RecurringPlanRequest` object and `Uri` object containing gateway address to `Gateway.PaymentApiPost()` method and await the `PaymentApiResponse`:

``` C#
PaymentApiResponse response = await Gateway.PaymentApiPost(new FinancialRequest("YourPrivateKey"), new Uri("YourGatewayUri"));
```

### Service
The most proper way to use GatewayClient is utilize .NET's dependency injection framework. To do that you will need to register GatewayClient in your `Startup.cs` or `Program.cs` and pass your base address Uri (e.g.: `"new Uri(https://abc.transactiongateway.com)"`) as an argument.
(The exact implementation may wary based on your version of .NET)

``` C#
builder.Services.AddTransient<IGatewyClient, GatewayClient>(new Uri(https://abc.transactiongateway.com));
```
_Note: you can also setup GatewayClient as Singleton or Scoped service, depending on your app needs._

You can now inject Gateway Client to your controller or service:
``` C#
class Foo{
    private readonly IGatewayClient _gatewayClient;

    public Foo(IGatewayClient gatewayClient)
    {
        _gatewayClient = gatewayClient;
    }

    //ToDo: Implement rest of the class methods
}
```
you can now use it in your class:

``` C#
PaymentApiResponse response = await _gatewayClient.PaymentApiPost(new FinancialRequest("YourPrivateKey", FinancialRequestType.Sale));

```



## How do I create request object?
In this library Gateway's Payment API request is separated into 4 separate requests `FinancialRequest`, `CustomerVaultRequest`, `InvoicingRequest`, and `RecurringPlanRequest`.
To create a request you need to instantiate one of these objects, passing your Private Security Key into it, and then add your request parameters:

```C#
var request = new FinancialRequest("SecurityKey", FinancialRequestType.Sale)
        {
            PaymentCredentials = new PaymentCredentials()
            {
                CreditCard = new CreditCard()
                {
                    Number = "4111111111111111",
                    Expiration = "10/25",
                    Cvv = "999"
                }
            },
            Amount = new decimal(1.50),
            Billing = new Billing() { Address = new Address() { Address1 = "888", PostalZip = "77777" } },
        };

```

## What about response?

Response comes in the form of `PaymentApiResponse` object with property names that correspond to those in your documentation.  
`PaymentApiResponse` object also contains convenience fields to get text response values instead of original numeric codes:

```C#
public sealed class PaymentApiResponse
{
        public byte? RawResponse { get; }
        public string ResponseText { get; }
        public string AuthCode { get; }
        public string TransactionId { get; }
        public string RawAvsResponse { get; }
        public string RawCvvResponse { get; }
        public string OrderId { get; }
        public string Type { get; }
        public string ResponseCode { get; }
        public string EmvAuthResponseData { get; }
        public string ProcessorId { get; }
        public string CustomerVaultId { get; }
        public string KountScore { get; }
        
        public TransactionResponse TransactionResponse => TransactionResponseUtils.ParseByte(RawResponse);
        public string ResponseMessage => ResultCodes.GetResponseCodeString(ResponseCode);
        public string AvsResponse => ResultCodes.GetAvsResponseString(RawAvsResponse);
        public string CvvResponse => ResultCodes.GetCvvResponseString(RawCvvResponse);
}
```

## Contributors
[Empyrean Merchant Services](https://empyreanms.com/)

## Version History

### v1.0.0

- Added support for Payment API requests