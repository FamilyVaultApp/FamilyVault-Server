using FamilyVaultServer.Services.PrivMx.Models.Params;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models.Parameters
{
    public class PrivMxSetUserAclParameters : PrivMxRequestParameters
    {
        [JsonPropertyName("contextId")]
        public required string ContextId { get; set; }
        [JsonPropertyName("userId")]
        public required string UserId { get; set; }
        [JsonPropertyName("acl")]
        public required string Acl { get; set; }
    }
}
