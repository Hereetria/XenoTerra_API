using XenoTerra.DTOLayer.Dtos.StoryDtos;

namespace XenoTerra.DTOLayer.Dtos.BlockUserDtos.HighlightDtos
{
    public class CreateHighlightDto
    {
        public required string Name { get; set; }
        public required string ProfilePicturePath { get; set; }
    }
}