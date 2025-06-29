using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Concrete;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Queries.Paginations.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.Services.Queries.Entity.CommentLikeQueryServices;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.CommentLikeResolvers;
using XenoTerra.DTOLayer.Dtos.CommentLikeAdminDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Own.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class CommentLikeOwnQuery(IMapper mapper, IQueryResolverHelper<CommentLike, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<CommentLike, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(CommentLikeFilterType))]
        [UseSorting(typeof(CommentLikeSortType))]
        public async Task<CommentLikeOwnConnection> GetAllLikesAsync(
            [Service] ICommentLikeQueryService service,
            [Service] ICommentLikeResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = await BuildAccessFilterAsync(httpContextAccessor, followedUserIdProvider, publicUserIdProvider);

            var query = service.GetAllQueryable(context, filter);
            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<CommentLike, ResultCommentLikeWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<CommentLikeOwnConnection, ResultCommentLikeWithRelationsOwnDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(CommentLikeFilterType))]
        [UseSorting(typeof(CommentLikeSortType))]
        public async Task<CommentLikeOwnConnection> GetLikesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] ICommentLikeQueryService service,
            [Service] ICommentLikeResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var filter = await BuildAccessFilterAsync(httpContextAccessor, followedUserIdProvider, publicUserIdProvider);

            var query = service.GetByIdsQueryable(parsedKeys, context, filter);
            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<CommentLike, ResultCommentLikeWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<CommentLikeOwnConnection, ResultCommentLikeWithRelationsOwnDto>(connection);
        }

        public async Task<ResultCommentLikeWithRelationsOwnDto?> GetLikeByIdAsync(
            string? key,
            [Service] ICommentLikeQueryService service,
            [Service] ICommentLikeResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var filter = await BuildAccessFilterAsync(httpContextAccessor, followedUserIdProvider, publicUserIdProvider);

            var query = service.GetByIdQueryable(parsedKey, context, filter);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultCommentLikeWithRelationsOwnDto>(entity);
        }

        private static async Task<Expression<Func<CommentLike, bool>>> BuildAccessFilterAsync(
            IHttpContextAccessor httpContextAccessor,
            IFollowedUserIdProvider followedUserIdProvider,
            IPublicUserIdProvider publicUserIdProvider)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            var followedUserIds = await followedUserIdProvider.GetFollowedUserIdsAsync();
            var publicUserIds = await publicUserIdProvider.GetPublicUserIdsAsync();

            var authorizedUserIds = followedUserIds
                .Concat(publicUserIds)
                .Append(currentUserId)
                .Distinct()
                .ToList();

            return FilterExpressionHelper.BuildNestedContainsExpression<CommentLike, Guid>(
                [
                    like => like.Comment.UserId
                ],
                authorizedUserIds);
        }
    }
}
