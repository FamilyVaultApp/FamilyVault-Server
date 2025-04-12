using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.Responses
{
    public class GetMemberFromFamilyGroupResponse
    {
        [JsonPropertyName("member")]
        public required FamilyGroupMember Member { get; set; }
    }
}
