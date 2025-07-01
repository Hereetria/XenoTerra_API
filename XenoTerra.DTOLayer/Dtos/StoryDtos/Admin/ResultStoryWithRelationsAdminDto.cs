using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.HighlightDtos.Admin;
using XenoTerra.DTOLayer.Dtos.ReportStoryDtos.Admin;
using XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Admin;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.StoryDtos.Admin
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
        public ICollection<ResultStoryLikeAdminDto> StoryLikes { get; set; } = [];
        public ICollection<ResultReportStoryAdminDto> ReportStories { get; set; } = [];
    }
}