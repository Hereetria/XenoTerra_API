
namespace XenoTerra.DTOLayer.Dtos.ViewStoryAdminDtos.Admin
{
    public class CreateViewStoryAdminDto
    {
        public Guid StoryId { get; set; }
        public Guid UserId { get; set; }
        public DateTime ViewedAt { get; set; }
    }
}