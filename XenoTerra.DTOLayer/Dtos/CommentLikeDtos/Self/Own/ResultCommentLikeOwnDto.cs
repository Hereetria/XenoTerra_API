namespace XenoTerra.DTOLayer.Dtos.CommentLikeDtos.Self.Own
{
    public class ResultCommentLikeOwnDto
    {
        public Guid CommentLikeId { get; init; }
        public Guid CommentId { get; init; }
        public Guid UserId { get; init; }
        public DateTime LikedAt { get; init; }
    }
}