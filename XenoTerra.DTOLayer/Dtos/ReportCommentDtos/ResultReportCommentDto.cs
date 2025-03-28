using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.ReportCommentDtos
{
    public record ResultReportCommentDto(
        Guid ReportCommentId,
        Guid ReporterUserId,
        Guid CommentId,
        string Reason,
        DateTime ReportedAt
    );
}
