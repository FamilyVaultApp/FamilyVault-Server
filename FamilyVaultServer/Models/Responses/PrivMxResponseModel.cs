using System.Text.Json;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.Responses
{
    public class PrivMxResponseModel
    {
        [JsonPropertyName("jsonrpc")]
        public string Jsonrpc { get; set; } = "2.0";
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("result")]
        public JsonElement? Result { get; set; }
        [JsonPropertyName("error")]
        public PrivMxResponseModelError? Error { get; set; }
    }
}
