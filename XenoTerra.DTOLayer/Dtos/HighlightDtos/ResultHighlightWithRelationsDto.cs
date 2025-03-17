

using XenoTerra.DTOLayer.Dtos.StoryDtos;

namespace XenoTerra.DTOLayer.Dtos.HighlightDtos
{
    public class ResultHighlightWithRelationsDto
    {
        public Guid HighlightId { get; set; }
        public string Name { get; set; }
        public string ProfilePicturePath { get; set; }

        public ICollection<ResultStoryDto?> Stories { get; set; }
    }

}