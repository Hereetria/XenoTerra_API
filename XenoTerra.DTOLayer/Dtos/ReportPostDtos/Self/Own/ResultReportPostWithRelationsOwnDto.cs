using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.PostDtos.Self.Own;

namespace XenoTerra.DTOLayer.Dtos.ReportPostDtos.Self.Own
{
    public class ResultReportPostWithRelationsOwnDto
    {
        public Guid ReportPostId { get; init; }
        public Guid ReporterUserId { get; init; }
        public Guid PostId { get; init; }
        public DateTime ReportedAt { get; init; }
        public ResultAppUserOwnDto ReporterUser { get; set; } = new();
        public ResultPostOwnDto Post { get; set; } = new();
    }
}