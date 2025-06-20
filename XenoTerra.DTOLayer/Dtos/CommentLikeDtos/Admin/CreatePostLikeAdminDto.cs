
namespace XenoTerra.DTOLayer.Dtos.CommentLikeAdminDtos.Admin
{
    public class CreateCommentLikeAdminDto
    {
        public Guid CommentId { get; set; }
        public Guid UserId { get; set; }
        public DateTime LikedAt { get; set; }
    }
}