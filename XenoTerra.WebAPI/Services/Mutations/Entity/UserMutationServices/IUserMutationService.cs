using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Mutations.Payloads;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.UserMutationServices
{
    public interface IUserMutationService
    {
        Task<CreateUserPayload> CreateAsync(RegisterDto dto);
        Task<UpdateUserPayload> UpdateAsync(UpdateUserDto dto, IEnumerable<string> modifiedFields);
        Task<DeleteUserPayload> DeleteAsync(Guid userId);
    }
}
