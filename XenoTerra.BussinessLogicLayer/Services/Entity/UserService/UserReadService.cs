﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.UserService
{
    public class UserReadService : ReadService<User, Guid>, IUserReadService
    {
        public UserReadService(IReadRepository<User, Guid> repository)
            : base(repository) { }
    }
}
