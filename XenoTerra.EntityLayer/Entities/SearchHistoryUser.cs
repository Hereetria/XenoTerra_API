﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.EntityLayer.Entities
{
    public class SearchHistoryUser
    {
        public Guid SearchHistoryId { get; set; }
        public SearchHistory SearchHistory { get; set; } = null!;

        public Guid UserId { get; set; }
        public AppUser User { get; set; } = null!;
    }

}
