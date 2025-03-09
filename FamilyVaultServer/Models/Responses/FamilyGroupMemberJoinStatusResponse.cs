using FamilyVaultServer.Services.MemberJoinToken.Models;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.Responses
{
    public class FamilyGroupMemberJoinStatusResponse
    {
        [JsonPropertyName("familyMemberJoinStatus")]
        public required FamilyGroupMemberJoinStatus FamilyGroupMemberJoinStatus {get;set;}
    }
}
