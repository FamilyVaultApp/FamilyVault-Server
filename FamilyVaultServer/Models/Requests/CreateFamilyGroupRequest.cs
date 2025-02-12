using System.ComponentModel.DataAnnotations;

namespace FamilyVaultServer.Models.Requests
{
    public class CreateFamilyGroupRequest
    {
        [Required]
        public required string Solution { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Description { get; set; }
        [Required]
        public required string Scope { get; set; }
    }
}
