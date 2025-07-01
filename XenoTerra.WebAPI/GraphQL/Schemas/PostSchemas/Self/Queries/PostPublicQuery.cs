using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.PostResolvers;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.PostQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Concrete;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Queries.Paginations.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Queries.Sorts;
using XenoTerra.DTOLayer.Dtos.PostDtos.Self.Own;

using XenoTerra.DTOLayer.Dtos.PostDtos.Self.Public;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Queries.Paginations.Public;
namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class PostPublicQuery(IMapper mapper, IQueryResolverHelper<Post, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Post, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(PostPublicFilterType))]
        [UseSorting(typeof(PostPublicSortType))]
        public async Task<PostPublicConnection> GetAllPostsAsync(
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

            var entityPublicConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Post, ResultPostWithRelationsPublicDto>(
                entityPublicConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<PostPublicConnection, ResultPostWithRelationsPublicDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(PostPublicFilterType))]
        [UseSorting(typeof(PostPublicSortType))]
        public async Task<PostPublicConnection> GetPostsByIdsAsync(
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

            var entityPublicConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Post, ResultPostWithRelationsPublicDto>(
                entityPublicConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<PostPublicConnection, ResultPostWithRelationsPublicDto>(connection);
        }

        public async Task<ResultPostWithRelationsPublicDto?> GetPostByIdAsync(
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

            return entity is null ? null : _mapper.Map<ResultPostWithRelationsPublicDto>(entity);
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
