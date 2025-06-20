
namespace XenoTerra.DTOLayer.Dtos.CommentAdminDtos.Admin
{
    public class CreateCommentAdminDto
    {
        public string Content { get; set; } = string.Empty;
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CommentedAt { get; set; }
        public Guid? ParentCommentId { get; set; }
    }
}