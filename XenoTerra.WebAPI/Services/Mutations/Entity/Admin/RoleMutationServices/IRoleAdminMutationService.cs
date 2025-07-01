using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.AppRoleDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.RoleMutationServices
{
    public interface IRoleAdminMutationService
    {
        Task<CreateRoleAdminPayload> CreateAsync(CreateAppRoleAdminDto dto);
        Task<UpdateRoleAdminPayload> UpdateAsync(UpdateAppRoleAdminDto dto, IEnumerable<string> modifiedFields);
        Task<DeleteRoleAdminPayload> DeleteAsync(Guid roleId);
    }
}