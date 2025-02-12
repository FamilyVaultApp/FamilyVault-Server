using Microsoft.Extensions.Options;

namespace FamilyVaultServer.Services.PrivMx
{
    public class PrivMxBridgeService : IPrivMxBridgeService
    {
        private IPrivMxBridgeClient _client;
        private IOptions<PrivMxOptions> _options;

        public PrivMxBridgeService(IOptions<PrivMxOptions> options)
        {
            _options = options;
            _client = new PrivMxBridgeClient(_options.Value);
        }

        public Task CreateSolution(string name)
        {
            return _client.ExecuteMethod("solution/createSolution", new
            {
                Name = name
            });
        }

        public Task CreateFamilyGroup(string solution, string name, string description, string scope) 
        {
            return _client.ExecuteMethod("context/getContext", new
            { 
                SolutionId = solution,
                Name = name,
                Description = description,
                Scope = scope,
            });
        }


    }
}
