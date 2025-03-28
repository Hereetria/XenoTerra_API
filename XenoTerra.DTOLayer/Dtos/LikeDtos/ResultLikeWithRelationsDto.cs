

using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.LikeDtos
{
    public record ResultLikeWithRelationsDto(
        Guid LikeId,
        Guid PostId,
        Guid UserId,
        DateTime LikedAt
    )
    {
        public ResultUserDto? User { get; set; }
        public ResultPostDto? Post { get; set; }
    }
}