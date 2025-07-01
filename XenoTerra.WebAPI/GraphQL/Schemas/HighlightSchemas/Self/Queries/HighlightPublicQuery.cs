using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.HighlightResolvers;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.HighlightQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Concrete;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Queries.Paginations.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Queries.Sorts;
using XenoTerra.DTOLayer.Dtos.HighlightDtos.Self.Own;

using XenoTerra.DTOLayer.Dtos.HighlightDtos.Self.Public;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Queries.Paginations.Public;
namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class HighlightPublicQuery(IMapper mapper, IQueryResolverHelper<Highlight, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Highlight, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(HighlightPublicFilterType))]
        [UseSorting(typeof(HighlightPublicSortType))]
        public async Task<HighlightPublicConnection> GetAllHighlightsAsync(
            [Service] IHighlightQueryService service,
            [Service] IHighlightResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = await BuildAccessFilterAsync(httpContextAccessor, followedUserIdProvider, publicUserIdProvider);

            var query = service.GetAllQueryable(context, filter);
            var entityPublicConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Highlight, ResultHighlightWithRelationsPublicDto>(
                entityPublicConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<HighlightPublicConnection, ResultHighlightWithRelationsPublicDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(HighlightPublicFilterType))]
        [UseSorting(typeof(HighlightPublicSortType))]
        public async Task<HighlightPublicConnection> GetHighlightsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IHighlightQueryService service,
            [Service] IHighlightResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var filter = await BuildAccessFilterAsync(httpContextAccessor, followedUserIdProvider, publicUserIdProvider);

            var query = service.GetByIdsQueryable(parsedKeys, context, filter);
            var entityPublicConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Highlight, ResultHighlightWithRelationsPublicDto>(
                entityPublicConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<HighlightPublicConnection, ResultHighlightWithRelationsPublicDto>(connection);
        }

        public async Task<ResultHighlightWithRelationsPublicDto?> GetHighlightByIdAsync(
            string? key,
            [Service] IHighlightQueryService service,
            [Service] IHighlightResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var filter = await BuildAccessFilterAsync(httpContextAccessor, followedUserIdProvider, publicUserIdProvider);

            var query = service.GetByIdQueryable(parsedKey, context, filter);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultHighlightWithRelationsPublicDto>(entity);
        }

        private static async Task<Expression<Func<Highlight, bool>>> BuildAccessFilterAsync(
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

            return FilterExpressionHelper.BuildContainsExpression<Highlight, Guid>(
                h => h.UserId,
                authorizedUserIds
            );
        }
    }
}
