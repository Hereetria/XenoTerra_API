

using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;

namespace XenoTerra.DTOLayer.Dtos.StoryDtos
{
    public class CreateStoryDto
    {
        public string Path { get; set; }
        public bool IsVideo { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public ResultUserByIdDto User { get; set; }
        public ICollection<ResultViewStoryByIdDto> ViewStories { get; set; }
        public ICollection<ResultHighlightByIdDto> Highlights { get; set; }
    }
}