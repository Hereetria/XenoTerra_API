

using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.FollowDtos
{
    public record class ResultFollowWithRelationsDto
    {
        public Guid FollowId { get; init; }
        public Guid FollowerId { get; init; }
        public Guid FollowingId { get; init; }
        public DateTime FollowedAt { get; init; }
        public ResultUserPrivateDto Follower { get; init; } = new();
        public ResultUserPrivateDto Following { get; init; } = new();
    }
}