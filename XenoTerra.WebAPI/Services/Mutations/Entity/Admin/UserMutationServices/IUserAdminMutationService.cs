using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.UserMutationServices
{
    public interface IUserAdminMutationService
    {
        Task<CreateUserAdminPayload> CreateAsync(RegisterDto dto);
        Task<UpdateUserAdminPayload> UpdateAsync(UpdateAppUserDto dto, IEnumerable<string> modifiedFields);
        Task<DeleteUserAdminPayload> DeleteAsync(Guid userId);
    }
}
