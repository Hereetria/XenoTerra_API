﻿using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.UserQueryServices
{
    public class UserQueryService : QueryService<User, Guid>, IUserQueryService
    {
        public UserQueryService(IReadService<User, Guid> readService)
            : base(readService)
        {
        }
    }
}
