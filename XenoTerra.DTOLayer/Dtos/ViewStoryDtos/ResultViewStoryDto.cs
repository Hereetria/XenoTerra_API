

namespace XenoTerra.DTOLayer.Dtos.ViewStoryDtos
{
    public class ResultViewStoryDto
    {
        public Guid ViewStoryId { get; set; }
        public Guid StoryId { get; set; }
        public Guid UserId { get; set; }
        public DateTime ViewedAt { get; set; }
    }
}