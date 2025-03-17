﻿using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.UserSettingQueryServices
{
    public class UserSettingQueryService : BaseQueryService<UserSetting, ResultUserSettingDto, Guid>, IUserSettingQueryService
    {
        public UserSettingQueryService(IReadService<UserSetting, Guid> readService, IMapper mapper)
            : base(readService, mapper) { }
    }

}
