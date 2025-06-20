namespace XenoTerra.DTOLayer.Dtos.ReportPostAdminDtos.Self.Own
{
    public class CreateReportPostOwnDto
    {
        public Guid ReporterUserId { get; set; }
        public Guid PostId { get; set; }
        public DateTime ReportedAt { get; set; }
    }
}
