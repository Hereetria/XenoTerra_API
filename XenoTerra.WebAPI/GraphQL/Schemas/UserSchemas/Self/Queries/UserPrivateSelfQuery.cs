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
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class UserPrivateSelfQuery(IMapper mapper, IQueryResolverHelper<User, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<User, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(UserSelfFilterType))]
        [UseSorting(typeof(UserSelfSortType))]
        public async Task<UserPrivateSelfConnection> GetAllUsersAsync(
            [Service] IUserQueryService service,
            [Service] IUserResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = CreateUserPrivateAccessFilter(httpContextAccessor);
            var query = service.GetAllQueryable(context, filter);

            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<User, ResultUserWithRelationsPrivateDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<UserPrivateSelfConnection, ResultUserWithRelationsPrivateDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(UserSelfFilterType))]
        [UseSorting(typeof(UserSelfSortType))]
        public async Task<UserPrivateSelfConnection> GetUsersByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IUserQueryService service,
            [Service] IUserResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));
            var filter = CreateUserPrivateAccessFilter(httpContextAccessor);
            var query = service.GetByIdsQueryable(parsedKeys, context, filter);

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
            var filter = CreateUserPrivateAccessFilter(httpContextAccessor);
            var query = service.GetByIdQueryable(parsedKey, context, filter);

            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultUserWithRelationsPrivateDto>(entity);
        }

        private static Expression<Func<User, bool>> CreateUserPrivateAccessFilter(IHttpContextAccessor httpContextAccessor)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            return FilterExpressionHelper.BuildEqualsExpression<User, Guid>(x => x.Id, currentUserId);
        }
    }
}
