using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AuthDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Own.Mutations.Payloads;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.UserMutationServices
{
    public interface IUserOwnMutationService
    {
        Task<CreateUserOwnPayload> CreateAsync(RegisterOwnDto dto);
        Task<UpdateUserOwnPayload> UpdateAsync(UpdateAppUserAdminOwnDto dto, IEnumerable<string> modifiedFields);
        Task<DeleteUserOwnPayload> DeleteAsync(Guid userId);
    }
}
