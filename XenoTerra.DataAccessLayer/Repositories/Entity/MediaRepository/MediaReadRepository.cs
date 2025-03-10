﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.MediaRepository
{
    public class MediaReadRepository : ReadRepository<Media, Guid>, IMediaReadRepository
    {
        public MediaReadRepository(AppDbContext context) : base(context) { }
    }
}
