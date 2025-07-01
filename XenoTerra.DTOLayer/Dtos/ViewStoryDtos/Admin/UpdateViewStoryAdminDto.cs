namespace XenoTerra.DTOLayer.Dtos.ViewStoryDtos.Admin
{
    public class UpdateViewStoryAdminDto
    {
        public Guid ViewStoryId { get; set; }
        public Guid? StoryId { get; set; }
        public Guid? UserId { get; set; }
    }
}