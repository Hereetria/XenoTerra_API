using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.SearchHistoryResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.SearchHistoryQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Queries
{
    public class SearchHistoryQuery(IMapper mapper, IQueryResolverHelper<SearchHistory, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<SearchHistory, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(SearchHistoryFilterType))]
        [UseSorting(typeof(SearchHistorySortType))]
        public async Task<SearchHistoryConnection> GetAllSearchHistoriesAsync(
            [Service] ISearchHistoryQueryService service,
            [Service] ISearchHistoryResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<SearchHistory, ResultSearchHistoryWithRelationsDto>(
                entityConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<SearchHistoryConnection, ResultSearchHistoryWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(SearchHistoryFilterType))]
        [UseSorting(typeof(SearchHistorySortType))]
        public async Task<SearchHistoryConnection> GetSearchHistoriesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] ISearchHistoryQueryService service,
            [Service] ISearchHistoryResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<SearchHistory, ResultSearchHistoryWithRelationsDto>(
                entityConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<SearchHistoryConnection, ResultSearchHistoryWithRelationsDto>(connection);
        }

        public async Task<ResultSearchHistoryWithRelationsDto?> GetSearchHistoryByIdAsync(
            string? key,
            [Service] ISearchHistoryQueryService service,
            [Service] ISearchHistoryResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return _mapper.Map<ResultSearchHistoryWithRelationsDto>(entity);
        }
    }
}
