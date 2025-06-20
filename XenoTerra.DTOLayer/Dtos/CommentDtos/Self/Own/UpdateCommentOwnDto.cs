namespace XenoTerra.DTOLayer.Dtos.CommentAdminDtos.Self.Own
{
    public class UpdateCommentOwnDto
    {
        public Guid CommentId { get; set; }
        public string? Content { get; set; } = string.Empty;
    }
}
