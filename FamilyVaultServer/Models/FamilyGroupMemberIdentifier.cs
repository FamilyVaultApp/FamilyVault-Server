using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models
{
    public class FamilyGroupMemberIdentifier
    {
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        [JsonPropertyName("firstname")]
        public required string Firstname { get; set; }
        [JsonPropertyName("surname")]
        public required string Surname { get; set; }
    }
}

