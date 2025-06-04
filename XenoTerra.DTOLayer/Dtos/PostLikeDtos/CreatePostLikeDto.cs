

using XenoTerra.DTOLayer.Dtos.PostDtos;

namespace XenoTerra.DTOLayer.Dtos.PostLikeDtos
{
    public class CreatePostLikeDto
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public DateTime LikedAt { get; set; }
    }
}