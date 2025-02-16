using FamilyVaultServer.Services.PrivMx.Models.Params;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models.Parameters
{
    public class PrivMxCreateContextParameters : PrivMxRequestParameters
    {
        [JsonPropertyName("solution")]
        public string Solution { get; set; } = string.Empty;
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
        [JsonPropertyName("scope")]
        public string Scope { get; set; } = string.Empty;
    }
}   
