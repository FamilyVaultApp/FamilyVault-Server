using FamilyVaultServer.Services.PrivMx.Models.Result;

namespace FamilyVaultServer.Services.PrivMx
{
    public interface IPrivMxService
    {
        Task<string> GetSolutionId();
        Task<PrivMxCreateSolutionResult> CreateSolution(string name);
        Task<PrivMxCreateContextResult> CreateContext(string name, string description, string scope);
        Task<bool> AddUserToContext(string contextId, string userId, string userPubKey, string acl);
        Task<PrivMxListUsersFromContextResult> ListUsersFromContext(string contextId, int skip, int limit, string sortOrder);
        Task<PrivMxGetUserFromContextResult> GetUserFromContext(string contextId, string userId);
        Task<bool> UpdateContext(string contextId, string? name = null, string? description = null, string? scope = null, string? policy = null);
        Task<bool> SetUserAcl(string contextId, string userId, string acl);
        Task<bool> RemoveUserFromContextByPubKey(string contextId, string userPubKey);
        Task<PrivMxGetContext> GetContext(string contextId);
    }
}
