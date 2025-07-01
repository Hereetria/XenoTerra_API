using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Own;

namespace XenoTerra.DTOLayer.Dtos.ReportCommentDtos.Self.Own
{
    public class ResultReportCommentWithRelationsOwnDto
    {
        public Guid ReportCommentId { get; init; }
        public Guid ReporterUserId { get; init; }
        public Guid CommentId { get; init; }
        public DateTime ReportedAt { get; init; }
        public ResultAppUserOwnDto ReporterUser { get; set; } = new();
        public ResultCommentOwnDto Comment { get; set; } = new();
    }
}