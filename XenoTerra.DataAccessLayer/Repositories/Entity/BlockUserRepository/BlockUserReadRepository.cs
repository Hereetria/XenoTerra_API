﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.BlockUserRepository
{
    public class BlockUserReadRepository(AppDbContext context) : ReadRepository<BlockUser, Guid>(context), IBlockUserReadRepository
    {
    }
}
