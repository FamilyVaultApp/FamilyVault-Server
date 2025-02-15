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
        
        public async Task<TResponseResult> ExecuteMethod<TRequestParameters, TResponseResult>(string methodName, TRequestParameters parameters)
            where TRequestParameters : PrivMxRequestParameters
            where TResponseResult : PrivMxResponseResult
        {
            return await SendRequest<TRequestParameters, TResponseResult>(PrivMxRequest<TRequestParameters>.Create(methodName, parameters));
        }
        
        public async Task<TResponseResult> SendRequest<TRequestParameters, TResponseResult>(PrivMxRequest<TRequestParameters> model)
            where TRequestParameters : PrivMxRequestParameters
            where TResponseResult : PrivMxResponseResult
        {
            var response = await _httpClient.PostAsJsonAsync("api", model);

            if (!response.IsSuccessStatusCode)
            {
                throw new PrivMxBridgeException($"Error while sending request to PrivMX Bridge: {response.StatusCode}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();

            var privMxBridgeResponse = JsonSerializer.Deserialize<PrivMxResponse<TResponseResult>>(responseContent);

            if (privMxBridgeResponse?.Error is not null)
            {
                throw new PrivMxBridgeException($"PrivMX Bridge Error: {privMxBridgeResponse.Error.Code}: {privMxBridgeResponse.Error.Message}");
            }

            if (privMxBridgeResponse?.Result is null)
            {
                throw new PrivMxBridgeException($"PrivMX Bridge result is empty {privMxBridgeResponse?.Id}");
            }

            return privMxBridgeResponse.Result;
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
