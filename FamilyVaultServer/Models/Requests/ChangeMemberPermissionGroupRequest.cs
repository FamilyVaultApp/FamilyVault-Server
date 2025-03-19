using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.Requests
{
    public class ChangeMemberPermissionGroupRequest
    {
        [Required]
        [JsonPropertyName("contextId")]
        public required string ContextId { get; set; }

        [Required]
        [JsonPropertyName("userId")]
        public required string UserId { get; set; }

        [Required]
        [JsonPropertyName("role")]
        public required PermissionGroup Role { get; set; }
    }
}
