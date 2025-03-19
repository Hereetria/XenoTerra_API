using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.BlockUserRepository
{
    public class BlockUserReadRepository : ReadRepository<BlockUser, ResultBlockUserWithRelationsDto, Guid>, IBlockUserReadRepository
    {
        public BlockUserReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
