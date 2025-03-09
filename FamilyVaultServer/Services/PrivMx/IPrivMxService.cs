using FamilyVaultServer.Services.PrivMx.Models.Result;

namespace FamilyVaultServer.Services.PrivMx
{
    public interface IPrivMxService
    {
        Task<string> GetSolutionId();
        Task<PrivMxCreateSolutionResult> CreateSolution(string name);
        Task<PrivMxCreateContextResult> CreateContext(string name, string description, string scope);
        Task<bool> AddUserToContext(string contextId, string userId, string userPubKey, string acl);

        Task<bool> RemoveUserFromContext(string contextId, string userId);
    }
}
