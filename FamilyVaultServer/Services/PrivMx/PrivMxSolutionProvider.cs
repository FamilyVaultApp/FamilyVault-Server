namespace FamilyVaultServer.Services.PrivMx
{
    public class PrivMxSolutionProvider(IPrivMxService privMxService, string solutionName, string? solutionId) : IPrivMxSolutionProvider
    {
        private IPrivMxService _privMxService = privMxService;
        private string _solutionName = solutionName;

        public async Task<string> GetSolutionId()
        {
            var cachedSolutionId = GetSolutionIdFromFileOrNull();

            if (cachedSolutionId is null)
            {
                if(solutionId is not null){
                    cachedSolutionId = solutionId;
                }else{
                    var createSolutionResult = await _privMxService.CreateSolution(_solutionName);
                    cachedSolutionId = createSolutionResult.SolutionId;
                }
                SaveSolutionIdInFile(cachedSolutionId);
            }

            return cachedSolutionId;
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
            var directory = Path.GetDirectoryName(SolutionIdFilePath)!;

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            File.WriteAllText(SolutionIdFilePath, solutionId);
        }

        private string SolutionIdFilePath => Path.Combine(AppContext.BaseDirectory, "config/solution");
    }
}
