using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Mutations.Payloads;
using XenoTerra.DTOLayer.Dtos.AuthDtos;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.UserMutationServices
{
    public interface IUserAdminMutationService
    {
        Task<CreateUserAdminPayload> CreateAsync(RegisterDto dto);
        Task<UpdateUserAdminPayload> UpdateAsync(UpdateAppUserAdminDto dto, IEnumerable<string> modifiedFields);
        Task<DeleteUserAdminPayload> DeleteAsync(Guid userId);
    }
}