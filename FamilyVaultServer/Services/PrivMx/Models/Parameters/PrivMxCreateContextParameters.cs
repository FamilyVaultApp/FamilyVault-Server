using FamilyVaultServer.Models.PrivMxPolicy;
using FamilyVaultServer.Services.PrivMx.Models.Params;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models.Parameters
{
    public class PrivMxCreateContextParameters : PrivMxRequestParameters
    {
        [JsonPropertyName("solution")]
        public required string Solution { get; set; }
        [JsonPropertyName("name")]
        public required string Name { get; set; }
        [JsonPropertyName("description")]
        public required string Description { get; set; }
        [JsonPropertyName("scope")]
        public required string Scope { get; set; }
        [JsonPropertyName("policy")]
        public PrivMxPolicy Policy = new PrivMxPolicy();
    }
}
