using FamilyVaultServer.Services.PrivMx.Models.Params;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models.Parameters
{
    public class PrivMxAddUserToContextParameters : PrivMxRequestParameters
    {
        [JsonPropertyName("contextId")]
        public string ContextId{ get; set; } = string.Empty;
        [JsonPropertyName("userId")]
        public string UserId { get; set; } = string.Empty;
        [JsonPropertyName("userPubKey")]
        public string UserPubKey { get; set; } = string.Empty;
        [JsonPropertyName("acl")]
        public string Acl { get; set; } = string.Empty;
    }
}   
