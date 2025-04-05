using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.Requests
{
    public class GetFamilyGroupNameRequest
    {
        [Required]
        [JsonPropertyName("contextId")]
        public required string ContextId { get; set; }
    }
}
