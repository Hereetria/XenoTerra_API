using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.StoryAdminDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.ReportStoryAdminDtos.Admin
{
    public class ResultReportStoryWithRelationsAdminDto
    {
        public Guid ReportStoryId { get; init; }
        public Guid ReporterUserId { get; init; }
        public Guid StoryId { get; init; }
        public DateTime ReportedAt { get; init; }

        public ResultAppUserAdminDto ReporterUser { get; set; } = new();
        public ResultStoryAdminDto Story { get; set; } = new();
    }
}
