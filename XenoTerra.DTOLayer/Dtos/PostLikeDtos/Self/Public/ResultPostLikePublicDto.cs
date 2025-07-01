namespace XenoTerra.DTOLayer.Dtos.PostLikeDtos.Self.Public
{
    public class ResultPostLikePublicDto
    {
        public Guid PostLikeId { get; init; }
        public Guid PostId { get; init; }
        public Guid UserId { get; init; }
        public DateTime LikedAt { get; init; }
    }
}