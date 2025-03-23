﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.UserSettingService
{

    public class UserSettingReadService : ReadService<UserSetting, Guid>, IUserSettingReadService
    {
        public UserSettingReadService(IReadRepository<UserSetting, Guid> repository)
            : base(repository) { }
    }
}
