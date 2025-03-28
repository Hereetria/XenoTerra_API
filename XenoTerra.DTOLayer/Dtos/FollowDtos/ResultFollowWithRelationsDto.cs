

using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.FollowDtos
{
    public record ResultFollowWithRelationsDto(
        Guid FollowId,
        Guid FollowerId,
        Guid FollowingId,
        DateTime FollowedAt
    )
    {
        public ResultUserDto? Follower { get; set; }
        public ResultUserDto? Following { get; set; }
    }
}