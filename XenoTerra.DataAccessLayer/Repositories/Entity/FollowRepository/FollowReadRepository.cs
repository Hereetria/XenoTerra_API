using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.FollowRepository
{
    public class FollowReadRepository(AppDbContext context) : ReadRepository<Follow, Guid>(context), IFollowReadRepository
    {
    }
}
