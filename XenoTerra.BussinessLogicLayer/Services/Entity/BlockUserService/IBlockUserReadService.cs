﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserService
{
    public interface IBlockUserReadService : IReadService<BlockUser, ResultBlockUserWithRelationsDto, Guid>
    {
    }
}
