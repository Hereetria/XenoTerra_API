﻿using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.UserPostTagQueryServices
{
    public class UserPostTagQueryService : QueryService<UserPostTag, Guid>, IUserPostTagQueryService
    {
        public UserPostTagQueryService(IReadService<UserPostTag, Guid> readService)
            : base(readService) { }
    }
}
