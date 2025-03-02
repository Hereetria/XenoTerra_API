

namespace XenoTerra.DTOLayer.Dtos.ReportCommentDtos
{
    public class CreateReportCommentDto
    {
        public Guid ReporterUserId { get; set; }
        public Guid CommentId { get; set; }
        public string Reason { get; set; }
        public DateTime ReportedAt { get; set; }
    }
}