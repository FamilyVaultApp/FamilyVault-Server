using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.Responses
{
    public class GetFamilyGroupNameResponse
    {
        [JsonPropertyName("familyGroupName")]
        public required string FamilyGroupName { get; set; }
    }
}
