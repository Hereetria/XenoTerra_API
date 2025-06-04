

using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.DTOLayer.Dtos.CommentDtos;

namespace XenoTerra.DTOLayer.Dtos.ReportCommentDtos
{
    public record class ResultReportCommentWithRelationsDto
    {
        public Guid ReportCommentId { get; init; }
        public Guid ReporterUserId { get; init; }
        public Guid CommentId { get; init; }
        public string Reason { get; init; } = string.Empty;
        public DateTime ReportedAt { get; init; }
        public ResultAppUserPrivateDto ReporterUser { get; init; } = new();
        public ResultCommentDto Comment { get; init; } = new();
    }
}