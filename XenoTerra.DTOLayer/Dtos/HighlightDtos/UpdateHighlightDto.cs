using XenoTerra.DTOLayer.Dtos.StoryDtos;

namespace XenoTerra.DTOLayer.Dtos.BlockUserDtos.HighlightDtos
{
    public class UpdateHighlightDto
    {
        public Guid HighlightId { get; set; }
        public string Name { get; set; }
        public string ProfilePicturePath { get; set; }
    }
}