using FamilyVaultServer.Services.PrivMx.Models.Parameters;
using FamilyVaultServer.Services.PrivMx.Models.Result;
using Microsoft.Extensions.Options;

namespace FamilyVaultServer.Services.PrivMx
{
    public class PrivMxService : IPrivMxService
    {
        private IPrivMxBridgeClient _client;
        private IPrivMxSolutionProvider _solutionProvider;
        private IOptions<PrivMxOptions> _options;

        public PrivMxService(IOptions<PrivMxOptions> options)
        {
            _options = options;
            _client = new PrivMxBridgeClient(_options.Value);
            _solutionProvider = new PrivMxSolutionProvider(this, _options.Value.SolutionName);
        }

        public Task<string> GetSolutionId()
        {
            return _solutionProvider.GetSolutionId();
        }

        public async Task<PrivMxCreateContextResult> CreateContext(string name, string description, string scope)
        {
            return await _client.ExecuteMethodWithResponse<PrivMxCreateContextParameters, PrivMxCreateContextResult>("context/createContext", new PrivMxCreateContextParameters
            {
                Solution = await GetSolutionId(),
                Name = name,
                Description = description,
                Scope = scope,
            });
        }

        public Task<PrivMxCreateSolutionResult> CreateSolution(string name)
            => _client.ExecuteMethodWithResponse<PrivMxCreateSolutionParameters, PrivMxCreateSolutionResult>("solution/createSolution", new PrivMxCreateSolutionParameters
            {
                Name = name
            });

        public Task<bool> AddUserToContext(string contextId, string userId, string userPubKey, string acl)
            => _client.ExecuteMethodWithOperationStatus("context/addUserToContext", new PrivMxAddUserToContextParameters
            {
                ContextId = contextId,
                UserId = userId,
                UserPubKey = userPubKey,
                Acl = acl,
            });

        public Task<PrivMxListUsersFromContextResult> PrivMxListUsersFromContext(string contextId, int skip, int limit, string sortOrder)
            => _client.ExecuteMethodWithResponse<PrivMxListUsersFromContextParemeters, PrivMxListUsersFromContextResult>("context/listUsersFromContext", new PrivMxListUsersFromContextParemeters
            {
                ContextId = contextId,
                Skip = skip,
                Limit = limit,
                SortOrder = sortOrder,
            });

        public Task<bool> UpdateContext(string contextId, string? name, string? description, string? scope, string? policy)
            => _client.ExecuteMethodWithOperationStatus("context/updateContext", new PrivMxUpdateContextParameters
            {
                ContextId = contextId,
                Name = name,
                Description = description,
                Scope = scope,
                Policy = policy
            });

        public Task<bool> SetUserAcl(string contextId, string userId, string acl)
            => _client.ExecuteMethodWithOperationStatus("context/setUserAcl", new PrivMxSetUserAclParameters
            {
                ContextId = contextId,
                UserId = userId,
                Acl = acl
            });
    }
}
