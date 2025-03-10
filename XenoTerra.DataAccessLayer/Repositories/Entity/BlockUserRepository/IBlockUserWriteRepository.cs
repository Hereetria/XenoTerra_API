using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.BlockUserRepository
{
    public interface IBlockUserWriteRepository : IWriteRepository<BlockUser, Guid>
    {
    }
}
