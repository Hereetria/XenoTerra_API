

using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.ReportCommentDtos
{
    public record class ResultReportCommentWithRelationsDto
    {
        public Guid ReportCommentId { get; init; }
        public Guid ReporterUserId { get; init; }
        public Guid CommentId { get; init; }
        public string Reason { get; init; } = string.Empty;
        public DateTime ReportedAt { get; init; }
        public ResultUserPrivateDto ReporterUser { get; init; } = new();
        public ResultCommentDto Comment { get; init; } = new();
    }
}