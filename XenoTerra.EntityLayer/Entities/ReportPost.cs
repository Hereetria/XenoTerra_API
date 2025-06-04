using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.EntityLayer.Entities
{
    public class ReportPost
    {
        public Guid ReportPostId { get; set; }

        public Guid ReporterUserId { get; set; }
        public AppUser ReporterUser { get; set; } = null!;

        public Guid PostId { get; set; }
        public Post Post { get; set; } = null!;

        public string Reason { get; set; } = string.Empty;

        public DateTime ReportedAt { get; set; }
    }
}
