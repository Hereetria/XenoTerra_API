using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.UserMutationServices
{
    public interface IUserSelfMutationService
    {
        Task<CreateUserSelfPayload> CreateAsync(RegisterDto dto);
        Task<UpdateUserSelfPayload> UpdateAsync(UpdateAppUserDto dto, IEnumerable<string> modifiedFields);
        Task<DeleteUserSelfPayload> DeleteAsync(Guid userId);
    }
}
