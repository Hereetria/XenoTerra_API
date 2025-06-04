using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.UserQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.AppUserResolvers;
using XenoTerra.DTOLayer.Dtos.AppUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class AppUserPrivateSelfQuery(IMapper mapper, IQueryResolverHelper<AppUser, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<AppUser, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(AppUserSelfFilterType))]
        [UseSorting(typeof(AppUserSelfSortType))]
        public async Task<AppUserPrivateSelfConnection> GetAllUsersAsync(
            [Service] IAppUserQueryService service,
            [Service] IAppUserResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = CreateUserPrivateAccessFilter(httpContextAccessor);
            var query = service.GetAllQueryable(context, filter);

            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<AppUser, ResultAppUserWithRelationsPrivateDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<AppUserPrivateSelfConnection, ResultAppUserWithRelationsPrivateDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(AppUserSelfFilterType))]
        [UseSorting(typeof(AppUserSelfSortType))]
        public async Task<AppUserPrivateSelfConnection> GetUsersByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IAppUserQueryService service,
            [Service] IAppUserResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));
            var filter = CreateUserPrivateAccessFilter(httpContextAccessor);
            var query = service.GetByIdsQueryable(parsedKeys, context, filter);

            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<AppUser, ResultAppUserWithRelationsPrivateDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<AppUserPrivateSelfConnection, ResultAppUserWithRelationsPrivateDto>(connection);
        }

        public async Task<ResultAppUserWithRelationsPrivateDto?> GetUserByIdAsync(
            string? key,
            [Service] IAppUserQueryService service,
            [Service] IAppUserResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var filter = CreateUserPrivateAccessFilter(httpContextAccessor);
            var query = service.GetByIdQueryable(parsedKey, context, filter);

            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultAppUserWithRelationsPrivateDto>(entity);
        }

        private static Expression<Func<AppUser, bool>> CreateUserPrivateAccessFilter(IHttpContextAccessor httpContextAccessor)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            return FilterExpressionHelper.BuildEqualsExpression<AppUser, Guid>(x => x.Id, currentUserId);
        }
    }
}
