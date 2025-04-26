namespace FamilyVaultServer.Services.PrivMx.Models
{
    public record class PrivMxAcl(string Type, string Object, string? Permission = null)
    {
        public override string ToString()
        {
            var separator = Permission is not null ? "/" : "";
            return $"{Type} {Object}{separator}{Permission}";
        }
    }
}
