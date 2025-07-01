using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.StoryResolvers;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.StoryQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Concrete;
using Microsoft.EntityFrameworkCore;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Queries.Paginations.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Queries.Sorts;
using XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Own;

using XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Public;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Queries.Paginations.Public;
namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class StoryPublicQuery(IMapper mapper, IQueryResolverHelper<Story, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Story, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(StoryPublicFilterType))]
        [UseSorting(typeof(StoryPublicSortType))]
        public async Task<StoryPublicConnection> GetAllStoriesAsync(
            [Service] IStoryQueryService service,
            [Service] IStoryResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = await BuildAccessFilterAsync(httpContextAccessor, followedUserIdProvider, publicUserIdProvider);

            var query = service.GetAllQueryable(context, filter);
            var entityPublicConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Story, ResultStoryWithRelationsPublicDto>(
                entityPublicConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<StoryPublicConnection, ResultStoryWithRelationsPublicDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(StoryPublicFilterType))]
        [UseSorting(typeof(StoryPublicSortType))]
        public async Task<StoryPublicConnection> GetStoriesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IStoryQueryService service,
            [Service] IStoryResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));
            var filter = await BuildAccessFilterAsync(httpContextAccessor, followedUserIdProvider, publicUserIdProvider);

            var query = service.GetByIdsQueryable(parsedKeys, context, filter);
            var entityPublicConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Story, ResultStoryWithRelationsPublicDto>(
                entityPublicConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<StoryPublicConnection, ResultStoryWithRelationsPublicDto>(connection);
        }

        public async Task<ResultStoryWithRelationsPublicDto?> GetStoryByIdAsync(
            string? key,
            [Service] IStoryQueryService service,
            [Service] IStoryResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var filter = await BuildAccessFilterAsync(httpContextAccessor, followedUserIdProvider, publicUserIdProvider);

            var query = service.GetByIdQueryable(parsedKey, context, filter);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultStoryWithRelationsPublicDto>(entity);
        }

        public async Task<IEnumerable<ResultStoryWithRelationsPublicDto>> GetLatestStoriesByFollowingsAsync(
            [Service] IStoryQueryService service,
            [Service] IStoryResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            var followedUserIds = await followedUserIdProvider.GetFollowedUserIdsAsync();

            // Sadece aktif takip edilen kullanýcýlar
            var validFollowedUserIds = followedUserIds.Distinct().ToList();

            var allFollowedStories = await service.GetRawQueryable()
                .AsNoTracking()
                .Where(s => validFollowedUserIds.Contains(s.UserId) && s.UserId != currentUserId)
                .Include(s => s.ViewStories)
                .ToListAsync();

            // Her kullanýcý için bir story: ya ilk görülmemiþ ya da sonuncusu
            var selectedStories = allFollowedStories
                .GroupBy(s => s.UserId)
                .Select(group =>
                {
                    var ordered = group.OrderBy(s => s.CreatedAt).ToList();

                    // currentUser'ýn görmediði ilk story
                    var firstUnseen = ordered.FirstOrDefault(s =>
                        !s.ViewStories.Any(v => v.UserId == currentUserId));

                    // Hepsi görüldüyse sonuncuyu getir
                    return firstUnseen ?? ordered.Last();
                })
                .ToList();

            // unseen story'ler önce
            var sortedStories = selectedStories
                .OrderBy(s => s.ViewStories.Any(v => v.UserId == currentUserId)) // false (unseen) önce
                .ThenByDescending(s => s.CreatedAt)
                .ToList();

            var storyIds = sortedStories.Select(s => s.StoryId).ToList();

            var query = service.GetCustomQueryable(
                context,
                baseQ => baseQ
                    .AsNoTracking()
                    .Where(s => storyIds.Contains(s.StoryId))
            );

            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);

            var entityMap = entities.ToDictionary(e => e.StoryId);
            var finalOrdered = storyIds
                .Select(id => entityMap.TryGetValue(id, out var entity) ? _mapper.Map<ResultStoryWithRelationsPublicDto>(entity) : null)
                .Where(dto => dto != null)
                .Cast<ResultStoryWithRelationsPublicDto>()
                .ToList();

            return finalOrdered;
        }


        private static async Task<Expression<Func<Story, bool>>> BuildAccessFilterAsync(
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

            return FilterExpressionHelper.BuildContainsExpression<Story, Guid>(s => s.UserId, authorizedUserIds);
        }
    }
}
