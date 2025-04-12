using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.Requests
{
    public class GetMemberFromFamilyGroupRequest
    {
        [JsonPropertyName("contextId")]
        public string ContextId { get; set; }
        [JsonPropertyName("userId")]
        public string UserId { get; set; }
    }
}
