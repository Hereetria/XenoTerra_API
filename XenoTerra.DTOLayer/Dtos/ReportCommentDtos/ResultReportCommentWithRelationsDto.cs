

using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.ReportCommentDtos
{
    public record ResultReportCommentWithRelationsDto(
        Guid ReportCommentId,
        Guid ReporterUserId,
        Guid CommentId,
        string Reason,
        DateTime ReportedAt
    )
    {
        public ResultUserDto? ReporterUser { get; set; }
        public ResultCommentDto? Comment { get; set; }
    }
}