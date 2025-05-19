using AutoMapper;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.UserSettingMutationServices
{
    public class UserSettingAdminMutationService(IMapper mapper)
        : MutationService<UserSetting, ResultUserSettingDto, CreateUserSettingDto, UpdateUserSettingDto, Guid>(mapper),
        IUserSettingAdminMutationService
    {
    }
}
