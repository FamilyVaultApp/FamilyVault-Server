using System.ComponentModel.DataAnnotations;

namespace FamilyVaultServer.Models.Requests
{
    public class CreateFamilyGroupRequest
    {
        [Required]
        public string Solution { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Scope { get; set; }
    }
}
