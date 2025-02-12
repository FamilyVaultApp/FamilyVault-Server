using System.ComponentModel.DataAnnotations;

namespace FamilyVaultServer.Models.Requests
{
    public class CreateSolutionRequest
    {
        [Required]
        public required string Name { get; set; }
    }
}
