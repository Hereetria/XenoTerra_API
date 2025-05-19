using AutoMapper;
using HotChocolate.Authorization;
using HotChocolate.Resolvers;
using System.Linq.Expressions;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.UserResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Self.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.UserQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
    public class UserPublicSelfQuery(IMapper mapper, IQueryResolverHelper<User, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<User, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(UserPublicSelfFilterType))]
        [UseSorting(typeof(UserPublicSelfSortType))]
        public async Task<UserPublicSelfConnection> GetAllUsersAsync(
            [Service] IUserQueryService service,
            [Service] IUserResolver resolver,
            [Service] IBlockedUserIdProvider blockedUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            var blockedUserIds = (await blockedUserIdProvider.GetBlockedUserIdsAsync(currentUserId)).ToList();

            var filter = CreateUserPublicAccessFilter(currentUserId, blockedUserIds);

            var query = service.GetAllQueryable(context).Where(filter);

            var entityPublicConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<User, ResultUserWithRelationsPublicDto>(
                entityPublicConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<UserPublicSelfConnection, ResultUserWithRelationsPublicDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(UserPublicSelfFilterType))]
        [UseSorting(typeof(UserPublicSelfSortType))]
        public async Task<UserPublicSelfConnection> GetUsersByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IUserQueryService service,
            [Service] IUserResolver resolver,
            [Service] IBlockedUserIdProvider blockedUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            var blockedUserIds = (await blockedUserIdProvider.GetBlockedUserIdsAsync(currentUserId)).ToList();

            var filter = CreateUserPublicAccessFilter(currentUserId, blockedUserIds);

            var query = service.GetByIdsQueryable(parsedKeys, context).Where(filter);

            var entityPublicConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<User, ResultUserWithRelationsPublicDto>(
                entityPublicConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<UserPublicSelfConnection, ResultUserWithRelationsPublicDto>(connection);
        }

        public async Task<ResultUserWithRelationsPublicDto?> GetUserByIdAsync(
            string? key,
            [Service] IUserQueryService service,
            [Service] IUserResolver resolver,
            [Service] IBlockedUserIdProvider blockedUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            var blockedUserIds = (await blockedUserIdProvider.GetBlockedUserIdsAsync(currentUserId)).ToList();

            var filter = CreateUserPublicAccessFilter(currentUserId, blockedUserIds);

            var query = service.GetByIdQueryable(parsedKey, context).Where(filter);

            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultUserWithRelationsPublicDto>(entity);
        }

        private static Expression<Func<User, bool>> CreateUserPublicAccessFilter(
            Guid currentUserId,
            IReadOnlyCollection<Guid> blockedUserIds) =>
                user =>
                    user.Id != currentUserId &&
                    !blockedUserIds.Contains(user.Id);
    }
}
