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
        public string PhotoUrl { get; set; } = string.Empty;

        public Guid SenderId { get; set; }
        public User Sender { get; set; } = null!;

        public Guid ReceiverId { get; set; }
        public User Receiver { get; set; } = null!;

        public DateTime UploadedAt { get; set; }
    }
}
