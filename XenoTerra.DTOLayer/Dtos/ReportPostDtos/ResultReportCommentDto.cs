using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.ReportPostDtos
{
    public record class ResultReportPostDto
    {
        public Guid ReportPostId { get; init; }
        public Guid ReporterUserId { get; init; }
        public Guid PostId { get; init; }
        public string Reason { get; init; } = string.Empty;
        public DateTime ReportedAt { get; init; }
    }
}
