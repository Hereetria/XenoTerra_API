namespace XenoTerra.DTOLayer.Dtos.CommentLikeAdminDtos.Self.Own
{
    public class ResultCommentLikeOwnDto
    {
        public Guid CommentLikeId { get; init; }
        public Guid CommentId { get; init; }
        public Guid UserId { get; init; }
        public DateTime LikedAt { get; init; }
    }
}