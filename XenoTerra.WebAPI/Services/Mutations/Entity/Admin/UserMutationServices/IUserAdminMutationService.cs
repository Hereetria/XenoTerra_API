using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.UserMutationServices
{
    public interface IUserAdminMutationService
    {
        Task<CreateUserAdminPayload> CreateAsync(RegisterDto dto);
        Task<UpdateUserAdminPayload> UpdateAsync(UpdateUserDto dto, IEnumerable<string> modifiedFields);
        Task<DeleteUserAdminPayload> DeleteAsync(Guid userId);
    }
}
