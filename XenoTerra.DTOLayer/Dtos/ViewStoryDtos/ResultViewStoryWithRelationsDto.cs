

using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.ViewStoryDtos
{
    public record class ResultViewStoryWithRelationsDto
    {
        public Guid ViewStoryId { get; init; }
        public Guid StoryId { get; init; }
        public Guid UserId { get; init; }
        public DateTime ViewedAt { get; init; }
        public ResultStoryWithRelationsDto Story { get; init; } = new();
        public ResultUserWithRelationsPrivateDto User { get; init; } = new();
    }
}