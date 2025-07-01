using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.UserSettingMutationServices
{
    public class UserSettingAdminMutationService(IMapper mapper)
        : MutationService<UserSetting, ResultUserSettingAdminDto, CreateUserSettingAdminDto, UpdateUserSettingAdminDto, Guid>(mapper),
        IUserSettingAdminMutationService
    {
    }
}