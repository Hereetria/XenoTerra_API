using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.RoleResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.RoleQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Queries
{
    public class RoleSelfQuery(IMapper mapper, IQueryResolverHelper<Role, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Role, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(RoleSelfFilterType))]
        [UseSorting(typeof(RoleSelfSortType))]
        public async Task<RoleSelfConnection> GetAllRolesAsync(
            [Service] IRoleQueryService service,
            [Service] IRoleResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapSelfConnection<Role, ResultRoleWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<RoleSelfConnection, ResultRoleWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(RoleSelfFilterType))]
        [UseSorting(typeof(RoleSelfSortType))]
        public async Task<RoleSelfConnection> GetRolesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IRoleQueryService service,
            [Service] IRoleResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapSelfConnection<Role, ResultRoleWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<RoleSelfConnection, ResultRoleWithRelationsDto>(connection);
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

            return _mapper.Map<ResultRoleWithRelationsDto>(entity);
        }
    }
}
