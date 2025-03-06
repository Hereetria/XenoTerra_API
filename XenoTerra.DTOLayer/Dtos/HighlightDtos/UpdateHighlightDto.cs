

using XenoTerra.DTOLayer.Dtos.StoryDtos;

namespace XenoTerra.DTOLayer.Dtos.HighlightDtos
{
    public class UpdateHighlightDto
    {
        public Guid HighlightId { get; set; }
        public string Name { get; set; }
        public string ProfilePicturePath { get; set; }
        public Guid StoryId { get; set; }
    }
}