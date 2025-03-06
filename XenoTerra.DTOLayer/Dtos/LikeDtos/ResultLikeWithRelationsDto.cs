

using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.LikeDtos
{
    public class ResultLikeWithRelationsDto
    {
        public Guid LikeId { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public DateTime LikedAt { get; set; }

        public ResultUserDto User { get; set; }
        public ResultPostDto Post { get; set; }
    }
}