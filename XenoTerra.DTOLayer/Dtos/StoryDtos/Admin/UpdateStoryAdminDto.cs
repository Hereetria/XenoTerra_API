
namespace XenoTerra.DTOLayer.Dtos.StoryAdminDtos.Admin
{
    public class UpdateStoryAdminDto
    {
        public Guid StoryId { get; set; }
        public string? Path { get; set; } = string.Empty;
        public bool? IsVideo { get; set; }
        public Guid? UserId { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}