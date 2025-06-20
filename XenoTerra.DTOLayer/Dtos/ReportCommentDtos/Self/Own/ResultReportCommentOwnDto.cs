namespace XenoTerra.DTOLayer.Dtos.ReportCommentAdminDtos.Self.Own
{
    public class ResultReportCommentOwnDto
    {
        public Guid ReportCommentId { get; init; }
        public Guid ReporterUserId { get; init; }
        public Guid CommentId { get; init; }
        public DateTime ReportedAt { get; init; }
    }
}