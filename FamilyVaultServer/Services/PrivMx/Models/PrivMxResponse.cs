using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models
{
    public class PrivMxResponse
    {
        [JsonPropertyName("jsonrpc")]
        public string JsonRpc { get; set; } = string.Empty;
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("result")]
        public object? Result { get; set; }
        [JsonPropertyName("error")]
        public PrivMxResponseError? Error { get; set; }
    }
}
