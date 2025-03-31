using FamilyVaultServer.Services.PrivMx.Models.Params;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models.Parameters
{
    public class PrivMxRemoveUserFromContextByPubKeyParameters : PrivMxRequestParameters
    {
        [JsonPropertyName("contextId")]
        public required string ContextId{ get; set; }

        [JsonPropertyName("userPubKey")]
        public required string UserPubKey { get; set; } 
    }
}   
