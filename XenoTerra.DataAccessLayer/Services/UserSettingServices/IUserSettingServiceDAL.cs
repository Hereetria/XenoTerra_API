
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.DataAccessLayer.Repositories;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Services.UserSettingServices
{
    
    public interface IUserSettingServiceDAL : IGenericRepositoryDAL<UserSetting, ResultUserSettingDto, ResultUserSettingWithRelationsDto, CreateUserSettingDto, UpdateUserSettingDto, Guid>

    {

    }
}