

using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.ViewStoryDtos
{
    public record ResultViewStoryWithRelationsDto(
        Guid ViewStoryId,
        Guid StoryId,
        Guid UserId,
        DateTime ViewedAt
    )
    {
        public ResultStoryWithRelationsDto? Story { get; set; }
        public ResultUserWithRelationsDto? User { get; set; }
    }
}