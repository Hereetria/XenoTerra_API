using XenoTerra.DTOLayer.Dtos.StoryDtos;

namespace XenoTerra.DTOLayer.Dtos.HighlightDtos
{
    public class ResultHighlightWithRelationsDto
    {
        public Guid HighlightId { get; init; }
        public string Name { get; init; } = string.Empty;
        public string ProfilePicturePath { get; init; } = string.Empty;

        public ICollection<ResultStoryDto>? Stories { get; set; }
    }

}