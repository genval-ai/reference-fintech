using System;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;
using System.Net.Http;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace WorldpayMoneyTransfer
{
    public class WorldpayMoneyTransferFunction
    {
        private readonly HttpClient _httpClient;
        private readonly string _worldpayApiEndpoint;
        private readonly string _merchantCode;
        private readonly string _apiKey;
        private readonly string _environment;
        private readonly string _notificationSecret;

        public WorldpayMoneyTransferFunction()
        {
            _httpClient = new HttpClient();
            _worldpayApiEndpoint = Environment.GetEnvironmentVariable("WORLDPAY_API_ENDPOINT");
            _merchantCode = Environment.GetEnvironmentVariable("WORLDPAY_MERCHANT_CODE");
            _apiKey = Environment.GetEnvironmentVariable("WORLDPAY_API_KEY");
            _environment = Environment.GetEnvironmentVariable("WORLDPAY_ENVIRONMENT");
            _notificationSecret = Environment.GetEnvironmentVariable("WORLDPAY_NOTIFICATION_SECRET");
        }

        public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
        {
            context.Logger.LogLine($"Processing request data for request {request.RequestContext.RequestId}.");

            if (request.HttpMethod == "POST")
            {
                if (request.Path == "/internal-transfer")
                {
                    return await HandleInternalTransfer(request);
                }
                else if (request.Path == "/external-transfer")
                {
                    return await HandleExternalTransfer(request);
                }
            }

            return new APIGatewayProxyResponse
            {
                StatusCode = 400,
                Body = "Invalid request"
            };
        }

        private async Task<APIGatewayProxyResponse> HandleInternalTransfer(APIGatewayProxyRequest request)
        {
            try
            {
                var internalTransferRequest = JsonConvert.DeserializeObject<InternalTransferRequest>(request.Body);

                // TODO: Implement the actual API call to Worldpay for internal transfer
                // This is a placeholder implementation
                var response = await _httpClient.PostAsync($"{_worldpayApiEndpoint}/internal-transfer", 
                    new StringContent(JsonConvert.SerializeObject(new
                    {
                        merchantCode = _merchantCode,
                        fromAccountId = internalTransferRequest.FromAccountId,
                        toAccountId = internalTransferRequest.ToAccountId,
                        amount = internalTransferRequest.Amount,
                        currency = internalTransferRequest.Currency
                    })));

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var transferResponse = JsonConvert.DeserializeObject<TransferResponse>(responseContent);

                    return new APIGatewayProxyResponse
                    {
                        StatusCode = 200,
                        Body = JsonConvert.SerializeObject(transferResponse)
                    };
                }
                else
                {
                    return new APIGatewayProxyResponse
                    {
                        StatusCode = 500,
                        Body = "Error processing internal transfer"
                    };
                }
            }
            catch (Exception ex)
            {
                return new APIGatewayProxyResponse
                {
                    StatusCode = 500,
                    Body = $"Internal server error: {ex.Message}"
                };
            }
        }

        private async Task<APIGatewayProxyResponse> HandleExternalTransfer(APIGatewayProxyRequest request)
        {
            try
            {
                var externalTransferRequest = JsonConvert.DeserializeObject<ExternalTransferRequest>(request.Body);

                // TODO: Implement the actual API call to Worldpay for external transfer
                // This is a placeholder implementation
                var response = await _httpClient.PostAsync($"{_worldpayApiEndpoint}/external-transfer", 
                    new StringContent(JsonConvert.SerializeObject(new
                    {
                        merchantCode = _merchantCode,
                        fromAccountId = externalTransferRequest.FromAccountId,
                        recipientName = externalTransferRequest.RecipientName,
                        recipientBank = externalTransferRequest.RecipientBank,
                        recipientAccountNumber = externalTransferRequest.RecipientAccountNumber,
                        amount = externalTransferRequest.Amount,
                        currency = externalTransferRequest.Currency
                    })));

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var transferResponse = JsonConvert.DeserializeObject<ExternalTransferResponse>(responseContent);

                    return new APIGatewayProxyResponse
                    {
                        StatusCode = 200,
                        Body = JsonConvert.SerializeObject(transferResponse)
                    };
                }
                else
                {
                    return new APIGatewayProxyResponse
                    {
                        StatusCode = 500,
                        Body = "Error processing external transfer"
                    };
                }
            }
            catch (Exception ex)
            {
                return new APIGatewayProxyResponse
                {
                    StatusCode = 500,
                    Body = $"Internal server error: {ex.Message}"
                };
            }
        }
    }

    public class InternalTransferRequest
    {
        public string FromAccountId { get; set; }
        public string ToAccountId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
    }

    public class ExternalTransferRequest
    {
        public string FromAccountId { get; set; }
        public string RecipientName { get; set; }
        public string RecipientBank { get; set; }
        public string RecipientAccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
    }

    public class TransferResponse
    {
        public string TransactionId { get; set; }
        public string Status { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class ExternalTransferResponse
    {
        public string TransactionId { get; set; }
        public string Status { get; set; }
        public DateTime EstimatedCompletionTime { get; set; }
        public decimal Fees { get; set; }
    }
}