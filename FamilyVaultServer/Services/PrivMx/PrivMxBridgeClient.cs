using FamilyVaultServer.Services.PrivMx.Models;
using FamilyVaultServer.Services.PrivMx.Models.Params;
using FamilyVaultServer.Services.PrivMx.Models.Result;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FamilyVaultServer.Services.PrivMx
{
    public class PrivMxBridgeClient : IPrivMxBridgeClient
    {
        private readonly HttpClient _httpClient;
        private readonly PrivMxOptions _options;

        public PrivMxBridgeClient(PrivMxOptions options)
        {
            _options = options;
            _httpClient = InitializeHttpClient();
        }

        public async Task<bool> ExecuteMethodWithOperationStatus<TRequestParameters>(string methodName, TRequestParameters parameters)
            where TRequestParameters : PrivMxRequestParameters
        {
            var stream = await SendRequestAndGetResponseStream(PrivMxRequest<TRequestParameters>.Create(methodName, parameters));

            var response = JsonSerializer.Deserialize<PrivMxResponseWithOperationStatus>(stream);
            ValidateResponseResultAndThrowException(response);

            return response?.Result == "OK";
        }

        public async Task<TResponseResult> ExecuteMethodWithResponse<TRequestParameters, TResponseResult>(string methodName, TRequestParameters parameters)
            where TRequestParameters : PrivMxRequestParameters
            where TResponseResult : PrivMxResponseResult
        {
            var stream = await SendRequestAndGetResponseStream(PrivMxRequest<TRequestParameters>.Create(methodName, parameters));

            var response = JsonSerializer.Deserialize<PrivMxResponseWithResult<TResponseResult>>(stream);
            ValidateResponseResultAndThrowException(response);

            return response?.Result!;
        }

        private async Task<Stream> SendRequestAndGetResponseStream<TRequestParameters>(PrivMxRequest<TRequestParameters> request)
            where TRequestParameters : PrivMxRequestParameters
        {
            var response = await _httpClient.PostAsJsonAsync("api", request);

            if (!response.IsSuccessStatusCode)
            {
                throw new PrivMxBridgeException($"Error while sending request to PrivMX Bridge: {response.StatusCode}");
            }

            return await response.Content.ReadAsStreamAsync();
        }

        private void ValidateResponseResultAndThrowException(PrivMxResponse? response) 
        {
            if (response?.Error is not null)
            {
                throw new PrivMxBridgeException($"PrivMX Bridge Error: {response.Error.Code}: {response.Error.Message}");
            }
        }

        private HttpClient InitializeHttpClient()
        {
            return new HttpClient
            {
                DefaultRequestHeaders =
                {
                    Authorization = new AuthenticationHeaderValue("Basic", GetAuthorizationHeader())
                },
                BaseAddress = new Uri(_options.Url)
            };
        }

        private string GetAuthorizationHeader()
        {
            var apiKeyId = _options.ApiKeyId ?? "";
            var apiSecret = _options.ApiKeySecret ?? "";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes($"{apiKeyId}:{apiSecret}");

            return Convert.ToBase64String(bytes);
        }
    }
}
