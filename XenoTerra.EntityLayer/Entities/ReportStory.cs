using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.EntityLayer.Entities
{
    public class ReportStory
    {
        public Guid ReportStoryId { get; set; }

        public Guid ReporterUserId { get; set; }
        public AppUser ReporterUser { get; set; } = null!;

        public Guid StoryId { get; set; }
        public Story Story { get; set; } = null!;

        public DateTime ReportedAt { get; set; }
    }
}
