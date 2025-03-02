﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.EntityLayer.Entities
{
    public class UserSetting
    {
        public Guid UserSettingId { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public bool IsPrivate { get; set; }
        public bool ReceiveNotifications { get; set; }
        public bool ShowActivityStatus { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
