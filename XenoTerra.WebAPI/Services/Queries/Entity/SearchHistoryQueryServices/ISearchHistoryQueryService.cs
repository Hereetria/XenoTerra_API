﻿using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.SearchHistoryQueryServices
{
    public interface ISearchHistoryQueryService : IQueryService<SearchHistory, ResultSearchHistoryWithRelationsDto, Guid>
    {
    }
}
