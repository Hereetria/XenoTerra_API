using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.HighlightResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.HighlightQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Concrete;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
    public class HighlightSelfQuery(IMapper mapper, IQueryResolverHelper<Highlight, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Highlight, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(HighlightSelfFilterType))]
        [UseSorting(typeof(HighlightSelfSortType))]
        public async Task<HighlightSelfConnection> GetAllHighlightsAsync(
            [Service] IHighlightQueryService service,
            [Service] IHighlightResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            var followedUserIds = (await followedUserIdProvider.GetFollowedUserIdsAsync()).ToList();
            var publicUserIds = (await publicUserIdProvider.GetPublicUserIdsAsync()).ToList();

            var filter = CreateHighlightAccessFilter(currentUserId, followedUserIds, publicUserIds);

            var query = service.GetAllQueryable(context).Where(filter);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Highlight, ResultHighlightWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<HighlightSelfConnection, ResultHighlightWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(HighlightSelfFilterType))]
        [UseSorting(typeof(HighlightSelfSortType))]
        public async Task<HighlightSelfConnection> GetHighlightsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IHighlightQueryService service,
            [Service] IHighlightResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            var followedUserIds = (await followedUserIdProvider.GetFollowedUserIdsAsync()).ToList();
            var publicUserIds = (await publicUserIdProvider.GetPublicUserIdsAsync()).ToList();

            var filter = CreateHighlightAccessFilter(currentUserId, followedUserIds, publicUserIds);

            var query = service.GetByIdsQueryable(parsedKeys, context).Where(filter);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Highlight, ResultHighlightWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<HighlightSelfConnection, ResultHighlightWithRelationsDto>(connection);
        }

        public async Task<ResultHighlightWithRelationsDto?> GetHighlightByIdAsync(
            string? key,
            [Service] IHighlightQueryService service,
            [Service] IHighlightResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            var followedUserIds = (await followedUserIdProvider.GetFollowedUserIdsAsync()).ToList();
            var publicUserIds = (await publicUserIdProvider.GetPublicUserIdsAsync()).ToList();

            var filter = CreateHighlightAccessFilter(currentUserId, followedUserIds, publicUserIds);

            var query = service.GetByIdQueryable(parsedKey, context).Where(filter);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultHighlightWithRelationsDto>(entity);
        }

        private static Expression<Func<Highlight, bool>> CreateHighlightAccessFilter(
            Guid currentUserId,
            IReadOnlyCollection<Guid> followedUserIds,
            IReadOnlyCollection<Guid> publicUserIds)
        {
            var authorizedUserIds = followedUserIds
                .Concat(publicUserIds)
                .Append(currentUserId)
                .Distinct()
                .ToList();

            return highlight => authorizedUserIds.Contains(highlight.UserId);
        }
    }
}
