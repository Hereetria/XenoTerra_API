using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.CommentDtos.Admin;

namespace XenoTerra.DTOLayer.Dtos.ReportCommentDtos.Admin
{
    public class ResultReportCommentWithRelationsAdminDto
    {
        public Guid ReportCommentId { get; init; }
        public Guid ReporterUserId { get; init; }
        public Guid CommentId { get; init; }
        public DateTime ReportedAt { get; init; }
        public ResultAppUserAdminDto ReporterUser { get; set; } = new();
        public ResultCommentAdminDto Comment { get; set; } = new();
    }
}