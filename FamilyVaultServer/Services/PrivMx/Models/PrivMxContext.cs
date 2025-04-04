using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models
{
    public class PrivMxContext
    {
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        [JsonPropertyName("created")]
        public required ulong Created { get; set; }
        [JsonPropertyName("modified")]
        public required ulong Modified { get; set; }
        [JsonPropertyName("solution")]
        public required string Solution { get; set; }
        [JsonPropertyName("name")]
        public required string Name { get; set; }
        [JsonPropertyName("description")]
        public required string Description { get; set; }
        [JsonPropertyName("scope")]
        public required string Scope { get; set; }
        [JsonPropertyName("shares")]
        public required List<string> Shares { get; set; }
        [JsonPropertyName("policy")]
        public required object Policy { get; set; }
    }
}
