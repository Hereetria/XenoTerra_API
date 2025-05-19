using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.StoryResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.StoryQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Concrete;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
    public class StorySelfQuery(IMapper mapper, IQueryResolverHelper<Story, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Story, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(StorySelfFilterType))]
        [UseSorting(typeof(StorySelfSortType))]
        public async Task<StorySelfConnection> GetAllStoriesAsync(
            [Service] IStoryQueryService service,
            [Service] IStoryResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            var followedUserIds = (await followedUserIdProvider.GetFollowedUserIdsAsync()).ToList();
            var publicUserIds = (await publicUserIdProvider.GetPublicUserIdsAsync()).ToList();

            var filter = CreateStoryAccessFilter(currentUserId, followedUserIds, publicUserIds);

            var query = service.GetAllQueryable(context).Where(filter);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Story, ResultStoryWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<StorySelfConnection, ResultStoryWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(StorySelfFilterType))]
        [UseSorting(typeof(StorySelfSortType))]
        public async Task<StorySelfConnection> GetStoriesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IStoryQueryService service,
            [Service] IStoryResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            var followedUserIds = (await followedUserIdProvider.GetFollowedUserIdsAsync()).ToList();
            var publicUserIds = (await publicUserIdProvider.GetPublicUserIdsAsync()).ToList();

            var filter = CreateStoryAccessFilter(currentUserId, followedUserIds, publicUserIds);

            var query = service.GetByIdsQueryable(parsedKeys, context).Where(filter);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Story, ResultStoryWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<StorySelfConnection, ResultStoryWithRelationsDto>(connection);
        }

        public async Task<ResultStoryWithRelationsDto?> GetStoryByIdAsync(
            string? key,
            [Service] IStoryQueryService service,
            [Service] IStoryResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            var followedUserIds = (await followedUserIdProvider.GetFollowedUserIdsAsync()).ToList();
            var publicUserIds = (await publicUserIdProvider.GetPublicUserIdsAsync()).ToList();

            var filter = CreateStoryAccessFilter(currentUserId, followedUserIds, publicUserIds);

            var query = service.GetByIdQueryable(parsedKey, context).Where(filter);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultStoryWithRelationsDto>(entity);
        }

        private static Expression<Func<Story, bool>> CreateStoryAccessFilter(
            Guid currentUserId,
            IReadOnlyCollection<Guid> followedUserIds,
            IReadOnlyCollection<Guid> publicUserIds)
        {
            var authorizedUserIds = followedUserIds
                .Concat(publicUserIds)
                .Append(currentUserId)
                .Distinct()
                .ToList();

            return story => authorizedUserIds.Contains(story.UserId);
        }
    }
}
