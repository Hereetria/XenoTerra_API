
namespace XenoTerra.DTOLayer.Dtos.ReportCommentAdminDtos.Admin
{
    public class UpdateReportCommentAdminDto
    {
        public Guid ReportCommentId { get; set; }
        public Guid? ReporterUserId { get; set; }
        public Guid? CommentId { get; set; }
    }
}