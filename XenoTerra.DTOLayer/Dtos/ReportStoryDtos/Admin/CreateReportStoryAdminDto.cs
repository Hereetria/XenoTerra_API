using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.ReportStoryAdminDtos.Admin
{
    public class CreateReportStoryAdminDto
    {
        public Guid ReporterUserId { get; set; }
        public Guid StoryId { get; set; }
        public string Reason { get; set; } = string.Empty;
        public DateTime ReportedAt { get; set; }
    }
}
