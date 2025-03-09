using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.Requests
{
    public class FamilyGroupMemberTokenRequest
    {
        [JsonPropertyName("token")]
        public required Guid Token { get; set; }
    }
}
