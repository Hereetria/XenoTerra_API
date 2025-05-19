using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.SearchHistoryResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.SearchHistoryQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
    public class SearchHistorySelfQuery(IMapper mapper, IQueryResolverHelper<SearchHistory, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<SearchHistory, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(SearchHistorySelfFilterType))]
        [UseSorting(typeof(SearchHistorySelfSortType))]
        public async Task<SearchHistorySelfConnection> GetAllSearchHistoriesAsync(
            [Service] ISearchHistoryQueryService service,
            [Service] ISearchHistoryResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var filter = CreateSearchHistoryAccessFilter(currentUserId);

            var query = service.GetAllQueryable(context).Where(filter);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<SearchHistory, ResultSearchHistoryWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<SearchHistorySelfConnection, ResultSearchHistoryWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(SearchHistorySelfFilterType))]
        [UseSorting(typeof(SearchHistorySelfSortType))]
        public async Task<SearchHistorySelfConnection> GetSearchHistoriesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] ISearchHistoryQueryService service,
            [Service] ISearchHistoryResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var filter = CreateSearchHistoryAccessFilter(currentUserId);

            var query = service.GetByIdsQueryable(parsedKeys, context).Where(filter);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<SearchHistory, ResultSearchHistoryWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<SearchHistorySelfConnection, ResultSearchHistoryWithRelationsDto>(connection);
        }

        public async Task<ResultSearchHistoryWithRelationsDto?> GetSearchHistoryByIdAsync(
            string? key,
            [Service] ISearchHistoryQueryService service,
            [Service] ISearchHistoryResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var filter = CreateSearchHistoryAccessFilter(currentUserId);

            var query = service.GetByIdQueryable(parsedKey, context).Where(filter);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultSearchHistoryWithRelationsDto>(entity);
        }

        private static Expression<Func<SearchHistory, bool>> CreateSearchHistoryAccessFilter(Guid currentUserId) =>
            history => history.UserId == currentUserId;
    }
}
