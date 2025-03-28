using XenoTerra.DTOLayer.Dtos.StoryDtos;

namespace XenoTerra.DTOLayer.Dtos.HighlightDtos
{
    public class UpdateHighlightDto
    {
        public Guid HighlightId { get; set; }
        public required string Name { get; set; }
        public required string ProfilePicturePath { get; set; }
    }
}