

using XenoTerra.DTOLayer.Dtos.AppUserDtos;

namespace XenoTerra.DTOLayer.Dtos.FollowDtos
{
    public record class ResultFollowWithRelationsDto
    {
        public Guid FollowId { get; init; }
        public Guid FollowerId { get; init; }
        public Guid FollowingId { get; init; }
        public DateTime FollowedAt { get; init; }
        public ResultAppUserPrivateDto Follower { get; init; } = new();
        public ResultAppUserPrivateDto Following { get; init; } = new();
    }
}