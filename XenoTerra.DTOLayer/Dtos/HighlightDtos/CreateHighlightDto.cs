

using XenoTerra.DTOLayer.Dtos.StoryDtos;

namespace XenoTerra.DTOLayer.Dtos.HighlightDtos
{
    public class CreateHighlightDto
    {
        public string Name { get; set; }
        public string ProfilePicturePath { get; set; }
        public Guid StoryId { get; set; }

        public ICollection<ResultStoryByIdDto> Stories { get; set; }
    }
}