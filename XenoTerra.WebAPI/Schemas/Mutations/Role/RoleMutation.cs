using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.RoleServices;
using XenoTerra.DTOLayer.Dtos.RoleDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.Role
{
    public class RoleMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new Role")]
        public async Task<ResultRoleByIdDto> CreateRoleAsync(CreateRoleDto createRoleDto, [Service] IRoleServiceBLL roleServiceBLL)
        {
            var result = await roleServiceBLL.CreateAsync(createRoleDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing Role")]
        public async Task<ResultRoleByIdDto> UpdateRoleAsync(UpdateRoleDto updateRoleDto, [Service] IRoleServiceBLL roleServiceBLL)
        {
            var result = await roleServiceBLL.UpdateAsync(updateRoleDto);
            return result;
        }

        [GraphQLDescription("Delete a Role by ID")]
        public async Task<bool> DeleteRoleAsync(Guid id, [Service] IRoleServiceBLL roleServiceBLL)
        {
            var result = await roleServiceBLL.DeleteAsync(id);
            return result;
        }
    }
}
