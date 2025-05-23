﻿using AutoMapper;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.UserSettingMutationServices
{
    public class UserSettingSelfMutationService(IMapper mapper)
        : MutationService<UserSetting, ResultUserSettingDto, CreateUserSettingDto, UpdateUserSettingDto, Guid>(mapper),
        IUserSettingSelfMutationService
    {
    }
}
