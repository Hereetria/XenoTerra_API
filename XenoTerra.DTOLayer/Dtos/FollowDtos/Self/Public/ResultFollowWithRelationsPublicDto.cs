using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Public;

namespace XenoTerra.DTOLayer.Dtos.FollowDtos.Self.Public
{
    public class ResultFollowWithRelationsPublicDto
    {
        public Guid FollowId { get; init; }
        public Guid FollowerId { get; init; }
        public Guid FollowingId { get; init; }
        public bool IsPending { get; init; }
        public DateTime FollowedAt { get; init; }
        public ResultAppUserPublicDto Follower { get; set; } = new();
        public ResultAppUserPublicDto Following { get; set; } = new();
    }
}