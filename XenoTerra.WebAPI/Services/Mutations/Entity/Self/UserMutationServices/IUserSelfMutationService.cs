using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.UserMutationServices
{
    public interface IUserSelfMutationService
    {
        Task<CreateUserSelfPayload> CreateAsync(RegisterDto dto);
        Task<UpdateUserSelfPayload> UpdateAsync(UpdateUserDto dto, IEnumerable<string> modifiedFields);
        Task<DeleteUserSelfPayload> DeleteAsync(Guid userId);
    }
}
