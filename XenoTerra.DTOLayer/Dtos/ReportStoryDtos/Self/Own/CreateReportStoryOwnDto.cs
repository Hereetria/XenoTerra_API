namespace XenoTerra.DTOLayer.Dtos.ReportStoryDtos.Self.Own
{
    public class CreateReportStoryOwnDto
    {
        public Guid ReporterUserId { get; set; }
        public Guid StoryId { get; set; }
        public string Reason { get; set; } = string.Empty;
        public DateTime ReportedAt { get; set; }
    }
}
