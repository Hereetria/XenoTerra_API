using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;

namespace XenoTerra.DTOLayer.Dtos.StoryDtos
{
    public record class ResultStoryWithRelationsDto
    {
        public Guid StoryId { get; init; }
        public string Path { get; init; } = string.Empty;
        public bool IsVideo { get; init; }
        public Guid UserId { get; init; }
        public DateTime CreatedAt { get; init; }
        public ResultAppUserPrivateDto User { get; init; } = new();
        public ICollection<ResultViewStoryDto> ViewStories { get; init; } = [];
        public ICollection<ResultHighlightDto> Highlights { get; init; } = [];
    }
}