namespace FamilyVaultServer.Exceptions
{
    [Serializable]
    public class ConfigurationNotSetException : Exception
    {
        public ConfigurationNotSetException() { }
        public ConfigurationNotSetException(string message) : base(message) { }
        public ConfigurationNotSetException(string message, Exception inner) : base(message, inner) { }
    }
}
