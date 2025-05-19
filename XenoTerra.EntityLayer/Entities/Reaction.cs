using XenoTerra.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.EntityLayer.Entities
{
    public class Reaction
    {
        public Guid ReactionId { get; set; }
        public string Payload { get; set; } = string.Empty;

        public Guid MessageId { get; set; }
        public Message Message { get; set; } = null!;
    }
}
