namespace FamilyVaultServer.Services.PrivMx
{
    public interface IPrivMxBridgeService
    {
        Task CreateSolution(string name);
        Task CreateFamilyGroup(string solutionId, string name, string description, string scope);
    }
}
