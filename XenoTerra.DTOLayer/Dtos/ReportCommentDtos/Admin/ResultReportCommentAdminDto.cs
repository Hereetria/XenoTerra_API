using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.ReportCommentDtos.Admin
{
    public class ResultReportCommentAdminDto
    {
        public Guid ReportCommentId { get; init; }
        public Guid ReporterUserId { get; init; }
        public Guid CommentId { get; init; }
        public DateTime ReportedAt { get; init; }
    }
}
