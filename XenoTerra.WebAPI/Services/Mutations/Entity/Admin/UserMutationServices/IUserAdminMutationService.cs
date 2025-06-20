using XenoTerra.DTOLayer.Dto.AppUserDto.Admin;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.UserAdminDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.UserMutationServices
{
    public interface IUserAdminMutationService
    {
        Task<CreateUserAdminPayload> CreateAsync(RegisterAdminDto dto);
        Task<UpdateUserAdminPayload> UpdateAsync(UpdateAppUserAdminDto dto, IEnumerable<string> modifiedFields);
        Task<DeleteUserAdminPayload> DeleteAsync(Guid userId);
    }
}