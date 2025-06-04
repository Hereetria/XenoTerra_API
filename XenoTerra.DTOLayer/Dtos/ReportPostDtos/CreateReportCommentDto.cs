

using XenoTerra.DTOLayer.Dtos.PostDtos;

namespace XenoTerra.DTOLayer.Dtos.ReportPostDtos
{
    public class CreateReportPostDto
    {
        public Guid ReporterUserId { get; set; }
        public Guid PostId { get; set; }
        public string Reason { get; set; } = string.Empty;
        public DateTime ReportedAt { get; set; }
    }
}