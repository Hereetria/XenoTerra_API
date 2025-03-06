

using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.ViewStoryDtos
{
    public class ResultViewStoryWithRelationsDto
    {
        public Guid ViewStoryId { get; set; }
        public Guid StoryId { get; set; }
        public Guid UserId { get; set; }
        public DateTime ViewedAt { get; set; }

        public ResultStoryWithRelationsDto Story { get; set; }
        public ResultUserWithRelationsDto User { get; set; }
    }
}