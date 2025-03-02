

namespace XenoTerra.DTOLayer.Dtos.ViewStoryDtos
{
    public class CreateViewStoryDto
    {
        public Guid StoryId { get; set; }
        public Guid UserId { get; set; }
        public DateTime ViewedAt { get; set; }
    }
}