using FamilyVaultServer.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FamilyVaultServer.Services.PrivMx
{
    public class PrivMxBridgeClient : IPrivMxBridgeClient
    {
        private HttpClient _httpClient;
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

            // TODO: Uwzględnienie błędów zwracanych przez PrivMx Bridge.
            if (!response.IsSuccessStatusCode)
            {
                throw new PrivMxBridgeException("Error while connecting to PrivMX Bridge");
            }

            var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<object>(responseStream) ?? new { };
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
