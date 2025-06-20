using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;

namespace XenoTerra.DTOLayer.Dtos.FollowAdminDtos.Admin
{
    public class ResultFollowWithRelationsAdminDto
    {
        public Guid FollowId { get; init; }
        public Guid FollowerId { get; init; }
        public Guid FollowingId { get; init; }
        public bool IsPending { get; init; }
        public DateTime FollowedAt { get; init; }
        public ResultAppUserAdminDto Follower { get; init; } = new();
        public ResultAppUserAdminDto Following { get; init; } = new();
    }
}