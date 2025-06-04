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
        public string Content { get; set; } = string.Empty;

        public Guid SenderId { get; set; }
        public AppUser Sender { get; set; } = null!;

        public Guid ReceiverId { get; set; }
        public AppUser Receiver { get; set; } = null!;

        public ICollection<Reaction> Reactions { get; set; } = [];
        public string? Header { get; set; }
        public DateTime SentAt { get; set; }

    }
}
