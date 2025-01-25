using System.ComponentModel.DataAnnotations;

namespace FamilyVaultServer.Models.Requests
{
    public class CreateFamilyGroupRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
