using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.PostAdminDtos.Admin;

namespace XenoTerra.DTOLayer.Dtos.ReportPostAdminDtos.Admin
{
    public class ResultReportPostWithRelationsAdminDto
    {
        public Guid ReportPostId { get; init; }
        public Guid ReporterUserId { get; init; }
        public Guid PostId { get; init; }
        public DateTime ReportedAt { get; init; }
        public ResultAppUserAdminDto ReporterUser { get; set; } = new();
        public ResultPostAdminDto Post { get; set; } = new();
    }
}