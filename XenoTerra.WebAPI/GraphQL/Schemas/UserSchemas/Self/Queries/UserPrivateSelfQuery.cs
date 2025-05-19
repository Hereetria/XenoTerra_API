using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.UserResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Self.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.UserQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
    public class UserPrivateSelfQuery(IMapper mapper, IQueryResolverHelper<User, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<User, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(UserPrivateSelfFilterType))]
        [UseSorting(typeof(UserPrivateSelfSortType))]
        public async Task<UserPrivateSelfConnection> GetAllUsersAsync(
            [Service] IUserQueryService service,
            [Service] IUserResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var filter = CreateUserPrivateAccessFilter(currentUserId);

            var query = service.GetAllQueryable(context).Where(filter);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<User, ResultUserWithRelationsPrivateDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<UserPrivateSelfConnection, ResultUserWithRelationsPrivateDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(UserPrivateSelfFilterType))]
        [UseSorting(typeof(UserPrivateSelfSortType))]
        public async Task<UserPrivateSelfConnection> GetUsersByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IUserQueryService service,
            [Service] IUserResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var filter = CreateUserPrivateAccessFilter(currentUserId);

            var query = service.GetByIdsQueryable(parsedKeys, context).Where(filter);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<User, ResultUserWithRelationsPrivateDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<UserPrivateSelfConnection, ResultUserWithRelationsPrivateDto>(connection);
        }

        public async Task<ResultUserWithRelationsPrivateDto?> GetUserByIdAsync(
            string? key,
            [Service] IUserQueryService service,
            [Service] IUserResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var filter = CreateUserPrivateAccessFilter(currentUserId);

            var query = service.GetByIdQueryable(parsedKey, context).Where(filter);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultUserWithRelationsPrivateDto>(entity);
        }

        private static Expression<Func<User, bool>> CreateUserPrivateAccessFilter(Guid currentUserId) =>
            history => history.Id == currentUserId;
    }
}
