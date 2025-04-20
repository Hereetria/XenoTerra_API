using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.ReportCommentDtos
{
    public record class ResultReportCommentDto
    {
        public Guid ReportCommentId { get; init; }
        public Guid ReporterUserId { get; init; }
        public Guid CommentId { get; init; }
        public string Reason { get; init; } = string.Empty;
        public DateTime ReportedAt { get; init; }
    }
}
