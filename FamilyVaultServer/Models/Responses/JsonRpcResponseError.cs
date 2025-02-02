namespace FamilyVaultServer.Exceptions
{
    public class JsonRpcResponseError
    {
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;
        public object? Data { get; set; }
    }
}
