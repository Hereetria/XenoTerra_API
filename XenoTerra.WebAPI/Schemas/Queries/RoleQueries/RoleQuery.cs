using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.BussinessLogicLayer.Services.Entity.RoleService;
using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.RoleQueries
{
    public class RoleQuery
    {
        public async Task<IEnumerable<ResultRoleWithRelationsDto>> GetAllRolesAsync(
            [Service] IRoleReadService roleReadService,
            [Service] RoleResolver resolver,
            [Service] IMapper mapper,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = roleReadService.FetchAllQueryable(selectedFields)
                ?? Enumerable.Empty<Role>().AsQueryable();

            var roles = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(roles, context);

            return mapper.Map<List<ResultRoleWithRelationsDto>>(roles);
        }

        public async Task<IEnumerable<ResultRoleWithRelationsDto>> GetRolesByIdsAsync(
            [Service] IRoleReadService roleReadService,
            [Service] RoleResolver resolver,
            [Service] IMapper mapper,
            List<Guid> keys,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = roleReadService.FetchByIdsQueryable(keys, selectedFields)
                ?? Enumerable.Empty<Role>().AsQueryable();

            var roles = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(roles, context);

            return mapper.Map<List<ResultRoleWithRelationsDto>>(roles);
        }

        public async Task<ResultRoleWithRelationsDto> GetRoleByIdAsync(
            [Service] IRoleReadService roleReadService,
            [Service] RoleResolver resolver,
            [Service] IMapper mapper,
            Guid key,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = roleReadService.FetchByIdQueryable(key, selectedFields)
                ?? Enumerable.Empty<Role>().AsQueryable();

            var role = await query.FirstOrDefaultAsync()
                ?? throw new KeyNotFoundException($"Role with ID {key} was not found in the database.");

            await resolver.PopulateRelatedFieldAsync(role, context);

            return mapper.Map<ResultRoleWithRelationsDto>(role);
        }

    }
}
