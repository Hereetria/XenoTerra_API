namespace XenoTerra.DTOLayer.Dtos.ReportStoryDtos.Self.Own
{
    public class ResultReportStoryOwnDto
    {
        public Guid ReportStoryId { get; init; }
        public Guid ReporterUserId { get; init; }
        public Guid StoryId { get; init; }
        public DateTime ReportedAt { get; init; }
    }
}