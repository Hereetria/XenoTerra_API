using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.RoleService;
using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.RoleResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.RoleQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.RoleQueries
{
    public class RoleQuery
    {
        private readonly IMapper _mapper;

        public RoleQuery(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResultRoleWithRelationsDto>> GetAllRolesAsync(
            [Service] IRoleQueryService service,
            [Service] IRoleResolver resolver,
            IResolverContext context)
        {
            var roles = await service.GetAllAsync(context);
            await resolver.PopulateRelatedFieldsAsync(roles, context);
            var roleDtos = _mapper.Map<List<ResultRoleWithRelationsDto>>(roles);
            return roleDtos;
        }

        public async Task<IEnumerable<ResultRoleWithRelationsDto>> GetRolesByIdsAsync(
            [Service] IRoleQueryService service,
            [Service] IRoleResolver resolver,
            IEnumerable<Guid> keys,
            IResolverContext context)
        {
            var roles = await service.GetByIdsAsync(keys, context);
            await resolver.PopulateRelatedFieldsAsync(roles, context);
            var roleDtos = _mapper.Map<List<ResultRoleWithRelationsDto>>(roles);
            return roleDtos;
        }

        public async Task<ResultRoleWithRelationsDto> GetRoleByIdAsync(
            [Service] IRoleQueryService service,
            [Service] IRoleResolver resolver,
            Guid key,
            IResolverContext context)
        {
            var role = await service.GetByIdAsync(key, context);
            await resolver.PopulateRelatedFieldAsync(role, context);
            var roleDto = _mapper.Map<ResultRoleWithRelationsDto>(role);
            return roleDto;
        }
    }

}
