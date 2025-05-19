using XenoTerra.DTOLayer.Dtos.StoryDtos;

namespace XenoTerra.DTOLayer.Dtos.HighlightDtos
{
    public class CreateHighlightDto
    {
        public string Name { get; set; } = string.Empty;
        public string ProfilePicturePath { get; set; } = string.Empty;
        public Guid UserId { get; set; }
    }
}