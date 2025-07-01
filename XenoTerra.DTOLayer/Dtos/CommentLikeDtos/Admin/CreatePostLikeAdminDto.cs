namespace XenoTerra.DTOLayer.Dtos.CommentLikeDtos.Admin
{
    public class CreateCommentLikeAdminDto
    {
        public Guid CommentId { get; set; }
        public Guid UserId { get; set; }
        public DateTime LikedAt { get; set; }
    }
}