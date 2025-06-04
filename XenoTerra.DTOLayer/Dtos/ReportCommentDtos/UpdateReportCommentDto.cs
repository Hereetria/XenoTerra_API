

using XenoTerra.DTOLayer.Dtos.CommentDtos;

namespace XenoTerra.DTOLayer.Dtos.ReportCommentDtos
{
    public class UpdateReportCommentDto
    {
        public Guid ReportCommentId { get; set; }
        public Guid? ReporterUserId { get; set; }
        public Guid? CommentId { get; set; }
        public string? Reason { get; set; } = string.Empty;
    }
}