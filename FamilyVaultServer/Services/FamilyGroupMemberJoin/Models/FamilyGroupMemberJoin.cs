namespace FamilyVaultServer.Services.MemberJoinToken.Models
{
    public class FamilyGroupMemberJoin
    {
        public required Guid Token { get; set; }
        public required FamilyGroupMemberJoinStatusEnum Status { get; set; }
        public FamilyGroupMemberJoinInfo? Info { get; set; } = null;
        public static FamilyGroupMemberJoin New()
        {
            return new FamilyGroupMemberJoin { Token = Guid.NewGuid(), Status = FamilyGroupMemberJoinStatusEnum.Pending };
        }
    }
}