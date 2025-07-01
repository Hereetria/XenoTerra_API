namespace XenoTerra.DTOLayer.Dtos.ReportPostDtos.Admin
{
    public class CreateReportPostAdminDto
    {
        public Guid ReporterUserId { get; set; }
        public Guid PostId { get; set; }
        public DateTime ReportedAt { get; set; }
    }
}