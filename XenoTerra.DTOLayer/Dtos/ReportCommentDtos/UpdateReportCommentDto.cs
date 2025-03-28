

using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.ReportCommentDtos
{
    public class UpdateReportCommentDto
    {
        public Guid ReportCommentId { get; set; }
        public Guid ReporterUserId { get; set; }
        public Guid CommentId { get; set; }
        public required string Reason { get; set; }
        public DateTime ReportedAt { get; set; }
    }
}