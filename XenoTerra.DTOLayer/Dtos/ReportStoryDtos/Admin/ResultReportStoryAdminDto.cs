using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.ReportStoryDtos.Admin
{
    public class ResultReportStoryAdminDto
    {
        public Guid ReportStoryId { get; init; }
        public Guid ReporterUserId { get; init; }
        public Guid StoryId { get; init; }
        public DateTime ReportedAt { get; init; }
    }
}
