﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.LikeRepository
{
    public class LikeWriteRepository : WriteRepository<Like, Guid>, ILikeWriteRepository
    {
        public LikeWriteRepository(IDbContextFactory<AppDbContext> contextFactory) : base(contextFactory) { }
    }
}
