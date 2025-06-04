

using XenoTerra.DTOLayer.Dtos.PostDtos;

namespace XenoTerra.DTOLayer.Dtos.ReportPostDtos
{
    public class UpdateReportPostDto
    {
        public Guid ReportPostId { get; set; }
        public Guid? ReporterUserId { get; set; }
        public Guid? PostId { get; set; }
        public string? Reason { get; set; } = string.Empty;
    }
}