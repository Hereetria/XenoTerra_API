

namespace XenoTerra.DTOLayer.Dtos.CommentDtos
{
    public class ResultCommentDto
    {
        public Guid CommentId { get; set; }
        public string Content { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CommentedAt { get; set; }
    }
}