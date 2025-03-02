

namespace XenoTerra.DTOLayer.Dtos.LikeDtos
{
    public class ResultLikeByIdDto
    {
        public Guid LikeId { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public DateTime LikedAt { get; set; }
    }
}