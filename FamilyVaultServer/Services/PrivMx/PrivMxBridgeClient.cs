using FamilyVaultServer.Exceptions;
using FamilyVaultServer.Models;
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

        public async Task<object> ExecuteMethod(string method, object parameters)
        {
            return await ExecuteMethod(PrivMxCommunicationModel.Create(method, parameters));
        }

        public async Task<object> ExecuteMethod(PrivMxCommunicationModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("api", model);
            var content = await response.Content.ReadAsStringAsync();
            
            if (!response.IsSuccessStatusCode)
            {
                throw new PrivMxBridgeException($"Error while connecting to PrivMX Bridge: {response.StatusCode}");
            }
            
            var privMxBridgeResponse = JsonSerializer.Deserialize<JsonRpcResponse>(content);
            
            if (privMxBridgeResponse?.Error != null)
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
            var client = new HttpClient { BaseAddress = new Uri(_options.Url) };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", GetAuthorizationHeader());
            return client;
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
