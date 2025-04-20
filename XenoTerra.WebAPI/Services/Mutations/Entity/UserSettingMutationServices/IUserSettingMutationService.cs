using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.UserSettingMutationServices
{
    public interface IUserSettingMutationService : IMutationService<UserSetting, ResultUserSettingDto, CreateUserSettingDto, UpdateUserSettingDto, Guid>
    {
    }
}
