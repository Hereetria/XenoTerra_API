namespace XenoTerra.DTOLayer.Dtos.StoryDtos.Admin
{
    public class CreateStoryAdminDto
    {
        public string Path { get; set; } = string.Empty;
        public bool IsVideo { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}