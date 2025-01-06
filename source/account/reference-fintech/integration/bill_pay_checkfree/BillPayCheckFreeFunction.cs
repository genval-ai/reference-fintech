using System;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;
using System.Net.Http;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace BillPayCheckFree
{
    public class BillPayCheckFreeFunction
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiEndpoint;
        private readonly string _apiKey;
        private readonly string _merchantId;
        private readonly string _environment;
        private readonly string _webhookSecret;

        public BillPayCheckFreeFunction()
        {
            _httpClient = new HttpClient();
            _apiEndpoint = Environment.GetEnvironmentVariable("CHECKFREE_API_ENDPOINT");
            _apiKey = Environment.GetEnvironmentVariable("CHECKFREE_API_KEY");
            _merchantId = Environment.GetEnvironmentVariable("CHECKFREE_MERCHANT_ID");
            _environment = Environment.GetEnvironmentVariable("CHECKFREE_ENVIRONMENT");
            _webhookSecret = Environment.GetEnvironmentVariable("CHECKFREE_WEBHOOK_SECRET");
        }

        public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
        {
            context.Logger.LogLine($"Processing request data for request {request.RequestContext.RequestId}.");

            if (request.HttpMethod == "POST")
            {
                if (request.Path == "/pay-bill")
                {
                    return await HandlePayBill(request);
                }
                else if (request.Path == "/get-bill-status")
                {
                    return await HandleGetBillStatus(request);
                }
                else if (request.Path == "/schedule-payment")
                {
                    return await HandleSchedulePayment(request);
                }
            }

            return new APIGatewayProxyResponse
            {
                StatusCode = 400,
                Body = "Invalid request"
            };
        }

        private async Task<APIGatewayProxyResponse> HandlePayBill(APIGatewayProxyRequest request)
        {
            try
            {
                var payBillRequest = JsonConvert.DeserializeObject<PayBillRequest>(request.Body);

                // TODO: Implement the actual API call to CheckFree for bill payment
                // This is a placeholder implementation
                var response = await _httpClient.PostAsync($"{_apiEndpoint}/payments/create", 
                    new StringContent(JsonConvert.SerializeObject(new
                    {
                        apiKey = _apiKey,
                        merchantId = _merchantId,
                        billerId = payBillRequest.BillerId,
                        accountNumber = payBillRequest.AccountNumber,
                        amount = payBillRequest.Amount,
                        dueDate = payBillRequest.DueDate,
                        paymentMethod = MapPaymentMethod(payBillRequest.PaymentMethod)
                    })));

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var payBillResponse = JsonConvert.DeserializeObject<PayBillResponse>(responseContent);

                    return new APIGatewayProxyResponse
                    {
                        StatusCode = 200,
                        Body = JsonConvert.SerializeObject(payBillResponse)
                    };
                }
                else
                {
                    return new APIGatewayProxyResponse
                    {
                        StatusCode = 500,
                        Body = "Error processing bill payment"
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

        private async Task<APIGatewayProxyResponse> HandleGetBillStatus(APIGatewayProxyRequest request)
        {
            try
            {
                var getBillStatusRequest = JsonConvert.DeserializeObject<GetBillStatusRequest>(request.Body);

                // TODO: Implement the actual API call to CheckFree for getting bill status
                // This is a placeholder implementation
                var response = await _httpClient.GetAsync($"{_apiEndpoint}/payments/{getBillStatusRequest.TransactionId}/status?apiKey={_apiKey}&merchantId={_merchantId}");

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var billStatusResponse = JsonConvert.DeserializeObject<GetBillStatusResponse>(responseContent);

                    return new APIGatewayProxyResponse
                    {
                        StatusCode = 200,
                        Body = JsonConvert.SerializeObject(billStatusResponse)
                    };
                }
                else
                {
                    return new APIGatewayProxyResponse
                    {
                        StatusCode = 500,
                        Body = "Error getting bill status"
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

        private async Task<APIGatewayProxyResponse> HandleSchedulePayment(APIGatewayProxyRequest request)
        {
            try
            {
                var schedulePaymentRequest = JsonConvert.DeserializeObject<SchedulePaymentRequest>(request.Body);

                // TODO: Implement the actual API call to CheckFree for scheduling payment
                // This is a placeholder implementation
                var response = await _httpClient.PostAsync($"{_apiEndpoint}/payments/schedule", 
                    new StringContent(JsonConvert.SerializeObject(new
                    {
                        apiKey = _apiKey,
                        merchantId = _merchantId,
                        billerId = schedulePaymentRequest.BillerId,
                        accountNumber = schedulePaymentRequest.AccountNumber,
                        amount = schedulePaymentRequest.Amount,
                        scheduledDate = schedulePaymentRequest.ScheduledDate,
                        paymentMethod = MapPaymentMethod(schedulePaymentRequest.PaymentMethod)
                    })));

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var schedulePaymentResponse = JsonConvert.DeserializeObject<SchedulePaymentResponse>(responseContent);

                    return new APIGatewayProxyResponse
                    {
                        StatusCode = 200,
                        Body = JsonConvert.SerializeObject(schedulePaymentResponse)
                    };
                }
                else
                {
                    return new APIGatewayProxyResponse
                    {
                        StatusCode = 500,
                        Body = "Error scheduling payment"
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

        private string MapPaymentMethod(string paymentMethod)
        {
            switch (paymentMethod)
            {
                case "bank_account":
                    return "ACH";
                case "debit_card":
                    return "DEBIT";
                case "credit_card":
                    return "CREDIT";
                default:
                    throw new ArgumentException($"Invalid payment method: {paymentMethod}");
            }
        }
    }

    public class PayBillRequest
    {
        public string BillerId { get; set; }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public string PaymentMethod { get; set; }
    }

    public class PayBillResponse
    {
        public string TransactionId { get; set; }
        public string Status { get; set; }
        public string ConfirmationNumber { get; set; }
        public DateTime ProcessingDate { get; set; }
    }

    public class GetBillStatusRequest
    {
        public string TransactionId { get; set; }
    }

    public class GetBillStatusResponse
    {
        public string TransactionId { get; set; }
        public string Status { get; set; }
        public DateTime ProcessingDate { get; set; }
        public DateTime? CompletionDate { get; set; }
    }

    public class SchedulePaymentRequest
    {
        public string BillerId { get; set; }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string PaymentMethod { get; set; }
    }

    public class SchedulePaymentResponse
    {
        public string ScheduleId { get; set; }
        public string Status { get; set; }
        public DateTime ScheduledDate { get; set; }
    }
}