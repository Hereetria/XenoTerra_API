namespace XenoTerra.DTOLayer.Dtos.PostAdminDtos.Admin
{
    public class UpdatePostAdminDto
    {
        public Guid PostId { get; set; }
        public string? Caption { get; set; } = string.Empty;
        public string? Path { get; set; } = string.Empty;
        public bool? IsVideo { get; set; }
        public string? Location { get; set; } = string.Empty;
        public Guid? UserId { get; set; }
    }
}