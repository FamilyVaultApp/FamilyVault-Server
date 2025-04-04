using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models
{
    public class PrivMxContextUser
    {
        [JsonPropertyName("userId")]
        public required string UserId { get; set; }
        [JsonPropertyName("pubKey")]
        public required string PubKey { get; set; }
        [JsonPropertyName("created")]
        public required int Created { get; set; }
        [JsonPropertyName("contextId")]
        public required string ContextId { get; set; }
        [JsonPropertyName("acl")]
        public required string Acl { get; set; }
    }
}
