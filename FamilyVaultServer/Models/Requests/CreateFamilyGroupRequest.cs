using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.Requests
{
    public class CreateFamilyGroupRequest
    {
        [Required]
        [JsonPropertyName("solution")]
        public required string Solution { get; set; }
        [Required]
        [JsonPropertyName("name")]
        public required string Name { get; set; }
        [Required]
        [JsonPropertyName("description")]
        public required string Description { get; set; }
        [Required]
        [JsonPropertyName("scope")]
        public required string Scope { get; set; }
    }
}
