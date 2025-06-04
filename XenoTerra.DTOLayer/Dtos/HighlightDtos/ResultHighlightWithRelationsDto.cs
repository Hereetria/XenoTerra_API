using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.HighlightDtos
{
    public record class ResultHighlightWithRelationsDto
    {
        public Guid HighlightId { get; init; }
        public string Name { get; init; } = string.Empty;
        public string ProfilePicturePath { get; init; } = string.Empty;
        public Guid UserId { get; set; }
        public AppUser User { get; init; } = null!;
        public ICollection<ResultStoryDto> Stories { get; init; } = [];
    }
}