﻿using System;
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
        public AppUser BlockingUser { get; set; } = null!;

        public Guid BlockedUserId { get; set; }
        public AppUser BlockedUser { get; set; } = null!;

        public DateTime BlockedAt { get; set; }
    }
}
