

using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.ViewStoryDtos
{
    public class UpdateViewStoryDto
    {
        public Guid ViewStoryId { get; set; }
        public Guid? StoryId { get; set; }
        public Guid? UserId { get; set; }
    }
}