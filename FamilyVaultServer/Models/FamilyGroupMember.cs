using FamilyVaultServer.Services.PrivMx.Models;
using FamilyVaultServer.Utils;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FamilyVaultServer.Models.Responses
{
    public class FamilyGroupMember
    {
        [JsonPropertyName("identifier")]
        public required FamilyGroupMemberIdentifier Identifier { get; set; }
        [JsonPropertyName("publicKey")]
        public required string PublicKey { get; set; }
        [JsonPropertyName("permissionGroup")]
        public required PermissionGroup PermissionGroup { get; set; }
        public static FamilyGroupMember FromPrivMxContextUser(PrivMxContextUser user)
        {
            return new FamilyGroupMember
            {
                Identifier = JsonSerializer.Deserialize<FamilyGroupMemberIdentifier>(user.UserId)!,
                PublicKey = user.PubKey,
                PermissionGroup = AclToPermissionGroupMapper.Map(user.Acl)
            };
        }
    }
}