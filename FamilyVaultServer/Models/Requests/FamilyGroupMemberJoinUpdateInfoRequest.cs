using FamilyVaultServer.Services.MemberJoinToken.Models;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.Requests
{
    public class FamilyGroupMemberJoinUpdateInfoRequest
    {
        [JsonPropertyName("token")]
        public required Guid Token { get; set; }
        [JsonPropertyName("info")]
        public required FamilyGroupMemberJoinInfo Info { get; set; }
    }
}
