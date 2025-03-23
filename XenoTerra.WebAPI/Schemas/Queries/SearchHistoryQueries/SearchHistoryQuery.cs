﻿using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryService;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Queries._Helpers;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.SearchHistoryResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.SearchHistoryQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.SearchHistoryQueries
{
    public class SearchHistoryQuery
    {
        private readonly IMapper _mapper;
        private readonly IQueryResolverHelper<SearchHistory, Guid> _queryResolver;

        public SearchHistoryQuery(IMapper mapper, IQueryResolverHelper<SearchHistory, Guid> queryResolver)
        {
            _mapper = mapper;
            _queryResolver = queryResolver;
        }

        [UsePaging]
        [UseFiltering(typeof(SearchHistoryFilterType))]
        [UseSorting(typeof(SearchHistorySortType))]
        public async Task<IEnumerable<ResultSearchHistoryWithRelationsDto>> GetAllSearchHistoriesAsync(
            [Service] ISearchHistoryQueryService service,
            [Service] ISearchHistoryResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultSearchHistoryWithRelationsDto>>(entities);
        }

        [UsePaging]
        [UseFiltering(typeof(SearchHistoryFilterType))]
        [UseSorting(typeof(SearchHistorySortType))]
        public async Task<IEnumerable<ResultSearchHistoryWithRelationsDto>> GetSearchHistoriesByIdsAsync(
            IEnumerable<Guid> keys,
            [Service] ISearchHistoryQueryService service,
            [Service] ISearchHistoryResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdsQueryable(keys, context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultSearchHistoryWithRelationsDto>>(entities);
        }

        public async Task<ResultSearchHistoryWithRelationsDto> GetSearchHistoryByIdAsync(
            Guid key,
            [Service] ISearchHistoryQueryService service,
            [Service] ISearchHistoryResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdQueryable(key, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);
            return _mapper.Map<ResultSearchHistoryWithRelationsDto>(entity);
        }
    }
}
