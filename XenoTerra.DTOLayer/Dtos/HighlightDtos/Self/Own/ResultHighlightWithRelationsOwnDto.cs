using XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.HighlightDtos.Self.Own
{
    public class ResultHighlightWithRelationsOwnDto
    {
        public Guid HighlightId { get; init; }
        public string Name { get; init; } = string.Empty;
        public string ProfilePicturePath { get; init; } = string.Empty;
        public Guid UserId { get; init; }
        public AppUser User { get; init; } = null!;
        public ICollection<ResultStoryOwnDto> Stories { get; set; } = [];
    }
}