using FamilyVaultServer.Services.PrivMx.Models.Params;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models.Parameters
{
    public class PrivMxUpdateContextParameters : PrivMxRequestParameters
    {
        [JsonPropertyName("contextId")]
        public required string ContextId { get; set; }
        [JsonPropertyName("name")]
        public required string Name { get; set; }
    }
}
