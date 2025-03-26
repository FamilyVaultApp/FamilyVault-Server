namespace FamilyVaultServer.Services.PrivMx
{
    public class PrivMxSolutionProvider(IPrivMxService privMxService, string solutionName) : IPrivMxSolutionProvider
    {
        private IPrivMxService _privMxService = privMxService;
        private string _solutionName = solutionName;

        public async Task<string> GetSolutionId()
        {
            var solutionId = GetSolutionIdFromFileOrNull();

            if (solutionId is null)
            {
                var createSolutionResult = await _privMxService.CreateSolution(_solutionName);
                solutionId = createSolutionResult.SolutionId;
                SaveSolutionIdInFile(solutionId);
            }

            return solutionId;
        }

        private string? GetSolutionIdFromFileOrNull()
        {
            if (!File.Exists(SolutionIdFilePath))
            {
                return null;
            }

            return File.ReadAllText(SolutionIdFilePath);
        }

        private void SaveSolutionIdInFile(string solutionId)
        {
            File.WriteAllText(SolutionIdFilePath, solutionId);
        }

        private string SolutionIdFilePath => Path.Combine(AppContext.BaseDirectory, "config/solution");
    }
}
