
namespace XenoTerra.DTOLayer.Dtos.ReportPostAdminDtos.Admin
{
    public class UpdateReportPostAdminDto
    {
        public Guid ReportPostId { get; set; }
        public Guid? ReporterUserId { get; set; }
        public Guid? PostId { get; set; }
    }
}