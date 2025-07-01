using XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Public;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.HighlightDtos.Self.Public
{
    public class ResultHighlightWithRelationsPublicDto
    {
        public Guid HighlightId { get; init; }
        public string Name { get; init; } = string.Empty;
        public string ProfilePicturePath { get; init; } = string.Empty;
        public Guid UserId { get; init; }
        public AppUser User { get; init; } = null!;
        public ICollection<ResultStoryPublicDto> Stories { get; set; } = [];
    }
}