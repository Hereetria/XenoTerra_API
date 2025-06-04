using XenoTerra.DTOLayer.Dtos.AppRoleDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.RoleMutationServices
{
    public interface IRoleAdminMutationService
    {
        Task<CreateRoleAdminPayload> CreateAsync(CreateAppRoleDto dto);
        Task<UpdateRoleAdminPayload> UpdateAsync(UpdateAppRoleDto dto, IEnumerable<string> modifiedFields);
        Task<DeleteRoleAdminPayload> DeleteAsync(Guid roleId);
    }
}
