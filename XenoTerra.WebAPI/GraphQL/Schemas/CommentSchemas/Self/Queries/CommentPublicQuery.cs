using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.CommentResolvers;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.CommentQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Concrete;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Queries.Paginations.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Queries.Sorts;
using XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Public;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Queries.Paginations.Public;
namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class CommentPublicQuery(IMapper mapper, IQueryResolverHelper<Comment, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Comment, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(CommentPublicFilterType))]
        [UseSorting(typeof(CommentPublicSortType))]
        public async Task<CommentPublicConnection> GetAllCommentsAsync(
            [Service] ICommentQueryService service,
            [Service] ICommentResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IBlockedUserIdProvider blockedUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = await BuildAccessFilterAsync(httpContextAccessor, followedUserIdProvider, publicUserIdProvider, blockedUserIdProvider);

            var query = service.GetAllQueryable(context, filter);
            var entityPublicConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Comment, ResultCommentWithRelationsPublicDto>(
                entityPublicConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<CommentPublicConnection, ResultCommentWithRelationsPublicDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(CommentPublicFilterType))]
        [UseSorting(typeof(CommentPublicSortType))]
        public async Task<CommentPublicConnection> GetCommentsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] ICommentQueryService service,
            [Service] ICommentResolver resolver,
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

            var connection = ConnectionMapper.MapConnection<Comment, ResultCommentWithRelationsPublicDto>(
                entityPublicConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<CommentPublicConnection, ResultCommentWithRelationsPublicDto>(connection);
        }

        public async Task<ResultCommentWithRelationsPublicDto?> GetCommentByIdAsync(
            string? key,
            [Service] ICommentQueryService service,
            [Service] ICommentResolver resolver,
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

            return entity is null ? null : _mapper.Map<ResultCommentWithRelationsPublicDto>(entity);
        }

        private static async Task<Expression<Func<Comment, bool>>> BuildAccessFilterAsync(
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

            return FilterExpressionHelper.BuildContainsAndNotContainsExpression<Comment, Guid>(
                c => c.Post.UserId,
                authorizedUserIds,
                blockedUserIds
            );
        }


    }
}
