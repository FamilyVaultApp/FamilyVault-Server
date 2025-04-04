using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models.Result
{
    public class PrivMxGetContext_ContextInfo : PrivMxResponseResult
    {
        [JsonPropertyName("id")]
        public required String Id { get; set; }
        [JsonPropertyName("created")]
        public required Int64 Created { get; set; }
        [JsonPropertyName("modified")]
        public required Int64 Modified { get; set; }
        [JsonPropertyName("solution")]
        public required String Solution { get; set; }
        [JsonPropertyName("name")]
        public required String Name { get; set; }
        [JsonPropertyName("description")]
        public required String Description { get; set; }
        [JsonPropertyName("scope")]
        public required String Scope { get; set; }
        [JsonPropertyName("shares")]
        public required List<String> Shares { get; set; }
        [JsonPropertyName("policy")]
        public required object Policy { get; set; }
    }
}