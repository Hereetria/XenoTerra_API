

namespace XenoTerra.DTOLayer.Dtos.StoryDtos
{
    public class ResultStoryDto
    {
        public Guid StoryId { get; set; }
        public string Path { get; set; }
        public bool isVideo { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}