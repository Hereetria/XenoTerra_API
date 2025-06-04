

using XenoTerra.DTOLayer.Dtos.PostDtos;

namespace XenoTerra.DTOLayer.Dtos.CommentDtos
{
    public class CreateCommentDto
    {
        public string Content { get; set; } = string.Empty;
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CommentedAt { get; set; }
        public Guid? ParentCommentId { get; set; }
    }
}