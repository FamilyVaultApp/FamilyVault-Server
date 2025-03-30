using FamilyVaultServer.Services.PrivMx.Models;
using FamilyVaultServer.Services.PrivMx.Models.Params;
using FamilyVaultServer.Services.PrivMx.Models.Result;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

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
            var result = await SendRequest<TRequestParameters, string>(methodName, parameters);
            return result == "OK";
        }

        public async Task<TResponseResult> ExecuteMethodWithResponse<TRequestParameters, TResponseResult>(string methodName, TRequestParameters parameters)
            where TRequestParameters : PrivMxRequestParameters
            where TResponseResult : PrivMxResponseResult
        {
            var result = await SendRequest<TRequestParameters, TResponseResult>(methodName, parameters);
            return result;
        }

        private async Task<TResponseResult> SendRequest<TRequestParameters, TResponseResult>(string methodName, TRequestParameters parameters)
            where TRequestParameters : PrivMxRequestParameters
            where TResponseResult : class
        {
            var stream = await SendRequestAndGetResponseStream(PrivMxRequest<TRequestParameters>.Create(methodName, parameters));

            var response = JsonSerializer.Deserialize<PrivMxResponse<TResponseResult>>(stream);

            if (response?.Error is not null)
            {
                throw new PrivMxBridgeException($"PrivMX Bridge Error: {response.Error.Code}: {response.Error.Message}");
            }

            if (response?.Result is null)
            {
                throw new PrivMxBridgeException($"PrivMX Bridge result is empty");
            }

            return response.Result;
        }

        private async Task<Stream> SendRequestAndGetResponseStream<TRequestParameters>(PrivMxRequest<TRequestParameters> request)
            where TRequestParameters : PrivMxRequestParameters
        {
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            var response = await _httpClient.PostAsJsonAsync("api", request, jsonSerializerOptions);

            if (!response.IsSuccessStatusCode)
            {
                throw new PrivMxBridgeException($"Error while sending request to PrivMX Bridge: {response.StatusCode}");
            }

            return await response.Content.ReadAsStreamAsync();
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
