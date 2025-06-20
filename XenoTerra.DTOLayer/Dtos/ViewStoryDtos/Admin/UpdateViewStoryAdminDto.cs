
namespace XenoTerra.DTOLayer.Dtos.ViewStoryAdminDtos.Admin
{
    public class UpdateViewStoryAdminDto
    {
        public Guid ViewStoryId { get; set; }
        public Guid? StoryId { get; set; }
        public Guid? UserId { get; set; }
    }
}