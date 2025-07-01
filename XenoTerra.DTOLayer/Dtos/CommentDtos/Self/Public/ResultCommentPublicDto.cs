namespace XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Public
{
    public class ResultCommentPublicDto
    {
        public Guid CommentId { get; init; }
        public string Content { get; init; } = string.Empty;
        public Guid PostId { get; init; }
        public Guid UserId { get; init; }
        public DateTime CommentedAt { get; init; }
        public Guid? ParentCommentId { get; init; }
    }
}