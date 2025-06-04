

using XenoTerra.DTOLayer.Dtos.PostDtos;

namespace XenoTerra.DTOLayer.Dtos.PostLikeDtos
{
    public class UpdatePostLikeDto
    {
        public Guid PostLikeId { get; set; }
        public Guid? PostId { get; set; }
        public Guid? UserId { get; set; }
    }
}