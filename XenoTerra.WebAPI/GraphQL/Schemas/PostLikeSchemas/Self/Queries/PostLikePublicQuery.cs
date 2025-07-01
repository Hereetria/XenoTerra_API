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
using XenoTerra.WebAPI.Services.Queries.Entity.PostLikeQueryServices;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.PostLikeResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Queries.Paginations.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Queries.Sorts;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Self.Own;

using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Self.Public;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Queries.Paginations.Public;
namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class PostLikePublicQuery(IMapper mapper, IQueryResolverHelper<PostLike, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<PostLike, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(PostLikePublicFilterType))]
        [UseSorting(typeof(PostLikePublicSortType))]
        public async Task<PostLikePublicConnection> GetAllPostLikesAsync(
            [Service] IPostLikeQueryService service,
            [Service] IPostLikeResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = await BuildAccessFilterAsync(httpContextAccessor, followedUserIdProvider, publicUserIdProvider);

            var query = service.GetAllQueryable(context, filter);
            var entityPublicConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<PostLike, ResultPostLikeWithRelationsPublicDto>(
                entityPublicConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<PostLikePublicConnection, ResultPostLikeWithRelationsPublicDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(PostLikePublicFilterType))]
        [UseSorting(typeof(PostLikePublicSortType))]
        public async Task<PostLikePublicConnection> GetPostLikesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IPostLikeQueryService service,
            [Service] IPostLikeResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var filter = await BuildAccessFilterAsync(httpContextAccessor, followedUserIdProvider, publicUserIdProvider);

            var query = service.GetByIdsQueryable(parsedKeys, context, filter);
            var entityPublicConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<PostLike, ResultPostLikeWithRelationsPublicDto>(
                entityPublicConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<PostLikePublicConnection, ResultPostLikeWithRelationsPublicDto>(connection);
        }

        public async Task<ResultPostLikeWithRelationsPublicDto?> GetPostLikeByIdAsync(
            string? key,
            [Service] IPostLikeQueryService service,
            [Service] IPostLikeResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var filter = await BuildAccessFilterAsync(httpContextAccessor, followedUserIdProvider, publicUserIdProvider);

            var query = service.GetByIdQueryable(parsedKey, context, filter);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultPostLikeWithRelationsPublicDto>(entity);
        }

        private static async Task<Expression<Func<PostLike, bool>>> BuildAccessFilterAsync(
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

            return FilterExpressionHelper.BuildNestedContainsExpression<PostLike, Guid>(
                [
                    like => like.Post.UserId
                ],
                authorizedUserIds);
        }
    }
}
