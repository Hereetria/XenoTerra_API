namespace XenoTerra.DTOLayer.Dtos.ReportPostDtos.Admin
{
    public class UpdateReportPostAdminDto
    {
        public Guid ReportPostId { get; set; }
        public Guid? ReporterUserId { get; set; }
        public Guid? PostId { get; set; }
    }
}