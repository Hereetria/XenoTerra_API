
namespace XenoTerra.DTOLayer.Dtos.CommentLikeAdminDtos.Admin
{
    public class UpdateCommentLikeAdminDto
    {
        public Guid CommentLikeId { get; set; }
        public Guid? CommentId { get; set; }
        public Guid? UserId { get; set; }
    }
}