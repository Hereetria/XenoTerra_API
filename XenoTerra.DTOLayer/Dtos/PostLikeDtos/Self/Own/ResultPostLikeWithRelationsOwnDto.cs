using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.PostDtos.Self.Own;

namespace XenoTerra.DTOLayer.Dtos.PostLikeDtos.Self.Own
{
    public class ResultPostLikeWithRelationsOwnDto
    {
        public Guid PostLikeId { get; init; }
        public Guid PostId { get; init; }
        public Guid UserId { get; init; }
        public DateTime LikedAt { get; init; }
        public ResultAppUserOwnDto User { get; set; } = new();
        public ResultPostOwnDto Post { get; set; } = new();
    }
}