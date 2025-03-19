using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.BlockUserRepository
{
    public class BlockUserWriteRepository : WriteRepository<BlockUser, ResultBlockUserDto, Guid>, IBlockUserWriteRepository
    {
        public BlockUserWriteRepository(IMapper mapper, AppDbContext context) : base(mapper, context)
        {
        }
    }
}
