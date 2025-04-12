using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.Responses
{
    public class GetMemberFromFamilyGroupResponse
    {
        [JsonPropertyName("member")]
        public FamilyGroupMember Member { get; set; }
    }
}
