using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.RoleQueries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.RoleQueries.Sorts;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.RoleResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.RoleQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Queries
{
    public class RoleQuery(IMapper mapper, IQueryResolverHelper<Role, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Role, Guid> _queryResolver = queryResolver;

        [UsePaging]
        [UseFiltering(typeof(RoleFilterType))]
        [UseSorting(typeof(RoleSortType))]
        public async Task<IEnumerable<ResultRoleWithRelationsDto>> GetAllRolesAsync(
            [Service] IRoleQueryService service,
            [Service] IRoleResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultRoleWithRelationsDto>>(entities);
        }

        [UsePaging]
        [UseFiltering(typeof(RoleFilterType))]
        [UseSorting(typeof(RoleSortType))]
        public async Task<IEnumerable<ResultRoleWithRelationsDto>> GetRolesByIdsAsync(
            IEnumerable<Guid> keys,
            [Service] IRoleQueryService service,
            [Service] IRoleResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdsQueryable(keys, context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultRoleWithRelationsDto>>(entities);
        }

        public async Task<ResultRoleWithRelationsDto> GetRoleByIdAsync(
            Guid key,
            [Service] IRoleQueryService service,
            [Service] IRoleResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdQueryable(key, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);
            return _mapper.Map<ResultRoleWithRelationsDto>(entity);
        }
    }
}
