namespace FamilyVaultServer.Services.MemberJoinToken.Models
{
    public class FamilyGroupMemberJoinStatus
    {
        public required Guid Token { get; set; }
        public required FamilyGroupMemberJoinStatusEnum Status { get; set; }
        public FamilyGroupMemberJoinStatusInfo? Info { get; set; } = null;
        public static FamilyGroupMemberJoinStatus New()
        {
            return new FamilyGroupMemberJoinStatus { Token = Guid.NewGuid(), Status = FamilyGroupMemberJoinStatusEnum.Pending };
        }
    }
}