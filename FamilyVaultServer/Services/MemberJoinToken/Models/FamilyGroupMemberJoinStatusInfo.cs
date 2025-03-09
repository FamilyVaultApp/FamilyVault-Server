using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.MemberJoinToken.Models
{
    public class FamilyGroupMemberJoinStatusInfo
    {
        [JsonPropertyName("contextId")]
        public required string ContextId  { get; set; }
    }
}
