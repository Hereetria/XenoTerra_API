using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.Entity.RoleService;
using XenoTerra.DTOLayer.Dtos.RoleDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.RoleMutations
{
    public class RoleMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new Role")]
        public async Task<ResultRoleDto> CreateRoleAsync(CreateRoleDto createRoleDto, [Service] IRoleWriteService roleWriteService)
        {
            var result = await roleWriteService.CreateAsync(createRoleDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing Role")]
        public async Task<ResultRoleDto> UpdateRoleAsync(UpdateRoleDto updateRoleDto, [Service] IRoleWriteService roleWriteService)
        {
            var result = await roleWriteService.UpdateAsync(updateRoleDto);
            return result;
        }

        [GraphQLDescription("Delete a Role by ID")]
        public async Task<bool> DeleteRoleAsync(Guid id, [Service] IRoleWriteService roleWriteService)
        {
            var result = await roleWriteService.DeleteAsync(id);
            return result;
        }
    }
}
