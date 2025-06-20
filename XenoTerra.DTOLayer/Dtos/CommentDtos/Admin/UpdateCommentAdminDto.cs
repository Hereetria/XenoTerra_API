namespace XenoTerra.DTOLayer.Dtos.CommentAdminDtos.Admin
{
    public class UpdateCommentAdminDto
    {
        public Guid CommentId { get; set; }
        public string? Content { get; set; } = string.Empty;
        public Guid? PostId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? ParentCommentId { get; set; }
    }
}