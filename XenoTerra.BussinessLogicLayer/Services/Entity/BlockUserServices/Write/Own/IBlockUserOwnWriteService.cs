using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.BlockUserAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserServices.Write.Own
{
    public interface IBlockUserOwnWriteService : IWriteService<BlockUser, CreateBlockUserOwnDto, UpdateBlockUserOwnDto, Guid>
    {
    }
}
