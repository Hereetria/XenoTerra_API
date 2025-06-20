using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.UserSettingAdminDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.UserSettingMutationServices
{
    public interface IUserSettingAdminMutationService : IMutationService<UserSetting, ResultUserSettingAdminDto, CreateUserSettingAdminDto, UpdateUserSettingAdminDto, Guid>
    {
    }
}