using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.Requests
{
    public class ListMembersFromFamilyGroupRequest
    {
        [Required]
        [JsonPropertyName("contextId")]
        public required string ContextId { get; set; }
    }
}
