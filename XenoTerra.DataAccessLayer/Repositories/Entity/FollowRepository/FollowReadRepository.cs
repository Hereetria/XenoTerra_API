using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.FollowRepository
{
    public class FollowReadRepository : ReadRepository<Follow, Guid>, IFollowReadRepository
    {
        public FollowReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
