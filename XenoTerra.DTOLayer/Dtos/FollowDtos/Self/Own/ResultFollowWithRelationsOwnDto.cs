using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;

namespace XenoTerra.DTOLayer.Dtos.FollowAdminDtos.Self.Own
{
    public class ResultFollowWithRelationsOwnDto
    {
        public Guid FollowId { get; init; }
        public Guid FollowerId { get; init; }
        public Guid FollowingId { get; init; }
        public bool IsPending { get; init; }
        public DateTime FollowedAt { get; init; }
        public ResultAppUserOwnDto Follower { get; init; } = new();
        public ResultAppUserOwnDto Following { get; init; } = new();
    }
}