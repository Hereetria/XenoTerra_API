using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.EntityLayer.Entities
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        public string Content { get; set; }

        public Guid PostId { get; set; }
        public Post Post { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public DateTime CommentedAt { get; set; }

        public ICollection<ReportComment> ReportComments { get; set; } = new List<ReportComment>(); 
    }
}
