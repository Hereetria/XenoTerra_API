using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.UserPostTagResolvers;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.UserPostTagQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Concrete;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Queries.Paginations.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Queries.Sorts;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Self.Public;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Queries.Paginations.Public;
namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class UserPostTagPublicQuery(IMapper mapper, IQueryResolverHelper<UserPostTag, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<UserPostTag, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(UserPostTagPublicFilterType))]
        [UseSorting(typeof(UserPostTagPublicSortType))]
        public async Task<UserPostTagPublicConnection> GetAllUserPostTagsAsync(
            [Service] IUserPostTagQueryService service,
            [Service] IUserPostTagResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IBlockedUserIdProvider blockedUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = await BuildAccessFilterAsync(httpContextAccessor, followedUserIdProvider, publicUserIdProvider, blockedUserIdProvider);

            var query = service.GetAllQueryable(context, filter);
            var entityPublicConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<UserPostTag, ResultUserPostTagWithRelationsPublicDto>(
                entityPublicConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<UserPostTagPublicConnection, ResultUserPostTagWithRelationsPublicDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(UserPostTagPublicFilterType))]
        [UseSorting(typeof(UserPostTagPublicSortType))]
        public async Task<UserPostTagPublicConnection> GetUserPostTagsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IUserPostTagQueryService service,
            [Service] IUserPostTagResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IBlockedUserIdProvider blockedUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var filter = await BuildAccessFilterAsync(httpContextAccessor, followedUserIdProvider, publicUserIdProvider, blockedUserIdProvider);

            var query = service.GetByIdsQueryable(parsedKeys, context, filter);
            var entityPublicConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<UserPostTag, ResultUserPostTagWithRelationsPublicDto>(
                entityPublicConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<UserPostTagPublicConnection, ResultUserPostTagWithRelationsPublicDto>(connection);
        }

        public async Task<ResultUserPostTagWithRelationsPublicDto?> GetUserPostTagByIdAsync(
            string? key,
            [Service] IUserPostTagQueryService service,
            [Service] IUserPostTagResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IBlockedUserIdProvider blockedUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var filter = await BuildAccessFilterAsync(httpContextAccessor, followedUserIdProvider, publicUserIdProvider, blockedUserIdProvider);

            var query = service.GetByIdQueryable(parsedKey, context, filter);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultUserPostTagWithRelationsPublicDto>(entity);
        }

        private static async Task<Expression<Func<UserPostTag, bool>>> BuildAccessFilterAsync(
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

            return FilterExpressionHelper.BuildContainsAndNotContainsExpression<UserPostTag, Guid>(
                c => c.Post.UserId,
                authorizedUserIds,
                blockedUserIds
            );
        }
    }
}
