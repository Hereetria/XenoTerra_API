using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;

namespace XenoTerra.DTOLayer.Dtos.StoryDtos
{
    public record ResultStoryWithRelationsDto(
        Guid StoryId,
        string Path,
        bool IsVideo,
        Guid UserId,
        DateTime CreatedAt
    )
    {
        public ResultUserDto? User { get; set; }
        public ICollection<ResultViewStoryDto>? ViewStories { get; set; }
        public ICollection<ResultHighlightDto>? Highlights { get; set; }
    }
}