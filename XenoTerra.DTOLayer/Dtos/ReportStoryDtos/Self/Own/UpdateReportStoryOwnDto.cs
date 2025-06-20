namespace XenoTerra.DTOLayer.Dtos.ReportStoryAdminDtos.Self.Own
{
    public class UpdateReportStoryOwnDto
    {
        public Guid? ReportStoryId { get; set; }
        public Guid? StoryId { get; set; }
        public string? Reason { get; set; } = string.Empty;
        public DateTime? ReportedAt { get; set; }
    }
}
