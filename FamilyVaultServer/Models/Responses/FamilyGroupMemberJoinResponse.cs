using FamilyVaultServer.Services.MemberJoinToken.Models;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.Responses
{
    public class FamilyGroupMemberJoinResponse
    {
        [JsonPropertyName("familyMemberJoinStatus")]
        public required FamilyGroupMemberJoin FamilyGroupMemberJoinStatus { get; set; }
    }
}
