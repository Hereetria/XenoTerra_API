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
        public User ReporterUser { get; set; }

        public Guid CommentId { get; set; }
        public Comment Comment { get; set; }
        
        public string Reason { get; set; }

        public DateTime ReportedAt { get; set; }
    }
}
