using AutoMapper;
using HotChocolate.Authorization;
using HotChocolate.Resolvers;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Public;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.AppUserResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Paginations.Public;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.AppUserQueryServices;
using XenoTerra.WebAPI.Services.Queries.Entity.FollowQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class AppUserPublicQuery(IMapper mapper, IQueryResolverHelper<AppUser, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<AppUser, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(AppUserPublicFilterType))]
        [UseSorting(typeof(AppUserPublicSortType))]
        public async Task<AppUserPublicConnection> GetAllUsersAsync(
            [Service] IAppUserQueryService service,
            [Service] IAppUserResolver resolver,
            [Service] IBlockedUserIdProvider blockedUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = CreateUserPublicAccessFilter(httpContextAccessor, blockedUserIdProvider);
            var query = service.GetAllQueryable(context, filter);

            var entityPublicConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<AppUser, ResultAppUserWithRelationsPublicDto>(
                entityPublicConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<AppUserPublicConnection, ResultAppUserWithRelationsPublicDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(AppUserPublicFilterType))]
        [UseSorting(typeof(AppUserPublicSortType))]
        public async Task<AppUserPublicConnection> GetUsersByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IAppUserQueryService service,
            [Service] IAppUserResolver resolver,
            [Service] IBlockedUserIdProvider blockedUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));
            var filter = CreateUserPublicAccessFilter(httpContextAccessor, blockedUserIdProvider);
            var query = service.GetByIdsQueryable(parsedKeys, context, filter);

            var entityPublicConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<AppUser, ResultAppUserWithRelationsPublicDto>(
                entityPublicConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<AppUserPublicConnection, ResultAppUserWithRelationsPublicDto>(connection);
        }

        public async Task<ResultAppUserWithRelationsPublicDto?> GetUserByIdAsync(
            string? key,
            [Service] IAppUserQueryService service,
            [Service] IAppUserResolver resolver,
            [Service] IBlockedUserIdProvider blockedUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var filter = CreateUserPublicAccessFilter(httpContextAccessor, blockedUserIdProvider);
            var query = service.GetByIdQueryable(parsedKey, context, filter);

            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultAppUserWithRelationsPublicDto>(entity);
        }

        [UseFiltering(typeof(AppUserPublicFilterType))]
        [UseSorting(typeof(AppUserPublicSortType))]
        public async Task<IEnumerable<ResultAppUserWithRelationsPublicDto>> GetMutualFollowersAsync(
            [Service] IAppUserQueryService service,
            [Service] IAppUserResolver resolver,
            [Service] IFollowQueryService followQueryService,
            Guid targetUserId,
            IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var baseQuery = followQueryService.GetRawQueryable();
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var currentUserFollowings = baseQuery
                .Where(f => f.FollowerId == currentUserId)
                .Select(f => f.FollowingId);

            var targetFollowers = baseQuery
                .Where(f => f.FollowingId == targetUserId)
                .Select(f => f.FollowerId);

            var mutualUserIds = currentUserFollowings.Intersect(targetFollowers).ToList();

            if (mutualUserIds.Count == 0)
                return [];

            var projectedQuery = service.GetByIdsQueryable(mutualUserIds, context);
            var result = await _queryResolver.ResolveEntitiesAsync(projectedQuery, resolver, context);

            return result.Select(u => _mapper.Map<ResultAppUserWithRelationsPublicDto>(u));
        }


        private static Expression<Func<AppUser, bool>> CreateUserPublicAccessFilter(
            IHttpContextAccessor httpContextAccessor,
            IBlockedUserIdProvider blockedUserIdProvider)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            var blockedUserIds = blockedUserIdProvider.GetBlockedUserIdsAsync(currentUserId).GetAwaiter().GetResult();

            var notPublic = FilterExpressionHelper.BuildNotEqualsExpression<AppUser, Guid>(u => u.Id, currentUserId);
            var notBlocked = FilterExpressionHelper.BuildNotContainsExpression<AppUser, Guid>(u => u.Id, blockedUserIds);

            return notPublic.And(notBlocked);
        }
    }

}
