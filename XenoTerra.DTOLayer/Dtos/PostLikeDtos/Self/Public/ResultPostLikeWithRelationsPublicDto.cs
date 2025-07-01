using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Public;
using XenoTerra.DTOLayer.Dtos.PostDtos.Self.Public;

namespace XenoTerra.DTOLayer.Dtos.PostLikeDtos.Self.Public
{
    public class ResultPostLikeWithRelationsPublicDto
    {
        public Guid PostLikeId { get; init; }
        public Guid PostId { get; init; }
        public Guid UserId { get; init; }
        public DateTime LikedAt { get; init; }
        public ResultAppUserPublicDto User { get; set; } = new();
        public ResultPostPublicDto Post { get; set; } = new();
    }
}