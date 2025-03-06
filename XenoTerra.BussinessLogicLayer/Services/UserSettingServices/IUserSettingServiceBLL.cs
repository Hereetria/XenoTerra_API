
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.EntityLayer.Entities;
namespace XenoTerra.BussinessLogicLayer.Services.UserSettingServices
{
        public interface IUserSettingServiceBLL : IGenericRepositoryBLL<UserSetting, ResultUserSettingDto, ResultUserSettingWithRelationsDto, CreateUserSettingDto, UpdateUserSettingDto, Guid>
    {

    }
}