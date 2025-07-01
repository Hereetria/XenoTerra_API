using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.FollowResolvers;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.FollowQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Concrete;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Queries.Paginations.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Queries.Sorts;
using XenoTerra.DTOLayer.Dtos.FollowDtos.Self.Own;

using XenoTerra.DTOLayer.Dtos.FollowDtos.Self.Public;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Queries.Paginations.Public;
namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class FollowPublicQuery(IMapper mapper, IQueryResolverHelper<Follow, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Follow, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(FollowPublicFilterType))]
        [UseSorting(typeof(FollowPublicSortType))]
        public async Task<FollowPublicConnection> GetAllFollowsAsync(
            [Service] IFollowQueryService service,
            [Service] IFollowResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = await BuildAccessFilterAsync(httpContextAccessor, followedUserIdProvider, publicUserIdProvider);

            var query = service.GetAllQueryable(context, filter);
            var entityPublicConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Follow, ResultFollowWithRelationsPublicDto>(
                entityPublicConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<FollowPublicConnection, ResultFollowWithRelationsPublicDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(FollowPublicFilterType))]
        [UseSorting(typeof(FollowPublicSortType))]
        public async Task<FollowPublicConnection> GetFollowsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IFollowQueryService service,
            [Service] IFollowResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var filter = await BuildAccessFilterAsync(httpContextAccessor, followedUserIdProvider, publicUserIdProvider);

            var query = service.GetByIdsQueryable(parsedKeys, context, filter);
            var entityPublicConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Follow, ResultFollowWithRelationsPublicDto>(
                entityPublicConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<FollowPublicConnection, ResultFollowWithRelationsPublicDto>(connection);
        }

        public async Task<ResultFollowWithRelationsPublicDto?> GetFollowByIdAsync(
            string? key,
            [Service] IFollowQueryService service,
            [Service] IFollowResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var filter = await BuildAccessFilterAsync(httpContextAccessor, followedUserIdProvider, publicUserIdProvider);

            var query = service.GetByIdQueryable(parsedKey, context, filter);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultFollowWithRelationsPublicDto>(entity);
        }

        private static async Task<Expression<Func<Follow, bool>>> BuildAccessFilterAsync(
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

            return FilterExpressionHelper.BuildMultiContainsOrExpression<Follow, Guid>(
                [nameof(Follow.FollowerId), nameof(Follow.FollowingId)],
                authorizedUserIds);
        }
    }
}
