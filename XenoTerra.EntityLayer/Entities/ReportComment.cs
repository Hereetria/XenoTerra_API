using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.EntityLayer.Entities
{
    public class ReportComment
    {
        public Guid ReportCommentId { get; set; }

        public Guid ReporterUserId { get; set; }
        public  AppUser ReporterUser { get; set; } = null!;

        public Guid CommentId { get; set; }
        public Comment Comment { get; set; } = null!;

        public DateTime ReportedAt { get; set; }
    }
}
