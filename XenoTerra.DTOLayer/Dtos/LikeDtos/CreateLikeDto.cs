

namespace XenoTerra.DTOLayer.Dtos.LikeDtos
{
    public class CreateLikeDto
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public DateTime LikedAt { get; set; }
    }
}