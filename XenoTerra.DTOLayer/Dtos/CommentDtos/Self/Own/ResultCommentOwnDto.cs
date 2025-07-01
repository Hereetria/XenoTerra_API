namespace XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Own
{
    public class ResultCommentOwnDto
    {
        public Guid CommentId { get; init; }
        public string Content { get; init; } = string.Empty;
        public Guid PostId { get; init; }
        public Guid UserId { get; init; }
        public DateTime CommentedAt { get; init; }
        public Guid? ParentCommentId { get; init; }
    }
}