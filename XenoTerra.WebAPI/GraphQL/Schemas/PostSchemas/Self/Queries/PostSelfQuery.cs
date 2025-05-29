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
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
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
            var filter = await CreatePostAccessFilterAsync(httpContextAccessor, followedUserIdProvider, publicUserIdProvider, blockedUserIdProvider);
            var query = service.GetAllQueryable(context, filter);

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
            var filter = await CreatePostAccessFilterAsync(httpContextAccessor, followedUserIdProvider, publicUserIdProvider, blockedUserIdProvider);
            var query = service.GetByIdsQueryable(parsedKeys, context, filter);

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
            var filter = await CreatePostAccessFilterAsync(httpContextAccessor, followedUserIdProvider, publicUserIdProvider, blockedUserIdProvider);
            var query = service.GetByIdQueryable(parsedKey, context, filter);

            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultPostWithRelationsDto>(entity);
        }

        private static async Task<Expression<Func<Post, bool>>> CreatePostAccessFilterAsync(
            IHttpContextAccessor httpContextAccessor,
            IFollowedUserIdProvider followedUserIdProvider,
            IPublicUserIdProvider publicUserIdProvider,
            IBlockedUserIdProvider blockedUserIdProvider)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            var followedUserIds = await followedUserIdProvider.GetFollowedUserIdsAsync();
            var publicUserIds = await publicUserIdProvider.GetPublicUserIdsAsync();
            var blockedUserIds = await blockedUserIdProvider.GetBlockedUserIdsAsync(currentUserId);

            var authorizedUserIds = followedUserIds
                .Concat(publicUserIds)
                .Append(currentUserId)
                .Distinct()
                .ToList();

            return FilterExpressionHelper.BuildContainsAndNotContainsExpression<Post, Guid>(
                p => p.UserId,
                authorizedUserIds,
                blockedUserIds
            );
        }
    }
}
