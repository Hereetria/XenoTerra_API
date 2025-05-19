using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.RoleMutationServices
{
    public interface IRoleAdminMutationService
    {
        Task<CreateRoleAdminPayload> CreateAsync(CreateRoleDto dto);
        Task<UpdateRoleAdminPayload> UpdateAsync(UpdateRoleDto dto, IEnumerable<string> modifiedFields);
        Task<DeleteRoleAdminPayload> DeleteAsync(Guid roleId);
    }
}
