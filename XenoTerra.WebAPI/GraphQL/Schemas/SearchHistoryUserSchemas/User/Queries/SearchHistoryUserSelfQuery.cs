using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.SearchHistoryUserResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.SearchHistoryUserQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Queries
{
    public class SearchHistoryUserSelfQuery(IMapper mapper, IQueryResolverHelper<SearchHistoryUser, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<SearchHistoryUser, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(SearchHistoryUserSelfFilterType))]
        [UseSorting(typeof(SearchHistoryUserSelfSortType))]
        public async Task<SearchHistoryUserSelfConnection> GetAllSearchHistoryUsersAsync(
            [Service] ISearchHistoryUserQueryService service,
            [Service] ISearchHistoryUserResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapSelfConnection<SearchHistoryUser, ResultSearchHistoryUserWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<SearchHistoryUserSelfConnection, ResultSearchHistoryUserWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(SearchHistoryUserSelfFilterType))]
        [UseSorting(typeof(SearchHistoryUserSelfSortType))]
        public async Task<SearchHistoryUserSelfConnection> GetSearchHistoryUsersByIdsAsync(
            IEnumerable<string>? keys,
            [Service] ISearchHistoryUserQueryService service,
            [Service] ISearchHistoryUserResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapSelfConnection<SearchHistoryUser, ResultSearchHistoryUserWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<SearchHistoryUserSelfConnection, ResultSearchHistoryUserWithRelationsDto>(connection);
        }

        public async Task<ResultSearchHistoryUserWithRelationsDto?> GetSearchHistoryUserByIdAsync(
            string? key,
            [Service] ISearchHistoryUserQueryService service,
            [Service] ISearchHistoryUserResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return _mapper.Map<ResultSearchHistoryUserWithRelationsDto>(entity);
        }
    }
}
