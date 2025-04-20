

using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.LikeDtos
{
    public record class ResultLikeWithRelationsDto
    {
        public Guid LikeId { get; init; }
        public Guid PostId { get; init; }
        public Guid UserId { get; init; }
        public DateTime LikedAt { get; init; }
        public ResultUserDto User { get; init; } = new();
        public ResultPostDto Post { get; init; } = new();
    }
}