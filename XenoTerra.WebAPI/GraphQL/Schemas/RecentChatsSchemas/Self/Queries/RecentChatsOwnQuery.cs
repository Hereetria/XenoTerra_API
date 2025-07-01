using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.RecentChatsResolvers;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.RecentChatsQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Queries.Paginations.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Queries.Sorts;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class RecentChatsOwnQuery(IMapper mapper, IQueryResolverHelper<RecentChats, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<RecentChats, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(RecentChatsOwnFilterType))]
        [UseSorting(typeof(RecentChatsOwnSortType))]
        public async Task<RecentChatsOwnConnection> GetAllRecentChatsAsync(
            [Service] IRecentChatsQueryService service,
            [Service] IRecentChatsResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = CreateRecentChatsAccessFilter(httpContextAccessor);
            var query = service.GetAllQueryable(context, filter);

            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<RecentChats, ResultRecentChatsWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<RecentChatsOwnConnection, ResultRecentChatsWithRelationsOwnDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(RecentChatsOwnFilterType))]
        [UseSorting(typeof(RecentChatsOwnSortType))]
        public async Task<RecentChatsOwnConnection> GetRecentChatsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IRecentChatsQueryService service,
            [Service] IRecentChatsResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));
            var filter = CreateRecentChatsAccessFilter(httpContextAccessor);
            var query = service.GetByIdsQueryable(parsedKeys, context, filter);

            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<RecentChats, ResultRecentChatsWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<RecentChatsOwnConnection, ResultRecentChatsWithRelationsOwnDto>(connection);
        }

        public async Task<ResultRecentChatsWithRelationsOwnDto?> GetRecentChatsByIdAsync(
            string? key,
            [Service] IRecentChatsQueryService service,
            [Service] IRecentChatsResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var filter = CreateRecentChatsAccessFilter(httpContextAccessor);
            var query = service.GetByIdQueryable(parsedKey, context, filter);

            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultRecentChatsWithRelationsOwnDto>(entity);
        }

        private static Expression<Func<RecentChats, bool>> CreateRecentChatsAccessFilter(IHttpContextAccessor httpContextAccessor)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            return FilterExpressionHelper.BuildEqualsExpression<RecentChats, Guid>(
                x => x.UserId,
                currentUserId
            );
        }
    }
}
