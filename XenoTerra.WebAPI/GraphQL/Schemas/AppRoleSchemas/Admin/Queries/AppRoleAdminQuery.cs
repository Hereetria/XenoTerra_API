using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.AppRoleResolvers;
using XenoTerra.DTOLayer.Dtos.AppRoleDtos.Admin;
using XenoTerra.WebAPI.Services.Queries.Entity.AppRoleQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class AppRoleAdminQuery(IMapper mapper, IQueryResolverHelper<AppRole, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<AppRole, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(AppRoleAdminFilterType))]
        [UseSorting(typeof(AppRoleAdminSortType))]
        public async Task<AppRoleAdminConnection> GetAllRolesAsync(
            [Service] IAppRoleQueryService service,
            [Service] IAppRoleResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<AppRole, ResultAppRoleWithRelationsAdminDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<AppRoleAdminConnection, ResultAppRoleWithRelationsAdminDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(AppRoleAdminFilterType))]
        [UseSorting(typeof(AppRoleAdminSortType))]
        public async Task<AppRoleAdminConnection> GetRolesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IAppRoleQueryService service,
            [Service] IAppRoleResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<AppRole, ResultAppRoleWithRelationsAdminDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<AppRoleAdminConnection, ResultAppRoleWithRelationsAdminDto>(connection);
        }

        public async Task<ResultAppRoleWithRelationsAdminDto?> GetRoleByIdAsync(
            string? key,
            [Service] IAppRoleQueryService service,
            [Service] IAppRoleResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultAppRoleWithRelationsAdminDto>(entity);
        }
    }
}
