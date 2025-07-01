using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Public;
using XenoTerra.DTOLayer.Dtos.HighlightDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.HighlightDtos.Self.Public;
using XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Admin;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Public
{
    public class ResultStoryWithRelationsPublicDto
    {
        public Guid StoryId { get; init; }
        public string Path { get; init; } = string.Empty;
        public bool IsVideo { get; init; }
        public Guid UserId { get; init; }
        public DateTime CreatedAt { get; init; }
        public ResultAppUserPublicDto User { get; set; } = new();
        public ICollection<ResultHighlightPublicDto> Highlights { get; set; } = [];
    }
}