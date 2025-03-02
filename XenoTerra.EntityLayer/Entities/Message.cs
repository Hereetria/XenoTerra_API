using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.EntityLayer.Entities
{
    public class Message
    {
        public Guid MessageId { get; set; }
        public string Content { get; set; }

        public Guid SenderId { get; set; }
        public User Sender { get; set; }

        public Guid ReceiverId { get; set; }
        public User Receiver { get; set; }

        public ICollection<Reaction> Reactions { get; set; } = new List<Reaction>();
        public string? Header { get; set; }
        public DateTime SentAt { get; set; }

    }
}
