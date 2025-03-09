using System.Text.Json.Serialization;

namespace FamilyVaultServer.Services.MemberJoinToken.Models
{
    public class FamilyGroupMemberJoinInfo
    {
        [JsonPropertyName("contextId")]
        public required string ContextId  { get; set; }
    }
}
