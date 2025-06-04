using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.UserQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.AppUserResolvers;
using XenoTerra.DTOLayer.Dtos.AppUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class AppUserAdminQuery(IMapper mapper, IQueryResolverHelper<AppUser, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<AppUser, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(AppUserAdminFilterType))]
        [UseSorting(typeof(AppUserAdminSortType))]
        public async Task<AppUserAdminConnection> GetAllUsersAsync(
            [Service] IAppUserQueryService service,
            [Service] IAppUserResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<AppUser, ResultAppUserWithRelationsPrivateDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<AppUserAdminConnection, ResultAppUserWithRelationsPrivateDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(AppUserAdminFilterType))]
        [UseSorting(typeof(AppUserAdminSortType))]
        public async Task<AppUserAdminConnection> GetUsersByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IAppUserQueryService service,
            [Service] IAppUserResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<AppUser, ResultAppUserWithRelationsPrivateDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<AppUserAdminConnection, ResultAppUserWithRelationsPrivateDto>(connection);
        }

        public async Task<ResultAppUserWithRelationsPrivateDto?> GetUserByIdAsync(
            string? key,
            [Service] IAppUserQueryService service,
            [Service] IAppUserResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultAppUserWithRelationsPrivateDto>(entity);
        }
    }
}
