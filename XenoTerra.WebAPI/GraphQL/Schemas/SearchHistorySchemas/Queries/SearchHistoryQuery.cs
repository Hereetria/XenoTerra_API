using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.SearchHistoryQueries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.SearchHistoryQueries.Sorts;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.SearchHistoryResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.SearchHistoryQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.SearchHistoryQueries
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
