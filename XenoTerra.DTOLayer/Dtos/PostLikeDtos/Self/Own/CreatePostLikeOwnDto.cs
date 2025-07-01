namespace XenoTerra.DTOLayer.Dtos.PostLikeDtos.Self.Own
{
    public class CreatePostLikeOwnDto
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public DateTime LikedAt { get; set; }
    }
}
