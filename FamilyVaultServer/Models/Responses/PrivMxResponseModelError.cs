using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.Responses
{
    public class PrivMxResponseModelError
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;
        [JsonPropertyName("data")]
        public object? Data { get; set; }
    }
}
