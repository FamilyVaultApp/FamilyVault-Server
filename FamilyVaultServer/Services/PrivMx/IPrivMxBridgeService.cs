using FamilyVaultServer.Models.Responses;

namespace FamilyVaultServer.Services.PrivMx
{
    public interface IPrivMxBridgeService
    {
        Task<PrivMxResponseModel> CreateAndAssignSolutionToService(string name);
        Task<PrivMxResponseModel> CreateContext(string solution, string name, string description, string scope);
    }
}
