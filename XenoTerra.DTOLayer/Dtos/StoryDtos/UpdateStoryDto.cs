

using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;

namespace XenoTerra.DTOLayer.Dtos.StoryDtos
{
    public class UpdateStoryDto
    {
        public Guid StoryId { get; set; }
        public string? Path { get; set; } = string.Empty;
        public bool? IsVideo { get; set; }
        public Guid? UserId { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}