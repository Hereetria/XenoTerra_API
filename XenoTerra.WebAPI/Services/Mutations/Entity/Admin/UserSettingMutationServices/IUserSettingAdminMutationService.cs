using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.UserSettingMutationServices
{
    public interface IUserSettingAdminMutationService : IMutationService<UserSetting, ResultUserSettingDto, CreateUserSettingDto, UpdateUserSettingDto, Guid>
    {
    }
}
