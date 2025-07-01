namespace XenoTerra.DTOLayer.Dtos.ReportPostDtos.Self.Own
{
    public class ResultReportPostOwnDto
    {
        public Guid ReportPostId { get; init; }
        public Guid ReporterUserId { get; init; }
        public Guid PostId { get; init; }
        public DateTime ReportedAt { get; init; }
    }
}