using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Own;

namespace XenoTerra.DTOLayer.Dtos.ReportStoryDtos.Self.Own
{
    public class ResultReportStoryWithRelationsOwnDto
    {
        public Guid ReportStoryId { get; init; }
        public Guid ReporterUserId { get; init; }
        public Guid StoryId { get; init; }
        public DateTime ReportedAt { get; init; }

        public ResultAppUserOwnDto ReporterUser { get; set; } = new();
        public ResultStoryOwnDto Story { get; set; } = new();
    }
}