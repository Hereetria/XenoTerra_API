using AutoMapper;
using HotChocolate.Authorization;
using HotChocolate.Resolvers;
using System.Linq.Expressions;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.ViewStoryResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Queries.Paginations.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.ViewStoryQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class ViewStoryOwnQuery(IMapper mapper, IQueryResolverHelper<ViewStory, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<ViewStory, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(ViewStoryOwnFilterType))]
        [UseSorting(typeof(ViewStoryOwnSortType))]
        public async Task<ViewStoryOwnConnection> GetAllViewStoriesAsync(
            [Service] IViewStoryQueryService service,
            [Service] IViewStoryResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = await BuildAccessFilterAsync(httpContextAccessor, followedUserIdProvider, publicUserIdProvider);

            var query = service.GetAllQueryable(context, filter);
            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<ViewStory, ResultViewStoryWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<ViewStoryOwnConnection, ResultViewStoryWithRelationsOwnDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(ViewStoryOwnFilterType))]
        [UseSorting(typeof(ViewStoryOwnSortType))]
        public async Task<ViewStoryOwnConnection> GetViewStoriesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IViewStoryQueryService service,
            [Service] IViewStoryResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));
            var filter = await BuildAccessFilterAsync(httpContextAccessor, followedUserIdProvider, publicUserIdProvider);

            var query = service.GetByIdsQueryable(parsedKeys, context, filter);
            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<ViewStory, ResultViewStoryWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<ViewStoryOwnConnection, ResultViewStoryWithRelationsOwnDto>(connection);
        }

        public async Task<ResultViewStoryWithRelationsOwnDto?> GetViewStoryByIdAsync(
            string? key,
            [Service] IViewStoryQueryService service,
            [Service] IViewStoryResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var filter = await BuildAccessFilterAsync(httpContextAccessor, followedUserIdProvider, publicUserIdProvider);

            var query = service.GetByIdQueryable(parsedKey, context, filter);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultViewStoryWithRelationsOwnDto>(entity);
        }

        private static async Task<Expression<Func<ViewStory, bool>>> BuildAccessFilterAsync(
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

            return FilterExpressionHelper.BuildContainsExpression<ViewStory, Guid>(s => s.UserId, authorizedUserIds);
        }
    }
}
