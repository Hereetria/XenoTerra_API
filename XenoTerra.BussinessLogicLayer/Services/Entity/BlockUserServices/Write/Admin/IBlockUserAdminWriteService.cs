using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.BlockUserAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserServices.Write.Admin
{
    public interface IBlockUserAdminWriteService : IWriteService<BlockUser, CreateBlockUserAdminDto, UpdateBlockUserAdminDto, Guid>
    {
    }
}
