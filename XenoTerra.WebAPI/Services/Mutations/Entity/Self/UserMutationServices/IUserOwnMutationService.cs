using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.AuthDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.UserMutationServices
{
    public interface IUserOwnMutationService
    {
        Task<CreateUserOwnPayload> CreateAsync(RegisterDto dto);
        Task<UpdateUserOwnPayload> UpdateAsync(UpdateAppUserOwnDto dto, IEnumerable<string> modifiedFields);
        Task<DeleteUserOwnPayload> DeleteAsync(Guid userId);
    }
}
