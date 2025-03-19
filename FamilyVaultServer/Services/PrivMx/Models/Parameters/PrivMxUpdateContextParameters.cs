using FamilyVaultServer.Services.PrivMx.Models.Params;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models.Parameters
{
    public class PrivMxUpdateContextParameters : PrivMxRequestParameters
    {
        [JsonPropertyName("contextId")]
        public required string ContextId { get; set; }
        [JsonPropertyName("name")]
        public string ?Name { get; set; }
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        [JsonPropertyName("scope")]
        public string? Scope { get; set; }
        [JsonPropertyName("policy")]
        public string? Policy { get; set; }
    }
}
