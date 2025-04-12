using FamilyVaultServer.Services.PrivMx.Models.Params;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models.Parameters
{
    public class PrivMxGetUserFromContextByPubKeyParameters : PrivMxRequestParameters
    {
        [JsonPropertyName("contextId")]
        public required string ContextId { get; set; }
        [JsonPropertyName("pubKey")]
        public required string PublicKey { get; set; }
    }
}
