

using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.DTOLayer.Dtos.PostDtos;

namespace XenoTerra.DTOLayer.Dtos.PostLikeDtos
{
    public record class ResultPostLikeWithRelationsDto
    {
        public Guid PostLikeId { get; init; }
        public Guid PostId { get; init; }
        public Guid UserId { get; init; }
        public DateTime LikedAt { get; init; }
        public ResultAppUserPrivateDto User { get; init; } = new();
        public ResultPostDto Post { get; init; } = new();
    }
}