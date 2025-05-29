using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.RoleResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.RoleQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class RoleAdminQuery(IMapper mapper, IQueryResolverHelper<Role, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Role, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(RoleAdminFilterType))]
        [UseSorting(typeof(RoleAdminSortType))]
        public async Task<RoleAdminConnection> GetAllRolesAsync(
            [Service] IRoleQueryService service,
            [Service] IRoleResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Role, ResultRoleWithRelationsDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<RoleAdminConnection, ResultRoleWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(RoleAdminFilterType))]
        [UseSorting(typeof(RoleAdminSortType))]
        public async Task<RoleAdminConnection> GetRolesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IRoleQueryService service,
            [Service] IRoleResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Role, ResultRoleWithRelationsDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<RoleAdminConnection, ResultRoleWithRelationsDto>(connection);
        }

        public async Task<ResultRoleWithRelationsDto?> GetRoleByIdAsync(
            string? key,
            [Service] IRoleQueryService service,
            [Service] IRoleResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultRoleWithRelationsDto>(entity);
        }
    }
}
