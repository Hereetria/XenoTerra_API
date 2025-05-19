using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.LikeResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Self.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.LikeQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Concrete;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
    public class LikeSelfQuery(IMapper mapper, IQueryResolverHelper<Like, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Like, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(LikeSelfFilterType))]
        [UseSorting(typeof(LikeSelfSortType))]
        public async Task<LikeSelfConnection> GetAllLikesAsync(
            [Service] ILikeQueryService service,
            [Service] ILikeResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            var followedUserIds = (await followedUserIdProvider.GetFollowedUserIdsAsync()).ToList();
            var publicUserIds = (await publicUserIdProvider.GetPublicUserIdsAsync()).ToList();

            var filter = CreateLikeAccessFilter(currentUserId, followedUserIds, publicUserIds);

            var query = service.GetAllQueryable(context).Where(filter);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Like, ResultLikeWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<LikeSelfConnection, ResultLikeWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(LikeSelfFilterType))]
        [UseSorting(typeof(LikeSelfSortType))]
        public async Task<LikeSelfConnection> GetLikesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] ILikeQueryService service,
            [Service] ILikeResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            var followedUserIds = (await followedUserIdProvider.GetFollowedUserIdsAsync()).ToList();
            var publicUserIds = (await publicUserIdProvider.GetPublicUserIdsAsync()).ToList();

            var filter = CreateLikeAccessFilter(currentUserId, followedUserIds, publicUserIds);

            var query = service.GetByIdsQueryable(parsedKeys, context).Where(filter);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Like, ResultLikeWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<LikeSelfConnection, ResultLikeWithRelationsDto>(connection);
        }

        public async Task<ResultLikeWithRelationsDto?> GetLikeByIdAsync(
            string? key,
            [Service] ILikeQueryService service,
            [Service] ILikeResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IPublicUserIdProvider publicUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            var followedUserIds = (await followedUserIdProvider.GetFollowedUserIdsAsync()).ToList();
            var publicUserIds = (await publicUserIdProvider.GetPublicUserIdsAsync()).ToList();

            var filter = CreateLikeAccessFilter(currentUserId, followedUserIds, publicUserIds);

            var query = service.GetByIdQueryable(parsedKey, context).Where(filter);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultLikeWithRelationsDto>(entity);
        }

        private static Expression<Func<Like, bool>> CreateLikeAccessFilter(
            Guid currentUserId,
            IReadOnlyCollection<Guid> followedUserIds,
            IReadOnlyCollection<Guid> publicUserIds)
        {
            var authorizedUserIds = followedUserIds
                .Concat(publicUserIds)
                .Append(currentUserId)
                .Distinct()
                .ToList();

            return like => authorizedUserIds.Contains(like.Post.UserId);
        }
    }
}
