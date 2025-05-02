

using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.LikeDtos
{
    public class UpdateLikeDto
    {
        public Guid LikeId { get; set; }
        public Guid? PostId { get; set; }
        public Guid? UserId { get; set; }
    }
}