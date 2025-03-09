using FamilyVaultServer.Services.MemberJoinToken.Models;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.Requests
{
    public class FamilyGroupMemberJoinStatusUpdateRequest
    {
        [JsonPropertyName("token")]
        public required Guid Token { get; set; }
        [JsonPropertyName("status")]
        public required FamilyGroupMemberJoinStatusEnum Status { get; set; }
    }
}
