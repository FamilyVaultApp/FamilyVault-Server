using FamilyVaultServer.Models.Responses;
using Microsoft.Extensions.Options;

namespace FamilyVaultServer.Services.PrivMx
{
    public class PrivMxBridgeService : IPrivMxBridgeService
    {
        private IPrivMxBridgeClient _client;
        private IOptions<PrivMxOptions> _options;
        private string? _solutionId;

        public PrivMxBridgeService(IOptions<PrivMxOptions> options)
        {
            _options = options;
            _client = new PrivMxBridgeClient(_options.Value);
        }

        public async Task<PrivMxResponseModel> CreateAndAssignSolutionToService(string name)
        {
            return await _client.ExecuteMethod("solution/createSolution", new
            {
                Name = name
            });
        }

        public async Task<PrivMxResponseModel> CreateContext(string solution, string name, string description, string scope)
        {
            return await _client.ExecuteMethod("context/createContext", new
            {
                Solution = solution,
                Name = name,
                Description = description,
                Scope = scope,
            });
        }
    }
}
