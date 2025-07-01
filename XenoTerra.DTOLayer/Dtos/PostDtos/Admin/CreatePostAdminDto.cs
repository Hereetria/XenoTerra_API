namespace XenoTerra.DTOLayer.Dtos.PostDtos.Admin
{
    public class CreatePostAdminDto
    {
        public string Caption { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public bool IsVideo { get; set; }
        public string? Location { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}