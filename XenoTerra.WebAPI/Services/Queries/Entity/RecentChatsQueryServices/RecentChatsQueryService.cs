﻿using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.RecentChatsQueryServices
{
    public class RecentChatsQueryService : QueryService<RecentChats, Guid>, IRecentChatsQueryService
    {
        public RecentChatsQueryService(IReadService<RecentChats, Guid> readService, IMapper mapper)
            : base(readService, mapper) { }
    }
}
