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
            return await _client.ExecuteMethod<PrivMxCreateContextParameters, PrivMxCreateContextResult>("context/createContext", new PrivMxCreateContextParameters
            {
                Solution = await GetSolutionId(),
                Name = name,
                Description = description,
                Scope = scope,
            });
        }

        public Task<PrivMxCreateSolutionResult> CreateSolution(string name)
            => _client.ExecuteMethod<PrivMxCreateSolutionParameters, PrivMxCreateSolutionResult>("solution/createSolution", new PrivMxCreateSolutionParameters
            {
                Name = name
            });
        public async Task<PrivMxAddUserToContextResult> AddUserToContext(string contextId, string userId, string userPubKey, string acl)
        {
            await _client.ExecuteMethod<PrivMxAddUserToContextParameters, PrivMxAddUserToContextResult>("context/addUserToContext", new PrivMxAddUserToContextParameters
            {
                ContextId = contextId,
                UserId = userId,
                UserPubKey = userPubKey,
                Acl = acl,
            });

            var result = new PrivMxAddUserToContextResult
            {
                Result = "OK"
            };

            return result;
        }
    }
}
