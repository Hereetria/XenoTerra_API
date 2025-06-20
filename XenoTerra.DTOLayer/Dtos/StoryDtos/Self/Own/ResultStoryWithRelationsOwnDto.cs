using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.HighlightAdminDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.ViewStoryAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.StoryAdminDtos.Self.Own
{
    public class ResultStoryWithRelationsOwnDto
    {
        public Guid StoryId { get; init; }
        public string Path { get; init; } = string.Empty;
        public bool IsVideo { get; init; }
        public Guid UserId { get; init; }
        public DateTime CreatedAt { get; init; }
        public ResultAppUserOwnDto User { get; set; } = new();
        public ICollection<ResultViewStoryOwnDto> ViewStories { get; set; } = [];
        public ICollection<ResultHighlightOwnDto> Highlights { get; set; } = [];
        public ICollection<StoryLike> StoryLikes { get; set; } = [];
    }
}