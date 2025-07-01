namespace XenoTerra.DTOLayer.Dtos.CommentLikeDtos.Admin
{
    public class UpdateCommentLikeAdminDto
    {
        public Guid CommentLikeId { get; set; }
        public Guid? CommentId { get; set; }
        public Guid? UserId { get; set; }
    }
}