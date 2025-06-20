namespace XenoTerra.DTOLayer.Dtos.CommentLikeAdminDtos.Self.Own
{
    public class CreateCommentLikeOwnDto
    {
        public Guid CommentId { get; set; }
        public Guid UserId { get; set; }
        public DateTime LikedAt { get; set; }
    }
}
