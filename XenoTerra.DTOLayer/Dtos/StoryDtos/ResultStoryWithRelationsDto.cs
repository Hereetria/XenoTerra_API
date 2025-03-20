

using XenoTerra.DTOLayer.Dtos.BlockUserDtos.HighlightDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;

namespace XenoTerra.DTOLayer.Dtos.StoryDtos
{
    public class ResultStoryWithRelationsDto
    {
        public Guid StoryId { get; set; }
        public string Path { get; set; }
        public bool IsVideo { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public ResultUserDto User { get; set; }
        public ICollection<ResultViewStoryDto> ViewStories { get; set; }
        public ICollection<ResultHighlightDto> Highlights { get; set; }
    }
}