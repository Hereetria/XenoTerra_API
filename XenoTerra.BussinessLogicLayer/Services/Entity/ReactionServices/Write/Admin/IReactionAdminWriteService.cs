﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.ReactionAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ReactionServices.Write.Admin
{
    public interface IReactionAdminWriteService : IWriteService<Reaction, CreateReactionAdminDto, UpdateReactionAdminDto, Guid> { }

}
