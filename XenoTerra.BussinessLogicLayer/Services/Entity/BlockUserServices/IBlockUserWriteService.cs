using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserService
{
    public interface IBlockUserWriteService : IWriteService<BlockUser, CreateBlockUserDto, UpdateBlockUserDto, Guid>
    {
    }
}
