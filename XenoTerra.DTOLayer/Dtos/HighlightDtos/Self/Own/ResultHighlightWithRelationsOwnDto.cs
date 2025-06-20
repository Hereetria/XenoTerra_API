using XenoTerra.DTOLayer.Dtos.StoryAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.HighlightAdminDtos.Self.Own
{
    public class ResultHighlightWithRelationsOwnDto
    {
        public Guid HighlightId { get; init; }
        public string Name { get; init; } = string.Empty;
        public string ProfilePicturePath { get; init; } = string.Empty;
        public Guid UserId { get; set; }
        public AppUser User { get; init; } = null!;
        public ICollection<ResultStoryOwnDto> Stories { get; init; } = [];
    }
}