

using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;

namespace XenoTerra.DTOLayer.Dtos.StoryDtos
{
    public class UpdateStoryDto
    {
        public Guid StoryId { get; set; }
        public required string Path { get; set; }
        public bool IsVideo { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}