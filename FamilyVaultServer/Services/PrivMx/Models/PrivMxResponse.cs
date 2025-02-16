using FamilyVaultServer.Services.PrivMx.Models.Result;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models
{
    public class PrivMxResponse<TResult>
        where TResult : PrivMxResponseResult
    {
        [JsonPropertyName("jsonrpc")]
        public string JsonRpc { get; set; } = string.Empty;
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("result")]
        public TResult? Result { get; set; }
        [JsonPropertyName("error")]
        public PrivMxResponseError? Error { get; set; }
    }
}
