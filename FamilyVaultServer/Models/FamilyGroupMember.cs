using FamilyVaultServer.Services.PrivMx.Models;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.Responses
{
    public class FamilyGroupMember
    {
        [JsonPropertyName("firstname")]
        public required string Firstname { get; set; }
        [JsonPropertyName("surname")]
        public required string Surname { get; set; }
        [JsonPropertyName("publicKey")]
        public required string PublicKey { get; set; }
        [JsonPropertyName("permissionGroup")]
        public required FamilyGroupMemberPermissionGroup PermissionGroup { get; set; }
        public static FamilyGroupMember FromPrivMxContextUser(PrivMxContextUser user)
        {
            var userIdSplitted = user.UserId.Split(" ");
            return new FamilyGroupMember
            {
                Firstname = userIdSplitted.First(),
                Surname = userIdSplitted.Last(),
                PublicKey = user.PubKey,
                // TODO: Ustawienie odpowiedniego PermissionGroup
                PermissionGroup = FamilyGroupMemberPermissionGroup.Member
            };
        }
    }
}