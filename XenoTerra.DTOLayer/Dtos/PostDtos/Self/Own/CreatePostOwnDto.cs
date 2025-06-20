namespace XenoTerra.DTOLayer.Dtos.PostAdminDtos.Self.Own
{
    public class CreatePostOwnDto
    {
        public string Caption { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public bool IsVideo { get; set; }
        public string? Location { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
