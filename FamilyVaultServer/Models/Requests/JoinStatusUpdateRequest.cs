using FamilyVaultServer.Services.MemberJoinToken.Models;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.Requests
{
    public class JoinStatusUpdateRequest
    {
        [JsonPropertyName("token")]
        public required Guid Token { get; set; }
        [JsonPropertyName("state")]
        public JoinStatusState State { get; set; }
        [JsonPropertyName("info")]
        public JoinStatusInfo? Info { get; set; }
    }
}
