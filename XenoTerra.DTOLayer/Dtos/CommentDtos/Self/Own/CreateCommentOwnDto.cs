namespace XenoTerra.DTOLayer.Dtos.CommentAdminDtos.Self.Own
{
    public class CreateCommentOwnDto
    {
        public string Content { get; set; } = string.Empty;
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CommentedAt { get; set; }
        public Guid? ParentCommentId { get; set; }
    }
}
