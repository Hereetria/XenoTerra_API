using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.AppUserResolvers;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.WebAPI.Services.Queries.Entity.AppUserQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Paginations.Own;
using XenoTerra.WebAPI.Services.Queries.Entity.FollowQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class AppUserOwnQuery(IMapper mapper, IQueryResolverHelper<AppUser, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<AppUser, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(AppUserOwnFilterType))]
        [UseSorting(typeof(AppUserOwnSortType))]
        public async Task<AppUserOwnConnection> GetAllUsersAsync(
            [Service] IAppUserQueryService service,
            [Service] IAppUserResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = CreateUserOwnAccessFilter(httpContextAccessor);
            var query = service.GetAllQueryable(context, filter);

            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<AppUser, ResultAppUserWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<AppUserOwnConnection, ResultAppUserWithRelationsOwnDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(AppUserOwnFilterType))]
        [UseSorting(typeof(AppUserOwnSortType))]
        public async Task<AppUserOwnConnection> GetUsersByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IAppUserQueryService service,
            [Service] IAppUserResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));
            var filter = CreateUserOwnAccessFilter(httpContextAccessor);
            var query = service.GetByIdsQueryable(parsedKeys, context, filter);

            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<AppUser, ResultAppUserWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<AppUserOwnConnection, ResultAppUserWithRelationsOwnDto>(connection);
        }

        public async Task<ResultAppUserWithRelationsOwnDto?> GetUserByIdAsync(
            string? key,
            [Service] IAppUserQueryService service,
            [Service] IAppUserResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var filter = CreateUserOwnAccessFilter(httpContextAccessor);
            var query = service.GetByIdQueryable(parsedKey, context, filter);

            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultAppUserWithRelationsOwnDto>(entity);
        }

        private static Expression<Func<AppUser, bool>> CreateUserOwnAccessFilter(IHttpContextAccessor httpContextAccessor)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            return FilterExpressionHelper.BuildEqualsExpression<AppUser, Guid>(
                b => b.Id,
                currentUserId
            );
        }
    }
}