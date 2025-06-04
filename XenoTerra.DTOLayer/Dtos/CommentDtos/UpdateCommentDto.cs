
namespace XenoTerra.DTOLayer.Dtos.CommentDtos
{
    public class UpdateCommentDto
    {
        public Guid CommentId { get; set; }
        public string? Content { get; set; } = string.Empty;
        public Guid? PostId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? ParentCommentId { get; set; }
    }
}