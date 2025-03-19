using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.Requests
{
    public class RenameFamilyGroupRequest
    {
        [Required]
        [JsonPropertyName("contextId")]
        public required string ContextId { get; set; }

        [Required]
        [JsonPropertyName("name")]
        public required string Name { get; set; }
    }
}
