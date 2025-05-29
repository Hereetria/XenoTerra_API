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
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class UserPublicSelfQuery(IMapper mapper, IQueryResolverHelper<User, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<User, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(UserSelfFilterType))]
        [UseSorting(typeof(UserSelfSortType))]
        public async Task<UserPublicSelfConnection> GetAllUsersAsync(
            [Service] IUserQueryService service,
            [Service] IUserResolver resolver,
            [Service] IBlockedUserIdProvider blockedUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = CreateUserPublicAccessFilter(httpContextAccessor, blockedUserIdProvider);
            var query = service.GetAllQueryable(context, filter);

            var entityPublicConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<User, ResultUserWithRelationsPublicDto>(
                entityPublicConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<UserPublicSelfConnection, ResultUserWithRelationsPublicDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(UserSelfFilterType))]
        [UseSorting(typeof(UserSelfSortType))]
        public async Task<UserPublicSelfConnection> GetUsersByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IUserQueryService service,
            [Service] IUserResolver resolver,
            [Service] IBlockedUserIdProvider blockedUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));
            var filter = CreateUserPublicAccessFilter(httpContextAccessor, blockedUserIdProvider);
            var query = service.GetByIdsQueryable(parsedKeys, context, filter);

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
            var filter = CreateUserPublicAccessFilter(httpContextAccessor, blockedUserIdProvider);
            var query = service.GetByIdQueryable(parsedKey, context, filter);

            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultUserWithRelationsPublicDto>(entity);
        }

        private static Expression<Func<User, bool>> CreateUserPublicAccessFilter(
            IHttpContextAccessor httpContextAccessor,
            IBlockedUserIdProvider blockedUserIdProvider)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            var blockedUserIds = blockedUserIdProvider.GetBlockedUserIdsAsync(currentUserId).GetAwaiter().GetResult();

            var notSelf = FilterExpressionHelper.BuildNotEqualsExpression<User, Guid>(u => u.Id, currentUserId);
            var notBlocked = FilterExpressionHelper.BuildNotContainsExpression<User, Guid>(u => u.Id, blockedUserIds);

            return notSelf.And(notBlocked);
        }
    }
}
