
namespace XenoTerra.DTOLayer.Dtos.ReportCommentAdminDtos.Admin
{
    public class CreateReportCommentAdminDto
    {
        public Guid ReporterUserId { get; set; }
        public Guid CommentId { get; set; }
        public DateTime ReportedAt { get; set; }
    }
}