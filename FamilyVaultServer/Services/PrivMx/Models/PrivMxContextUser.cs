using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.PrivMx.Models
{
    public class PrivMxContextUser
    {
        [JsonPropertyName("userId")]
        public required String UserId { get; set; }
        [JsonPropertyName("pubKey")]
        public required String PubKey { get; set; }
        [JsonPropertyName("created")]
        public required Int64 Created { get; set; }
        [JsonPropertyName("contextId")]
        public required String ContextId { get; set; }
        [JsonPropertyName("acl")]
        public required String Acl { get; set; }
    }
}
