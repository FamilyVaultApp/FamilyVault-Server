using FamilyVaultServer.Services.PrivMx.Models.Params;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models.Parameters
{
    public class PrivMxAddUserToContextParameters : PrivMxRequestParameters
    {
        [JsonPropertyName("contextId")]
        public required string ContextId{ get; set; }
        [JsonPropertyName("userId")]
        public required string UserId { get; set; }
        [JsonPropertyName("userPubKey")]
        public required string UserPubKey { get; set; } 
        [JsonPropertyName("acl")]
        public string? Acl { get; set; }
    }
}   
