using System.ComponentModel.DataAnnotations;

namespace FamilyVaultServer.Models.Requests
{
    public class CreateSolutionRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
