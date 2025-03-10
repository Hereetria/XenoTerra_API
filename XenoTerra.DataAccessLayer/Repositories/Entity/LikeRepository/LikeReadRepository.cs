using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.LikeRepository
{
    public class LikeReadRepository : ReadRepository<Like, Guid>, ILikeReadRepository
    {
        public LikeReadRepository(AppDbContext context) : base(context) { }
    }
}
