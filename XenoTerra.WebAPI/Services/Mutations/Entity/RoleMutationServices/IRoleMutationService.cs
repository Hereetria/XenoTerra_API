using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Mutations.Payloads;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.RoleMutationServices
{
    public interface IRoleMutationService
    {
        Task<CreateRolePayload> CreateAsync(CreateRoleDto dto);
        Task<UpdateRolePayload> UpdateAsync(UpdateRoleDto dto, IEnumerable<string> modifiedFields);
        Task<DeleteRolePayload> DeleteAsync(Guid roleId);
    }
}
