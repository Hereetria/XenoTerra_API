using XenoTerra.DTOLayer.Dtos.UserSettingDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.UserSettingMutationServices
{
    public interface IUserSettingOwnMutationService
    {
        Task<UpdateUserSettingOwnPayload> UpdateAsync(UpdateUserSettingOwnDto dto, IEnumerable<string> modifiedFields);
        Task<DeleteUserSettingOwnPayload> DeleteAsync(Guid key);
    }
}
