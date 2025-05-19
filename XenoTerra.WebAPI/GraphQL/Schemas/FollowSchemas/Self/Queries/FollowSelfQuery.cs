using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.FollowResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.FollowQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Concrete;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
    public class FollowSelfQuery(IMapper mapper, IQueryResolverHelper<Follow, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Follow, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(FollowSelfFilterType))]
        [UseSorting(typeof(FollowSelfSortType))]
        public async Task<FollowSelfConnection> GetAllFollowsAsync(
            [Service] IFollowQueryService service,
            [Service] IFollowResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            var followedUserIds = (await followedUserIdProvider.GetFollowedUserIdsAsync()).ToList();
            var publicUserIds = (await publicUserIdProvider.GetPublicUserIdsAsync()).ToList();

            var filter = CreateFollowAccessFilter(currentUserId, followedUserIds, publicUserIds);

            var query = service.GetAllQueryable(context).Where(filter);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Follow, ResultFollowWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<FollowSelfConnection, ResultFollowWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(FollowSelfFilterType))]
        [UseSorting(typeof(FollowSelfSortType))]
        public async Task<FollowSelfConnection> GetFollowsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IFollowQueryService service,
            [Service] IFollowResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            var followedUserIds = (await followedUserIdProvider.GetFollowedUserIdsAsync()).ToList();
            var publicUserIds = (await publicUserIdProvider.GetPublicUserIdsAsync()).ToList();

            var filter = CreateFollowAccessFilter(currentUserId, followedUserIds, publicUserIds);

            var query = service.GetByIdsQueryable(parsedKeys, context).Where(filter);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Follow, ResultFollowWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<FollowSelfConnection, ResultFollowWithRelationsDto>(connection);
        }

        public async Task<ResultFollowWithRelationsDto?> GetFollowByIdAsync(
            string? key,
            [Service] IFollowQueryService service,
            [Service] IFollowResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            var followedUserIds = (await followedUserIdProvider.GetFollowedUserIdsAsync()).ToList();
            var publicUserIds = (await publicUserIdProvider.GetPublicUserIdsAsync()).ToList();

            var filter = CreateFollowAccessFilter(currentUserId, followedUserIds, publicUserIds);

            var query = service.GetByIdQueryable(parsedKey, context).Where(filter);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultFollowWithRelationsDto>(entity);
        }

        private static Expression<Func<Follow, bool>> CreateFollowAccessFilter(
            Guid currentUserId,
            IReadOnlyCollection<Guid> followedUserIds,
            IReadOnlyCollection<Guid> publicUserIds)
        {
            var authorizedUserIds = followedUserIds
                .Concat(publicUserIds)
                .Append(currentUserId)
                .Distinct()
                .ToList();

            return follow =>
                authorizedUserIds.Contains(follow.FollowerId) ||
                authorizedUserIds.Contains(follow.FollowingId);
        }
    }
}
