using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.HighlightAdminDtos.Admin;
using XenoTerra.DTOLayer.Dtos.ViewStoryAdminDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.StoryAdminDtos.Admin
{
    public class ResultStoryWithRelationsAdminDto
    {
        public Guid StoryId { get; init; }
        public string Path { get; init; } = string.Empty;
        public bool IsVideo { get; init; }
        public Guid UserId { get; init; }
        public DateTime CreatedAt { get; init; }
        public ResultAppUserAdminDto User { get; set; } = new();
        public ICollection<ResultViewStoryAdminDto> ViewStories { get; set; } = [];
        public ICollection<ResultHighlightAdminDto> Highlights { get; set; } = [];
        public ICollection<StoryLike> StoryLikes { get; set; } = [];
        public ICollection<ReportStory> ReportStories { get; set; } = [];
    }
}