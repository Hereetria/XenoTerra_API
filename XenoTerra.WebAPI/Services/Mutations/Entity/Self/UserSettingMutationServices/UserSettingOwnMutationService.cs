using AutoMapper;
using XenoTerra.DTOLayer.Dtos.UserSettingAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.UserSettingMutationServices
{
    public class UserSettingOwnMutationService(IMapper mapper)
        : MutationService<UserSetting, ResultUserSettingOwnDto, CreateUserSettingOwnDto, UpdateUserSettingOwnDto, Guid>(mapper),
        IUserSettingOwnMutationService
    {
    }
}
