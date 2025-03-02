using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.EntityLayer.Entities
{
    public class Media
    {
        public Guid MediaId { get; set; }
        public string PhotoUrl { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public DateTime UploadedAt { get; set; }
    }
}
