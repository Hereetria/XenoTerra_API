using XenoTerra.DTOLayer.Dtos.UserSettingAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.UserSettingMutationServices
{
    public interface IUserSettingOwnMutationService : IMutationService<UserSetting, ResultUserSettingOwnDto, CreateUserSettingOwnDto, UpdateUserSettingOwnDto, Guid>
    {
    }
}
