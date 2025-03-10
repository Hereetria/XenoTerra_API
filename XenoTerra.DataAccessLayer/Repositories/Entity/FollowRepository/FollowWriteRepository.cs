using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.FollowRepository
{

    public class FollowWriteRepository : WriteRepository<Follow, Guid>, IFollowWriteRepository
    {
        public FollowWriteRepository(IDbContextFactory<AppDbContext> contextFactory) : base(contextFactory) { }
    }
}
