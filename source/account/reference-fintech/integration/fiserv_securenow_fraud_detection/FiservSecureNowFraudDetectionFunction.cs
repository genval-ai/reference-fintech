using System;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;
using System.Net.Http;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace FiservSecureNowFraudDetection
{
    public class FiservSecureNowFraudDetectionFunction
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiEndpoint;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _organizationId;

        public FiservSecureNowFraudDetectionFunction()
        {
            _httpClient = new HttpClient();
            _apiEndpoint = Environment.GetEnvironmentVariable("SECURENOW_API_ENDPOINT");
            _clientId = Environment.GetEnvironmentVariable("SECURENOW_CLIENT_ID");
            _clientSecret = Environment.GetEnvironmentVariable("SECURENOW_CLIENT_SECRET");
            _organizationId = Environment.GetEnvironmentVariable("SECURENOW_ORGANIZATION_ID");
        }

        public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
        {
            context.Logger.LogLine($"Processing request data for request {request.RequestContext.RequestId}.");

            if (request.HttpMethod == "POST")
            {
                if (request.Path == "/assess-session-risk")
                {
                    return await HandleSessionRiskAssessment(request);
                }
                else if (request.Path == "/assess-transaction-risk")
                {
                    return await HandleTransactionRiskAssessment(request);
                }
            }

            return new APIGatewayProxyResponse
            {
                StatusCode = 400,
                Body = "Invalid request"
            };
        }

        private async Task<APIGatewayProxyResponse> HandleSessionRiskAssessment(APIGatewayProxyRequest request)
        {
            try
            {
                var sessionRiskRequest = JsonConvert.DeserializeObject<SessionRiskAssessmentRequest>(request.Body);

                // TODO: Implement the actual API call to Fiserv SecureNow for session risk assessment
                // This is a placeholder implementation
                var response = await _httpClient.PostAsync($"{_apiEndpoint}/assess-session-risk", 
                    new StringContent(JsonConvert.SerializeObject(new
                    {
                        clientId = _clientId,
                        clientSecret = _clientSecret,
                        organizationId = _organizationId,
                        sessionId = sessionRiskRequest.SessionId,
                        userId = sessionRiskRequest.UserId,
                        deviceInfo = sessionRiskRequest.DeviceInfo,
                        ipAddress = sessionRiskRequest.IpAddress,
                        timestamp = sessionRiskRequest.Timestamp
                    })));

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var riskAssessment = JsonConvert.DeserializeObject<SessionRiskAssessmentResponse>(responseContent);

                    return new APIGatewayProxyResponse
                    {
                        StatusCode = 200,
                        Body = JsonConvert.SerializeObject(riskAssessment)
                    };
                }
                else
                {
                    return new APIGatewayProxyResponse
                    {
                        StatusCode = 500,
                        Body = "Error assessing session risk"
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

        private async Task<APIGatewayProxyResponse> HandleTransactionRiskAssessment(APIGatewayProxyRequest request)
        {
            try
            {
                var transactionRiskRequest = JsonConvert.DeserializeObject<TransactionRiskAssessmentRequest>(request.Body);

                // TODO: Implement the actual API call to Fiserv SecureNow for transaction risk assessment
                // This is a placeholder implementation
                var response = await _httpClient.PostAsync($"{_apiEndpoint}/assess-transaction-risk", 
                    new StringContent(JsonConvert.SerializeObject(new
                    {
                        clientId = _clientId,
                        clientSecret = _clientSecret,
                        organizationId = _organizationId,
                        transactionId = transactionRiskRequest.TransactionId,
                        amount = transactionRiskRequest.Amount,
                        sourceAccount = transactionRiskRequest.SourceAccount,
                        destinationAccount = transactionRiskRequest.DestinationAccount,
                        timestamp = transactionRiskRequest.Timestamp
                    })));

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var riskAssessment = JsonConvert.DeserializeObject<TransactionRiskAssessmentResponse>(responseContent);

                    return new APIGatewayProxyResponse
                    {
                        StatusCode = 200,
                        Body = JsonConvert.SerializeObject(riskAssessment)
                    };
                }
                else
                {
                    return new APIGatewayProxyResponse
                    {
                        StatusCode = 500,
                        Body = "Error assessing transaction risk"
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

    public class SessionRiskAssessmentRequest
    {
        public string SessionId { get; set; }
        public string UserId { get; set; }
        public object DeviceInfo { get; set; }
        public string IpAddress { get; set; }
        public string Timestamp { get; set; }
    }

    public class TransactionRiskAssessmentRequest
    {
        public string TransactionId { get; set; }
        public decimal Amount { get; set; }
        public string SourceAccount { get; set; }
        public string DestinationAccount { get; set; }
        public string Timestamp { get; set; }
    }

    public class SessionRiskAssessmentResponse
    {
        public string RiskLevel { get; set; }
        public decimal RiskScore { get; set; }
        public string[] Factors { get; set; }
    }

    public class TransactionRiskAssessmentResponse
    {
        public string RiskLevel { get; set; }
        public decimal RiskScore { get; set; }
        public string RecommendedAction { get; set; }
    }
}