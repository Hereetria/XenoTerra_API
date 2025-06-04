

using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.DTOLayer.Dtos.PostDtos;

namespace XenoTerra.DTOLayer.Dtos.ReportPostDtos
{
    public record class ResultReportPostWithRelationsDto
    {
        public Guid ReportPostId { get; init; }
        public Guid ReporterUserId { get; init; }
        public Guid PostId { get; init; }
        public string Reason { get; init; } = string.Empty;
        public DateTime ReportedAt { get; init; }
        public ResultAppUserPrivateDto ReporterUser { get; init; } = new();
        public ResultPostDto Post { get; init; } = new();
    }
}