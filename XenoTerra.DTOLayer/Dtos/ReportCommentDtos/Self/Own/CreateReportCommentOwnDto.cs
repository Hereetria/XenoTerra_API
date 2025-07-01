namespace XenoTerra.DTOLayer.Dtos.ReportCommentDtos.Self.Own
{
    public class CreateReportCommentOwnDto
    {
        public Guid ReporterUserId { get; set; }
        public Guid CommentId { get; set; }
        public DateTime ReportedAt { get; set; }
    }
}
