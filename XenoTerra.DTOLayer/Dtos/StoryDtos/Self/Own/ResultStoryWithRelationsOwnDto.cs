using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.HighlightDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Admin;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Own
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
        public ICollection<ResultStoryLikeAdminDto> StoryLikes { get; set; } = [];
    }
}