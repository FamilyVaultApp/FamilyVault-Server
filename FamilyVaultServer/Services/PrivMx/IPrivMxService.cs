using FamilyVaultServer.Services.PrivMx.Models.Result;

namespace FamilyVaultServer.Services.PrivMx
{
    public interface IPrivMxService
    {
        Task<PrivMxCreateSolutionResult> CreateSolution(string name);
        Task<PrivMxCreateContextResult> CreateContext(string name, string description, string scope);
    }
}
