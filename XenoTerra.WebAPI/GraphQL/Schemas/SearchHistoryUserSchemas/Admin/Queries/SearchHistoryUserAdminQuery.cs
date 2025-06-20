using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.SearchHistoryUserResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.SearchHistoryUserQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class SearchHistoryUserAdminQuery(IMapper mapper, IQueryResolverHelper<SearchHistoryUser, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<SearchHistoryUser, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(SearchHistoryUserAdminFilterType))]
        [UseSorting(typeof(SearchHistoryUserAdminSortType))]
        public async Task<SearchHistoryUserAdminConnection> GetAllSearchHistoryUsersAsync(
            [Service] ISearchHistoryUserQueryService service,
            [Service] ISearchHistoryUserResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<SearchHistoryUser, ResultSearchHistoryUserWithRelationsAdminDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<SearchHistoryUserAdminConnection, ResultSearchHistoryUserWithRelationsAdminDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(SearchHistoryUserAdminFilterType))]
        [UseSorting(typeof(SearchHistoryUserAdminSortType))]
        public async Task<SearchHistoryUserAdminConnection> GetSearchHistoryUsersByIdsAsync(
            IEnumerable<string>? keys,
            [Service] ISearchHistoryUserQueryService service,
            [Service] ISearchHistoryUserResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<SearchHistoryUser, ResultSearchHistoryUserWithRelationsAdminDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<SearchHistoryUserAdminConnection, ResultSearchHistoryUserWithRelationsAdminDto>(connection);
        }

        public async Task<ResultSearchHistoryUserWithRelationsAdminDto?> GetSearchHistoryUserByIdAsync(
            string? key,
            [Service] ISearchHistoryUserQueryService service,
            [Service] ISearchHistoryUserResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultSearchHistoryUserWithRelationsAdminDto>(entity);
        }
    }
}
