using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.EntityLayer.Entities
{
    public class BlockUser
    {
        public Guid BlockUserId { get; set; }

        public Guid BlockingUserId { get; set; }
        public User BlockingUser { get; set; }

        public Guid BlockedUserId { get; set; }
        public User BlockedUser { get; set; }

        public DateTime BlockedAt { get; set; }
    }
}
