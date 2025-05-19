using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.PostResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.PostQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Concrete;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
    public class PostSelfQuery(IMapper mapper, IQueryResolverHelper<Post, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Post, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(PostSelfFilterType))]
        [UseSorting(typeof(PostSelfSortType))]
        public async Task<PostSelfConnection> GetAllPostsAsync(
            [Service] IPostQueryService service,
            [Service] IPostResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IBlockedUserIdProvider blockedUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            var followedUserIds = (await followedUserIdProvider.GetFollowedUserIdsAsync()).ToList();
            var publicUserIds = (await publicUserIdProvider.GetPublicUserIdsAsync()).ToList();
            var blockedUserIds = (await blockedUserIdProvider.GetBlockedUserIdsAsync(currentUserId)).ToList();

            var filter = CreatePostAccessFilter(currentUserId, followedUserIds, publicUserIds, blockedUserIds);

            var query = service.GetAllQueryable(context).Where(filter);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Post, ResultPostWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<PostSelfConnection, ResultPostWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(PostSelfFilterType))]
        [UseSorting(typeof(PostSelfSortType))]
        public async Task<PostSelfConnection> GetPostsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IPostQueryService service,
            [Service] IPostResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IBlockedUserIdProvider blockedUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            var followedUserIds = (await followedUserIdProvider.GetFollowedUserIdsAsync()).ToList();
            var publicUserIds = (await publicUserIdProvider.GetPublicUserIdsAsync()).ToList();
            var blockedUserIds = (await blockedUserIdProvider.GetBlockedUserIdsAsync(currentUserId)).ToList();

            var filter = CreatePostAccessFilter(currentUserId, followedUserIds, publicUserIds, blockedUserIds);

            var query = service.GetByIdsQueryable(parsedKeys, context).Where(filter);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Post, ResultPostWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<PostSelfConnection, ResultPostWithRelationsDto>(connection);
        }

        public async Task<ResultPostWithRelationsDto?> GetPostByIdAsync(
            string? key,
            [Service] IPostQueryService service,
            [Service] IPostResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IBlockedUserIdProvider blockedUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            var followedUserIds = (await followedUserIdProvider.GetFollowedUserIdsAsync()).ToList();
            var publicUserIds = (await publicUserIdProvider.GetPublicUserIdsAsync()).ToList();
            var blockedUserIds = (await blockedUserIdProvider.GetBlockedUserIdsAsync(currentUserId)).ToList();

            var filter = CreatePostAccessFilter(currentUserId, followedUserIds, publicUserIds, blockedUserIds);

            var query = service.GetByIdQueryable(parsedKey, context).Where(filter);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultPostWithRelationsDto>(entity);
        }

        private static Expression<Func<Post, bool>> CreatePostAccessFilter(
            Guid currentUserId,
            IReadOnlyCollection<Guid> followedUserIds,
            IReadOnlyCollection<Guid> publicUserIds,
            IReadOnlyCollection<Guid> blockedUserIds)
        {
            var authorizedUserIds = followedUserIds
                .Concat(publicUserIds)
                .Append(currentUserId)
                .Distinct()
                .ToList();

            return post =>
                authorizedUserIds.Contains(post.UserId) &&
                !blockedUserIds.Contains(post.UserId);
        }
    }
}
