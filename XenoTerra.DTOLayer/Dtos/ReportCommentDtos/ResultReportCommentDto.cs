using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.ReportCommentDtos
{
    public class ResultReportCommentDto
    {
        public Guid ReportCommentId { get; set; }
        public Guid ReporterUserId { get; set; }
        public Guid CommentId { get; set; }
        public string Reason { get; set; }
        public DateTime ReportedAt { get; set; }
    }
}
