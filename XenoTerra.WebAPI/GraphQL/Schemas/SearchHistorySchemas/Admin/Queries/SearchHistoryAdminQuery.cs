using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.SearchHistoryResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.SearchHistoryQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class SearchHistoryAdminQuery(IMapper mapper, IQueryResolverHelper<SearchHistory, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<SearchHistory, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(SearchHistoryAdminFilterType))]
        [UseSorting(typeof(SearchHistoryAdminSortType))]
        public async Task<SearchHistoryAdminConnection> GetAllSearchHistoriesAsync(
            [Service] ISearchHistoryQueryService service,
            [Service] ISearchHistoryResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<SearchHistory, ResultSearchHistoryWithRelationsDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<SearchHistoryAdminConnection, ResultSearchHistoryWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(SearchHistoryAdminFilterType))]
        [UseSorting(typeof(SearchHistoryAdminSortType))]
        public async Task<SearchHistoryAdminConnection> GetSearchHistoriesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] ISearchHistoryQueryService service,
            [Service] ISearchHistoryResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<SearchHistory, ResultSearchHistoryWithRelationsDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<SearchHistoryAdminConnection, ResultSearchHistoryWithRelationsDto>(connection);
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

            return entity is null ? null : _mapper.Map<ResultSearchHistoryWithRelationsDto>(entity);
        }
    }
}
