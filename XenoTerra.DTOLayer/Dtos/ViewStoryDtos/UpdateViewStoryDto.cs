

using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.ViewStoryDtos
{
    public class UpdateViewStoryDto
    {
        public Guid ViewStoryId { get; set; }
        public Guid StoryId { get; set; }
        public Guid UserId { get; set; }
        public DateTime ViewedAt { get; set; }

        public ResultStoryByIdDto Story { get; set; }
        public ResultUserByIdDto User { get; set; }
    }
}